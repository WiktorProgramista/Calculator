using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface ICalculator
    {
        string CalculateExpresion(List<string> expression);
    }
}
