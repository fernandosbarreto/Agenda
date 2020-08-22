using System;

namespace Agenda.Models

{
    public class Encomenda
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdDoce { get; set; }
        public int IdTpDoce { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public DateTime Entrega { get; set; }


    }
}