#nullable enable
using System;

namespace Util
{
    public sealed class Result<TResult, TError> : Result<TError>
    {
        public TResult? Value { get; }

        public Result(TResult value)
        {
            Value = value;
            IsSuccess = true;
            Error = default;
        }

        public static Result<TResult, TError> CreateSuccess(TResult value)
        {
            return new Result<TResult, TError>(value);
        }

        public void Match(Action<TResult> onSuccess, Action<TError> onError)
        {
            if (IsSuccess)
                onSuccess(Value!);
            else 
                onError(Error!);
        }
    }

    public class Result<TError>
    {
        public bool IsSuccess { get; protected set; }
        
        public TError? Error { get; protected set; }
        
        protected Result(TError error)
        {
            IsSuccess = false;
            Error = error;
        }

        protected Result()
        {
            IsSuccess = true;
            Error = default;
        }

        public static Result<TError> Ok()
        {
            return new Result<TError>();
        }
        
        public static Result<TError> CreateError(TError error)
        {
            return new Result<TError>(error);
        }

        public void Match(Action onSuccess, Action<TError> onError)
        {
            if (IsSuccess)
                onSuccess();
            else 
                onError(Error!);
        }
        
        public static implicit operator Result<TError>(TError error)
        {
            return CreateError(error);
        }
    }
}