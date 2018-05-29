using ArchivistGame.Listview;
using ArchivistGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArchivistGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseTopic : ContentPage
    {
        public List<Emne> Topics { get; set; }

        private ServerConnection server;


        public ChooseTopic()
        {
            server = ServerConnection.Instance;
            Topics = server.GetTopics();
            InitializeComponent();
            TopicsTable.ItemsSource = Topics;

        }

        private void TopicsTable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView view = sender as ListView;
            var emne = (Emne)view.SelectedItem;
            Singleton_obj.Instance.Emne = emne;
            if (server.GetQuestions(emne.Emne_Navn).Count() == 0)
            {
                DisplayAlert("Hov!", "Ingen spørgsmål fundet.", "Ok");
                Navigation.PushAsync(new MainPage());
            }
            else
            {
                Navigation.PushAsync(new QuestionPage());

            }
        }

    }
}