using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RPBUtilities.Crypt
{
    public class RSAEnc
    {
        private readonly RSA _rsa;
        public readonly string PublicKey;
        public RSAEnc()
        {
            _rsa = RSA.Create();
            PublicKey = _rsa.ToXmlString(false);
        }
    }
}
