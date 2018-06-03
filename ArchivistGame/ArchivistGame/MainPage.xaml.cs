using ArchivistGame.SettingsFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android;
using ArchivistGame.Droid;

namespace ArchivistGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            // Final thing:
            // Clearing the entire navigation stack and returning to mainPage.
            try
            {
                this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
                Console.WriteLine("Pages removed");
            }
            catch (Exception)
            {
                Console.WriteLine("No pages to remove");
            }
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
