using System;

namespace AppMESAPP;

public partial class MetodoPagoPage : ContentPage
{
    public MetodoPagoPage()
    {
        InitializeComponent();
    }

    private async void OnPayPalClicked(object sender, EventArgs e)
    {
        var uri = new Uri("https://www.paypal.com/");
        await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }

    private async void OnMercadoPagoClicked(object sender, EventArgs e)
    {
        var uri = new Uri("https://www.mercadopago.com/");
        await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
    }
}
