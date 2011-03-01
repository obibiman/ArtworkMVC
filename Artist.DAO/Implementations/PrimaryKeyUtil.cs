using System;

namespace Artist.DAO.Implementations
{
    public class PrimaryKeyUtil
    {
        public static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}