using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.Model
{
    public abstract class Result<V>
    {
        private Result()
        {
        }

        public abstract void Effect(Action<V> success, Action<String> failure);

        private class Failure : Result<V>
        {
            private string message;

            internal Failure(String message)
            {
                this.message = message;
            }

            public override void Effect(Action<V> success, Action<string> failure)
            {
                failure(message);
            }
        }

        private class Success : Result<V>
        {
            private V value;

            internal Success(V value)
            {
                this.value = value;
            }

            public override void Effect(Action<V> success, Action<string> failure)
            {
                success(value);
            }
        }

        public static Result<V> failure(String message)
        {
            return new Failure(message);
        }

        public static Result<V> success(V value)
        {
            return new Success(value);
        }
    }
}
