using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MemeCalcBackEnd;

namespace MemeCalc
{
    class MainViewModel : INotifyPropertyChanged
    {
        public enum UnitCategory { Length, Weight, Volume }
        private UnitCategory selectedCategory;
        private decimal inputValue;
        private object selectedFromUnit;
        private object selectedToUnit;
        private string result;

        public UnitCategory SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (SetProperty(ref selectedCategory, value))
                {
                    CategoryDisplayName = selectedCategory switch
                    {
                        UnitCategory.Length => "Len",
                        UnitCategory.Weight => "Mass",
                        UnitCategory.Volume => "Vol"
                    };
                    UpdateAvailableUnits();
                }
            }
        }

        public ObservableCollection<object> AvailableUnits { get; } = new();

        public object SelectedFromUnit
        {
            get => selectedFromUnit;
            set => SetProperty(ref selectedFromUnit, value);
        }

        public object SelectedToUnit
        {
            get => selectedToUnit;
            set => SetProperty(ref selectedToUnit, value);
        }

        public decimal InputValue
        {
            get => inputValue;
            set => SetProperty(ref inputValue, value);
        }

        public string Result
        {
            get => result;
            set => SetProperty(ref result, value);
        }

        private string categoryDisplayName;
        public string CategoryDisplayName
        {
            get => categoryDisplayName;
            set => SetProperty(ref categoryDisplayName, value);
        }

        public ICommand ConvertCommand { get; }
        public ICommand CycleCategoryCommand { get; }
        public ICommand AppendInputCommand { get; }

        public MainViewModel()
        {
            SelectedCategory = UnitCategory.Length;
            CategoryDisplayName = SelectedCategory.ToString();
            CycleCategoryCommand = new RelayCommand(_ => CycleCategory());
            ConvertCommand = new RelayCommand(ExecuteConvert);
            UpdateAvailableUnits();
            AppendInputCommand = new RelayCommand(param =>
            {
                if (param is string digit)
                {
                    var current = InputValue.ToString();
                    if (decimal.TryParse(current + digit, out decimal result))
                    {
                        InputValue = result;
                    }
                }
            });
        }

        private void CycleCategory()
        {
            SelectedCategory = SelectedCategory switch
            {
                UnitCategory.Length => UnitCategory.Weight,
                UnitCategory.Weight => UnitCategory.Volume,
                UnitCategory.Volume => UnitCategory.Length,
                _ => UnitCategory.Length
            };
        }
        private void UpdateAvailableUnits()
        {
            AvailableUnits.Clear();

            switch (SelectedCategory)
            {
                case UnitCategory.Length:
                    foreach (var unit in Enum.GetValues(typeof(UnitConverter.LengthUnit)))
                        AvailableUnits.Add(unit);
                    break;
                case UnitCategory.Weight:
                    foreach (var unit in Enum.GetValues(typeof(UnitConverter.WeightUnit)))
                        AvailableUnits.Add(unit);
                    break;
                case UnitCategory.Volume:
                    foreach (var unit in Enum.GetValues(typeof(UnitConverter.VolumeUnit)))
                        AvailableUnits.Add(unit);
                    break;
            }
            SelectedFromUnit = AvailableUnits.Count > 0 ? AvailableUnits[0] : null;
            SelectedToUnit = AvailableUnits.Count > 1 ? AvailableUnits[1] : null;
        }

        private void ExecuteConvert(object _)
        {
            try
            {
                decimal output = SelectedCategory switch
                {
                    UnitCategory.Length => new UnitConverter.LengthUnitConverter(InputValue,
                    (UnitConverter.LengthUnit)SelectedFromUnit, (UnitConverter.LengthUnit)SelectedToUnit).Convert(),

                    UnitCategory.Weight => new UnitConverter.WeightUnitConverter(InputValue,
                    (UnitConverter.WeightUnit)SelectedFromUnit, (UnitConverter.WeightUnit)SelectedToUnit).Convert(),

                    UnitCategory.Volume => new UnitConverter.VolumeUnitConverter(InputValue,
                    (UnitConverter.VolumeUnit)SelectedFromUnit, (UnitConverter.VolumeUnit)SelectedToUnit).Convert(),
                    _ => throw new InvalidOperationException("Invalid category")
                };
                Result = output.ToString("N4");
            }
            catch (Exception ex)
            {
                Result = $"Error: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<t>(ref t storage, t value, [CallerMemberName] string prop = "")
        {
            if (Equals(storage, value)) return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            return true;
        }
    }
}
