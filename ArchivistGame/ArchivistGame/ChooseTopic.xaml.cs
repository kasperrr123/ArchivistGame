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

        private ServerConnection server;

        public ChooseTopic()
        {
            InitializeComponent();
            server = new ServerConnection();

            FillTopicsTable();
        }

        private void FillTopicsTable()
        {
            // create a TableSection to hold the cells
            var section = new TableSection("Topics");
            foreach (var bikes in server.Bikes)
            {

                // populate Data on TableView
                var id = bikes.id;
                var type = bikes.type;
                var model = bikes.model;
                var price = bikes.price;
                var gender = bikes.gender;

                var cell = new TextCell { Text = id, Detail = model };
                section.Add(cell);
            }

            // add the section to the TableView root
            TopicsTable.Root.Add(section);
        }
    }
}