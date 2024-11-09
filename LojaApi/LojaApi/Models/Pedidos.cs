namespace LojaApi.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public DateTime Datapedido { get;set; }

        public int StatusPedido { get; set; }

        public decimal ValorTotal { get;}

    }
}
