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
		}


        void OnImageNameTapped(object sender, EventArgs args)
        {
            DisplayAlert("Yes!", "TODO Settings page", "Ok");
        }



        private void GoToChooseTopicPage_Clicked(object sender, EventArgs e)
        {
            
           
            Singleton_obj.Instance.Playername = Playername_Field.Text;
            Navigation.PushAsync(new ChooseTopic());
        }
    }
}
