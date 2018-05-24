﻿using System;
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
			InitializeComponent ();
            Current_IP = ServerConnection.Instance.IP.ToString();
            Current_PORT = ServerConnection.Instance.PORT.ToString();
        }

        private void Ændre_indstillinger_Btn_Clicked(object sender, EventArgs e)
        {
            ServerConnection.Instance.IP = Ip_adresse.Text;
            ServerConnection.Instance.PORT = int.Parse(Port_adresse.Text);
        }

        private void Cast_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}