using ArchivistGame.Droid;
using ArchivistGame.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArchivistGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SeeScore : ContentPage
	{
        public string Total_points { get; set; }
        public string Antal_rigtige { get; set; }
        public string Procent_rigtige { get; set; }

        public string Position_1 { get; set; }
        public SeeScore ()
		{
            MainActivity.player.SelectTrack(1);
            BindingContext = this;
            Total_points = "Total points: " + Singleton_obj.Instance.Points;
            Antal_rigtige = "Antal rigtige: " + Singleton_obj.Instance.Antal_Rigtige + "/" + Singleton_obj.Instance.Antal_Spørgsmål;
            decimal a = (decimal)Singleton_obj.Instance.Antal_Rigtige / (decimal)Singleton_obj.Instance.Antal_Spørgsmål;
            Procent_rigtige = "Procent rigtige: " + a*100 + "%";
			InitializeComponent ();
		}

        private void Afslut_Btn_Clicked(object sender, EventArgs e)
        {
            Score score = new Score
            {
                spillernavn = Singleton_obj.Instance.Playername,
                point = Singleton_obj.Instance.Points,
                emne = Singleton_obj.Instance.Emne.Emne_Navn,
                resultat = Singleton_obj.Instance.Antal_Rigtige.ToString(),
                dato = System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.ToString("HH:mm:s"),
            };
           
            var result = ServerConnection.Instance.PostToScoreboard(JsonConvert.SerializeObject(score));
            DisplayAlert("Uploadet", "Gemt i databasen" + "\n" + result, "Ok");
            // TODO - Post score to database.


            // Final thing:
            // Clearing the entire navigation stack and returning to mainPage.
            //var existingPages = Navigation.NavigationStack.ToList();
            //foreach (var page in existingPages)
            //{
            //    Navigation.RemovePage(page);
            //}
            Navigation.PushAsync(new MainPage());
        }
    }
}