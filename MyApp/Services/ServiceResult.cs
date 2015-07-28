using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Services
{
    public abstract class ServiceResultBase
    {
        /// <summary>
        /// Gets the date and time of when this result was created
        /// </summary>
        public DateTime Timestamp { get; protected set; }

        /// <summary>
        /// True if the operation was successful
        /// </summary>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// List of errors
        /// </summary>
        public IEnumerable<string> Errors { get; protected set; }

        protected ServiceResultBase()
        {
            Timestamp = DateTime.UtcNow;
        }
    }

    /// <summary>
    /// Represents the result of a Service action with included success/error data
    /// </summary>
    public class ServiceResult : ServiceResultBase
    {
        public string Message { get; protected set; }

        /// <summary>
        /// Success result
        /// </summary>
        /// <returns></returns>
        public static ServiceResult Success(string message = "")
        {
            var result = new ServiceResult
            {
                Succeeded = true
            };
            return result;
        }

        /// <summary>
        /// Failed result
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static ServiceResult Failed(params string[] errors)
        {
            if (errors.Length == 0)
                throw new Exception("Failed result must contain an error message");

            var result = new ServiceResult
            {
                Succeeded = false,
                Errors = errors
            };
            return result;
        }
    }

    /// <summary>
    /// Represents the result of a Service action with included success/error data and a data payload
    /// </summary>
    public class ServiceResult<T> : ServiceResultBase where T : class
    {
        public T Data { get; protected set; }

        /// <summary>
        /// Success result
        /// </summary>
        /// <returns></returns>
        public static ServiceResult<T> Success(T data)
        {
            var result = new ServiceResult<T>
            {
                Succeeded = true,
                Data = data,
            };
            return result;
        }

        /// <summary>
        /// Failed result
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static ServiceResult<T> Failed(params string[] errors)
        {
            if (errors.Length == 0)
                throw new Exception("Failed result must contain an error message");

            var result = new ServiceResult<T>
            {
                Succeeded = false,
                Errors = errors,
                Data = null
            };
            return result;
        }
    }

    /// <summary>
    /// Represents the result of a Service action with included success/error, and a collection of objects
    /// </summary>
    public class ServiceCollectionResult<T> : ServiceResultBase
    {
        public IEnumerable<T> Data { get; protected set; }
        public int Count { get; protected set; }

        /// <summary>
        /// Creates a success result with a data payload
        /// </summary>
        /// <param name="data">Payload to include with result</param>
        /// <returns></returns>
        public static ServiceCollectionResult<T> Success(IEnumerable<T> data)
        {
            var collection = data as T[] ?? data.ToArray();
            var result = new ServiceCollectionResult<T>
            {
                Succeeded = true,
                Data = collection,
                Count = collection.Count(),
            };
            return result;
        }

        /// <summary>
        /// Creates a failed result with optional error messages
        /// </summary>
        public static ServiceCollectionResult<T> Failed(params string[] errors)
        {
            if (errors.Length == 0)
                throw new Exception("Failed result must contain an error message");

            var result = new ServiceCollectionResult<T>
            {
                Succeeded = false,
                Errors = errors,
            };
            return result;
        }
    }
}
