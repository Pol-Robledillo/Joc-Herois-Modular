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
        public static int[,] AssignCharacterStats(int[,] stats, int[,] statsBase, int characters, int statTypes)
        {
            for (int i = 0; i < characters; i++)
            {
                for (int j = 0; j < statTypes; j++)
                {
                    stats[i, j] = statsBase[i, j];
                    Console.Write(stats[i, j]);
                }
                Console.WriteLine();
            }
            return stats;
        }
    }
}
