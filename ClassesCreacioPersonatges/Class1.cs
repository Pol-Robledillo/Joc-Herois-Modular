namespace ClassesCreacioPersonatges
{
    public class CharacterCreation
    {
        public static bool ValidateNameFormat(string name, string[] invalidCharacters)
        {
            foreach (string character in invalidCharacters)
            {
                if (name.Contains(character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
