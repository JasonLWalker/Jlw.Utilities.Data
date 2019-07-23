
// ReSharper disable once CheckNamespace

using System;
using System.Security.Cryptography;
using System.Text;

namespace Jlw.Standard.Utilities.Data
{
    public partial class DataUtility
    {
	    public static string Sha256Hash(string text)  
	    {  
		    // SHA512 is disposable by inheritance.  
		    using(var sha256 = SHA256.Create())  
		    {  
			    // Send a sample text to hash.  
			    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));  
			    // Get the hashed string.  
			    return System.BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
		    }  
	    }  

	    public static string Md5Hash(string text)  
	    {  
		    // MD5 is disposable by inheritance.  
		    using(var md5 = MD5.Create())  
		    {  
			    // Send a sample text to hash.  
			    var hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));  
			    // Get the hashed string.  
			    return System.BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
		    }  
	    }  


        public static string BaseEncode(long val, ushort baseN=16, string chars ="0123456789ABCDEF")
        {
            StringBuilder s = new StringBuilder();
            long n = val;
            do
            {
                var i = (int)(n % baseN);
                s.Insert(0, chars[i]);
                n = (n - i) / baseN;
            } while (n > 0);

            return s.ToString();
        }

        public static long BaseDecode(string s, int baseN=16, string chars ="0123456789ABCDEF")
        {
            if (string.IsNullOrWhiteSpace(s) || s.Length < 1)
                return 0;

            int len = (s?.Length ?? 0);
            long val = 0;
            for (int i=0; i < len; i++)
            {
                char c = s[i];
                int n = chars.IndexOf(c);
                if (n >= 0) 
                    val += n * (long)Math.Pow(baseN, (len - i) - 1);
            }
            return val;
        }

        public static string Base48Encode(long val)
        {
            return BaseEncode(val, 48, "23456789abcdefghjkmnpqrtwxyzABCDEFGHJKMNPQRTWXYZ");
        }

        public static long Base48Decode(string val)
        {
            return BaseDecode(val, 48, "23456789abcdefghjkmnpqrtwxyzABCDEFGHJKMNPQRTWXYZ");
        }

        public static string Base25Encode(long val)
        {
            return BaseEncode(val, 25, "234689ABCDEFGHJKMNPQRWXYZ");
        }

        public static long Base25Decode(string val)
        {
            return BaseDecode(val, 25, "234689ABCDEFGHJKMNPQRWXYZ");
        }


	    public static string GenerateSalt()  
	    {  
		    byte[] bytes = new byte[128 / 8];  
		    using(var keyGenerator = RandomNumberGenerator.Create())  
		    {  
			    keyGenerator.GetBytes(bytes);  
			    return BitConverter.ToString(bytes).Replace("-", "").ToLower();  
		    }  
	    }  
    }
}
