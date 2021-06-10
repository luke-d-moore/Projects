using System;
using System.Collections.Generic;
using System.Text;
using EncryptDecryptApp.Interfaces;

namespace EncryptDecryptApp
{
    public class AllowedCharactersHelper : IAllowedCharactersGenerator
    {
        public string getAllowedCharacters()
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz ,.<>?/;:'@[{}]+=-_#~()*&^%£$!0123456789";
        }
    }
}
