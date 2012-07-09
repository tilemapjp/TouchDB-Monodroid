using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NUnit.Framework;
using Com.Couchbase.Touchdb;

namespace TouchDB_Monodroid_Test.Tests
{
    [TestFixture]
    class Changes : Java.Lang.Object, Java.Util.IObserver
    {
        int changeNotifications { get; set; }

        [Test]
        public void TestServer()
        {
            string filesDir = MainActivity.Main.FilesDir.AbsolutePath;

            TDDatabase db = TDDatabase.CreateEmptyDBAtPath(filesDir + "/touch_couch_test.sqlite3");

            db.AddObserver(this);

            Dictionary<string, Java.Lang.Object> documentProperties = new Dictionary<string, Java.Lang.Object>();
            documentProperties.Add("foo", 1);
            documentProperties.Add("bar", false);
            documentProperties.Add("baz", "touch");

            TDBody body = new TDBody(documentProperties);
            TDRevision rev1 = new TDRevision(body);

            TDStatus status = new TDStatus();
            rev1 = db.PutRevision(rev1, null, false, status);

            Assert.True(changeNotifications == 1);

            db.Close();
            db.DeleteDatabase();
        }

        public void Update(Java.Util.Observable observable, Java.Lang.Object data)
        {
            changeNotifications++;
        }
    }
}