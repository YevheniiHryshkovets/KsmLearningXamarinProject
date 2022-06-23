using DesctopKSMClient.Data;
using DesctopKSMClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DesctopKSMClient
{
    public partial class MainPage : ContentPage
    {

        TestsPage testsPage = new TestsPage();
        LearnPage learnPage = new LearnPage();
        InfoPage infoPage = new InfoPage();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LearningButton_Clicked(object sender, EventArgs e)
        {
            if (User.UserName == null || User.GroupName == null)
                await Navigation.PushModalAsync(infoPage);
            else
                await Navigation.PushModalAsync(learnPage);
        }

        private async void TestsButton_Clicked(object sender, EventArgs e)
        {
            if (User.UserName == null || User.GroupName == null)
                await Navigation.PushModalAsync(infoPage);
            else
                await Navigation.PushModalAsync(testsPage);
        }

        private async void InfoButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(infoPage);
        }
    }
}
