using DesctopKSMClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesctopKSMClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            AnswerList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private void backButton_Clicked(object sender, EventArgs e)
        {
            if (userName.Text != null || groupName.Text != null)
            {
                User.UserName = userName.Text;
                User.GroupName = groupName.Text;
                Navigation.PopModalAsync();
            }
            else if (User.UserName != null && User.GroupName != null)
                Navigation.PopModalAsync();
            else
                DisplayAlert("Помилка", "Заповніть всі поля)", "Ok");
        }

    }
}