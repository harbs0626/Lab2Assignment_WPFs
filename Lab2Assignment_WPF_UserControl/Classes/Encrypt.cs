using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #2 - WPF (Add-On Class & Security)
/// ** Date (MM/dd/yyy) : 01/24/2020
/// </summary>
namespace Lab2Assignment_WPF_UserControl.Classes
{
    public class Encrypt
    {
        public static string EncryptMe(string _password)
        {
            try
            {
                string _returnValue = string.Empty;
                string _key = "h@rb!nh@rb!n";
                string _vectorIV = "c3nt3nn!@l";

                byte[] _keyByte = { };
                byte[] _vectorIVByte = { };
                byte[] _inputByteArray = { };

                _keyByte = Encoding.UTF8.GetBytes(_key.Substring(0, 8));
                _vectorIVByte = Encoding.UTF8.GetBytes(_vectorIV.Substring(0, 8));
                _inputByteArray = new byte[_password.Replace(" ", "+").Length];
                
                MemoryStream _memoryStream = null;
                CryptoStream _cryptoStream = null;

                using (DESCryptoServiceProvider _dESCryptoServiceProvider = 
                    new DESCryptoServiceProvider())
                {
                    _memoryStream = new MemoryStream();
                    _cryptoStream = new CryptoStream(
                        _memoryStream,
                        _dESCryptoServiceProvider.CreateEncryptor(_keyByte, _vectorIVByte), 
                        CryptoStreamMode.Write);
                    _cryptoStream.Write(_inputByteArray, 0, _inputByteArray.Length);
                    _cryptoStream.FlushFinalBlock();
                    Encoding _encoding = Encoding.UTF8;
                    _returnValue = _encoding.GetString(_memoryStream.ToArray());
                }

                return _returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
