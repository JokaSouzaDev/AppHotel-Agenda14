using AppHotelJoaquim.Models;
using AppHotelJoaquim.Views;

namespace AppHotelJoaquim;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var app = (App)Application.Current!;

        pckQuarto.ItemsSource = app.list_quartos;
        pckQuarto.SelectedIndex = 0;

        dtpCheckin.MinimumDate = DateTime.Today;
        dtpCheckin.MaximumDate = DateTime.Today.AddMonths(1);
        dtpCheckin.Date = DateTime.Today;

        dtpCheckout.MinimumDate = DateTime.Today.AddDays(1);
        dtpCheckout.MaximumDate = DateTime.Today.AddMonths(6);
        dtpCheckout.Date = DateTime.Today.AddDays(1);
    }

    private void OnCheckinChanged(object sender, DateChangedEventArgs e)
    {
        if (dtpCheckout is null ||
            dtpCheckin?.Date is not DateTime checkin)
            return;

        dtpCheckout.MinimumDate = checkin.AddDays(1);
        dtpCheckout.MaximumDate = checkin.AddMonths(6);

        if (dtpCheckout.Date is not DateTime checkout ||
            checkout <= checkin)
        {
            dtpCheckout.Date = checkin.AddDays(1);
        }
    }

    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        var adultos = (int)stpAdultos.Value;
        var criancas = (int)stpCriancas.Value;

        if (adultos < 1)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Selecione pelo menos um adulto.",
                "OK");
            return;
        }

        if (pckQuarto.SelectedItem is not Quarto quarto)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Selecione uma acomodação.",
                "OK");
            return;
        }

        if (dtpCheckin.Date is not DateTime checkin ||
            dtpCheckout.Date is not DateTime checkout ||
            checkout <= checkin)
        {
            await DisplayAlertAsync(
                "Datas inválidas",
                "Confira o período da estadia.",
                "OK");
            return;
        }

        decimal valorDiaria =
            adultos * (decimal)quarto.ValorDiariaAdulto +
            criancas * (decimal)quarto.ValorDiariaCrianca;

        var reserva = new ReservaResumo(
            quarto.Descricao,
            valorDiaria,
            adultos,
            criancas,
            checkin,
            checkout
        );

        await Shell.Current.GoToAsync(
            nameof(ResultadoPage),
            new Dictionary<string, object>
            {
                ["reserva"] = reserva
            });
    }
}