using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VcsConnect_Client.Workers.General_Workers
{
    public class Tools
    {
        // method to remove special charcters from string
        public static string RemoveSpecialCharacters(string str)
        {
            char[] buffer = new char[str.Length];
            int idx = 0;

            //char cr = (char)13;
            //char lf = (char)10;
            //char tab = (char)9;
            //Single Quote = (char)39; removed

            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z') || (c == '.') || (c == '_')
                    || (c == ' ') || (c == '-') || (c == '#') || (c == '$')
                    || (c == '!') || (c == '*') || (c == '(') || (c == ')')
                    || (c == '%') || (c == '@') || (c == '{') || (c == '}')
                    || (c == '?') || (c == '/') || (c == '+') || (c == ',')
                    || (c == (char)13) || (c == (char)10) || (c == (char)9) || (c == (char)39))
                {
                    buffer[idx] = c;
                    idx++;
                }
            }

            return new string(buffer, 0, idx);
        }



        // convert nulls to strings
        public static string NullToString(string strHld)
        {
            if (strHld == null)
            {
                strHld = "";
            }

            return strHld;
        }
    }
}