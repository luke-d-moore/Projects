using System;
using System.Collections.Generic;
using System.Text;
using EncryptDecryptApp.Interfaces;

namespace EncryptDecryptApp
{
    public class EncryptionBase
    {
        protected string _stringToProcess;
        protected double _encryptionNumber;
        protected IAllowedCharactersGenerator _allowedCharactersGenerator;
        protected INumberListGenerator _numberListGenerator;
    }
}
