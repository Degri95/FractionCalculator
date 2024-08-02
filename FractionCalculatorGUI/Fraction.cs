using System;

namespace FractionCalculatorGUI
{
    class Fraction
    {
        private int numerator;
        private int denominator; 

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
            
        }

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        { 
            return denominator;
        }

        public void SetNumerator(int num)
        {
            numerator = num;
        }

        public void SetDenominator(int den)
        {
            denominator = den;
        }
        
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }

        public static Fraction Parse(string input)
        {
            Fraction parsedFraction = new Fraction();
            int indexSlash = input.IndexOf("/");
            parsedFraction.SetNumerator(int.Parse(input.Substring(0, indexSlash)));
            parsedFraction.SetDenominator(int.Parse(input.Substring(indexSlash + 1)));

            return parsedFraction;

        }
        public void Enter()
        {
            Console.WriteLine("Enter the numerator: ");
            numerator = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Enter the denominator: ");
                denominator = int.Parse(Console.ReadLine());
            } while (denominator == 0);
        }
        public static Fraction Add(Fraction fracOne, Fraction fracTwo)
        {
            Fraction addedFraction = new Fraction();
            addedFraction.numerator = (fracOne.numerator * fracTwo.denominator) + (fracTwo.numerator * fracOne.denominator);
            addedFraction.denominator = fracOne.denominator * fracTwo.denominator;
            return addedFraction;
        }
        public static Fraction Sub(Fraction fracOne, Fraction fracTwo)
        {
            Fraction subFraction = new Fraction();
            subFraction.numerator = (fracOne.numerator * fracTwo.denominator) - (fracTwo.numerator * fracOne.denominator);
            subFraction.denominator = fracOne.denominator * fracTwo.denominator;
            return subFraction;
        }

        public static Fraction Mult(Fraction fracOne, Fraction fracTwo)
        {
            Fraction multFraction = new Fraction();
            multFraction.numerator = fracOne.numerator * fracTwo.numerator;
            multFraction.denominator = fracOne.denominator * fracTwo.denominator;
            return multFraction;
        }

        public static Fraction Div(Fraction fracOne, Fraction fracTwo)
        {
            //while (fracTwo.numerator == 0)
            //{
            //    Console.WriteLine("Numerator Cannot be Zero, Enter a New Numerator for Fraction Two");
            //    fracTwo.numerator = int.Parse(Console.ReadLine());
            //}

            if (fracTwo.GetDenominator() == 0)
            {
                throw new DivideByZeroException("Can't divide by zero");
            }

            Fraction divFraction = new Fraction();
            
            divFraction.numerator = fracOne.GetNumerator() * fracTwo.GetDenominator();
            divFraction.denominator = fracOne.GetDenominator() * fracTwo.GetNumerator();
            return divFraction;
            
            
            

        }
    }
}
