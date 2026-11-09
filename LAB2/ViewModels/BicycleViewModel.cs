using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LAB2.Services;

namespace LAB2.ViewModels;

public partial class BicycleViewModel : ViewModelBase
{
    private readonly MainViewModel _mainViewModel;

    [ObservableProperty]
    private string _startTimeText = string.Empty;

    [ObservableProperty]
    private string _endTimeText = string.Empty;

    [ObservableProperty]
    private string _totalCostText = string.Empty;

    public BicycleViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
    }

    [RelayCommand]
    private async Task Calculate()
    {
        if (!int.TryParse(StartTimeText, out int startTime))
        {
            await MessageBox.Show("Please enter a valid numeric starting time (0-23).", "Invalid Input");
            return;
        }

        if (startTime < 0 || startTime > 23)
        {
            await MessageBox.Show("Invalid start time! It must be from 0 to 23.", "Invalid Input");
            return;
        }

        if (!int.TryParse(EndTimeText, out int endTime))
        {
            await MessageBox.Show("Please enter a valid numeric ending time (0-24).", "Invalid Input");
            return;
        }

        if (endTime < 0 || endTime > 24)
        {
            await MessageBox.Show("Invalid end time! It must be from 0 to 24. Hours cannot exceed 24.", "Invalid Input");
            return;
        }

        int totalHours;
        if (endTime > startTime)
        {
            totalHours = endTime - startTime;
        }
        else
        {
            totalHours = (24 - startTime) + endTime;
        }

        if (totalHours > 24)
        {
            await MessageBox.Show("Invalid rental! Total hours cannot exceed 24.", "Rental Error");
            return;
        }

        int totalCost = 0;
        for (int i = 0; i < totalHours; i++)
        {
            int hour = (startTime + i) % 24;

            if (hour < 7)
            {
                totalCost += 500;
            }
            else if (hour < 14)
            {
                totalCost += 1000;
            }
            else if (hour < 19)
            {
                totalCost += 1500;
            }
            else if (hour < 21)
            {
                totalCost += 1000;
            }
            else
            {
                totalCost += 500;
            }
        }

        TotalCostText = $"{totalCost} RWF ({totalHours} hour(s))";

        await MessageBox.Show(
            $"Total rental hours: {totalHours} hour(s)\nTotal rental cost: {totalCost} RWF",
            "Rental Summary"
        );
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
