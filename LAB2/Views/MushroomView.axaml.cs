using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using LAB2.ViewModels;

namespace LAB2.Views;

public partial class MushroomView : UserControl
{
    private TextBox? _box1;
    private TextBox? _box2;
    private TextBox? _box3;

    public MushroomView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        _box1 = this.FindControl<TextBox>("AnswerBox1");
        _box2 = this.FindControl<TextBox>("AnswerBox2");
        _box3 = this.FindControl<TextBox>("AnswerBox3");

        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object? sender, System.EventArgs e)
    {
        if (DataContext is MushroomViewModel vm)
        {
            vm.PropertyChanged += OnViewModelPropertyChanged;
        }
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(MushroomViewModel.IsQ2Visible))
        {
            if (DataContext is MushroomViewModel vm && vm.IsQ2Visible)
            {
                Dispatcher.UIThread.Post(() => _box2?.Focus());
            }
        }
        else if (e.PropertyName == nameof(MushroomViewModel.IsQ3Visible))
        {
            if (DataContext is MushroomViewModel vm && vm.IsQ3Visible)
            {
                Dispatcher.UIThread.Post(() => _box3?.Focus());
            }
        }
    }

    private async void AnswerBox1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is MushroomViewModel vm)
        {
            await vm.CheckAnswerValidation(vm.Answer1);
        }
    }

    private async void AnswerBox2_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is MushroomViewModel vm)
        {
            await vm.CheckAnswerValidation(vm.Answer2);
        }
    }

    private async void AnswerBox3_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && DataContext is MushroomViewModel vm)
        {
            await vm.CheckAnswerValidation(vm.Answer3);
        }
    }
}
