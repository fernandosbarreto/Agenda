namespace Agenda.Models
{
    public class Doce
    {
        public int Id { get; set; }
        public int TpDoceId { get; set; }

        public string Sabor { get; set; }
        public double Preco { get; set; }
        public TpDoce TpDoce { get; set; }
    }
}