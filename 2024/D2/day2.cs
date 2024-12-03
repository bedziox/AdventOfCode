namespace AdventOfCode._2024
{
    public sealed class Day2
    {
        List<List<int>> reports = new();
        public Day2()
        {
            int count = 0;
            string[] lines = File.ReadAllLines("D:\\Dev\\AdventOfCode\\2024\\D2\\input.txt");
            foreach (var line in lines)
            {
                List<int> report = line.Split(" ").Select(Int32.Parse).ToList();
                reports.Add(report);
                count++;
            }
            Console.WriteLine($"Processed {count} lines");
            // Part 1
            Console.WriteLine($"Safe reports: {safeReports()}");
            // Part 2
            Console.WriteLine($"Safe reports with damp: {safeReportsWithDampening()}");
        }

        private int safeReports()
        {
            int safeReports = 0;
            foreach (var report in reports)
            {
                if (IsSafe(report))
                    safeReports++;
            }
            return safeReports;
        }
        private int safeReportsWithDampening()
        {
            int safeReports = 0;
            foreach (var report in reports)
            {
                if (IsSafe(report))
                    safeReports++;
                else
                {
                    for (int i = 0; i < report.Count; i++)
                    {
                        var modifiedReport = report.Where((item, index) => index != i).ToList();
                        if (IsSafe(modifiedReport))
                        {
                            safeReports++;
                            break;
                        }
                    }
                }
            }
            return safeReports;
        }
        private bool IsSafe(List<int> report)
        {
            bool isDesc = report[0] > report[1];
            for (int i = 0; i < report.Count - 1; i++)
            {
                bool diffCorrect = Math.Abs(report[i] - report[i + 1]) <= 3 && Math.Abs(report[i] - report[i + 1]) >= 1;
                bool orderMaintained = isDesc ? report[i] >= report[i + 1] : report[i] <= report[i + 1];
                if (!diffCorrect || !orderMaintained)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
