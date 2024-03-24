using System;
using System.Collections.Generic;
using System.Text;
using EncryptDecryptApp.Interfaces;

namespace EncryptDecryptApp
{
    class IrrationalNumberGenerator : IIrrationalNumberGenerator
    {
        public double getIrrationalNumber(double encryptionNumber, double root)
        {
            return Math.Pow(encryptionNumber, (1.0 / root));
        }
    }
}
