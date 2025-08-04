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
        private UnitDisplay selectedFromUnit;
        private UnitDisplay selectedToUnit;
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

        public ObservableCollection<UnitDisplay> AvailableUnits { get; } = new();

        public UnitDisplay SelectedFromUnit
        {
            get => selectedFromUnit;
            set => SetProperty(ref selectedFromUnit, value);
        }

        public UnitDisplay SelectedToUnit
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
                    foreach (UnitConverter.LengthUnit unit in Enum.GetValues(typeof(UnitConverter.LengthUnit)))
                    {
                        if (UnitConverter.ConversionData.lengthUnits.TryGetValue(unit, out var unitData))
                        {
                            AvailableUnits.Add(new UnitDisplay(unit, unitData));
                        }
                    }
                    break;

                case UnitCategory.Weight:
                    foreach (UnitConverter.WeightUnit unit in Enum.GetValues(typeof(UnitConverter.WeightUnit)))
                    {
                        if (UnitConverter.ConversionData.weightUnits.TryGetValue(unit, out var unitData))
                        {
                            AvailableUnits.Add(new UnitDisplay(unit, unitData));
                        }
                    }
                    break;

                case UnitCategory.Volume:
                    foreach (UnitConverter.VolumeUnit unit in Enum.GetValues(typeof(UnitConverter.VolumeUnit)))
                    {
                        if (UnitConverter.ConversionData.volumeUnits.TryGetValue(unit, out var unitData))
                        {
                            AvailableUnits.Add(new UnitDisplay(unit, unitData));
                        }
                    }
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
                    (UnitConverter.LengthUnit)SelectedFromUnit.EnumValue, (UnitConverter.LengthUnit)SelectedToUnit.EnumValue).Convert(),

                    UnitCategory.Weight => new UnitConverter.WeightUnitConverter(InputValue,
                    (UnitConverter.WeightUnit)SelectedFromUnit.EnumValue, (UnitConverter.WeightUnit)SelectedToUnit.EnumValue).Convert(),

                    UnitCategory.Volume => new UnitConverter.VolumeUnitConverter(InputValue,
                    (UnitConverter.VolumeUnit)SelectedFromUnit.EnumValue, (UnitConverter.VolumeUnit)SelectedToUnit.EnumValue).Convert(),
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

    public class UnitDisplay
    {
        public object EnumValue { get; }
        public string Name => Unit.Name;
        public string? IconPath => Unit.IconPath;
        public UnitClass Unit { get; }

        public UnitDisplay(object enumValue, UnitClass unit)
        {
            EnumValue = enumValue;
            Unit = unit;
        }
    }
}
