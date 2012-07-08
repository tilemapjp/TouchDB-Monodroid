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
using NUnitLite.MonoDroid;
using System.Reflection;

namespace TouchDB_Monodroid_Test
{
    [Activity(Label = "TouchDB Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TestRunnerActivity
    {
        public static MainActivity Main { get; set; }

        public MainActivity()
        {
            Main = this;
        }

        protected override IEnumerable<Assembly> GetAssembliesForTest()
        {
            yield return GetType().Assembly;
        }

        protected override Type GetDetailsActivityType
        {
            get { return typeof(DetailsActivity); }
        }
    }
}