using System;
using System.Collections.Generic;
using System.Text;

namespace NET.S._2018.Haiduk._06
{
    /// <summary>
    /// Public immutable class that describes polynomial of one variable and contains methods for working with it,
    /// and overrides virtual methods of System.Object class.
    /// </summary>
    public class Polynomial
    {                               
        public Polynomial(double variable, int[] coefficients)
        {
            Variable = variable;
            Coefficients = (int[])coefficients.Clone();
        }

        public double Variable { get; private set; }

        public int[] Coefficients { get; private set; }

        public static bool operator ==(Polynomial p1, Polynomial p2) => p1.Variable == p2.Variable && p1.Coefficients == p2.Coefficients;
        
        public static bool operator !=(Polynomial p1, Polynomial p2) => p1.Variable != p2.Variable || p1.Coefficients != p2.Coefficients;
        
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1.Coefficients.Length > p2.Coefficients.Length)
            {
                Polynomial p3 = p1;
                for (int i = 0; i < p1.Coefficients.Length; i++)
                {
                    p3.Coefficients[i] = p1.Coefficients[i] + p2.Coefficients[i];
                    p3.Variable = Math.Pow(p1.Variable, i);
                }

                return p3;
            }
            else
            {
                Polynomial p3 = p2;
                for (int i = 0; i < p2.Coefficients.Length; i++)
                {
                    p3.Coefficients[i] = p1.Coefficients[i] + p2.Coefficients[i];
                    p3.Variable = Math.Pow(p2.Variable, i);
                }

                return p3;
            }
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1.Coefficients.Length > p2.Coefficients.Length)
            {
                Polynomial p3 = p1;
                for (int i = 0; i < p1.Coefficients.Length; i++)
                {
                    p3.Coefficients[i] = p1.Coefficients[i] - p2.Coefficients[i];
                    p3.Variable = Math.Pow(p1.Variable, i);
                }

                return p3;
            }
            else
            {
                Polynomial p3 = p2;
                for (int i = 0; i < p2.Coefficients.Length; i++)
                {
                    p3.Coefficients[i] = p1.Coefficients[i] - p2.Coefficients[i];
                    p3.Variable = Math.Pow(p2.Variable, i);
                }

                return p3;
            }
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1.Coefficients.Length > p2.Coefficients.Length)
            {
                Polynomial p3 = p1;
                for (int i = 0; i < p1.Coefficients.Length; i++)
                {
                    p3.Coefficients[i] = p1.Coefficients[i] * p2.Coefficients[i];
                    p3.Variable = Math.Pow(p1.Variable, i * 2);
                }

                return p3;
            }
            else
            {
                Polynomial p3 = p2;
                for (int i = 0; i < p2.Coefficients.Length; i++)
                {
                    p3.Coefficients[i] = p1.Coefficients[i] * p2.Coefficients[i];
                    p3.Variable = Math.Pow(p2.Variable, i * 2);
                }

                return p3;
            }
        }

        public override bool Equals(object obj)
        {
            var polynomial = obj as Polynomial;
            return polynomial != null &&
                   Variable == polynomial.Variable &&
                   EqualityComparer<int[]>.Default.Equals(Coefficients, polynomial.Coefficients);
        }

        public override int GetHashCode()
        {
            var hashCode = -2027836800;
            hashCode = (hashCode * -1521134295) + Variable.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<int[]>.Default.GetHashCode(Coefficients);
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 2; i < Coefficients.Length; i++)
            {
                stringBuilder.Append($"{Coefficients[i]} * x ^ {i} + ");
            }

            string s = $"{Coefficients[0]} + {Coefficients[1]} * x + {stringBuilder.ToString()}";
            return s.Substring(0, s.Length - 3);
        }
    }
}
