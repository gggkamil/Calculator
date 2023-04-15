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
                case "*":
                    result = x*y; 
                    break;
                case "/":
                    result = x/y;
                    break;
                case "%":
                    result = x*y/y;
                    break;

            }
            return result;
        }
    }

}
