namespace Loja.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome {  get; set; }   
        public int Idade {get; set; }
        public DateTime Nascimento { get; set; }    

    }
}
