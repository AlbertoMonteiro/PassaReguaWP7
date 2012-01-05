namespace PassaRegua.Model
{
    public class Conta
    {
        public int PessoasSemBeber { get; set; }

        public int PessoasQueBeberam { get; set; }

        private int TotalDePessoas { get { return PessoasQueBeberam + PessoasSemBeber; } }

        public decimal ValorDaConta { get; set; }

        public decimal ValorEmBebida { get; set; }

        public decimal ValorDoServico { get; set; }

        public decimal ValorExtra { get; set; }

        private decimal ValorTotal { get { return ValorDaConta + ValorExtra + (ValorExtra * ValorDoServico / 100); } }

        private decimal TotalSemBebida { get { return ValorTotal - ValorEmBebida; } }

        public decimal ValorPorPessoaSemBeber { get { return TotalSemBebida / TotalDePessoas; } }

        public decimal ValorPorPessoaQueBebeu { get { return ValorEmBebida / PessoasQueBeberam + ValorPorPessoaSemBeber; } }
    }
}
