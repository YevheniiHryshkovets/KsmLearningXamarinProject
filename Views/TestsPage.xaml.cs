using DesctopKSMClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesctopKSMClient.Views.TestPages;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesctopKSMClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestsPage : ContentPage
    {
        public List<Test> testsList { get; set; }
        public TestsPage()
        {
            InitializeComponent();
            testsList = new List<Test>
            {
                new Test("ІР-адресація", 1),
                new Test("Основи мережного з'єднання і передавання даних", 2),
                new Test("Ethernet-концепції", 3),
                new Test("Взаємодія між мережами", 4),
                new Test("Взаємодія мережних застосунків", 5)
            };
            BindingContext = this;
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BackToMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void OpenButton_Clicked(object sender, EventArgs e)
        {
            var testItem = testsViev.SelectedItem as Test;
            if (testItem != null)
                OpenTestAsync(testItem);
        }
        public async void OpenTestAsync(Test test)
        {
            var num = test.Id;
            switch (num)
            {
                case 1:
                    await Navigation.PushModalAsync(new FirstTestPage());
                    break;
                case 2:
                    await Navigation.PushModalAsync(new SecondTestPage());
                    break;
                case 3:
                    await Navigation.PushModalAsync(new ThirdTestPage());
                    break;
                case 4:
                    await Navigation.PushModalAsync(new FourthTestPage());
                    break;
                case 5:
                    await Navigation.PushModalAsync(new FifthTestPage());
                    break;

            }
        }
    }
}