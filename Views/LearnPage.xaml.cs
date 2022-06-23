using DesctopKSMClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesctopKSMClient.Views.InfoPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesctopKSMClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LearnPage : ContentPage
    {
        public List<Lesson> lessonsList { get; set; }
        public LearnPage()
        {
            InitializeComponent();

            lessonsList = new List<Lesson>
            {
            new Lesson(1, "Підключення до мережі інтернет"),
            new Lesson(2, "Комутація/Маршрутизація"),
            new Lesson(3, "Сервери, типи серверів їх функції"),
            new Lesson(4, "Фізична й логічна структуризація"),
            new Lesson(5, "Класифікація ліній зв'язку"),
            new Lesson(6, "Фізичний рівень моделі OSI"),
            new Lesson(7, "Протоколи та моделі"),
            new Lesson(8, "Канальний рівень моделі OSI"),
            new Lesson(9, "Пакети IPv.4 IPv.6"),
            new Lesson(10, "Структура IPv.4 та класова адресація"),
            new Lesson(11, "IPv.6 адресація"),
            new Lesson(12, "Рівень застосування")
            };
            BindingContext = this;
        }

        private void backButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void OpenLessonButton_Clicked(object sender, EventArgs e)
        {
            var lessonItem = lessonsView.SelectedItem as Lesson;
            if(lessonItem != null)
            {
                OpenButtonAsync(lessonItem);
            }
        }
        
        public async void OpenButtonAsync(Lesson lesson)
        {
            var num = lesson.ID;
            switch (num)
            {
                case 1:
                    await Navigation.PushModalAsync(new FirstLessonPage());
                    break;
                case 2:
                    await Navigation.PushModalAsync(new SecondLessonPage());
                    break;
                case 3:
                    await Navigation.PushModalAsync(new ThirdLessonPage());
                    break;
                case 4:
                    await Navigation.PushModalAsync(new FourthLessonPage());
                    break;
                case 5:
                    await Navigation.PushModalAsync(new FifthLessonPage());
                    break;
                case 6:
                    await Navigation.PushModalAsync(new SixthLessonPage());
                    break;
                case 7:
                    await Navigation.PushModalAsync(new SeventhLessonPage());
                    break;
                case 8:
                    await Navigation.PushModalAsync(new EighthLessonPage());
                    break;
                case 9:
                    await Navigation.PushModalAsync(new NinethLessonPage());
                    break;
                case 10:
                    await Navigation.PushModalAsync(new TenthLessonPage());
                    break;
                case 11:
                    await Navigation.PushModalAsync(new EleventhLessonPage());
                    break;
                case 12:
                    await Navigation.PushModalAsync(new TwelwethLessonPage());
                    break;
            }
        }
    }
}