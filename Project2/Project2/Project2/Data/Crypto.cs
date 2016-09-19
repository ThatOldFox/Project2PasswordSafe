/*References
 * - Seridonio,P,2016,Cryptography Shared Code,Xamarin, Retrieved 10/09/2016 
 *   https://forums.xamarin.com/discussion/64399/cryptography-shared-code
 */
using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLCrypto;
using System.Diagnostics;

namespace Project2.Data
{
    public static class Crypto //Seridonio,2016
    {
        public static string EncryptToText(string text)
        {
            byte[] encryptedText = InternalCrypto.Encrypt(text);
            return Convert.ToBase64String(encryptedText);
        }

        public static byte[] EncryptToBytes(string text)
        {
            try
            {
                return InternalCrypto.Encrypt(text);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            return InternalCrypto.Encrypt(text); 


        }

        public static string DecryptFromText(string encryptedText)
        {
            return InternalCrypto.Decrypt(Encoding.UTF8.GetBytes(encryptedText));
        }

        public static string DecryptFromBytes(byte[] encryptedText)
        {
            return InternalCrypto.Decrypt(encryptedText);
        }

        public static string Teste()
        {
            byte[] bytes = EncryptToBytes("Teste");
            string text = DecryptFromBytes(bytes);
            return text;
        }
        public static string Testee()
        {
            string bytes = EncryptToText("Teste");
            string text = DecryptFromText(bytes);
            return text;
        }

        internal static class InternalCrypto
        {
            private static readonly string _passwordEncryption = "12345678";
            private static readonly int _iterations = 1000;
            private static readonly int _keyLenght = 32;
            private static readonly byte[] _salt = Encoding.UTF8.GetBytes("12345678");
            private static readonly byte[] _derivedKey = NetFxCrypto.DeriveBytes.GetBytes(_passwordEncryption, _salt, _iterations, _keyLenght);

            internal static byte[] Encrypt(string text) //Seridonio,2016
            {
                ISymmetricKeyAlgorithmProvider aesCrypto = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
                ICryptographicKey symmtricKey = aesCrypto.CreateSymmetricKey(_derivedKey);
                ICryptoTransform encryptor = WinRTCrypto.CryptographicEngine.CreateEncryptor(symmtricKey);
                byte[] byteText = Encoding.UTF8.GetBytes(text);
                byte[] encryptedText = encryptor.TransformFinalBlock(byteText, 0, byteText.Length);
                return encryptedText;
                
            }


            internal static string Decrypt(byte[] encryptedText) //Seridonio,2016
            {
                ISymmetricKeyAlgorithmProvider aesCrypto = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
                ICryptographicKey symmtricKey = aesCrypto.CreateSymmetricKey(_derivedKey);
                ICryptoTransform decryptor = WinRTCrypto.CryptographicEngine.CreateDecryptor(symmtricKey);
                byte[] decryptedText = decryptor.TransformFinalBlock(encryptedText, 0, encryptedText.Length);
                return Encoding.UTF8.GetString(decryptedText, 0, decryptedText.Length);
               
            }
        }
    }
}
