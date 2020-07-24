using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace exp.net
{
    public static class ExpNet
    {
        /// <summary>
        /// Generates binary expression
        /// </summary>
        /// <param name="type"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryExpression binary(ExpressionType type, Expression left, Expression right) => Expression.MakeBinary(type, left, right);

        /// <summary>
        /// creates constant expressions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConstantExpression constant<T>(T value) => Expression.Constant(value, typeof(T));
    }
}
