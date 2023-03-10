namespace Portfolio.Shared.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string input)
        {
            int result;
            try
            {
                result = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                result = 0;
            }

            return result;
        }
    }
}