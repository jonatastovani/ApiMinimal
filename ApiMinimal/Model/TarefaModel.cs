using ApiMinimal.Enums;

namespace ApiMinimal.Model
{
    public class TarefaModel
    {
        public int id { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }

        public StatusTarefa status { get; set; }

        public int? usuarioId { get; set; }

        public virtual UsuarioModel? usuario { get; set; }
    }
}
