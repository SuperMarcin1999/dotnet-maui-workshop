using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private readonly MonkeyService _monkeyService;

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";

        _monkeyService = monkeyService;
    }

    [RelayCommand]
    async Task GetMonkeyAsync()
    {
        if(IsBusy) return;

        try
        {
            IsBusy = true;
            var monkeys = await _monkeyService.GetMonkeys();

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            await Shell.Current.DisplayAlert("Error!", e.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}