using System;

namespace Agenda.Models

{
    public class Encomenda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int DoceId { get; set; }
        public string Quantidade { get; set; }
        public string Preco { get; set; }
        public DateTime Entrega { get; set; }

        public Doce Doce { get; set; }
        public Cliente Cliente { get; set; }
    }
}