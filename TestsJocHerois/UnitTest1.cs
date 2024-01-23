using LlibreriaJoc;
using CombatMethods;
using ClassesCreacioPersonatges;
namespace TestsJocHerois
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValidateOptionCorrect()
        {
            // Arrange
            string[] options = { "a", "b", "c" };
            string option = "a";
            bool expected = true;

            // Act
            bool result = GlobalMethods.ValidateOption(option, options);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateOptionIncorrect()
        {
            // Arrange
            string[] options = { "a", "b", "c" };
            string option = "j";
            bool expected = false;

            // Act
            bool result = GlobalMethods.ValidateOption(option, options);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateAttemptsCorrect()
        {
            // Arrange
            int attempts = 3;
            bool expected = true;

            // Act
            bool result = GlobalMethods.ValidateAttempts(attempts);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateAttemptsIncorrect()
        {
            // Arrange
            int attempts = 0;
            bool expected = false;

            // Act
            bool result = GlobalMethods.ValidateAttempts(attempts);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateEndOptionCorrect()
        {
            // Arrange
            string option = "b";
            bool expected = true;

            // Act
            bool result = GlobalMethods.CheckProgramEnd(option);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateEndOptionIncorrect()
        {
            // Arrange
            string option = "j";
            bool expected = false;

            // Act
            bool result = GlobalMethods.CheckProgramEnd(option);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestGenerateRandomMinMax()
        {
            // Arrange
            int min = 0, max = 10;
            bool expected = true;

            // Act
            int num = GlobalMethods.GenerateRandom(min, max);
            bool result = num >= min && num < max;

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestGenerateRandomMax()
        {
            // Arrange
            int max = 10;
            bool expected = true;

            // Act
            int num = GlobalMethods.GenerateRandom(max);
            bool result = num >= 0 && num < max;

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestArrangeNumListCorrect()
        {
            // Arrange
            int[] numbers = { 1, 2, 3, 4 };
            int num = 1, position = 3;
            int[] expected = { 4, 2, 3, 1 };

            // Act
            numbers = Combat.ArrangeNumsList(numbers, num, position);

            // Assert
            Assert.AreEqual(expected[position], numbers[position]);
        }
        [TestMethod]
        public void TestValidateHPCorrect()
        {
            // Arrange
            int hp = 100;
            bool expected = true;

            // Act
            bool result = Combat.ValidateHP(hp);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateHPIncorrect()
        {
            // Arrange
            int hp = 0;
            bool expected = false;

            // Act
            bool result = Combat.ValidateHP(hp);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestShowHP()
        {
            // Arrange
            double[] hp = { 100, 80, 120, 90 };
            string[] names = { "Personaje1", "Personaje2", "Personaje3", "Personaje4" };

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Combat.ShowHP(hp, names);
                string result = sw.ToString().Trim();

                // Assert
                string expected = "Vida dels personatges: \nPersonaje3: 120\tPersonaje1: 100\tPersonaje4: 90\tPersonaje2: 80";
                Assert.AreEqual(expected, result);
            }
        }
        [TestMethod]
        public void TestValidateSkillCDCorrect()
        {
            // Arrange
            int cd = 3;
            string option = "c";
            bool expected = true;

            // Act
            bool result = Combat.ValidateSkillCD(option, cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateSkillCDIncorrect1()
        {
            // Arrange
            int cd = 0;
            string option = "c";
            bool expected = false;

            // Act
            bool result = Combat.ValidateSkillCD(option, cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateSkillCDIncorrect2()
        {
            // Arrange
            int cd = 3;
            string option = "b";
            bool expected = false;

            // Act
            bool result = Combat.ValidateSkillCD(option, cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateSkillCDSingleCorrect()
        {
            // Arrange
            int cd = 3;
            bool expected = true;

            // Act
            bool result = Combat.ValidateSkillCD(cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateSkillCDSingleIncorrect1()
        {
            // Arrange
            int cd = 0;
            bool expected = false;

            // Act
            bool result = Combat.ValidateSkillCD(cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestCalculateAttack()
        {
            // Arrange
            double atk = 200, def = 20, expected = 160;

            // Act
            double result = Combat.Attack(atk, def);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateOverhealCorrect()
        {
            // Arrange
            int hp = 190, maxHP = 200;
            bool expected = false;

            // Act
            bool result = Combat.ValidateOverHeal(hp, maxHP);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateOverhealIncorrect()
        {
            // Arrange
            int hp = 210, maxHP = 200;
            bool expected = true;

            // Act
            bool result = Combat.ValidateOverHeal(hp, maxHP);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateStunCorrect()
        {
            // Arrange
            int stun = 2;
            bool expected = true;

            // Act
            bool result = Combat.ValidateStunMonster(stun);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateStunIncorrect()
        {
            // Arrange
            int stun = 0;
            bool expected = false;

            // Act
            bool result = Combat.ValidateStunMonster(stun);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateBarbSkillCorrect()
        {
            // Arrange
            int cd = 3;
            bool expected = true;

            // Act
            bool result = Combat.ValidateBarbarianSkill(cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateBarbSkillIncorrect()
        {
            // Arrange
            int cd = 0;
            bool expected = false;

            // Act
            bool result = Combat.ValidateBarbarianSkill(cd);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateNamesCorrect()
        {
            // Arrange
            string[] invalidCharacters = { " ", ".", ";", ":", "-", "_",
                                           "!", "¡", "?", "¿", "(", ")",
                                           "[", "]", "{", "}", "'", "\"",
                                           "·", "$", "%", "&", "/", "=",
                                           "+", "*", "ª", "º", "<", ">",
                                           "¬", "¨", "´", "`", "€", "£" };
            string names = "pol,hugo,pablo,silvia";
            bool expected = true;

            // Act
            bool result = CharacterCreation.ValidateNameFormat(names, invalidCharacters);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateNamesIncorrect1()
        {
            // Arrange
            string[] invalidCharacters = { " ", ".", ";", ":", "-", "_",
                                           "!", "¡", "?", "¿", "(", ")",
                                           "[", "]", "{", "}", "'", "\"",
                                           "·", "$", "%", "&", "/", "=",
                                           "+", "*", "ª", "º", "<", ">",
                                           "¬", "¨", "´", "`", "€", "£" };
            string names = "pol,hugo,pabl.o,silvia?";
            bool expected = false;

            // Act
            bool result = CharacterCreation.ValidateNameFormat(names, invalidCharacters);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateNamesIncorrect2()
        {
            // Arrange
            string[] invalidCharacters = { " ", ".", ";", ":", "-", "_",
                                           "!", "¡", "?", "¿", "(", ")",
                                           "[", "]", "{", "}", "'", "\"",
                                           "·", "$", "%", "&", "/", "=",
                                           "+", "*", "ª", "º", "<", ">",
                                           "¬", "¨", "´", "`", "€", "£" };
            string names = "pol,hugo,pablo,silvia,antonio";
            bool expected = false;

            // Act
            bool result = CharacterCreation.ValidateNameFormat(names, invalidCharacters);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestSplitNames()
        {
            // Arrange
            string names = "pol,hugo,pablo,silvia";
            string[] expected = { "pol", "hugo", "pablo", "silvia" };
            bool expectedComparison = true, comparisonResult = true;

            // Act
            string[] result = CharacterCreation.AssignCharacterNames(names);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != expected[i])
                {
                    expectedComparison = false;
                }
            }

            // Assert
            Assert.AreEqual(expectedComparison, comparisonResult);
        }
        [TestMethod]
        public void TestAssignStatsHeroes()
        {
            // Arrange
            int characters = 4, statTypes = 4;
            int[,] MaxStats = { { 2000, 300, 35, 0 },
                { 3750, 250, 45, 0 },
                { 1500, 400, 35, 0 },
                { 2500, 120, 40, 0 } };

            int[,] expected = { { 2000, 300, 35, 0 },
                { 3750, 250, 45, 0 },
                { 1500, 400, 35, 0 },
                { 2500, 120, 40, 0 } };

            int[,] result = new int[characters, statTypes];

            // Act
            result = CharacterCreation.AssignStats(result, MaxStats, characters, statTypes);

            // Assert
            for (int i = 0; i < characters; i++)
            {
                for (int j = 0; j < statTypes; j++)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }
        [TestMethod]
        public void TestAssignStatsMonster()
        {
            // Arrange
            int[] MaxStats = { 2000, 300, 35 };
            int[] expected = { 2000, 300, 35 };
            int[] result = new int[MaxStats.Length];
            bool expectedComparison = true, comparisonResult = true;

            // Act
            result = CharacterCreation.AssignStats(result, MaxStats);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != expected[i])
                {
                    expectedComparison = false;
                }
            }

            // Assert
            Assert.AreEqual(expectedComparison, comparisonResult);
        }
        [TestMethod]
        public void TestValidateStatRangeCorrect()
        {
            // Arrange
            int min = 0, max = 10, stat = 5;
            bool expected = true;

            // Act
            bool result = CharacterCreation.ValidateStatRange(stat, min, max);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateStatRangeIncorrect1()
        {
            // Arrange
            int min = 0, max = 10, stat = 17;
            bool expected = false;

            // Act
            bool result = CharacterCreation.ValidateStatRange(stat, min, max);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestValidateStatRangeIncorrect2()
        {
            // Arrange
            int min = 0, max = 10, stat = -2;
            bool expected = false;

            // Act
            bool result = CharacterCreation.ValidateStatRange(stat, min, max);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestAssignNameMessageCorrect1()
        {
            // Arrange
            int character = 0;
            string archer = "archer", barbarian = "barbarian", mage = "mage", druid = "druid";

            // Act
            string result = CharacterCreation.AssignNameMessage(character, archer, barbarian, mage, druid);

            // Assert
            Assert.AreEqual(archer, result);
        }
        [TestMethod]
        public void TestAssignNameMessageCorrect2()
        {
            // Arrange
            int character = 1;
            string archer = "archer", barbarian = "barbarian", mage = "mage", druid = "druid";

            // Act
            string result = CharacterCreation.AssignNameMessage(character, archer, barbarian, mage, druid);

            // Assert
            Assert.AreEqual(barbarian, result);
        }
        [TestMethod]
        public void TestAssignNameMessageCorrect3()
        {
            // Arrange
            int character = 2;
            string archer = "archer", barbarian = "barbarian", mage = "mage", druid = "druid";

            // Act
            string result = CharacterCreation.AssignNameMessage(character, archer, barbarian, mage, druid);

            // Assert
            Assert.AreEqual(mage, result);
        }
        [TestMethod]
        public void TestAssignNameMessageCorrect4()
        {
            // Arrange
            int character = 3;
            string archer = "archer", barbarian = "barbarian", mage = "mage", druid = "druid";

            // Act
            string result = CharacterCreation.AssignNameMessage(character, archer, barbarian, mage, druid);

            // Assert
            Assert.AreEqual(druid, result);
        }
        [TestMethod]
        public void TestAssignNameMessageIncorrect()
        {
            // Arrange
            int character = 5;
            string archer = "archer", barbarian = "barbarian", mage = "mage", druid = "druid";

            // Act
            string result = CharacterCreation.AssignNameMessage(character, archer, barbarian, mage, druid);

            // Assert
            Assert.AreEqual("", result);
        }
        [TestMethod]
        public void TestAssignStatMessageCorrect1()
        {
            // Arrange
            int stat = 0;
            string hp = "hp", atk = "atk", def = "def";

            // Act
            string result = CharacterCreation.AssignStatMessage(stat, hp, atk, def);

            // Assert
            Assert.AreEqual(hp, result);
        }
        [TestMethod]
        public void TestAssignStatMessageCorrect2()
        {
            // Arrange
            int stat = 1;
            string hp = "hp", atk = "atk", def = "def";

            // Act
            string result = CharacterCreation.AssignStatMessage(stat, hp, atk, def);

            // Assert
            Assert.AreEqual(atk, result);
        }
        [TestMethod]
        public void TestAssignStatMessageCorrect3()
        {
            // Arrange
            int stat = 2;
            string hp = "hp", atk = "atk", def = "def";

            // Act
            string result = CharacterCreation.AssignStatMessage(stat, hp, atk, def);

            // Assert
            Assert.AreEqual(def, result);
        }
        [TestMethod]
        public void TestAssignStatMessageIncorrect()
        {
            // Arrange
            int stat = 4;
            string hp = "hp", atk = "atk", def = "def";

            // Act
            string result = CharacterCreation.AssignStatMessage(stat, hp, atk, def);

            // Assert
            Assert.AreEqual("", result);
        }
        [TestMethod]
        public void TestAssignRandomStatsHeroes()
        {
            // Arrange
            int characters = 4, statTypes = 4;
            int[,] MinStats = { { 1500, 200, 25, 0 },
                { 3000, 150, 35, 0 },
                { 1100, 300, 20, 0 },
                { 2000, 100, 25, 0 } };
            int[,] MaxStats = { { 2000, 300, 35, 0 },
                { 3750, 250, 45, 0 },
                { 1500, 400, 35, 0 },
                { 2500, 120, 40, 0 } };
            int[,] result = new int[characters, statTypes];
            bool expectedComparison = true, comparisonResult = true;

            // Act
            result = CharacterCreation.AssignStats(result, MaxStats, characters, statTypes);
            for (int i = 0; i < characters; i++)
            {
                for (int j = 0; j < statTypes; j++)
                {
                    if (result[i, j] < MinStats[i, j] || result[i, j] > MaxStats[i, j])
                    {
                        expectedComparison = false;
                    }
                }
            }

            // Assert
            Assert.AreEqual(expectedComparison, comparisonResult);
        }
        [TestMethod]
        public void TestAssignRandomStatsMonster()
        {
            // Arrange
            int[] MonsterMinStats = { 7000, 300, 20 };
            int[] MonsterMaxStats = { 10000, 400, 30 };
            int[] result = new int[3];
            bool expectedComparison = true, comparisonResult = true;

            // Act
            result = CharacterCreation.AssignStats(result, MonsterMinStats, MonsterMaxStats);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < MonsterMinStats[i] || result[i] > MonsterMaxStats[i])
                {
                    expectedComparison = false;
                }
            }

            // Assert
            Assert.AreEqual(expectedComparison, comparisonResult);
        }
        [TestMethod]
        public void TestAssignCurrentHealth()
        {
            // Arrange
            int hp = 0, characters = 4;
            int[,] stats = { { 1500, 200, 25, 0 },
                { 3000, 150, 35, 0 },
                { 1100, 300, 20, 0 },
                { 2000, 100, 25, 0 } };
            double[] result = new double[characters];

            // Act
            result = CharacterCreation.AssignCurrentHP(result, stats, hp);

            // Assert
            for (int i = 0; i < characters; i++)
            {
                Assert.AreEqual(stats[i, 0], result[i]);
            }
        }
        [TestMethod]
        public void TestAssignMonsterCurrentHealth()
        {
            // Arrange
            int hp = 0;
            int[] stats = { 1500, 200, 25, 0 };

            // Act
            double result = CharacterCreation.AssignCurrentHP(stats, hp);

            // Assert
            Assert.AreEqual(stats[hp], result);
        }
        [TestMethod]
        public void TestAssignTotalHP()
        {
            // Arrange
            double[] vida = { 50, 500, 500, 50 };
            int expected = 1100;

            // Act
            double result = CharacterCreation.AssignTotalHP(vida);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}