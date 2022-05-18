namespace TalkingClock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Objective 1
            Console.WriteLine(DateTime.Now.ToHumanFriendlyTime());

            // Objective 2

            while (true)
            {
                var input = Console.ReadLine();
                var split = input.Split(':');

                if (split.Length > 1 &&
                    int.TryParse(split[0], out var hours) &&
                    hours.ValidHours() &&
                    int.TryParse(split[1], out var minutes) &&
                    minutes.ValidMinutes())
                {
                    Console.WriteLine(new DateTime(1, 1, 1, hours, minutes, 0).ToHumanFriendlyTime());
                }
                else if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid time detected - please try again in the format 'HH:mm' with values that are valid using a clock representing a time on Earth.");
                }
            }
        }
    }
}