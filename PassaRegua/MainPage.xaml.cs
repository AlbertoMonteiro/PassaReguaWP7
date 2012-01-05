using System.Globalization;
using System.Threading;
using System.Windows;
using Microsoft.Phone.Controls;
using PassaRegua.ViewModel;

namespace PassaRegua
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            InitializeComponent();
            var contaViewModel = new ContaViewModel
            {
                PessoasQueBeberam = 3,
                PessoasSemBeber = 2,
                ValorDaConta = new decimal(120.74),
                ValorEmBebida = new decimal(38.55),
                ValorExtra = 20
            };
            //DataContext = contaViewModel;
        }
    }
}