using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LAB2.Views;

public partial class ChooseView : UserControl
{
    public ChooseView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
