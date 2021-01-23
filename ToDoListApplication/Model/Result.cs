using System;

namespace ToDoListApplication.Model
{
    public abstract class Result<V>
    {
        private Result()
        {
        }

        public abstract void Effect(Action<V> success, Action<String> failure);
        public abstract bool IsFailure();

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

            public override bool IsFailure()
            {
                return true;
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

            public override bool IsFailure()
            {
                return false;
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
