using System;
using System.Text;
using Connex.Encryption;

namespace AppCtrl.Encryption
{
	/// <summary>
	/// Summary description for MmsGenericEncryption.
	/// </summary>
	public class GenericEncryption
	{
        private EncryptionAlgorithm _algorithm1 = EncryptionAlgorithm.Rc2; //(8,8)
        //private EncryptionAlgorithm _algorithm2 = EncryptionAlgorithm.TripleDes; //(16,8)
        //private EncryptionAlgorithm _algorithm3 = EncryptionAlgorithm.Rijndael; //(32,16)
        private EncryptionAlgorithm _algorithm2 = EncryptionAlgorithm.Des; //(8,8)

        private byte[] _key;
        private byte[] _vector;
        public static string key { get; set; }
        public static string vector { get; set; }
 
		public GenericEncryption()
		{
            try
            {
                if (key != null && vector != null)
                {
                    _key = Convert.FromBase64String(key);
                    _vector = Convert.FromBase64String(vector);
                }
                else
                {
                    _key = Convert.FromBase64String("");
                    _vector = Convert.FromBase64String("");
                }
            }
            catch (Exception ex)
            {
                //return "Error while encrypting data value: \n" + ex.Message;
            }
            
		}

        public static string Encrypt(string data, LevelEncrypt level)
        { 
            GenericEncryption GE = new GenericEncryption();
            try
            {
                switch (level)
                {
                    case LevelEncrypt.low:
                        {
                            return GE.EncryptAlgorithm_1(data);
                        }
                    case LevelEncrypt.medium:
                        {
                            string buf = GE.EncryptAlgorithm_1(data);
                            return GE.EncryptAlgorithm_2(buf);
                        }
                    default:
                        {
                            string buf = GE.EncryptAlgorithm_1(data);
                            string buf2 = GE.EncryptAlgorithm_2(buf);
                            return GE.EncryptAlgorithm_1(buf2);
                        }

                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Error while encrypting data value: \n" +  ex.Message);
                return "Error while encrypting data value: \n" + ex.Message;
            }

        }

        public static string Decrypt(string data, LevelEncrypt level)
        {
            GenericEncryption GE = new GenericEncryption();
            try
            {
                switch (level)
                {
                    case LevelEncrypt.low:
                        {
                            return GE.DecryptAlgorithm_1(data);
                        }
                    case LevelEncrypt.medium:
                        {
                            string buf = GE.DecryptAlgorithm_2(data);
                            return GE.DecryptAlgorithm_1(buf);
                        }
                    default:
                        {
                            string buf = GE.DecryptAlgorithm_1(data);
                            string buf2 = GE.DecryptAlgorithm_2(buf);
                            return GE.DecryptAlgorithm_1(buf2);
                        }

                }
            }
            catch (Exception ex)
            {
                return "Error while decrypting data value: \n" + ex.Message;
            }

        }


        public string EncryptAlgorithm_1(string encryptValue)
        {
            try
            {
                EncryptionAlgorithm algorithm = _algorithm1;

                Encryptor enc = new Encryptor(algorithm);
                enc.IV = _vector;
                byte[] yEncrypt = Encoding.Unicode.GetBytes(encryptValue);

                return Convert.ToBase64String(enc.Encrypt(yEncrypt, _key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EncryptAlgorithm_2(string encryptValue)
        {
            try
            {
                EncryptionAlgorithm algorithm = _algorithm2;

                Encryptor enc = new Encryptor(algorithm);
                enc.IV = _vector;
                byte[] yEncrypt = Encoding.Unicode.GetBytes(encryptValue);

                return Convert.ToBase64String(enc.Encrypt(yEncrypt, _key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DecryptAlgorithm_1(string decryptValue)
        {
            try
            {
                EncryptionAlgorithm algorithm = _algorithm1;
                Decryptor dec = new Decryptor(algorithm);
                dec.IV = _vector;
                //Go ahead and decrypt.
                return Encoding.Unicode.GetString(dec.Decrypt(Convert.FromBase64String(decryptValue), _key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DecryptAlgorithm_2(string decryptValue)
        {
            try
            {
                EncryptionAlgorithm algorithm = _algorithm2;
                Decryptor dec = new Decryptor(algorithm);
                dec.IV = _vector;
                //Go ahead and decrypt.
                return Encoding.Unicode.GetString(dec.Decrypt(Convert.FromBase64String(decryptValue), _key));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
