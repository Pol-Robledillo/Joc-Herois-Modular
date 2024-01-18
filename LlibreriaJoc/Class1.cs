namespace LlibreriaJoc
{
    public class GlobalMethods
    {
        public static bool ValidateOption(string option, string[] validOptions)
        {
            return validOptions.Contains(option);
        }
    }
}
