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
        #region Types
        public enum UnitCategory { Length, Weight, Volume } // Categories of supported units
        #endregion

        #region Fields (backing storage)
        // Backing fields for bindable properties.
        private UnitCategory selectedCategory;
        private decimal inputValue;
        private UnitDisplay selectedFromUnit;
        private UnitDisplay selectedToUnit;
        private string result;
        private string categoryDisplayName;
        #endregion

        private bool _isRefreshing = false;

        #region Properties (bindable)
        // Changes available units when set
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

        // List of units shown for the current category in the UI.
        public ObservableCollection<UnitDisplay> FromUnits { get; } = new();
        public ObservableCollection<UnitDisplay> ToUnits { get; } = new();
        private List<UnitDisplay> _allUnits = new();

        public UnitDisplay SelectedFromUnit
        {
            get => selectedFromUnit;
            set
            {
                if (SetProperty(ref selectedFromUnit, value))
                    RefreshToUnits();
            }
        }

        public UnitDisplay SelectedToUnit
        {
            get => selectedToUnit;
            set
            {
                if (SetProperty(ref selectedToUnit, value))
                    RefreshFromUnits();
            }
        }

        private void RefreshToUnits()
        {
            if (_isRefreshing) return;
            _isRefreshing = true;
            var current = SelectedToUnit;
            ToUnits.Clear();
            foreach (var u in _allUnits.Where(u => u != SelectedFromUnit))
                ToUnits.Add(u);
            SelectedToUnit = ToUnits.Contains(current) ? current : ToUnits.FirstOrDefault();
            _isRefreshing = false;
        }

        private void RefreshFromUnits()
        {
            if (_isRefreshing) return;
            _isRefreshing = true;
            var current = SelectedFromUnit;
            FromUnits.Clear();
            foreach (var u in _allUnits.Where(u => u != selectedToUnit))
                FromUnits.Add(u);
            SelectedFromUnit = FromUnits.Contains(current) ? current : FromUnits.FirstOrDefault();
            _isRefreshing = false;
        }

        public decimal InputValue
        {
            get => inputValue;
            set => SetProperty(ref inputValue, value);
        }


        // Result string shown in UI, already formattted for display.
        public string Result
        {
            get => result;
            set => SetProperty(ref result, value);
        }

        
        public string CategoryDisplayName
        {
            get => categoryDisplayName;
            set => SetProperty(ref categoryDisplayName, value);
        }
        #endregion


        #region Commands
        // Commands bound to UI buttons.
        public ICommand ConvertCommand { get; }
        public ICommand CycleCategoryCommand { get; }
        public ICommand AppendInputCommand { get; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            SelectedCategory = UnitCategory.Length;
            CategoryDisplayName = SelectedCategory.ToString();

            // Cycles between unit categories.
            CycleCategoryCommand = new RelayCommand(_ => CycleCategory());

            // Peforms conversions.
            ConvertCommand = new RelayCommand(ExecuteConvert);

            // Populates initial unit list.
            UpdateAvailableUnits();

            // Handles numeric keypad input (appends digits to current value).
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
        #endregion


        #region Private Methods (behavior)
        // Changes SelectedCategory to the next one in sequence.
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

        // Refreshes AvailableUnits based on the currerntly selected category.
        private void UpdateAvailableUnits()
        {
            _allUnits.Clear();

            switch (SelectedCategory)
            {
                case UnitCategory.Length:
                    foreach (UnitConverter.LengthUnit unit in Enum.GetValues(typeof(UnitConverter.LengthUnit)))
                    {
                        if (UnitConverter.ConversionData.lengthUnits.TryGetValue(unit, out var unitData))
                        {
                            _allUnits.Add(new UnitDisplay(unit, unitData));
                        }
                    }
                    break;

                case UnitCategory.Weight:
                    foreach (UnitConverter.WeightUnit unit in Enum.GetValues(typeof(UnitConverter.WeightUnit)))
                    {
                        if (UnitConverter.ConversionData.weightUnits.TryGetValue(unit, out var unitData))
                        {
                            _allUnits.Add(new UnitDisplay(unit, unitData));
                        }
                    }
                    break;

                case UnitCategory.Volume:
                    foreach (UnitConverter.VolumeUnit unit in Enum.GetValues(typeof(UnitConverter.VolumeUnit)))
                    {
                        if (UnitConverter.ConversionData.volumeUnits.TryGetValue(unit, out var unitData))
                        {
                            _allUnits.Add(new UnitDisplay(unit, unitData));
                        }
                    }
                    break;
            }
            // Default "From" and "To" units to the first two in the list.
            SelectedFromUnit = _allUnits.Count > 0 ? _allUnits[0] : null;
            SelectedToUnit = _allUnits.Count > 1 ? _allUnits[1] : null;
            RefreshFromUnits();
            RefreshToUnits();
        }

        // Executes unit conversion based on current input and selections.
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
        #endregion


        #region INotifyPropertyChanged
        // INotifyPropertyChanged helper for updating bound properties.
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<t>(ref t storage, t value, [CallerMemberName] string prop = "")
        {
            if (Equals(storage, value)) return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            return true;
        }
        #endregion
    }

    // Wrapper for unit metadata to be bound in the UI.
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
