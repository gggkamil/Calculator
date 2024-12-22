using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calculator
    {
        public static double Calculate(double x, double y, string mathOperator)
        {
            double result = 0;

            switch(mathOperator)
            {
                case "+":
                    result = x+y;
                    break;
                case "-":
                    result = x-y;
                    break;
                case "x":
                    result = x*y; 
                    break;
                case "/":
                    result = x/y;
                    break;
                case "%":
                    result = (x*y)/100;
                    break;

            }
            return result;
        }
        public static string ToTrimmedString(this double target, string decimalFormat) =>
    target.ToString(decimalFormat) switch
    {
        var strValue when strValue.Contains(".") =>
            strValue.TrimEnd('0') switch
            {
                var trimmedStr when trimmedStr.EndsWith(".") => trimmedStr.TrimEnd('.'),
                var trimmedStr => trimmedStr
            },
        var strValue => strValue
    };

    }

}
