﻿using Productos.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Productos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListaView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
