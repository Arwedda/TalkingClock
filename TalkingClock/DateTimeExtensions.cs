using System.Text;

namespace TalkingClock
{
    public static class DateTimeExtensions
    {
        public static string ToHumanFriendlyTime(this DateTime dateTime)
        {
            var relationalWord = CalculateRelationalWord(dateTime.Minute);
            var minutes = MinuteConverter(dateTime.Minute);
            var hours = HourConverter(relationalWord, dateTime.Hour);

            return ConstructedFriendlyString(dateTime, relationalWord, minutes, hours);
        }

        private static string ConstructedFriendlyString(DateTime dateTime, string relationalWord, string minutes, string hours)
        {
            StringBuilder sb = new($"{dateTime.Hour.ToString("D2")}:{dateTime.Minute.ToString("D2")} ");

            if (relationalWord.Contains('\''))
            {
                sb.Append($"{hours} {relationalWord}");
            }
            else
            {
                sb.Append($"{minutes} {relationalWord} {hours.ToLowerInvariant()}");
            }

            return sb.ToString();
        }

        private static string HourConverter(string relationalWord, int hour)
        {
            if (string.Equals(relationalWord, "to", StringComparison.OrdinalIgnoreCase))
            {
                // Could loop back to 0 if it reaches 24, but since this data isn't used anymore we can just add a third "twelve" case
                hour++; 
            }

            switch (hour)
            {
                case 0:
                case 12:
                case 24:
                    return "Twelve";
                case 1:
                case 13:
                    return "One";
                case 2:
                case 14:
                    return "Two";
                case 3:
                case 15:
                    return "Three";
                case 4:
                case 16:
                    return "Four";
                case 5:
                case 17:
                    return "Five";
                case 6:
                case 18:
                    return "Six";
                case 7:
                case 19:
                    return "Seven";
                case 8:
                case 20:
                    return "Eight";
                case 9:
                case 21:
                    return "Nine";
                case 10:
                case 22:
                    return "Ten";
                case 11:
                case 23:
                    return "Eleven";
                default:
                    return "Is an invalid time";
            }
        }

        private static string CalculateRelationalWord(int minute)
        {
            if (minute == 0)
            {
                return "o'clock";
            }
            else if (minute < 31)
            {
                return $"past";
            }
            else
            {
                return $"to";
            }
        }

        private static string MinuteConverter(int minute)
        {
            switch (minute)
            {
                case 0:
                    return "";
                case 1:
                case 59:
                    return "One";
                case 2:
                case 58:
                    return "Two";
                case 3:
                case 57:
                    return "Three";
                case 4:
                case 56:
                    return "Four";
                case 5:
                case 55:
                    return "Five";
                case 6:
                case 54:
                    return "Six";
                case 7:
                case 53:
                    return "Seven";
                case 8:
                case 52:
                    return "Eight";
                case 9:
                case 51:
                    return "Nine";
                case 10:
                case 50:
                    return "Ten";
                case 11:
                case 49:
                    return "Eleven";
                case 12:
                case 48:
                    return "Twelve";
                case 13:
                case 47:
                    return "Thirteen";
                case 14:
                case 46:
                    return "Fourteen";
                case 15:
                case 45:
                    return "Quarter";
                case 16:
                case 44:
                    return "Sixteen";
                case 17:
                case 43:
                    return "Seventeen";
                case 18:
                case 42:
                    return "Eighteen";
                case 19:
                case 41:
                    return "Nineteen";
                case 20:
                case 40:
                    return "Twenty";
                case 21:
                case 39:
                    return "Twenty-one";
                case 22:
                case 38:
                    return "Twenty-two";
                case 23:
                case 37:
                    return "Twenty-three";
                case 24:
                case 36:
                    return "Twenty-four";
                case 25:
                case 35:
                    return "Twenty-five";
                case 26:
                case 34:
                    return "Twenty-six";
                case 27:
                case 33:
                    return "Twenty-seven";
                case 28:
                case 32:
                    return "Twenty-eight";
                case 29:
                case 31:
                    return "Twenty-nine";
                case 30:
                    return "Half";
                default:
                    return "Is an invalid time";
            }
        }
    }
}
