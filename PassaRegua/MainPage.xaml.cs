using Microsoft.Phone.Tasks;

namespace PassaRegua
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {			
			InitializeComponent();
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var share = new ShareStatusTask {Status = "Estou usando Passa a Régua para Windows Phone 7 by @AibertoMonteiro"};
            share.Show();
        }
    }
}