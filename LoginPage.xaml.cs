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
        string contrase�a = PasswordEntry.Text;

        if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(contrase�a))
        {
            var usuario = await _mongoService.ObtenerUsuario(correo);

            if (usuario != null && usuario["contrase�a"] == contrase�a)
            {
                await DisplayAlert("�xito", "Inicio de sesi�n exitoso", "OK");
                // Aqu� podr�as redirigir al usuario a la pantalla principal
                await Navigation.PushAsync(new ReservaPage());
            }
            else
            {
                await DisplayAlert("Error", "Correo o contrase�a incorrectos", "OK");
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
        await DisplayAlert("Info", "Recuperaci�n de contrase�a a�n no implementada", "OK");
    }
}
