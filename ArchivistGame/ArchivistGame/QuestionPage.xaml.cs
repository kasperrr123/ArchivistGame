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
	public partial class QuestionPage : ContentPage
	{

        public ServerConnection server;
        public string Question_Name { get; set; }

        public string Image_Path { get; set; }



        public QuestionPage ()
		{
            server = ServerConnection.Instance;
            Question_Name = server.Questions[0].Question_name;
            Image_Path = server.Questions[0].Image_path;
            Timer_Slider.Value = 0;
			InitializeComponent ();
           

		}

       
    }
}