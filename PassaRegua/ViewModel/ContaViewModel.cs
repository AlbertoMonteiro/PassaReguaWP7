﻿using System;
using System.Windows;
using GalaSoft.MvvmLight;

namespace PassaRegua.ViewModel
{
    public class ContaViewModel : ViewModelBase
    {
        private int _pessoasSemBeber;

        public int PessoasSemBeber
        {
            get { return _pessoasSemBeber; }
            set
            {
                _pessoasSemBeber = value;
                AllChanged();
            }
        }

        private int _pessoasQueBeberam;

        public int PessoasQueBeberam
        {
            get { return _pessoasQueBeberam; }
            set
            {
                _pessoasQueBeberam = value;
                AllChanged();
            }
        }

        private int TotalDePessoas
        {
            get { return PessoasQueBeberam + PessoasSemBeber; }
        }

        private decimal _valorDaConta;

        public decimal ValorDaConta
        {
            get { return _valorDaConta; }
            set
            {
                _valorDaConta = value;
                AllChanged();
            }
        }

        private decimal _valorEmBebida;

        public decimal ValorEmBebida
        {
            get { return _valorEmBebida; }
            set
            {
                if (value > _valorDaConta)
                {
                    MessageBox.Show("Valor não pode ser superior ao valor da total conta.", "Passa a régua", MessageBoxButton.OK);
                    _valorEmBebida = 0;
                    AllChanged();
                    throw new Exception("Pau");
                }
                else
                {
                    _valorEmBebida = value;
                    AllChanged();
                }
            }
        }

        private decimal _valorDoServico;

        public decimal ValorDoServico
        {
            get { return _valorDoServico; }
            set
            {
                _valorDoServico = value;
                AllChanged();
            }
        }

        private decimal _valorExtra;

        public decimal ValorExtra
        {
            get { return _valorExtra; }
            set
            {
                _valorExtra = value;
                AllChanged();
            }
        }

        private decimal ValorTotal
        {
            get { return ValorDaConta + ValorExtra + (ValorDaConta * (ValorDoServico / 100)); }
        }

        private decimal TotalSemBebida
        {
            get { return ValorTotal - ValorEmBebida; }
        }

        public decimal ValorPorPessoaSemBeber
        {
            get { return TotalDePessoas != 0 && PessoasSemBeber > 0 ? TotalSemBebida / TotalDePessoas : 0; }
        }

        public decimal ValorPorPessoaQueBebeu
        {
            get { return PessoasQueBeberam + ValorPorPessoaSemBeber > 0 ? ValorEmBebida / PessoasQueBeberam + (TotalSemBebida / TotalDePessoas) : 0; }
        }

        private void AllChanged()
        {
            var type = GetType();
            foreach (var propertyInfo in type.GetProperties())
            {
                RaisePropertyChanged(propertyInfo.Name);
            }
        }
    }
}
