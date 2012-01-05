using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using PassaRegua.Model;

namespace PassaRegua.ViewModel
{
    public class ContaViewModel : ViewModelBase
    {
        public Conta Model { get; set; }

        public ContaViewModel(Conta conta)
        {
            Model = conta;
        }
    }
}
