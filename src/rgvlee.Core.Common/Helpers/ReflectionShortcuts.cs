using System;
using System.Reflection;
using System.Threading.Tasks;

namespace rgvlee.Core.Common.Helpers
{
    public static class ReflectionShortcuts
    {
        private static readonly MethodInfo _taskFromResultMethod = typeof(Task).GetMethod(nameof(Task.FromResult));

        public static readonly MethodInfo StringEqualsMethodWithStringArgument = typeof(string).GetMethod("Equals", new[] { typeof(string) });

        public static MethodInfo TaskFromResultMethod<T>()
        {
            return TaskFromResultMethod(typeof(T));
        }

        public static MethodInfo TaskFromResultMethod(Type type)
        {
            return _taskFromResultMethod.MakeGenericMethod(type);
        }
    }
}