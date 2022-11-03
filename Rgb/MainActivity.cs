using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Graphics;

namespace Rgb
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SeekBar sbRed;
        private SeekBar sbBlue;
        private SeekBar sbGreen;

        private TextView backgroundColor;

        private TextView txtRed;
        private TextView txtBlue;
        private TextView txtGreen;

        private TextView txtRGB;
        private TextView txtHex;

        private int redCounter = 0;
        private int blueCounter = 0;
        private int greenCounter = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            SetView();
        }

        private void SetView()
        {
            sbRed = FindViewById<SeekBar>(Resource.Id.sbRed);
            sbBlue = FindViewById<SeekBar>(Resource.Id.sbBlue);
            sbGreen = FindViewById<SeekBar>(Resource.Id.sbGreen);

            backgroundColor = FindViewById<TextView>(Resource.Id.ColorBlock);

            txtRed = FindViewById<TextView>(Resource.Id.txtRed);
            txtBlue = FindViewById<TextView>(Resource.Id.txtBlue);
            txtGreen = FindViewById<TextView>(Resource.Id.txtGreen);

            txtRGB = FindViewById<TextView>(Resource.Id.txtRGB);
            txtHex = FindViewById<TextView>(Resource.Id.txtHex);


            sbRed.ProgressChanged += SbRed_ProgressChanged;
            sbBlue.ProgressChanged += SbBlue_ProgressChanged;
            sbGreen.ProgressChanged += SbGreen_ProgressChanged;
        }

        private void SbRed_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            redCounter = sbRed.Progress;
            txtRed.Text = redCounter.ToString();
            txtRGB.Text = $"({redCounter}, {greenCounter}, {blueCounter})";
            txtHex.Text = $"({redCounter:X2}{greenCounter:X2}{blueCounter:X2})";
            backgroundColor.SetBackgroundColor(Color.Rgb(redCounter, greenCounter, blueCounter));
        }

        private void SbGreen_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            greenCounter = sbGreen.Progress;
            txtGreen.Text = greenCounter.ToString();
            txtRGB.Text = $"({redCounter}, {greenCounter}, {blueCounter})";
            txtHex.Text = $"({redCounter:X2}{greenCounter:X2}{blueCounter:X2})";
            backgroundColor.SetBackgroundColor(Color.Rgb(redCounter, greenCounter, blueCounter));
        }

        private void SbBlue_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            blueCounter = sbBlue.Progress;
            txtBlue.Text = blueCounter.ToString();
            txtRGB.Text = $"({redCounter}, {greenCounter}, {blueCounter})";
            txtHex.Text = $"({redCounter:X2}{greenCounter:X2}{blueCounter:X2})";
            backgroundColor.SetBackgroundColor(Color.Rgb(redCounter, greenCounter, blueCounter));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}