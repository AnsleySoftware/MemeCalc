namespace MemeCalcBackEnd
{
    public class UnitConverter
    {
        public class LengthUnitConverter
        {
            public decimal Input { get; set; }
            public LengthUnit From { get; set; }
            public LengthUnit To { get; set; }
            public LengthUnitConverter(decimal input, LengthUnit from, LengthUnit to)
            {
                Input = input;
                From = from;
                To = to;
            }
            public decimal Convert()
            {
                if (!ConversionData.lengthUnits.TryGetValue(From, out var fromFactor) ||
                    !ConversionData.lengthUnits.TryGetValue(To, out var toFactor))
                    throw new InvalidOperationException("Invalid conversion units.");

                return (Input * fromFactor.Ratio) / toFactor.Ratio;
            }

        }

        public class WeightUnitConverter
        {
            public decimal Input { get; set; }
            public WeightUnit From { get; set; }
            public WeightUnit To { get; set; }
            public WeightUnitConverter(decimal input, WeightUnit from, WeightUnit to)
            {
                Input = input;
                From = from;
                To = to;
            }
            public decimal Convert()
            {
                if (!ConversionData.weightUnits.TryGetValue(From, out var fromFactor) ||
                    !ConversionData.weightUnits.TryGetValue(To, out var toFactor))
                    throw new InvalidOperationException("Invalid conversion units");
                return (Input * fromFactor.Ratio) / toFactor.Ratio;
            }
        }

        public class VolumeUnitConverter
        {
            public decimal Input { get; set; }
            public VolumeUnit From { get; set; }
            public VolumeUnit To { get; set; }

            public VolumeUnitConverter(decimal input, VolumeUnit from, VolumeUnit to)
            {
                Input = input;
                From = from;
                To = to;
            }

            public decimal Convert()
            {
                if (!ConversionData.volumeUnits.TryGetValue(From, out var fromFactor) ||
                    !ConversionData.volumeUnits.TryGetValue(To, out var toFactor))
                    throw new InvalidOperationException("Invalid conversion units.");

                return (Input * fromFactor.Ratio) / toFactor.Ratio;
            }
        }

        public static class ConversionData
        {
            public static readonly Dictionary<VolumeUnit, UnitClass> volumeUnits = new()
            {
                { VolumeUnit.Milliliters, new UnitClass("Milliliters", 1.0m) },
                { VolumeUnit.CubicCentimeters, new UnitClass("Cubic Centimeters", 1.0m) },
                { VolumeUnit.Liters, new UnitClass("Liters", 1000m) },
                { VolumeUnit.CubicMeters, new UnitClass("Cubic Meters", 1_000_000m)},
                { VolumeUnit.Teaspoons, new UnitClass("Teaspoons", 4.9289192708m) },
                { VolumeUnit.FluidOunces, new UnitClass("Fluid Ounces", 29.573515625m) },
                { VolumeUnit.Cups, new UnitClass("Cups", 236.588125m) },
                { VolumeUnit.Pints, new UnitClass("Pints", 473.17625m) },
                { VolumeUnit.Quarts, new UnitClass("Quarts", 946.3525m) },
                { VolumeUnit.Gallons, new UnitClass("Gallons", 3785.41m) },
                { VolumeUnit.CubicInches, new UnitClass("Cubic Inches", 16.387064m) },
                { VolumeUnit.CubicFeet, new UnitClass("Cubic Feet", 28316.846592m) },
                { VolumeUnit.CubicYards, new UnitClass("Cubic Yards", 764_554.85798m) },
                { VolumeUnit.AdultHumans, new UnitClass("Adult Human Bodies", 42_000m) },
                { VolumeUnit.DirtyDiapers, new UnitClass("Dirty Diapers", 105m, "Icons/diaper.png") }
            };

            public static readonly Dictionary<LengthUnit, UnitClass> lengthUnits = new()
            {
                { LengthUnit.Millimeters, new UnitClass("Millimeters", 1.0m) },
                { LengthUnit.Angstroms, new UnitClass("Angstroms", 0.0000001m) },
                { LengthUnit.Nanometers, new UnitClass("Nanometers", 0.000001m) },
                { LengthUnit.Microns, new UnitClass("Microns", 0.001m)},
                { LengthUnit.Centimeters, new UnitClass("Centimeters", 10m) },
                { LengthUnit.Meters, new UnitClass("Meters", 1000m) },
                { LengthUnit.Kilometers, new UnitClass("Kilomters", 1_000_000m) },
                { LengthUnit.Inches, new UnitClass("Inches", 25.4m) },
                { LengthUnit.Feet, new UnitClass("Feet", 304.8m) },
                { LengthUnit.Yards, new UnitClass("Yards", 914.4m) },
                { LengthUnit.Miles, new UnitClass("Miles", 1_609_344m) },
                { LengthUnit.NauticalMiles, new UnitClass("Nautical Miles", 1_852_000m) },
                { LengthUnit.Bananas, new UnitClass("Bananas", 175m, "Icons/banana.png") },
                { LengthUnit.FootballFields, new UnitClass("Football Fields", 109_728m, "Icons/footballfield.png") }
            };

            public static readonly Dictionary<WeightUnit, UnitClass> weightUnits = new()
            {
                { WeightUnit.Grams, new UnitClass("Grams", 1.0m) },
                { WeightUnit.Carats, new UnitClass("Carats", 0.200000m) },
                { WeightUnit.Milligrams, new UnitClass("Milligrams", 0.001000m) },
                { WeightUnit.Centigrams, new UnitClass("Centigrams", 0.010000m)},
                { WeightUnit.Decigrams, new UnitClass("Decigrams", 0.100000m) },
                { WeightUnit.Dekagrams, new UnitClass("Dekagrams", 10.000000m) },
                { WeightUnit.Hectograms, new UnitClass("Hectograms", 100.000000m) },
                { WeightUnit.Kilograms, new UnitClass("Kilograms", 1000.000000m) },
                { WeightUnit.MetricTonnes, new UnitClass("Metric Tonnes", 1000000.000000m) },
                { WeightUnit.Ounces, new UnitClass("Ounces", 28.349523125m) },
                { WeightUnit.Pounds, new UnitClass("Pounds", 453.59237m) },
                { WeightUnit.Stone, new UnitClass("Stones", 6350.293000m) },
                { WeightUnit.ShortTons, new UnitClass("Short Tons", 907184.740000m) },
                { WeightUnit.LongTons, new UnitClass("Long Tons", 1016046.9088m) },
                { WeightUnit.Penguins, new UnitClass("Penguins", 34000m, "Icons/penguin.png") },
                { WeightUnit.JumboJets, new UnitClass("Jumbo Jets", 50_000_000m, "Icons/airplane.png") }
            };
        }

        public enum WeightUnit
        {
            JumboJets,
            Penguins,
            Grams,
            Carats,
            Milligrams,
            Centigrams,
            Decigrams,
            Dekagrams,
            Hectograms,
            Kilograms,
            MetricTonnes,
            Ounces,
            Pounds,
            Stone,
            ShortTons,
            LongTons
        }

        public enum LengthUnit
        {
            Bananas,
            FootballFields,
            Millimeters,
            Angstroms,
            Nanometers,
            Microns,
            Centimeters,
            Meters,
            Kilometers,
            Inches,
            Feet,
            Yards,
            Miles,
            NauticalMiles
        }

        public enum VolumeUnit
        {
            AdultHumans,
            DirtyDiapers,
            Milliliters,
            CubicCentimeters,
            Liters,
            CubicMeters,
            Teaspoons,
            FluidOunces,
            Cups,
            Pints,
            Quarts,
            Gallons,
            CubicInches,
            CubicFeet,
            CubicYards
        }
    }
}
