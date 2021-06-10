using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptDecryptApp.Interfaces
{
    public interface INumberListGenerator
    {
        public List<int> getNumberList(int length, double encryptionNumber);
        public char[] getCleanNumberString(string numberString);
    }
}
