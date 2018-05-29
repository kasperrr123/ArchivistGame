
using ArchivistGame.Droid;
using ArchivistGame.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArchivistGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage, INotifyPropertyChanged
    {

        public ServerConnection server;

        private Task timer;
        private bool hasAnswered;
        private string question_name;
        public string Question_Name
        {
            get { return question_name; }
            set { question_name = value; this.propertyIsChanged(); }
        }


        private string image_path;

        public string Image_Path
        {
            get { return image_path; }
            set { image_path = value; this.propertyIsChanged(); }
        }

        public string Spiller_Navn { get; set; }

        private int slider_value;

        public int Slider_value
        {
            get { return slider_value; }
            set { slider_value = value; this.propertyIsChanged(); }
        }

        private string current_points;

        public string Current_Points
        {
            get { return current_points; }
            set { current_points = value; this.propertyIsChanged(); }
        }

        private string antal_rigtige;

        public string Antal_Rigtige
        {
            get { return antal_rigtige; }
            set { antal_rigtige = value; this.propertyIsChanged(); }
        }

        private string time_used;

        public string Time_Used
        {
            get { return time_used; }
            set { time_used = value; this.propertyIsChanged(); }
        }

        private string svar_1;

        public string Svar_1
        {
            get { return svar_1; }
            set { svar_1 = value; this.propertyIsChanged(); }
        }

        private string svar_2;

        public string Svar_2
        {
            get { return svar_2; }
            set { svar_2 = value; this.propertyIsChanged(); }
        }

        private string svar_3;

        public string Svar_3
        {
            get { return svar_3; }
            set { svar_3 = value; this.propertyIsChanged(); }
        }
        private string svar_4;

        public string Svar_4
        {
            get { return svar_4; }
            set { svar_4 = value; this.propertyIsChanged(); }
        }

        private int antalrigtige_int;

        private string fact;

        public string Fact
        {
            get { return fact; }
            set { fact = value; this.propertyIsChanged(); }
        }


        private int counter;

        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyIsChanged([CallerMemberName] string test = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(test));
        }

        public List<Question> ListOfQuestions { get; set; }

        public List<Svar> listOfAnswers;



        public QuestionPage()
        {
          

            hasAnswered = false;
            counter = 0;
            Singleton_obj.Instance.Antal_Rigtige = 0;
            antalrigtige_int = 0;
            BindingContext = this;
            server = ServerConnection.Instance;


            ListOfQuestions = server.GetQuestions(Singleton_obj.Instance.Emne.Emne_Navn);
            
            Singleton_obj.Instance.Antal_Spørgsmål = ListOfQuestions.Count;
            listOfAnswers = server.GetAnswers(ListOfQuestions[counter].Question_navn);
            
            Question_Name = ListOfQuestions[counter].Question_navn;
            Image_Path = ListOfQuestions[counter].Image_path;
            Spiller_Navn = "Spillernavn: " + "\n" + Singleton_obj.Instance.Playername;
            Current_Points = "Points: " + "\n" + Singleton_obj.Instance.Points;
            Antal_Rigtige = "Antal rigtige: " + "\n" + antalrigtige_int + "/" + ListOfQuestions.Count;
            Fact = ListOfQuestions[counter].Fact;



            Slider_value = 15;
            InitializeComponent();

            SetAnswers();




        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowDisplayAlert();
        }

        private async void ShowDisplayAlert()
        {
            var x = await DisplayAlert("Klar?", "Er du klar til at quizze?", "Ja", "Nej");
            Console.WriteLine("After displayalert");
            if (!x)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                Console.WriteLine("Im ready to quiz");
                StartTimer();



            }

        }

        private void StartTimer()
        {
            hasAnswered = false;
            Slider_value = 15;
            timer = Task.Run(() =>
            {

                for (int i = 15; i >= 0; i--)
                {
                    if (hasAnswered)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Inside thread");
                        Thread.Sleep(1000);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Slider_value = i;
                        });
                        Console.WriteLine("**************** " + i + " ****************");
                    }


                }
            }).ContinueWith(timer =>
            {
                timer.Dispose();
            });




        }



        private void SetAnswers()
        {
            if (listOfAnswers.Count == 2)
            {
                svarMuligheder_row2.IsVisible = false;
                Svar_1 = listOfAnswers[0].Svar_navn;
                Svar_2 = listOfAnswers[1].Svar_navn;

            }
            else
            {
                Svar_1 = listOfAnswers[0].Svar_navn;
                Svar_2 = listOfAnswers[1].Svar_navn;
                Svar_3 = listOfAnswers[2].Svar_navn;
                Svar_4 = listOfAnswers[3].Svar_navn;
            }
        }

        void OnImageNameTapped(object sender, EventArgs args)
        {
            counter++;

            if (ListOfQuestions.Count - 1 < counter)
            {
                Navigation.PushAsync(new SeeScore());
            }
            else
            {
                Question_Name = ListOfQuestions[counter].Question_navn;
                listOfAnswers = server.GetAnswers(Question_Name);
                SetAnswers();
                DisableRestOfTheButtons(false);
                SetDefaultBtnColor();
                Image_Path = ListOfQuestions[counter].Image_path;
                StartTimer();

            }
        }

        private void SetDefaultBtnColor()
        {
            btn_1.BackgroundColor = Color.LightBlue;
            btn_2.BackgroundColor = Color.LightBlue;
            btn_3.BackgroundColor = Color.LightBlue;
            btn_4.BackgroundColor = Color.LightBlue;
        }

        private void Svar_clicked(object sender, EventArgs e)
        {
            hasAnswered = true;
            Button btn = sender as Button;
            bool correctAnswer = false;
            foreach (var answer in listOfAnswers)
            {
                if (btn.Text == answer.Svar_navn && answer.Rigtig == true)
                {
                    btn.BackgroundColor = Color.LightGreen;
                    DisplayAlert("Rigtigt", "Det var det rigtige svar", "Ok");
                    antalrigtige_int++;
                    Singleton_obj.Instance.Antal_Rigtige++;
                    Singleton_obj.Instance.Points += Slider_value;
                    Current_Points = "Points: " + "\n" + Singleton_obj.Instance.Points;
                    Antal_Rigtige = "Antal rigtige: " + "\n" + antalrigtige_int + "/" + ListOfQuestions.Count;
                    correctAnswer = true;
                    break;
                }


            }
            if (!correctAnswer)
            {
                btn.BackgroundColor = Color.Red;
                DisplayAlert("Forkert", "Det var ikke det rigtige svar", "Ok");
            }

            GåVidere_btn.IsVisible = true;
            DisableRestOfTheButtons(true);
        }

        private void DisableRestOfTheButtons(bool show)
        {
            btn_1.IsEnabled = !show;
            btn_2.IsEnabled = !show;
            btn_3.IsEnabled = !show;
            btn_4.IsEnabled = !show;
        }
    }
}