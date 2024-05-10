﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;
using System.Text;

namespace appFermento_Natural_E_commerce.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = MD5.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);
            var strHexa = new StringBuilder();
            foreach ( var item in array )
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();

        }
    }
}
