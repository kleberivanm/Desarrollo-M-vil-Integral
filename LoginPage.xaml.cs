using MesApp.Services;
using System;
using Microsoft.Maui.Controls;
using MongoDB.Bson;

namespace AppMESAPP;

public partial class LoginPage : ContentPage
{
    private MongoDBService _mongoService;
    public LoginPage()
    {
        InitializeComponent();
        _mongoService = new MongoDBService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string correo = EmailEntry.Text;
        string contraseña = PasswordEntry.Text;

        if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contraseña))
        {
            var usuario = await _mongoService.ObtenerUsuario(correo);

            if (usuario != null && usuario["contraseña"] == contraseña)
            {
                await DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
                // Aquí podrías redirigir al usuario a la pantalla principal
                await Navigation.PushAsync(new ReservaPage());
            }
            else
            {
                await DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ReservaPage());
    }

    private async void OnForgotPasswordClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Recuperación de contraseña aún no implementada", "OK");
    }
}
