using System;
using System.Collections.Generic;
using System.Text;

namespace NET.S._2018.Haiduk._06
{
    /// <summary>
    /// Public immutable class that describes polynomial of one variable and contains methods for working with it,
    /// and overrides virtual methods of System.Object class.
    /// </summary>
    public sealed class Polynomial
    {
        private static double epsilon;

        private readonly double[] coefficients = { };

        private int degree;

        static Polynomial()
        {
            try
            {
                epsilon = double.Parse(System.Configuration.ConfigurationSettings.AppSettings["epsilon"]);
            }
            catch (Exception)
            {
                epsilon = 0.000001;
            }            
        }

        /// <summary>
        /// Public constructor for Polynomial
        /// </summary>
        /// <param name="coefficients">Given array of Polynomial coefficients</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
            degree = Degree;
        }

        /// <summary>
        /// Property for Polynomial degree
        /// </summary>
        public int Degree
        {
            get
            {
                if (coefficients.Length == 1)
                {
                    return 0;
                }

                int i;
                for (i = coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(coefficients[i]) > epsilon)
                    {
                        break;
                    }
                }

                return i;
            }
        }

        /// <summary>
        /// Indexer for Polynomial
        /// </summary>
        /// <param name="number">Index for Polynom member</param>
        /// <returns>Member of Polynom by given index</returns>
        public double this[int number]
        {
            get
            {
                if (degree > coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return coefficients[degree];
            }

            private set
            {
                if (number >= 0 || number < coefficients.Length)
                {
                    coefficients[number] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        #region Public Methods
        /// <summary>
        /// Method that overrides operator '==' to compare two Polynomials
        /// </summary>
        /// <param name="p1">1st polynomial</param>
        /// <param name="p2">2nd polynomial</param>
        /// <returns>True if polynomials are equal, else false</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2))
            {
                return true;
            }

            if (p1 is null || p2 is null)
            {
                return false;
            }

            return p1.Equals(p2);
        }

        /// <summary>
        /// Method that overrides operator '!=' to compare two Polynomials
        /// </summary>
        /// <param name="p1">1st polynomial</param>
        /// <param name="p2">2nd polynomial</param>
        /// <returns>True if polynomials are not equal, else false</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2) => !p1.Equals(p2);

        /// <summary>
        /// Method that overrides operator '+' for addition of two Polynomials
        /// </summary>
        /// <param name="p1">1st polynomial</param>
        /// <param name="p2">2nd polynomial</param>
        /// <returns>New polynomial that is sum of given</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            double[] larger = new double[p1.Degree], smaller = new double[p2.Degree];
            ExtractPolynomialCoefficients(p1, p2, ref larger, ref smaller);
            for (int i = 0; i < smaller.Length; i++)
            {
                larger[i] += smaller[i];
            }

            return new Polynomial(larger);
        }

        /// <summary>
        /// Method that overrides operator '-' for substaction of two Polynomials
        /// </summary>
        /// <param name="p1">1st polynomial</param>
        /// <param name="p2">2nd polynomial</param>
        /// <returns>New polynomial that is difference of given</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            double[] larger = new double[p1.Degree], smaller = new double[p2.Degree];
            ExtractPolynomialCoefficients(p1, p2, ref larger, ref smaller);
            for (int i = 0; i < smaller.Length; i++)
            {
                larger[i] -= smaller[i];
            }

            return new Polynomial(larger);
        }

        /// <summary>
        /// Method that overrides operator '*' for multiplication of two Polynomials
        /// </summary>
        /// <param name="p1">1st polynomial</param>
        /// <param name="p2">2nd polynomial</param>
        /// <returns>New polynomial that is result of multiplication of given</returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 is null || p2 is null)
            {
                throw new ArgumentNullException();
            }
                        
            double[] result = new double[p1.coefficients.Length + p2.coefficients.Length];
            for (int i = 0; i < p1.coefficients.Length; i++)
            {
                for (int j = 0; j < p2.coefficients.Length; j++)
                {
                    result[i + j] += p1.coefficients[i] * p2.coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Method that overrides Equals method of System.Object class 
        /// </summary>
        /// <param name="obj">Boxed polynomial to compare with given</param>
        /// <returns>True if polynomials are equal, else false</returns>
        public override bool Equals(object obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            if (!ReferenceEquals(this, obj))
            {
                return false;
            }

            var other = obj as Polynomial;
            if (coefficients.Length != other.coefficients.Length)
            {
                return false;
            }

            for (var i = 0; i < coefficients.Length; i++)
            {
                if (!coefficients[i].Equals(other.coefficients[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method that overrides GetHashCode method of System.Object class
        /// </summary>
        /// <returns>HashCode of polynomial</returns>
        public override int GetHashCode()
        {
            var hashCode = 8179101;
            hashCode = (hashCode * -1521134295) + EqualityComparer<double[]>.Default.GetHashCode(coefficients);
            hashCode = (hashCode * -1521134295) + degree.GetHashCode();
            hashCode = (hashCode * -1521134295) + Degree.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Method that overrides ToString method of System.Object class
        /// </summary>
        /// <returns>String representation of polynomial</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 2; i < coefficients.Length; i++)
            {
                if (coefficients[i] > epsilon)
                {
                    stringBuilder.Append($"{coefficients[i]} * x ^ {i} + ");
                }
                else
                {
                    continue;
                }
            }

            string s = $"{coefficients[0]} + {coefficients[1]} * x + {stringBuilder.ToString()}";
            return s.Substring(0, s.Length - 3);
        }
#endregion

        #region Private Methods
        private static void ExtractPolynomialCoefficients(Polynomial p1, Polynomial p2, ref double[] larger, ref double[] smaller)
        {
            if (p1 is null || p2 is null)
            {
                throw new ArgumentNullException();
            }
            
            Array.Copy(p1.coefficients, larger, larger.Length);
            Array.Copy(p2.coefficients, smaller, smaller.Length);
            if (larger.Length < smaller.Length)
            {
                larger = new double[p2.Degree];
                smaller = new double[p1.Degree];
                Array.Copy(p2.coefficients, larger, larger.Length);
                Array.Copy(p1.coefficients, smaller, smaller.Length);
            }
        }
        #endregion
    }
}
