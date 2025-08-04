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
                { VolumeUnit.CubicCentimeters,  1.0m },
                { VolumeUnit.Liters, 1000m },
                { VolumeUnit.CubicMeters, 1_000_000m},
                { VolumeUnit.Teaspoons, 4.9289192708m },
                { VolumeUnit.FluidOunces, 29.573515625m },
                { VolumeUnit.Cups, 236.588125m },
                { VolumeUnit.Pints, 473.17625m },
                { VolumeUnit.Quarts, 946.3525m },
                { VolumeUnit.Gallons, 3785.41m },
                { VolumeUnit.CubicInches, 16.387064m },
                { VolumeUnit.CubicFeet, 28316.846592m },
                { VolumeUnit.CubicYards, 764_554.85798m },
                { VolumeUnit.Adult_Humans, 42_000 }
            };

            public static readonly Dictionary<LengthUnit, decimal> lengthUnits = new()
            {
                { LengthUnit.Millimeters, 1.0m },
                { LengthUnit.Angstroms, 0.0000001m },
                { LengthUnit.Nanometers, 0.000001m },
                { LengthUnit.Microns, 0.001m},
                { LengthUnit.Centimeters, 10m },
                { LengthUnit.Meters, 1000m },
                { LengthUnit.Kilometers, 1_000_000m },
                { LengthUnit.Inches, 25.4m },
                { LengthUnit.Feet, 304.8m },
                { LengthUnit.Yards, 914.4m },
                { LengthUnit.Miles, 1_609_344m },
                { LengthUnit.NauticalMiles, 1_852_000m },
                { LengthUnit.Bananas, 175m },
                { LengthUnit.FootballFields, 109_728m }
            };

            public static readonly Dictionary<WeightUnit, decimal> weightUnits = new()
            {
                { WeightUnit.Grams, 1.0m },
                { WeightUnit.Carats, 0.200000m },
                { WeightUnit.Milligrams, 0.001000m },
                { WeightUnit.Centigrams, 0.010000m},
                { WeightUnit.Decigrams, 0.100000m },
                { WeightUnit.Dekagrams, 10.000000m },
                { WeightUnit.Hectograms, 100.000000m },
                { WeightUnit.Kilograms, 1000.000000m },
                { WeightUnit.MetricTonnes, 1000000.000000m },
                { WeightUnit.Ounces, 28.349523125m },
                { WeightUnit.Pounds, 453.59237m },
                { WeightUnit.Stone, 6350.293000m },
                { WeightUnit.ShortTons, 907184.740000m },
                { WeightUnit.LongTons, 1016046.9088m },
                { WeightUnit.Penguins, 34000m },
                { WeightUnit.JumboJets, 50_000_000m }
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
            LongTons,
            Penguins,
            JumboJets
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
            NauticalMiles,
            Bananas,
            FootballFields
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
            CubicYards,
            Adult_Humans
        }
    }
}
