using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        [NotMapped]
        public string Msg { get; set; }
        [NotMapped]
        public bool OperationValidation { get; set; }
    }
}
