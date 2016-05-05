using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MercadoEnvio.Helpers
{
    public class EncryptHelper
    {
        public string Sha256Encrypt(string text)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256Hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256Hasher.ComputeHash(encoder.GetBytes(text));
            return ByteArrayToString(hashedDataBytes);
        }

        private string ByteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            foreach (byte t in inputArray)
            {
                output.Append(t.ToString("X2"));
            }
            return output.ToString();
        }
    }
}
