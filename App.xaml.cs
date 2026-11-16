using AppHotelJoaquim.Models;

namespace AppHotelJoaquim;

public partial class App : Application
{
    public List<Quarto> list_quartos = new()
    {
        new Quarto
        {
            Descricao = "Suite de Luxo EXTREMO",
            ValorDiariaAdulto = 500.00,
            ValorDiariaCrianca = 300.00
        },
        new Quarto
        {
            Descricao = "Suite de Luxo",
            ValorDiariaAdulto = 400.00,
            ValorDiariaCrianca = 250.00
        },
        new Quarto
        {
            Descricao = "Suite Simples",
            ValorDiariaAdulto = 300.00,
            ValorDiariaCrianca = 150.00
        },  
        new Quarto
        {
            Descricao = "Quarto Simples",
            ValorDiariaAdulto = 200.00,
            ValorDiariaCrianca = 100.00
        },
        new Quarto
        {
            Descricao = "Quarto Economico",
            ValorDiariaAdulto = 50.00,
            ValorDiariaCrianca = 20.00
        }
    };

    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Light;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}
