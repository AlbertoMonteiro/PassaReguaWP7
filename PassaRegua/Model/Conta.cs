
using System.ComponentModel;

namespace PassaRegua.Model
{
    public class Conta : INotifyPropertyChanged
    {
        private int _pessoasSemBeber;
        public int PessoasSemBeber
        {
            get { return _pessoasSemBeber; }
            set
            {
                _pessoasSemBeber = value;
                OnPropertyChanged("PessoasSemBeber");
            }
        }

        private int _pessoasQueBeberam;
        public int PessoasQueBeberam
        {
            get { return _pessoasQueBeberam; }
            set
            {
                _pessoasQueBeberam = value;
                OnPropertyChanged("PessoasQueBeberam");
            }
        }

        private int TotalDePessoas { get { return PessoasQueBeberam + PessoasSemBeber; } }

        private decimal _valorDaConta;
        public decimal ValorDaConta
        {
            get { return _valorDaConta; }
            set
            {
                _valorDaConta = value;
                OnPropertyChanged("ValorDaConta");
            }
        }

        private decimal _valorEmBebida;
        public decimal ValorEmBebida
        {
            get { return _valorEmBebida; }
            set
            {
                _valorEmBebida = value;
                OnPropertyChanged("ValorEmBebida");
            }
        }

        private decimal _valorDoServico;
        public decimal ValorDoServico
        {
            get { return _valorDoServico; }
            set
            {
                _valorDoServico = value;
                OnPropertyChanged("ValorDoServico");
            }
        }

        private decimal _valorExtra;
        public decimal ValorExtra
        {
            get { return _valorExtra; }
            set
            {
                _valorExtra = value;
                OnPropertyChanged("ValorExtra");
            }
        }

        private decimal ValorTotal { get { return ValorDaConta + ValorExtra + (ValorExtra * ValorDoServico / 100); } }

        private decimal TotalSemBebida { get { return ValorTotal - ValorEmBebida; } }

        public decimal ValorPorPessoaSemBeber { get { return TotalSemBebida / TotalDePessoas; } }

        public decimal ValorPorPessoaQueBebeu { get { return ValorEmBebida / PessoasQueBeberam + ValorPorPessoaSemBeber; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}

