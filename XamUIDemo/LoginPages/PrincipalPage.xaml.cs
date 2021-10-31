using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamUIDemo.Utils;

namespace XamUIDemo.LoginPages
{
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();
            this.Saludo.Text = "Hola ,"+loginUser.getInstance().UserLog.Nombre;
        }
    }
}
