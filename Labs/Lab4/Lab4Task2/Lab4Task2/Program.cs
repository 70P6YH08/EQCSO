
int[] firstSetTemps = [20, 21, 20, 22, 21, 20, 21, 22, 20, 21, 20, 22];
int[] secondSetTemps = [20, 21, 20, 22, 21, 29, 21, 22, 20, 21, 20, 22];

Dictionary<int, int[]> sets = new()
{
    { 1 , firstSetTemps },
    { 2 , secondSetTemps }
};

static void GalculateDeviations(Dictionary<int, int[]> sets)
{
    foreach (var set in sets)
    {
        var setValues = set.Value;
        var n = setValues.Length;

        double sumForStandDev = 0;
        double sumForEndAvgDev = 0;

        double avgDev = Math.Round(setValues.Average(), 2);

        for (int i = 0; i < n; i++)
            sumForStandDev += Math.Pow((setValues[i] - avgDev), 2);

        double standDev = Math.Round(Math.Sqrt(sumForStandDev / n), 2);

        double doubleStandDev = 2 * standDev;

        int emissionsCount = 0;

        for (int i = 0; i < n; i++)
        {
            if (Math.Abs(setValues[i] - avgDev) > doubleStandDev)
            {
                emissionsCount++;
                continue;
            }
            sumForEndAvgDev += setValues[i];
        }

        double endAvgDev = Math.Round(sumForEndAvgDev / (n - emissionsCount), 2);

        Console.WriteLine($"Набор {set.Key}:\n" +
            $"\t- среднее изначальное отклонение: {avgDev}\n" +
            $"\t- стандартное отклонение: {standDev}\n" +
            $"\t- среднее конечное отклонение:{endAvgDev}");
        Console.WriteLine();
    }
}

static void GetAvgTemp(Dictionary<int, int[]> sets)
{
    foreach (var set in sets)
    {
        double sumForAvg = 0;
        var setValues = set.Value;

        var n = setValues.Length;

        int emissionsCount = 0;

        for (int i = 0; i < n; i++)
        {
            if (setValues[i] < 15 && setValues[i] > 30)
            {
                emissionsCount++;
                continue;
            }
            sumForAvg += setValues[i];
        }

        Console.WriteLine($"Набор {set.Key}:\n" +
            $"\t- среднее значение:  {Math.Round(sumForAvg / (n - emissionsCount), 2)}");
    }
}

GalculateDeviations(sets);

GetAvgTemp(sets);