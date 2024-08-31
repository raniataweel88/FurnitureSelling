using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.helper
{
    public static class HashHelper
    {
 
          public  static string GenerateSHA384String(string inputString)
            {
                SHA384 sha384 = SHA384Managed.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);
                byte[] hash = sha384.ComputeHash(bytes);
                return GetStringFromHash(hash);
            }
      
         public   static string GetStringFromHash(byte[] hash)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("X2"));
                }
                Console.WriteLine(result.Length);
                return result.ToString();
            }
        }
    }

