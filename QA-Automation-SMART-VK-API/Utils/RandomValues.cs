using System;

namespace QA_Automation_SMART_VK_API.Utils
{
    public static class RandomValues
    {
        public static string MakeRandomString(int stringLength)
        {
            Random rndGen = new Random();

            string symbols = "qwertyuiopasdfghjklzxcvbnm0123456789_!";
            char[] letters = symbols.ToCharArray();

            string randomString = "";

            for (int i = 0; i < stringLength; i++)
            {
                randomString += letters[rndGen.Next(letters.Length)].ToString();
            }

            return randomString;
        }
    }
}