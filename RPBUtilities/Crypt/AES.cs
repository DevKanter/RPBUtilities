using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace RPBUtilities.Crypt
{
    public class AES
    {
        private readonly AesManaged _aes = new AesManaged();
        private readonly ICryptoTransform _enc;
        private readonly ICryptoTransform _dec;

        public readonly byte[] Key;
        public readonly byte[] IV;
        public AES()
        {
            Key = _aes.Key;
            IV = _aes.IV;
            _enc = _aes.CreateEncryptor(_aes.Key,_aes.IV);
            _dec = _aes.CreateDecryptor(_aes.Key,_aes.IV);
        }

        public AES(byte[] key, byte[] iv)
        {
            _aes.Key = key;
            _aes.IV = iv;
            _enc = _aes.CreateEncryptor(_aes.Key, _aes.IV);
            _dec = _aes.CreateDecryptor(_aes.Key, _aes.IV);
        }

        public byte[] Encrypt(byte[] data)
        {
            using (var memory = new MemoryStream())
            using (var crypto = new CryptoStream(memory, _enc, CryptoStreamMode.Write))
            {
                crypto.Write(data, 0, data.Length);
                crypto.FlushFinalBlock();
                return memory.ToArray();
            }


        }
        public byte[] Decrypt(byte[] buffer,int size) 
        {
            using (var memory = new MemoryStream())
            using (var crypto = new CryptoStream(memory, _dec, CryptoStreamMode.Write))
            {
                crypto.Write(buffer, 0, size);
                crypto.FlushFinalBlock();
                return memory.ToArray();
            }
        }
    }
}
