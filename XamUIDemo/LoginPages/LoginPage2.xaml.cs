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

            var user = new User
            {

                Email = this.Email.Text,
                Password = this.Pass.Text
            };
            var client = new RestClient("https://taw-argentina.herokuapp.com");
            var request = new RestRequest("users/login", Method.POST);


            Type _type = user.GetType();
            System.Reflection.PropertyInfo[] listaPropiedades = _type.GetProperties();
            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                request.AddParameter(propiedad.Name, propiedad.GetValue(user, null));

            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                loginUser.getInstance().UserLog= JsonConvert.DeserializeObject<UserResponses>(response.Content);
                await Navigation.PushAsync(new PrincipalPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Error de credenciales", "volver");
            }

        }
    }

   
}
