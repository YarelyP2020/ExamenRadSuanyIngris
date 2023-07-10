using ExamenRadSuanyIngris.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenRadSuanyIngris
{
    public partial class App : Application
    {
        static Database db;

        public static Database Database
        {
            get
            {
                var dbpath = String.Empty;
                var namedb = String.Empty;
                var fullpath = String.Empty;

                dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                namedb = "DBContac.db3";
                fullpath = Path.Combine(dbpath, namedb);

                if (db == null)
                {
                    db = new Database(fullpath);
                }

                return db;
            }
        }



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.PageListContactos());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
