using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Linq.Expressions.Expression;
using System.Text;
using System.Linq;
using System.Collections;

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
        public static BinaryExpression binary(ExpressionType type, Expression left, Expression right) => MakeBinary(type, left, right);

        /// <summary>
        /// creates constant expressions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConstantExpression constant<T>(T value) => Constant(value, typeof(T));
    }

}
