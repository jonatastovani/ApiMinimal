using ApiMinimal.Data;
using ApiMinimal.Model;
using ApiMinimal.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemasTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemasTarefasDBContext sistemasTarefasDBContext)
        {
            _dbContext = sistemasTarefasDBContext;
        }
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.usuario) 
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                    .Include(x => x.usuario)
                    .ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            tarefaPorId.name = tarefa.name;
            tarefaPorId.description = tarefa.description;
            tarefaPorId.status = tarefa.status;
            tarefaPorId.usuarioId = tarefa.usuarioId;

             _dbContext.Tarefas.Update(tarefaPorId);
            await  _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
