using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Couchbase.Touchdb;
using Com.Couchbase.Touchdb.Listener;

namespace TouchDB_Monodroid_Test
{
    [Activity(Label = "TouchDB_Monodroid_Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TDServer server;
            try
            {
                server = new TDServer(FilesDir.AbsolutePath);

                // The TDListener constructor bindings are not getting created
                //TDListener listener = new TDListener(server, 8888);
                //listener.Start();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}

