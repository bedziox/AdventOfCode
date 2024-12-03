using System.Text.RegularExpressions;

namespace AdventOfCode._2024
{
    public sealed class Day3
    {
        public Day3()
        {
            string input = File.ReadAllText("D:\\Dev\\AdventOfCode\\2024\\D3\\input.txt");
            var result = parseInputBasic(input);
            // part 1
            Console.WriteLine($"Result of addition: {result}");
            // part 2
            var result2 = pasreInputWithEnabling(input);
            Console.WriteLine($"Result of addition: {result2}");
        }

        public int parseInputBasic(string input)
        {
            int result = 0;
            Regex regex = new Regex(@"mul\([0-9]{1,3},[0-9]{1,3}\)");
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                result += parseMultiplication(match.Value);
            }

            return result;
        }

        public int pasreInputWithEnabling(string input)
        {
            int result = 0;
            Regex regex = new Regex(@"don't\(\)|do\(\)|mul\([0-9]{1,3},[0-9]{1,3}\)");
            MatchCollection matches = regex.Matches(input);
            bool isEnabled = true;
            foreach (Match match in matches)
            {
                if (match.Value.ToString() == "don't()")
                {
                    isEnabled = false;
                    continue;
                }
                else if (match.Value.ToString() == "do()")
                {
                    isEnabled = true;
                    continue;
                }
                result += parseMultiplicationWithEnabling(match.Value, isEnabled);
            }
            return result;
        }

        public int parseMultiplication(string input)
        {
            // Input is in form mul(a,b)
            var values = input.Replace("mul(", "").Replace(")", "").Split(",");
            return Int32.Parse(values[0]) * Int32.Parse(values[1]);
        }
        public int parseMultiplicationWithEnabling(string input, bool isEnabled)
        {
            if (!isEnabled)
                return 0;
            Regex regex = new Regex(@"mul\([0-9]{1,3},[0-9]{1,3}\)");
            var match = regex.Match(input);
            if (match.Success)
            {
                return parseMultiplication(match.Value);
            }
            return 0;
        }
    }
}
