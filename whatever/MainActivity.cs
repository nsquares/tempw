using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace whatever
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity 
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);                              //in java this is super.OnCreate instead of base.OnCreate
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)    //  is just the 3 dots
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        /*public override bool OnOptionsItemSelected(IMenuItem item)   //eventhandler for 3 dots
        {
            int id = item.ItemId;             //whatever the user clicks on is stored
            if (id == Resource.Id.action_settings)        //settings button clicked
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }*/

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            Android.Content.Intent myIntent = new Intent(this, typeof(conversation));

            StartActivity(myIntent);
            



            /*
            View view = (View)sender;
            Snackbar.Make(view, "hello motherfucker", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            */

        }






        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
