using CommunityToolkit.Mvvm.Input;

namespace LAB2.ViewModels;

public partial class ChooseViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    public ChooseViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    [RelayCommand]
    private void GoToBicycle()
    {
        _mainViewModel.NavigateToBicycle();
    }

    [RelayCommand]
    private void GoToMushroom()
    {
        _mainViewModel.NavigateToMushroom();
    }
}
