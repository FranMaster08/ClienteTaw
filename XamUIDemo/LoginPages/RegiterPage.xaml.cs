using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;
using XamUIDemo.Animations;
using XamUIDemo.Responses;
using XamUIDemo.Utils;

namespace XamUIDemo.LoginPages
{
    public partial class RegiterPage : ContentPage
    {
        public RegiterPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
               // await ViewAnimations.FadeAnimY(Logo);
               
                await ViewAnimations.FadeAnimY(SignupButton);
            });
        }
        protected void Back(object s, EventArgs e)
        {
            Navigation.PopAsync();
        }
        protected async void Login(object s, EventArgs e)
        {
            var user = new User
            {
                Nombre = this.Nombre.Text,
                Apellido = this.Apellido.Text,
                Fecha = this.fecha.Date.ToLongDateString(),
                Direccion = this.Direccion.Text,
                Cuidad = this.Ciudad.Text,
                Provincia = this.Provincia.Text,
                Email = this.Email.Text,
                Password = this.Password.Text,
            };
            var client = new RestClient("https://taw-argentina.herokuapp.com");
            var request = new RestRequest("users", Method.POST);


            Type _type = user.GetType();
            System.Reflection.PropertyInfo[] listaPropiedades = _type.GetProperties();
            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
                request.AddParameter(propiedad.Name, propiedad.GetValue(user, null));
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new LoginPage2());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Content, "volver");
                await Navigation.PopAsync();
            } 
             
        }
    }
}
