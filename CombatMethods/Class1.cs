using LlibreriaJoc;
namespace CombatMethods
{
    public class Combat
    {
        public static bool ValidateHP(double hp)
        {
            return hp > 0;
        }
        public static void ShowHP(double[] hp, string[] names)
        {
            const string MsgCharsHP = "Vida dels personatges: \n{0}: {1}\t{2}: {3}\t{4}: {5}\t{6}: {7}";
            int[] aliveChars = { 0, 1, 2, 3 };
            double[] hpOrder = { hp[0], hp[1], hp[2], hp[3] };
            double auxHP;
            int auxNum;
            for (int i = 0; i < hpOrder.Length - 1; i++)
            {
                for (int j = 0; j < hpOrder.Length - i - 1; j++)
                {
                    if (hpOrder[j] < hpOrder[j + 1])
                    {
                        auxHP = hpOrder[j];
                        auxNum = aliveChars[j];

                        hpOrder[j] = hpOrder[j + 1];
                        aliveChars[j] = aliveChars[j + 1];

                        hpOrder[j + 1] = auxHP;
                        aliveChars[j + 1] = auxNum;
                    }
                }
            }
            Console.WriteLine(MsgCharsHP, names[aliveChars[0]], hpOrder[0], names[aliveChars[1]], hpOrder[1], names[aliveChars[2]], hpOrder[2], names[aliveChars[3]], hpOrder[3]);
        }
        public static bool ValidateSkillCD (string option, int skillCD)
        {
            return option == "c" && skillCD > 0;
        }
        public static bool ValidateSkillCD(int skillCD)
        {
            return skillCD > 0;
        }
        public static double Attack(double attack, double defense)
        {
            return attack - (attack * (defense * 100));
        }
        public static bool CalcProbability(int probability)
        {
            int randomNum = GlobalMethods.GenerateRandom(100);
            return randomNum < probability;
        }
    }
}
