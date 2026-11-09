using System.Threading.Tasks;
using LAB2.Views;

namespace LAB2.Services;

public static class MessageBox
{
    public static Task Show(string message, string title = "Message")
    {
        return MessageBoxWindow.Show(message, title);
    }
}
