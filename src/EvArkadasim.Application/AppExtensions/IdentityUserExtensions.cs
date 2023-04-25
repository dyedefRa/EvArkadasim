using System;

namespace EvArkadasim.AppExtensions
{
    public static class IdentityUserExtensions
    {
        public static string GenerateUserName(string email)
        {
            Random rand = new Random();
            string number = rand.Next(1000).ToString("D3");

            return email.Split('@')[0] + number;
        }
    }
}
