using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmegaC
{
    public class InputData
    {

        public static string dataInput(string input)
        {
            string result = null;

            return result = input.Trim();
        }

        public static string dataInput(decimal input)
        {
            string result = null;

            return result = input.ToString().Trim(); 
        }

    }
}