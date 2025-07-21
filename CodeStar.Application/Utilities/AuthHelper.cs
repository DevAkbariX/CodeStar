using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Utilities
{
    public static class AuthHelper
    {
        public static string HashPassword(string password)
        {
            try
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        public static string GenerateResetToken()
        {
            try
            {
                return Guid.NewGuid().ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
