using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DesctopKSMClient.Data;
using DesctopKSMClient.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DesctopKSMClient.Views.TestPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstTestPage : ContentPage
    {
        public List<Button> buttons { get; set; }
        public MailAddress adminMail = new MailAddress("mainksmappsender@ukr.net");
        public MailAddress senderMail = new MailAddress("mainksmappsender@ukr.net");
        public DateTime startTime { get; set; }
        public FirstTestPage()
        {
            InitializeComponent();
            DisplayAlert("Тест розпочався", "У вас є 10 хвилин на виконання", "Зрозуміло!");
            startTime = DateTime.Now;

            buttons = new List<Button>
            {
                FirstQuestThirdButton, SecondQuestSecondButton, ThirdQuestFirstButton, FourthQuestThirdButton, FifthQuestThirdButton,
                SixthQuestThirdButton, SeventhQuestFirstButton, EighthQuestFourthButton, NinthQuestThirdButton, TenthQuestFirstButton
            };
            Result(buttons);
        }

        public bool IsRightAnswer(Button button)
        {
            string image = button.ImageSource.ToString();
            if (image == "File: AnswerClickOn.png")
                return true;
            return false;
        }

        public int Result(List<Button> buttonList)
        {
            int result = 0;
            foreach (var i in buttonList)
            {
                if (IsRightAnswer(i))
                    result++;
            }
            return result;
        }

        private async void finishTestButton_Clicked(object sender, EventArgs e)
        {
            int result = Result(buttons);
            if ((DateTime.Now - startTime).Minutes < 12)
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.ukr.net";
                    smtpClient.Port = 465;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(MailSender.adminMail.Address, MailSender.senderMailPassword);

                    MailMessage message = new MailMessage();
                    message.From = senderMail;
                    message.To.Add(adminMail);
                    message.Subject = "TestResult";
                    message.Body = "Результат проходження теста ІР-адресація = " + result + "/10 ім'я студента: " + User.UserName + " з групи " + User.GroupName;
                    smtpClient.Send(message);
                }
                catch
                {
                    DisplayAlert("Exception", "Can't send message", "Ok");
                    DisplayAlert("Тест завершено", "Результат " + result + "/10", "Ok");
                    Answer answer = new Answer
                    {
                        studentName = User.UserName,
                        groupName = User.GroupName,
                        testName = "ІР-адресація",
                        result = Result(buttons),
                        dateTime = DateTime.Now
                    };
                    App.Database.SaveItem(answer);
                    await Navigation.PopModalAsync();
                }
                DisplayAlert("Тест завершено", "Резкльтат - " + result + "/10", "Ок");
                await Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Ви не встигли", " ", "Ok");
                Navigation.PopModalAsync();
            }
        }

        public SmtpClient SmtpClientCreat(MailAddress address, string password)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(address.Address, password);
            return smtpClient;
        }

        public void ChangeButtonImage(Button clickButton, Button secondButton, Button thirthdButton, Button fourthButton)
        {
            clickButton.Image = "AnswerClickOn.png";
            secondButton.Image = "AnswerClick.png";
            thirthdButton.Image = "AnswerClick.png";
            fourthButton.Image = "AnswerClick.png";
        }

        #region
        private void FirstQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FirstQuestFirstButton, FirstQuestSecondButton, FirstQuestThirdButton, FirstQuestFourthButton);
        }
        private void FirstQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FirstQuestSecondButton, FirstQuestFirstButton, FirstQuestThirdButton, FirstQuestFourthButton);
        }
        private void FirstQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FirstQuestThirdButton, FirstQuestSecondButton, FirstQuestFirstButton, FirstQuestFourthButton);
        }
        private void FirstQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FirstQuestFourthButton, FirstQuestSecondButton, FirstQuestThirdButton, FirstQuestFirstButton);
        }

        private void SecondQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SecondQuestFirstButton, SecondQuestSecondButton, SecondQuestThirdButton, SecondQuestFourthButton);
        }
        private void SecondQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SecondQuestSecondButton, SecondQuestFirstButton, SecondQuestThirdButton, SecondQuestFourthButton);
        }
        private void SecondQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SecondQuestThirdButton, SecondQuestSecondButton, SecondQuestFirstButton, SecondQuestFourthButton);
        }
        private void SecondQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SecondQuestFourthButton, SecondQuestSecondButton, SecondQuestThirdButton, SecondQuestFirstButton);
        }

        private void ThirdQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(ThirdQuestFirstButton, ThirdQuestSecondButton, ThirdQuestThirdButton, ThirdQuestFourthButton);
        }
        private void ThirdQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(ThirdQuestSecondButton, ThirdQuestFirstButton, ThirdQuestThirdButton, ThirdQuestFourthButton);
        }
        private void ThirdQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(ThirdQuestThirdButton, ThirdQuestSecondButton, ThirdQuestFirstButton, ThirdQuestFourthButton);
        }
        private void ThirdQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(ThirdQuestFourthButton, ThirdQuestSecondButton, ThirdQuestThirdButton, ThirdQuestFirstButton);
        }

        private void FourthQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FourthQuestFirstButton, FourthQuestSecondButton, FourthQuestThirdButton, FourthQuestFourthButton);
        }
        private void FourthQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FourthQuestSecondButton, FourthQuestFirstButton, FourthQuestThirdButton, FourthQuestFourthButton);
        }
        private void FourthQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FourthQuestThirdButton, FourthQuestSecondButton, FourthQuestFirstButton, FourthQuestFourthButton);
        }
        private void FourthQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FourthQuestFourthButton, FourthQuestSecondButton, FourthQuestThirdButton, FourthQuestFirstButton);
        }

        private void FifthQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FifthQuestFirstButton, FifthQuestSecondButton, FifthQuestThirdButton, FifthQuestFourthButton);
        }
        private void FifthQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FifthQuestSecondButton, FifthQuestFirstButton, FifthQuestThirdButton, FifthQuestFourthButton);
        }
        private void FifthQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FifthQuestThirdButton, FifthQuestSecondButton, FifthQuestFirstButton, FifthQuestFourthButton);
        }
        private void FifthQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(FifthQuestFourthButton, FifthQuestSecondButton, FifthQuestThirdButton, FifthQuestFirstButton);
        }

        private void SixthQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SixthQuestFirstButton, SixthQuestSecondButton, SixthQuestThirdButton, SixthQuestFourthButton);
        }
        private void SixthQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SixthQuestSecondButton, SixthQuestFirstButton, SixthQuestThirdButton, SixthQuestFourthButton);
        }
        private void SixthQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SixthQuestThirdButton, SixthQuestSecondButton, SixthQuestFirstButton, SixthQuestFourthButton);
        }
        private void SixthQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SixthQuestFourthButton, SixthQuestSecondButton, SixthQuestThirdButton, SixthQuestFirstButton);
        }

        private void SeventhQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SeventhQuestFourthButton, SeventhQuestSecondButton, SeventhQuestThirdButton, SeventhQuestFirstButton);
        }
        private void SeventhQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SeventhQuestThirdButton, SeventhQuestSecondButton, SeventhQuestFirstButton, SeventhQuestFourthButton);
        }
        private void SeventhQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SeventhQuestSecondButton, SeventhQuestFirstButton, SeventhQuestThirdButton, SeventhQuestFourthButton);
        }
        private void SeventhQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(SeventhQuestFirstButton, SeventhQuestSecondButton, SeventhQuestThirdButton, SeventhQuestFourthButton);
        }

        private void EighthQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(EighthQuestFourthButton, EighthQuestSecondButton, EighthQuestThirdButton, EighthQuestFirstButton);
        }
        private void EighthQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(EighthQuestThirdButton, EighthQuestSecondButton, EighthQuestFirstButton, EighthQuestFourthButton);
        }
        private void EighthQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(EighthQuestSecondButton, EighthQuestFirstButton, EighthQuestThirdButton, EighthQuestFourthButton);
        }
        private void EighthQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(EighthQuestFirstButton, EighthQuestSecondButton, EighthQuestThirdButton, EighthQuestFourthButton);
        }

        private void NinthQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(NinthQuestFourthButton, NinthQuestSecondButton, NinthQuestThirdButton, NinthQuestFirstButton);
        }
        private void NinthQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(NinthQuestThirdButton, NinthQuestSecondButton, NinthQuestFirstButton, NinthQuestFourthButton);
        }
        private void NinthQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(NinthQuestSecondButton, NinthQuestFirstButton, NinthQuestThirdButton, NinthQuestFourthButton);
        }
        private void NinthQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(NinthQuestFirstButton, NinthQuestSecondButton, NinthQuestThirdButton, NinthQuestFourthButton);
        }

        private void TenthQuestFourthButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(TenthQuestFourthButton, TenthQuestSecondButton, TenthQuestThirdButton, TenthQuestFirstButton);
        }
        private void TenthQuestThirdButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(TenthQuestThirdButton, TenthQuestSecondButton, TenthQuestFirstButton, TenthQuestFourthButton);
        }
        private void TenthQuestSecondButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(TenthQuestSecondButton, TenthQuestFirstButton, TenthQuestThirdButton, TenthQuestFourthButton);
        }
        private void TenthQuestFirstButton_Clicked(object sender, EventArgs e)
        {
            ChangeButtonImage(TenthQuestFirstButton, TenthQuestSecondButton, TenthQuestThirdButton, TenthQuestFourthButton);
        }
        #endregion
    }
}