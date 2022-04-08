using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class MyCalculator : ICalculator
    {
        public string CalculateExpresion(List<string> expression)
        {
            //1 * 2 / 3
            expression = expression.Where(c => !String.IsNullOrEmpty(c)).ToList();
            double num1 = 0;
            double num2 = 0;
            string Operator = "";

            //3 / 2 * 1 count = 5
            expression.Reverse();
            //1 * 2 / 3
            Stack<String> myStack = new Stack<string>(expression);
            //jest rozny od 1 
            while (myStack.Count != 1)
            {
                //1
                num1 = double.Parse(myStack.Pop());
                // *
                Operator = myStack.Pop();
                // 2
                num2 = double.Parse(myStack.Pop());
                while(myStack.Count>0 && ( myStack.Peek() == "/" || myStack.Peek() == "*")) {
                    var nextOperator = myStack.Pop();
                    var num3 = double.Parse(myStack.Pop());
                    if(nextOperator == "/")
                    {
                        num2 = num2 / num3;
                    }
                    if(nextOperator == "*")
                    {
                        num2 = num2 * num3;
                    }
                }
                if(Operator == "+")
                {
                    myStack.Push((num1 + num2).ToString());
                }
                if (Operator == "-")
                {
                    myStack.Push((num1 - num2).ToString());
                }
                if (Operator == "*")
                {  
                    myStack.Push((num1 * num2).ToString());
                }
                if (Operator == "/")
                {
                    myStack.Push((num1 / num2).ToString());
                }
            }
            return myStack.Pop().ToString();
        }
    }
}
