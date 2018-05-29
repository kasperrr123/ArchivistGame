using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArchivistGame.SettingsFunction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : ContentPage
	{
        public string Current_IP { get; set; }
        public string Current_PORT { get; set; }

        public Settings ()
		{
            BindingContext = this;
            Current_IP = ServerConnection.Instance.IP.ToString();
            Current_PORT = ServerConnection.Instance.PORT.ToString();
            InitializeComponent ();
           
        }

        private void Ændre_indstillinger_Btn_Clicked(object sender, EventArgs e)
        {
            try
            {
                ServerConnection.Instance.IP = Ip_adresse.Text;
                ServerConnection.Instance.PORT = int.Parse(Port_adresse.Text);
                DisplayAlert("Ok", "Indstillingerne er gemt", "Ok");
                Navigation.PopAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

     
    }
}