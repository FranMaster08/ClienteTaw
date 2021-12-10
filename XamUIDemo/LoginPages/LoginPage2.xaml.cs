using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;
using XamUIDemo.Animations;
using XamUIDemo.Responses;
using XamUIDemo.Utils;

namespace XamUIDemo.LoginPages
{
    public partial class LoginPage2 : ContentPage
    {
        public void Data()
        {
            var client = new RestClient("https://tawargentina.herokuapp.com/users/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("user", "francisco.jimenez@gmail.com");
            request.AddParameter("pass", "12345");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        public LoginPage2()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await ViewAnimations.FadeAnimY(Logo);
                await ViewAnimations.FadeAnimY(MainStack);

            });
        }
        protected void Back(object s, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
        protected async void Login(object s, EventArgs e)
        {

            try
            {

                var client = new RestClient("https://tawargentina.herokuapp.com/users/login");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("user", this.Email.Text?.Trim());
                request.AddParameter("pass", this.Pass.Text?.Trim());
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //loginUser.getInstance().UserLog = JsonConvert.DeserializeObject<UserResponses>(response.Content);
                    await Navigation.PushAsync(new PrincipalPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Error de credenciales", "volver");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error de credenciales", "volver");
            }

        }
    }

   
}
