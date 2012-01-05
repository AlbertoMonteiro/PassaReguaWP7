using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Tasks;

namespace PassaRegua
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ImageTap(object sender, GestureEventArgs e)
        {
            var share = new ShareStatusTask { Status = "Estou usando Passa a Régua para Windows Phone 7 by @AibertoMonteiro" };
            share.Show();
        }

        private void TextBoxKeyUp(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                var allTextBox = GetAllTextBox(LayoutRoot).ToList();
                var nextIndex = allTextBox.IndexOf(textBox) + 1;
                if (allTextBox.Count > nextIndex) 
                    allTextBox[nextIndex].Focus();
            }
            else
            {
                var notNumber = new Regex("[^0-9.]+");
                textBox.Text = notNumber.Replace(textBox.Text, "");
                ToInt(textBox);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private static IEnumerable<TextBox> GetAllTextBox(Panel element)
        {
            foreach (var child in element.Children)
            {
                if (child is TextBox)
                    yield return (TextBox)child;
                else if (child is Panel && ((Panel)child).Children.Any())
                    foreach (var textBox in GetAllTextBox((Panel)child))
                        yield return textBox;
            }
        }

        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.SelectAll();
        }

        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            ToInt(textBox);
        }

        private static void ToInt(TextBox textBox)
        {
            int number;
            int.TryParse(textBox.Text, out number);
            textBox.Text = number.ToString();
        }
    }
}