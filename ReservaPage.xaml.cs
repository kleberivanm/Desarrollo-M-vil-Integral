using System;

namespace AppMESAPP;

public partial class ReservaPage : ContentPage
{
    public ReservaPage()
    {
        InitializeComponent();
    }

    private async void OnConfirmClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(RestauranteEntry.Text) || string.IsNullOrEmpty(BebidaEntry.Text) ||
            string.IsNullOrEmpty(ComidaEntry.Text) || string.IsNullOrEmpty(PersonasEntry.Text))
        {
            await DisplayAlert("Error", "Por favor completa los campos obligatorios", "OK");
            return;
        }

        await DisplayAlert("Éxito", "Reservación Confirmada", "OK");
        await Navigation.PushAsync(new MetodoPagoPage());  // Ir a método de pago
    }
}
