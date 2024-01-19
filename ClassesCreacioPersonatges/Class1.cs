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
            string[] characterNames = name.Split(',');
            if (characterNames.Length != 4)
            {
                return false;
            }
            return true;
        }
        public static string[] AssignCharacterNames(string names)
        {
            return names.Split(',');
        }
    }
}
