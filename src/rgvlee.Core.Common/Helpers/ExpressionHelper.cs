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
        ///     Creates a method call expression representing a call to an instance method that takes no arguments.
        /// </summary>
        /// <typeparam name="TInstance">The instance type.</typeparam>
        /// <typeparam name="TMethodReturns">The return type of the method being called.</typeparam>
        /// <param name="methodToCall">The method to call.</param>
        /// <returns>A method call expression representing a call to an instance method that takes no arguments.</returns>
        public static Expression<Func<TInstance, TMethodReturns>> CreateMethodCallExpression<TInstance, TMethodReturns>(MethodInfo methodToCall)
        {
            EnsureArgument.IsNotNull(methodToCall, nameof(methodToCall));

            var instance = Expression.Parameter(typeof(TInstance));
            return Expression.Lambda<Func<TInstance, TMethodReturns>>(Expression.Call(instance, methodToCall), instance);
        }

        /// <summary>
        ///     Creates a method call expression representing a call to an instance method that takes the provided arguments.
        /// </summary>
        /// <typeparam name="TInstance">The instance type.</typeparam>
        /// <typeparam name="TMethodReturns">The return type of the method being called.</typeparam>
        /// <param name="methodToCall">The method to call.</param>
        /// <param name="argumentsToPassToMethodBeingCalled">The arguments to pass to the method being called.</param>
        /// <returns>A method call expression representing a call to an instance method that takes the provided arguments.</returns>
        public static Expression<Func<TInstance, TMethodReturns>> CreateMethodCallExpression<TInstance, TMethodReturns>(MethodInfo methodToCall, params Expression[] argumentsToPassToMethodBeingCalled)
        {
            EnsureArgument.IsNotNull(methodToCall, nameof(methodToCall));

            var instance = Expression.Parameter(typeof(TInstance));
            return Expression.Lambda<Func<TInstance, TMethodReturns>>(Expression.Call(instance, methodToCall, argumentsToPassToMethodBeingCalled), instance);
        }
    }
}