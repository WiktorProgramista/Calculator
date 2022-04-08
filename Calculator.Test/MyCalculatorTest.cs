using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Calculator.Test
{
    public class CalculatorTestInput
    {
        public List<string> Expresion { get; set; }
        public double Result { get; set; }
        public CalculatorTestInput(List<String> exprestion, double result)
        {
            Expresion = exprestion;
            Result = result;
        }

    }

    public class Tests
    {
        ICalculator calculator;
        private static readonly List<CalculatorTestInput> validInputs = new List<CalculatorTestInput> {
            new CalculatorTestInput(new List<string>{"2","+","2"},4),
            new CalculatorTestInput(new List<string>{"2","*","2"},4),
            new CalculatorTestInput(new List<string>{"2","/","2"},1),
            new CalculatorTestInput(new List<string>{"2","-","2"},0),
            new CalculatorTestInput(new List<string>{"2","*","2", "+", "2"},6),
            new CalculatorTestInput(new List<string>{"2","/","2", "-", "2"},-1),
            new CalculatorTestInput(new List<string>{"2","+","2", "*", "2"},6),
            new CalculatorTestInput(new List<string>{"2","+","2", "/", "2"},3),
            new CalculatorTestInput(new List<string>{"2","-","2", "*", "2"},-2),
            new CalculatorTestInput(new List<string>{"2","-","2", "/", "2"},1),
            new CalculatorTestInput(new List<string>{"2","*","0"},0),
            new CalculatorTestInput(new List<string>{"2","+","0"},2),
            new CalculatorTestInput(new List<string>{"2","-","0"},2),
            new CalculatorTestInput(new List<string>{"2","+","2", "*", "2", "*", "2"},10),
            new CalculatorTestInput(new List<string>{"2","+","2", "/", "2", "/", "2"},2.5),
        };

        [SetUp]
        public void Setup()
        {
            calculator = new MyCalculator();
        }

        [Test]
        [TestCaseSource("validInputs")]
        public void For_Valid_Expresion_Returns_Valid_Result(CalculatorTestInput input)
        {
            var x = calculator.CalculateExpresion(input.Expresion);
            Assert.AreEqual(x, input.Result);
        }
        [Test]
        public void When_In_Expresion_Is_Zero_Division_Exception_Is_Thrown()
        {
            Assert.Throws<InvalidOperationException>(() => calculator.CalculateExpresion(new List<String> { "2", "/", "0" }));
        }
    }
}