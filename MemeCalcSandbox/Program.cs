using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Diagnostics;

namespace SandBoxApp
{
    enum WeightUnit
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

    class Program
    {

        static readonly Dictionary<WeightUnit, double> weightUnits = new()
        {
            { WeightUnit.Grams, 1.0 },
            { WeightUnit.Carats, 1.0 / 0.2 },
            { WeightUnit.Milligrams, 1.0 / 0.001 },
            { WeightUnit.Centigrams, 1.0 / 0.01},
            { WeightUnit.Decigrams, 1.0 / 0.1 },
            { WeightUnit.Dekagrams, 1.0 / 10 },
            { WeightUnit.Hectograms, 1.0 / 100 },
            { WeightUnit.Kilograms, 1.0 / 1000 },
            { WeightUnit.MetricTonnes, 1.0 / 1000000 },
            { WeightUnit.Ounces, 1.0 / 28.3495 },
            { WeightUnit.Pounds, 1.0 / 453.592 },
            { WeightUnit.Stone, 1.0 / 6350.29 },
            { WeightUnit.ShortTons, 1.0 / 907184.74 },
            { WeightUnit.LongTons, 1.0 / 1016046.91 }
        };

        static void Main()
        {
            double grams = weightUnits[WeightUnit.Grams];
            double result = ConvertWeight(grams, WeightUnit.Dekagrams, WeightUnit.Kilograms, 5);
            Debug.WriteLine($"Dekagrams to kilograms: {result}");
        }
        static double ConvertWeight(double value, WeightUnit from, WeightUnit to, double numberOf)
        {
            double baseVal = value / weightUnits[from];
            double newVal = baseVal * weightUnits[to];
            return newVal * numberOf;
        }

    }
}





