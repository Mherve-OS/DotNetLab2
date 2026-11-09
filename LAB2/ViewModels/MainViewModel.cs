using CommunityToolkit.Mvvm.ComponentModel;

namespace LAB2.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _currentView;

    public MainViewModel()
    {
        // Start at Login View as specified in the PDF workflow
        _currentView = new LoginViewModel(this);
    }

    public void NavigateTo(ViewModelBase newView)
    {
        CurrentView = newView;
    }

    public void NavigateToLogin()
    {
        NavigateTo(new LoginViewModel(this));
    }

    public void NavigateToChoose()
    {
        NavigateTo(new ChooseViewModel(this));
    }

    public void NavigateToBicycle()
    {
        NavigateTo(new BicycleViewModel(this));
    }

    public void NavigateToMushroom()
    {
        NavigateTo(new MushroomViewModel(this));
    }
}
