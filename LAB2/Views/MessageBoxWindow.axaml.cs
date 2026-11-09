using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LAB2.Views;

public partial class MessageBoxWindow : Window
{
    public MessageBoxWindow()
    {
        InitializeComponent();
    }

    public MessageBoxWindow(string message, string title = "Message")
    {
        InitializeComponent();
        Title = title;
        var textBlock = this.FindControl<TextBlock>("MessageTextBlock");
        if (textBlock != null)
        {
            textBlock.Text = message;
        }
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OkButton_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    public static async Task Show(string message, string title = "Message", Window? owner = null)
    {
        if (owner == null && Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            owner = desktop.MainWindow;
        }

        var dialog = new MessageBoxWindow(message, title);
        if (owner != null && owner.IsVisible)
        {
            await dialog.ShowDialog(owner);
        }
        else
        {
            dialog.Show();
        }
    }
}
