namespace LlibreriaJoc
{
    public class GlobalMethods
    {
        public static bool ValidateStartOption(string option, string MsgError, int attempts)
        {
            if ((option == "a") || (option == "b"))
            {
                return false;
            } else
            {
                Console.WriteLine(MsgError, attempts);
                return true;
            }
        }
    }
}
