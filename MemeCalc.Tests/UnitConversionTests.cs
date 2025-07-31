using static MemeCalc.Tests.UnitConversionTests;

namespace MemeCalc.Tests
{
    public class UnitConversionTests
    {
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
        static readonly Dictionary<WeightUnit, decimal> weightUnits = new()
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
        
        [Theory]
        [InlineData(5.0, WeightUnit.Pounds, WeightUnit.Ounces, 80.0)]
        [InlineData(6.0, WeightUnit.ShortTons, WeightUnit.LongTons, 5.357143)]
        [InlineData(3.0, WeightUnit.Decigrams, WeightUnit.Ounces, 0.010582)]
        [InlineData(20.0, WeightUnit.Pounds, WeightUnit.Stone, 1.428571)]
        public void WeightConversion_ProducesCorrectResult(decimal input, WeightUnit from, WeightUnit to, decimal expected)
        {
            decimal actual = Convert(input, from, to);
            decimal rounded = Math.Round(actual, 6);
            Assert.Equal(expected, rounded);
        }

        public decimal Convert(decimal value, WeightUnit from, WeightUnit to)
        {
            var fromFactor = weightUnits[from];
            var toFactor = weightUnits[to];
            return (value / fromFactor) * toFactor;
        }
    }

    public class LengthConversionTests
    {
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

        static readonly Dictionary<LengthUnit, decimal> lengthUnits = new()
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

        [Theory]
        [InlineData(5.0, LengthUnit.Feet, LengthUnit.Angstroms, 15_240_000_000)]
        [InlineData(6.0, LengthUnit.Meters, LengthUnit.NauticalMiles, 0.00324)]
        [InlineData(3.0, LengthUnit.Yards, LengthUnit.Centimeters, 274.32)]
        [InlineData(20.0, LengthUnit.Inches, LengthUnit.Microns, 508_000)]
        public void LengthConversion_ProducesCorrectResult(decimal input, LengthUnit from, LengthUnit to, decimal expected)
        {
            decimal actual = Convert(input, from, to);
            decimal rounded = Math.Round(actual, 6);
            Assert.Equal(expected, rounded);
        }

        public decimal Convert(decimal value, LengthUnit from, LengthUnit to)
        {
            var fromFactor = lengthUnits[from];
            var toFactor = lengthUnits[to];
            return (value / fromFactor) * toFactor;
        }
    }

    public class VolumeConversionTests
    {
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

        static readonly Dictionary<VolumeUnit, decimal> volumeUnits = new()
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

        [Theory]
        [InlineData(5.0, VolumeUnit.CubicYards, VolumeUnit.CubicMeters, 3.822774)]
        [InlineData(6.0, VolumeUnit.Quarts, VolumeUnit.Liters, 5.678115)]
        [InlineData(3.0, VolumeUnit.CubicYards, VolumeUnit.Gallons, 605.922363)]
        [InlineData(20.0, VolumeUnit.CubicInches, VolumeUnit.Pints, 0.692641)]
        public void VolumeConversion_ProducesCorrectResult(decimal input, VolumeUnit from, VolumeUnit to, decimal expected)
        {
            decimal actual = Convert(input, from, to);
            decimal rounded = Math.Round(actual, 6);
            Assert.Equal(expected, rounded);
        }

        public decimal Convert(decimal value, VolumeUnit from, VolumeUnit to)
        {
            var fromFactor = volumeUnits[from];
            var toFactor = volumeUnits[to];
            return (value / fromFactor) * toFactor;
        }
    }
}