using System;
using Xunit;
using Xunit.Abstractions;

using _ = exp.net.ExpNet;
using static exp.net.ExpNet;
using System.Linq.Expressions;
using static fn.net.Fn;

namespace exp.net.tests
{
    public abstract class ExpNetTestsBase : ITestOutputHelper
    {
        protected readonly ITestOutputHelper output;

        ExpNetTestsBase() { }

        public ExpNetTestsBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void WriteLine(string message) => output.WriteLine(message);

        public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
    }

    public class BinaryExpressionTests : ExpNetTestsBase
    {
        public BinaryExpressionTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Binary_expression_sum()
        {
            var adder10 = curry<ExpressionType, Expression, Expression, BinaryExpression>(binary, ExpressionType.Add, constant(10));
            var exp1 = adder10(constant(10));
            var exp2 = adder10(constant(5));

            BinaryExpression sum = binary(ExpressionType.Add, constant(10), constant(10));


        }
    }
}
