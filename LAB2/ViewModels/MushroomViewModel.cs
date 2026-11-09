using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LAB2.Services;

namespace LAB2.ViewModels;

public partial class MushroomViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    [ObservableProperty]
    private string _answer1 = string.Empty;

    [ObservableProperty]
    private string _answer2 = string.Empty;

    [ObservableProperty]
    private string _answer3 = string.Empty;

    [ObservableProperty]
    private bool _isQ2Visible = false;

    [ObservableProperty]
    private string _q2Prompt = "Does your mushroom grow in a forest? (yes/no):";

    [ObservableProperty]
    private bool _isQ3Visible = false;

    [ObservableProperty]
    private string _q3Prompt = string.Empty;

    [ObservableProperty]
    private bool _isResultVisible = false;

    [ObservableProperty]
    private string _resultText = string.Empty;

    private string _lastAnnouncedResult = string.Empty;

    public MushroomViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    partial void OnAnswer1Changed(string value)
    {
        string a1 = value?.Trim().ToLower() ?? "";

        if (a1 != "yes")
        {
            Answer2 = string.Empty;
            Answer3 = string.Empty;
            IsQ2Visible = false;
            IsQ3Visible = false;
        }

        if (a1 == "no")
        {
            ResultText = "Your mushroom is Cepe de bordeaux.";
            IsResultVisible = true;
            AnnounceResult(ResultText);
        }
        else if (a1 == "yes")
        {
            IsResultVisible = false;
            ResultText = string.Empty;
            _lastAnnouncedResult = string.Empty;
            Q2Prompt = "Does your mushroom grow in a forest? (yes/no):";
            IsQ2Visible = true;
        }
        else
        {
            IsResultVisible = false;
            ResultText = string.Empty;
            _lastAnnouncedResult = string.Empty;
        }
    }

    partial void OnAnswer2Changed(string value)
    {
        if (!IsQ2Visible)
            return;

        string a2 = value?.Trim().ToLower() ?? "";

        Answer3 = string.Empty;
        IsQ3Visible = false;
        IsResultVisible = false;
        ResultText = string.Empty;
        _lastAnnouncedResult = string.Empty;

        if (a2 == "no")
        {
            Q3Prompt = "Does your mushroom have a ring? (yes/no):";
            IsQ3Visible = true;
        }
        else if (a2 == "yes")
        {
            Q3Prompt = "Does your mushroom have a convex cup? (yes/no):";
            IsQ3Visible = true;
        }
    }

    partial void OnAnswer3Changed(string value)
    {
        if (!IsQ3Visible)
            return;

        string a2 = Answer2?.Trim().ToLower() ?? "";
        string a3 = value?.Trim().ToLower() ?? "";

        if (a3 != "yes" && a3 != "no")
        {
            IsResultVisible = false;
            ResultText = string.Empty;
            _lastAnnouncedResult = string.Empty;
            return;
        }

        if (a2 == "no")
        {
            ResultText = (a3 == "yes")
                ? "Your mushroom is Agaric Jaunissant."
                : "Your mushroom is Coprin chevelu.";
        }
        else if (a2 == "yes")
        {
            ResultText = (a3 == "yes")
                ? "Your mushroom is Pied bleu."
                : "Your mushroom is Girolle.";
        }

        IsResultVisible = true;
        AnnounceResult(ResultText);
    }

    private async void AnnounceResult(string message)
    {
        if (string.IsNullOrEmpty(message) || message == _lastAnnouncedResult)
            return;

        _lastAnnouncedResult = message;
        await MessageBox.Show(message, "Mushroom Result");
    }

    public async Task CheckAnswerValidation(string input)
    {
        string val = input?.Trim().ToLower() ?? "";
        if (!string.IsNullOrEmpty(val) && val != "yes" && val != "no")
        {
            await MessageBox.Show("Invalid answer!", "Error");
        }
    }

    [RelayCommand]
    private void Back()
    {
        _mainViewModel.NavigateToChoose();
    }

    [RelayCommand]
    private void Logout()
    {
        _mainViewModel.NavigateToLogin();
    }
}
