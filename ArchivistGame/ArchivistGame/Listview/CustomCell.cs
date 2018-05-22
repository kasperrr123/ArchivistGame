using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArchivistGame.Listview
{
    class CustomCell : ViewCell
    {
        public String Text { get; set; }

        public CustomCell()
        {
            //instantiate each of our views
            var image = new Image();
            StackLayout cellWrapper = new StackLayout();
            StackLayout horizontalLayout = new StackLayout();
            Label text_label = new Label
            {
                Text = Text,
            };
            image.Source = "icon.png";


            //Set properties for desired design
            cellWrapper.BackgroundColor = Color.FromHex("#eee");
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            text_label.TextColor = Color.FromHex("#f35e20");

            //add views to the view hierarchy

            horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(text_label);
            cellWrapper.Children.Add(horizontalLayout);
            View = cellWrapper;

        }
  
    }

}
