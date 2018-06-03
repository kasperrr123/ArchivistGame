
using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.OS;




namespace ArchivistGame.Droid
{
    [Activity(Label = "ArchivistGame", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MediaPlayer player;
        public static int[] Songs = new int[2];
        protected override void OnCreate(Bundle bundle)
        {
            player = new MediaPlayer();
            LoadSongs();
            PlayThemeSong();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

        }


        public void PlayThemeSong()
        {

            player.Stop();
            player = MediaPlayer.Create(this, Songs[0]);
            player.Start();
            player.Looping = true;



        }
        public void PlayFinalSong()
        {

            player.Stop();
            player = MediaPlayer.Create(this, Songs[1]);
            player.Start();
            player.Looping = true;



        }

        private void LoadSongs()
        {

            Songs[0] = Resource.Raw.Theme;
            Songs[1] = Resource.Raw.scoreMusic;

        }


    }
}

