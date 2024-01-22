using static System.Net.Mime.MediaTypeNames;
using System;

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
        public static int[,] AssignStats(int[,] stats, int[,] statsBase, int characters, int statTypes)
        {
            for (int i = 0; i < characters; i++)
            {
                for (int j = 0; j < statTypes; j++)
                {
                    stats[i, j] = statsBase[i, j];
                }
            }
            return stats;
        }
        public static int[] AssignStats(int[] stats, int[] statsBase)
        {
            for (int i = 0; i < stats.Length; i++)
            {
                stats[i] = statsBase[i];
            }
            return stats;
        }
        public static bool ValidateStatRange(int stat, int min, int max)
        {
            return stat >= min && stat <= max;
        }
        public static string AssignNameMessage(int character, string ArcherMSG, string BarbarianMSG, string MageMSG, string DruidMSG)
        {
            switch (character)
            {
                case 0:
                    return ArcherMSG;
                case 1:
                    return BarbarianMSG;
                case 2:
                    return MageMSG;
                case 3:
                    return DruidMSG;
                default:
                    return "";
            }
        }
        public static string AssignStatMessage(int character, string HP, string ATK, string DEF)
        {
            switch (character)
            {
                case 0:
                    return HP;
                case 1:
                    return ATK;
                case 2:
                    return DEF;
                default:
                    return "";
            }
        }
        public static int[,] AssignStats(int[,] stats, int[,] minStats, int[,] maxStats, int characters, int statTypes)
        {
            for (int i = 0; i < characters; i++)
            {
                for (int j = 0; j < statTypes; j++)
                {
                    stats[i, j] = GenerateRandom(minStats[i, j], maxStats[i, j]);
                }
            }
            return stats;
        }
        public static int[] AssignStats(int[] stats, int[] minStats, int[] maxStats)
        {
            for (int i = 0; i < stats.Length; i++)
            {
                stats[i] = GenerateRandom(minStats[i], maxStats[i]);
            }
            return stats;
        }
        public static int GenerateRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
        public static double[] AssignCurrentHP(double[] currentHP, int[,] characters, int HP)
        {
            for (int i = 0; i < currentHP.Length; i++)
            {
                currentHP[i] = characters[i, HP];
            }
            return currentHP;
        }
        public static double AssignCurrentHP(int[] monster, int HP)
        {
            return monster[HP];
        }
        public static double AssignTotalHP(double[] charactersHP)
        {
            double totalHP = 0;
            for (int i = 0; i < charactersHP.Length; i++)
            {
                totalHP += charactersHP[i];
            }
            return totalHP;
        }
    }
}
