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
        public List<Bike> Topics { get; set; }

        private ServerConnection server;

        public ChooseTopic()
        {
            server = ServerConnection.Instance;
            Topics = server.Topics;
            InitializeComponent();
            TopicsTable.ItemsSource = Topics;            
     
        }

        private void TopicsTable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            ListView view = sender as ListView;
            var topic = (Bike)view.SelectedItem;
            Singleton_obj.Instance.Topic = topic;
            server.GetQuestions(topic.model);
            Navigation.PushAsync(new QuestionPage());
        }
    }
}