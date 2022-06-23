using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesctopKSMClient.Views.InfoPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeventhLessonPage : ContentPage
    {
        public SeventhLessonPage()
        {
            InitializeComponent();
        }
        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}