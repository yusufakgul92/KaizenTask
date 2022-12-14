using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCreator.Core
{
    public class CodeGeneratorLogic
    {
        public HashSet<string> GeneratedCodes;
        private const string ValidCharacters = "ACDEFGHKLMNPRTXYZ234579";

        public CodeGeneratorLogic()
        {
            GeneratedCodes = new HashSet<string>();
        }

        public string GenerateCode()
        {
            string code = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                code = GenerateRandomCode(8);
                isValid = IsValidCode(code);
            }

            return code;
        }

        //istenen kod listesini oluşturma
        public void FillHash()
        {
            for (int i = 0; i < 10000000; i++)
            {
                string code = GenerateCode();
                GeneratedCodes.Add(code);   
            }
        }

        //içerip içermediğini kontrol
        private bool IsValidCode(string code)
        {
            return !GeneratedCodes.Contains(code);
        }

        //kod oluşturma
        private string GenerateRandomCode(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = r.Next(ValidCharacters.Length);
                sb.Append(ValidCharacters[index]);
            }

            return sb.ToString();
        }
    }
}
