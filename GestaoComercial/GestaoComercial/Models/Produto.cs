namespace Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Estoque { get; set; }
        public string CodigoDeBarras { get; set; }
    }
}
