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
    class Server
    {
        [Test]
        public void TestServer()
        {
            string path = MainActivity.Main.FilesDir.AbsolutePath + "/tests";
            Java.IO.File serverPathFile = new Java.IO.File(path);
            Com.Couchbase.Touchdb.Support.FileDirUtils.DeleteRecursive(serverPathFile);
            serverPathFile.Mkdir();

            TDServer server = new TDServer(path);

            TDDatabase old = server.GetExistingDatabaseNamed("foo");
            if (old != null)
                old.DeleteDatabase();

            TDDatabase db = server.GetDatabaseNamed("foo");
            Assert.NotNull(db);
            Assert.True(db.Name == "foo");
            //Assert.assertTrue(db.getPath().startsWith(getServerPath()));
            Assert.True(db.Exists() == false);
            
            //Assert.ReferenceEquals(db, server.GetDatabaseNamed("foo"));
            Assert.True(object.ReferenceEquals(db, server.GetDatabaseNamed("foo")));

            Assert.True(db.Open());
            Assert.True(db.Exists());

            db.Close();
            server.DeleteDatabaseNamed("foo");
            server.Close();
        }
    }
}