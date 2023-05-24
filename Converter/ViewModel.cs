using System.ComponentModel;
using System.Windows.Input;
using Converter.Model;
using System.Collections.ObjectModel;
using Flurl.Http;

namespace Converter.ViewModel;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private ObservableCollection<VPP> listValute = new ();
    private VPP firstValute;
    private VPP secondValute;
    private DateTime selectedDate = DateTime.Today;

    public ViewModel()
    {
        LoadData(DateTime.Today.ToString("yyyy/MM/dd").Replace(".", "/"));
    }
    public DateTime SelectedDate
    {
        get => selectedDate;
        set
        {
            if (selectedDate != value)
            {
                selectedDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDate)));
                LoadData(selectedDate.ToString("yyyy/MM/dd").Replace(".", "/"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Conversion)));
            }
        }
    }
    
    public ObservableCollection<VPP> ListValute
    {
        get => listValute;
        set
        {
            if (listValute != value)
            {
                listValute = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListValute))); 
            }
        }
    }
    
    
    
    private string valueinput = string.Empty;
    public string ValueInput
    {
        get => valueinput;
        set
        {
            if (valueinput == value) return;
            valueinput = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValueInput)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondValute)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstValute)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Conversion)));
        }
    }
    
    public double Conversion
    {
        get
        {
            if (secondValute == null || firstValute == null) return 0;
            if (double.TryParse(valueinput, out var valuein))
                return Math.Round(
                    ((valuein * FirstValute.Value / FirstValute.Nominal) / (SecondValute.Value / SecondValute.Nominal)),
                    5);
            return 0;
        }
}
    public VPP FirstValute
    {
        get => firstValute;
        set
        {
            if (firstValute != value)
            {
                firstValute = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValueInput)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondValute)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstValute)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Conversion)));
            }
        }
    }
    public VPP SecondValute
    {
        get => secondValute;
        set
        {
            if (secondValute != value)
            {
                secondValute = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ValueInput)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondValute)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstValute)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Conversion)));
            }
        }
    }

    private async Task LoadData(string date)
    {
        string a = null;
        string b = null;
        if (FirstValute != null)
        {
            a = FirstValute.Name;
        }
        if(SecondValute != null)
        {
            b = SecondValute.Name;
        }
    
        try
        {
            var result = await $"https://www.cbr-xml-daily.ru/archive/{date}/daily_json.js".GetJsonAsync<Root>();
            if (result != null)
            {
                ListValute.Clear();
                foreach (var ok in result.Valute.Valutes)
                {
                    ListValute.Add(new VPP() { Name = ok.Name, Value = ok.Value, Nominal = ok.Nominal });
                }
                ListValute.Add(new VPP()
                {
                    CharCode = "RUB", 
                    Name = "Российский рубль", 
                    Value = 1, 
                    Nominal = 1 
                });
            }
        }
        catch (Exception e)
        {
            SelectedDate = selectedDate.AddDays(-1);
        }
    
        FirstValute = ListValute.FirstOrDefault(c => c.Name == a);
        SecondValute = ListValute.FirstOrDefault(d => d.Name == b);
    }
}