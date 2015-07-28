using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
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

    public class ServiceResult<T> : ServiceResultBase where T : class
    {
        public T Data { get; protected set; }

        /// <summary>
        ///     Static success result
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
        ///     Failed helper method
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

    public class ServiceResult : ServiceResultBase
    {
        public string Message { get; protected set; }

        /// <summary>
        ///     Static success result
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
        ///     Failed helper method
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
}
