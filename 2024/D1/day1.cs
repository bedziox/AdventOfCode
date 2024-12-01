namespace AdventOfCode._2024
{
    public class Day1
    {
        List<int> left = new();
        List<int> right = new();

        public Day1()
        {
            // Part 1
            int count = 0;
            string[] lines = File.ReadAllLines("D:\\Dev\\AdventOfCode\\2024\\D1\\input.txt");
            foreach (var line in lines)
            {
                string[] fields = line.Split("   ");
                left.Add(int.Parse(fields[0]));
                right.Add(int.Parse(fields[1]));
                count++;
            }
            Console.WriteLine($"Processed {count} lines");
            left.Sort();
            right.Sort();
            Console.WriteLine("Total distance: " + calculateDistance());
            //Part 2
            Console.WriteLine("Total similarity: " + calculateSimilarity());
        }

        private int calculateDistance()
        {
            int distance = left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
            return distance;
        }
        private int calculateSimilarity()
        {
            int similarity = 0;
            var frequencyRight = right.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            foreach (var value in left)
            {
                if (frequencyRight.ContainsKey(value))
                {
                    similarity += value * frequencyRight[value];
                }
            }
            return similarity;
        }
    }
}
