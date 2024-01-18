namespace LlibreriaJoc
{
    public class GlobalMethods
    {
        public static bool ValidateOption(string option, string[] validOptions)
        {
            return validOptions.Contains(option);
        }
        public static bool ValidateAttempts(int attempts)
        {
            return attempts > 0;
        }
    }
}
