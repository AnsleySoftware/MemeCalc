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
                { VolumeUnit.Milliliters, new UnitClass("Milliliters", 1.0m, "Icons/beaker.png") },
                { VolumeUnit.CubicCentimeters, new UnitClass("Cubic Centimeters", 1.0m, "Icons/beaker.png") },
                { VolumeUnit.Liters, new UnitClass("Liters", 1000m, "Icons/beaker.png") },
                { VolumeUnit.CubicMeters, new UnitClass("Cubic Meters", 1_000_000m, "Icons/beaker.png")},
                { VolumeUnit.Teaspoons, new UnitClass("Teaspoons", 4.9289192708m, "Icons/beaker.png") },
                { VolumeUnit.FluidOunces, new UnitClass("Fluid Ounces", 29.573515625m, "Icons/beaker.png") },
                { VolumeUnit.Cups, new UnitClass("Cups", 236.588125m, "Icons/beaker.png") },
                { VolumeUnit.Pints, new UnitClass("Pints", 473.17625m, "Icons/beaker.png") },
                { VolumeUnit.Quarts, new UnitClass("Quarts", 946.3525m, "Icons/beaker.png") },
                { VolumeUnit.Gallons, new UnitClass("Gallons", 3785.41m, "Icons/beaker.png") },
                { VolumeUnit.CubicInches, new UnitClass("Cubic Inches", 16.387064m, "Icons/beaker.png") },
                { VolumeUnit.CubicFeet, new UnitClass("Cubic Feet", 28316.846592m, "Icons/beaker.png") },
                { VolumeUnit.CubicYards, new UnitClass("Cubic Yards", 764_554.85798m, "Icons/beaker.png") },
                { VolumeUnit.AdultHumans, new UnitClass("Adult Human Bodies", 42_000m, "Icons/adultBody.png") },
                { VolumeUnit.DirtyDiapers, new UnitClass("Dirty Diapers", 105m, "Icons/diaper.png") },
                { VolumeUnit.KFCBuckets, new UnitClass("Family Chicken Buckets", 5000m, "Icons/chickenBucket.png") },
                { VolumeUnit.PortaPotties, new UnitClass("Porta Potties", 227_100m, "Icons/portapottie.png") },
                { VolumeUnit.BeerKegs, new UnitClass("Beer Kegs", 58_700, "Icons/beerKeg.png") },
                { VolumeUnit.KetchupPackets, new UnitClass("Ketchup Packets", 9m, "Icons/ketchup.png") },
                { VolumeUnit.Bathtubs, new UnitClass("Bath Tubs", 302_800, "Icons/bathtub.png") },
                { VolumeUnit.OlympicPools, new UnitClass("Olympic Swimming Pools", 2_500_000_000m, "Icons/swimmingPool.png") },
                { VolumeUnit.ShotGlasses, new UnitClass("Shot Glasses", 44m, "Icons/tumblerGlass.png") },
                { VolumeUnit.LargeMilkshakes, new UnitClass("Large Milkshakes", 650m, "Icons/milkshake.png") }
            };

            public static readonly Dictionary<LengthUnit, UnitClass> lengthUnits = new()
            {
                { LengthUnit.Millimeters, new UnitClass("Millimeters", 1.0m, "Icons/ruler.png") },
                { LengthUnit.Angstroms, new UnitClass("Angstroms", 0.0000001m, "Icons/ruler.png") },
                { LengthUnit.Nanometers, new UnitClass("Nanometers", 0.000001m, "Icons/ruler.png") },
                { LengthUnit.Microns, new UnitClass("Microns", 0.001m, "Icons/ruler.png")},
                { LengthUnit.Centimeters, new UnitClass("Centimeters", 10m, "Icons/ruler.png") },
                { LengthUnit.Meters, new UnitClass("Meters", 1000m, "Icons/ruler.png") },
                { LengthUnit.Kilometers, new UnitClass("Kilomters", 1_000_000m, "Icons/ruler.png") },
                { LengthUnit.Inches, new UnitClass("Inches", 25.4m, "Icons/ruler.png") },
                { LengthUnit.Feet, new UnitClass("Feet", 304.8m, "Icons/ruler.png") },
                { LengthUnit.Yards, new UnitClass("Yards", 914.4m, "Icons/ruler.png") },
                { LengthUnit.Miles, new UnitClass("Miles", 1_609_344m, "Icons/ruler.png") },
                { LengthUnit.NauticalMiles, new UnitClass("Nautical Miles", 1_852_000m, "Icons/ruler.png") },
                { LengthUnit.Bananas, new UnitClass("Bananas", 175m, "Icons/banana.png") },
                { LengthUnit.FootballFields, new UnitClass("Football Fields", 109_728m, "Icons/footballfield.png") },
                { LengthUnit.F150s, new UnitClass("Ford F150s", 5882.64m, "Icons/pickupTruck.png") },
                { LengthUnit.AircraftCarriers, new UnitClass("Aircraft Carriers", 342_290.4m, "Icons/aircraftCarrier.png") },
                { LengthUnit.SchoolBuses, new UnitClass("School Buses", 10670, "Icons/schoolBus.png") },
                { LengthUnit.ParkingSpots, new UnitClass("Parking Spots", 5480m, "Icons/parkingSpot.png") },
                { LengthUnit.TRexes, new UnitClass("T-Rexes", 12_200m, "Icons/tRex.png") },
                { LengthUnit.SubwayFootlongs, new UnitClass("Subway FootLongs", 280m, "Icons/sub.png") },
                { LengthUnit.HotDogs, new UnitClass("Hot Dogs", 150m, "Icons/hotdog.png") },
                { LengthUnit.GreatWalls, new UnitClass("Great Walls of China", 21196000000m, "Icons/greatWall.png") },
                { LengthUnit.EmpireStateBuildings, new UnitClass("Empire State Buildings", 381000m, "Icons/skyScraper.png") }
            };

            public static readonly Dictionary<WeightUnit, UnitClass> weightUnits = new()
            {
                { WeightUnit.Grams, new UnitClass("Grams", 1.0m, "Icons/scale.png") },
                { WeightUnit.Carats, new UnitClass("Carats", 0.200000m, "Icons/scale.png") },
                { WeightUnit.Milligrams, new UnitClass("Milligrams", 0.001000m, "Icons/scale.png") },
                { WeightUnit.Centigrams, new UnitClass("Centigrams", 0.010000m, "Icons/scale.png")},
                { WeightUnit.Decigrams, new UnitClass("Decigrams", 0.100000m, "Icons/scale.png") },
                { WeightUnit.Dekagrams, new UnitClass("Dekagrams", 10.000000m, "Icons/scale.png") },
                { WeightUnit.Hectograms, new UnitClass("Hectograms", 100.000000m, "Icons/scale.png") },
                { WeightUnit.Kilograms, new UnitClass("Kilograms", 1000.000000m, "Icons/scale.png") },
                { WeightUnit.MetricTonnes, new UnitClass("Metric Tonnes", 1000000.000000m, "Icons/scale.png") },
                { WeightUnit.Ounces, new UnitClass("Ounces", 28.349523125m, "Icons/scale.png") },
                { WeightUnit.Pounds, new UnitClass("Pounds", 453.59237m, "Icons/scale.png") },
                { WeightUnit.Stone, new UnitClass("Stones", 6350.293000m, "Icons/scale.png") },
                { WeightUnit.ShortTons, new UnitClass("Short Tons", 907184.740000m, "Icons/scale.png") },
                { WeightUnit.LongTons, new UnitClass("Long Tons", 1016046.9088m, "Icons/scale.png") },
                { WeightUnit.Penguins, new UnitClass("Penguins", 34000m, "Icons/penguin.png") },
                { WeightUnit.JumboJets, new UnitClass("Jumbo Jets", 50_000_000m, "Icons/airplane.png") },
                { WeightUnit.F150s, new UnitClass("Ford F150s", 2_267_960, "Icons/pickupTruck.png") },
                { WeightUnit.AircraftCarriers, new UnitClass("Aircraft Carriers", 96_300_847_462m, "Icons/aircraftCarrier.png") },
                { WeightUnit.LabradorRetrievers, new UnitClass("Labrador Retrievers", 29_500m, "Icons/dog.png") },
                { WeightUnit.Marshmallows, new UnitClass("Marshmallows", 7m, "Icons/marshmallow.png") },
                { WeightUnit.Sofas, new UnitClass("Sofas", 136_000m, "Icons/sofa.png") },
                { WeightUnit.MoonLanders, new UnitClass("Moon Landers", 15_200_000m, "Icons/moonlander.png") },
                { WeightUnit.Paperclips, new UnitClass("Paper Clips", 1m, "Icons/paperclip.png") },
                { WeightUnit.BigMacs, new UnitClass("Big Macs", 240m, "Icons/cheeseburger.png") },
                
            };
        }

        public enum WeightUnit
        {
            LabradorRetrievers,
            Marshmallows,
            Sofas,
            MoonLanders,
            Paperclips,
            BigMacs,
            JumboJets,
            F150s,
            AircraftCarriers,
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
            SchoolBuses,
            ParkingSpots,
            TRexes,
            SubwayFootlongs,
            HotDogs,
            GreatWalls,
            EmpireStateBuildings,
            F150s,
            AircraftCarriers,
            Bananas,
            FootballFields,
            DNAHelix,
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
            KFCBuckets,
            PortaPotties,
            BeerKegs,
            KetchupPackets,
            Bathtubs,
            OlympicPools,
            ShotGlasses,
            LargeMilkshakes,
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
