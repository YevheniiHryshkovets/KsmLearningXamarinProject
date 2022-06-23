using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DesctopKSMClient.Model;
using System.IO;

namespace DesctopKSMClient
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "answers.db";
        public static AnswerRepository database;
        public static AnswerRepository Database
        {
            get
            {
                if(database == null)
                {
                    database = new AnswerRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
