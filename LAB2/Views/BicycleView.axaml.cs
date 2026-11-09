using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LAB2.Views;

public partial class BicycleView : UserControl
{
    public BicycleView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
