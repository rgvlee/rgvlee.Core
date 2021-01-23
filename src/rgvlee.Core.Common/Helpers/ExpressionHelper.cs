using System;
using System.Linq.Expressions;
using System.Reflection;

namespace rgvlee.Core.Common.Helpers
{
    /// <summary>
    ///     A helper for creating expressions.
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        ///     Creates a method call expression for an instance method that takes no arguments.
        /// </summary>
        /// <typeparam name="TInstance">The instance type.</typeparam>
        /// <typeparam name="TMethodReturns">The method return type.</typeparam>
        /// <param name="methodInfo">The instance method.</param>
        /// <returns>A a method call expression for an instance method that takes no arguments.</returns>
        public static Expression<Func<TInstance, TMethodReturns>> CreateMethodCallExpression<TInstance, TMethodReturns>(MethodInfo methodInfo)
        {
            EnsureArgument.IsNotNull(methodInfo, nameof(methodInfo));

            var parameter = Expression.Parameter(typeof(TInstance));
            return Expression.Lambda<Func<TInstance, TMethodReturns>>(Expression.Call(parameter, methodInfo), parameter);
        }

        /// <summary>
        ///     Creates a method call expression for an instance method that takes the provided arguments.
        /// </summary>
        /// <typeparam name="TInstance">The instance type.</typeparam>
        /// <typeparam name="TMethodReturns">The method return type.</typeparam>
        /// <param name="methodInfo">The instance method.</param>
        /// <param name="arguments">The arguments to pass to the method.</param>
        /// <returns>A a method call expression for an instance method that takes the provided arguments.</returns>
        public static Expression<Func<TInstance, TMethodReturns>> CreateMethodCallExpression<TInstance, TMethodReturns>(MethodInfo methodInfo, params Expression[] arguments)
        {
            EnsureArgument.IsNotNull(methodInfo, nameof(methodInfo));

            var parameter = Expression.Parameter(typeof(TInstance));
            return Expression.Lambda<Func<TInstance, TMethodReturns>>(Expression.Call(parameter, methodInfo, arguments), parameter);
        }
    }
}