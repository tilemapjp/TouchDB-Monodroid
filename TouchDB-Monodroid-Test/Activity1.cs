using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Couchbase.Touchdb;
using Com.Couchbase.Touchdb.Listener;
using Com.Couchbase.Touchdb.Ektorp;
using Android.Util;

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
                Log.Info("####", "Starting...");

                string path = FilesDir.AbsolutePath + "/tests";
                Java.IO.File serverPathFile = new Java.IO.File(path);
                Com.Couchbase.Touchdb.Support.FileDirUtils.DeleteRecursive(serverPathFile);
                serverPathFile.Mkdir();

                server = new TDServer(path);
                TDDatabase old = server.GetExistingDatabaseNamed("foo");
                if (old != null)
                    old.DeleteDatabase();

                TDDatabase db = server.GetDatabaseNamed("foo");
                db.Open();
                db.Exists();

                // The TDListener constructor bindings are not getting created
                //TDListener listener = new TDListener(server, 8888);
                //listener.Start();
                foreach (string name in server.AllDatabaseNames())
                    Log.Info("####", "DB " + name);
                server.Close();

                Log.Info("####", "Server closed");
            }
            catch (Exception ex)
            {
                Log.Error("#### EXCEPTION", ex.Message);
            }
        }
    }
}

