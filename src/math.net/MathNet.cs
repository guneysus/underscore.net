using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace math.net
{
    public static class MathNet
    {
        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="ir">interest rate per month</param>
        /// <param name="np">number of periods (months)</param>
        /// <param name="pv">present value</param>
        /// <param name="fv">future value</param>
        /// <param name="type">
        /// when the payments are due:
        ///       *        0: end of the period, e.g.end of month(default)
        ///       *        1: beginning of period
        /// </param>
        /// <returns></returns>
        [Pure]
        public static decimal PMT(double ir, int np, decimal pv, decimal fv = 0, int type = 0)
        {
            /*
              from: https://stackoverflow.com/a/22385930/1766716
               * ir   - interest rate per month
               * np   - number of periods (months)
               * pv   - present value
               * fv   - future value
               * type - when the payments are due:
               *        0: end of the period, e.g. end of month (default)
               *        1: beginning of period
               */
            if (ir == 0)
            {
                return -(pv + fv) / np;
            }

            decimal pvif = (decimal)Math.Pow(1 + ir, np);
            decimal pmt = (-(decimal)ir * pv * (pvif + fv)) / (pvif - 1);

            if (type == 1)
            {
                pmt /= 1 + (decimal)ir;
            }

            return pmt;
        }


        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static decimal floor(decimal number)
        {
            return Math.Floor(number);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static double floor(double number)
        {
            return Math.Floor(number);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        [Pure]
        public static decimal round(decimal number, int precision)
        {
            return Math.Round(number, precision);
        }

        /// <summary>
        /// TODO #doc #test
        /// </summary>
        /// <param name="number"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        [Pure]
        public static double round(double number, int precision)
        {
            return Math.Round(number, precision);
        }

        /// <summary>
        /// TODO #doc
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Pure]
        public static int factorial(int number)
        {
            IEnumerable<int> source = Enumerable.Range(1, number);
            return source.Aggregate((a, b) => a * b);
        }

        public static decimal percentage(decimal value, decimal percent) => value * percent / 100.0m;
        public static decimal percentage(decimal value, float percent) => value * Convert.ToDecimal(percent) / 100.0m;
        public static decimal percentage(decimal value, double percent) => value * Convert.ToDecimal(percent) / 100.0m;

        public static Func<decimal, decimal> percentage(decimal percent) => value => value * percent / 100.0m;
        public static Func<decimal, decimal> percentage(float percent) => value => value * Convert.ToDecimal(percent) / 100.0m;
        public static Func<decimal, decimal> percentage(double percent) => value => value * Convert.ToDecimal(percent) / 100.0m;
    }
}
