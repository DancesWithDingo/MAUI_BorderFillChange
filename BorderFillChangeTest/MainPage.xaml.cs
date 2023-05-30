namespace BorderFillChangeTest;

public partial class MainPage : ContentPage
{
    public MainPage() {
        InitializeComponent();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e) {
        Container.HorizontalOptions = Container.HorizontalOptions.Alignment == LayoutOptions.Fill.Alignment ? LayoutOptions.Start : LayoutOptions.Fill;
    }
}
