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
                if (!ConversionData.lengthUnits.TryGetValue(From, out decimal fromFactor) ||
                    !ConversionData.lengthUnits.TryGetValue(To, out decimal toFactor))
                    throw new InvalidOperationException("Invalid conversion units.");

                return (Input * fromFactor) / toFactor;
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
                if (!ConversionData.weightUnits.TryGetValue(From, out decimal fromFactor) ||
                    !ConversionData.weightUnits.TryGetValue(To, out decimal toFactor))
                    throw new InvalidOperationException("Invalid conversion units");
                return (Input * fromFactor) / toFactor;
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
                if (!ConversionData.volumeUnits.TryGetValue(From, out decimal fromFactor) ||
                    !ConversionData.volumeUnits.TryGetValue(To, out decimal toFactor))
                    throw new InvalidOperationException("Invalid conversion units.");

                return (Input * fromFactor) / toFactor;
            }
        }

        public static class ConversionData
        {
            public static readonly Dictionary<VolumeUnit, decimal> volumeUnits = new()
            {
                { VolumeUnit.Milliliters, 1.0m },
                { VolumeUnit.CubicCentimeters, 1.0m / 1.0m },
                { VolumeUnit.Liters, 1.0m / 1000m },
                { VolumeUnit.CubicMeters, 1.0m / 1_000_000m},
                { VolumeUnit.Teaspoons, 1.0m / 4.9289192708m },
                { VolumeUnit.FluidOunces, 1.0m / 29.573515625m },
                { VolumeUnit.Cups, 1.0m / 236.588125m },
                { VolumeUnit.Pints, 1.0m / 473.17625m },
                { VolumeUnit.Quarts, 1.0m / 946.3525m },
                { VolumeUnit.Gallons, 1.0m / 3785.41m },
                { VolumeUnit.CubicInches, 1.0m / 16.387064m },
                { VolumeUnit.CubicFeet, 1.0m / 28316.846592m },
                { VolumeUnit.CubicYards, 1.0m / 764_554.85798m }
            };

            public static readonly Dictionary<LengthUnit, decimal> lengthUnits = new()
            {
                { LengthUnit.Millimeters, 1.0m },
                { LengthUnit.Angstroms, 1.0m / 0.0000001m },
                { LengthUnit.Nanometers, 1.0m / 0.000001m },
                { LengthUnit.Microns, 1.0m / 0.001m},
                { LengthUnit.Centimeters, 1.0m / 10m },
                { LengthUnit.Meters, 1.0m / 1000m },
                { LengthUnit.Kilometers, 1.0m / 1_000_000m },
                { LengthUnit.Inches, 1.0m / 25.4m },
                { LengthUnit.Feet, 1.0m / 304.8m },
                { LengthUnit.Yards, 1.0m / 914.4m },
                { LengthUnit.Miles, 1.0m / 1_609_344m },
                { LengthUnit.NauticalMiles, 1.0m / 1_852_000m }
            };

            public static readonly Dictionary<WeightUnit, decimal> weightUnits = new()
            {
                { WeightUnit.Grams, 1.0m },
                { WeightUnit.Carats, 1.0m / 0.200000m },
                { WeightUnit.Milligrams, 1.0m / 0.001000m },
                { WeightUnit.Centigrams, 1.0m / 0.010000m},
                { WeightUnit.Decigrams, 1.0m / 0.100000m },
                { WeightUnit.Dekagrams, 1.0m / 10.000000m },
                { WeightUnit.Hectograms, 1.0m / 100.000000m },
                { WeightUnit.Kilograms, 1.0m / 1000.000000m },
                { WeightUnit.MetricTonnes, 1.0m / 1000000.000000m },
                { WeightUnit.Ounces, 1.0m / 28.349523125m },
                { WeightUnit.Pounds, 1.0m / 453.59237m },
                { WeightUnit.Stone, 1.0m / 6350.293000m },
                { WeightUnit.ShortTons, 1.0m / 907184.740000m },
                { WeightUnit.LongTons, 1.0m / 1016046.9088m }
            };
        }

        public enum WeightUnit
        {
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
