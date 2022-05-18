namespace TalkingClock
{
    public static class IntegerExtensions
    {
        public static bool ValidMinutes(this int minutes)
        {
            return minutes > -1 &&
                   minutes < 60;
        }

        public static bool ValidHours(this int hours)
        {
            return hours > -1 &&
                   hours < 24;
        }
    }
}
