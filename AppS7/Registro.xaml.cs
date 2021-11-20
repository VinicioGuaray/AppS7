﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppS7.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public Registro()
        {
            InitializeComponent();
            conn = DependencyService.Get<dataBase>().GetConnection();

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var registros = new Estudiante { nombre = name.Text, usuario = usuario.Text, password = password.Text };
                conn.InsertAsync(registros);

                DisplayAlert("alerta", "Se guardo correctamente", "ok");
            }
            catch(Exception ex)
            {

            }
        }
        private void limpiar()
        {
            name.Text = "";
            password.Text = "";
            usuario.Text = "";
        }
    }
}