using ArchivistGame.SettingsFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArchivistGame
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Singleton_obj.Instance.Reset();
		}


        void OnImageNameTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Settings());
        }



        private void GoToChooseTopicPage_Clicked(object sender, EventArgs e)
        {
            
           
            Singleton_obj.Instance.Playername = Playername_Field.Text;
            Navigation.PushAsync(new ChooseTopic());
        }
    }
}
