public class Result<T>
    {
        private Result(StatusTypeEnum status, string message = null)
        {
            this.Status = status;
            this.Message = message;
        }

        private Result(StatusTypeEnum status, T entity, string message = null)
        {
            this.Status = status;
            this.Entity = entity;
            this.Message = message;
        }

        private Result(StatusTypeEnum status, T entity, Uri uri, string message = null)
        {
            this.Status = status;
            this.Message = message;
            this.Entity = entity;
            this.Uri = uri;
        }

        public T Entity { get; }

        /// <summary>
        /// Message that will be sent on the Response Body
        /// </summary>
        public string Message { get; set; }

        public StatusTypeEnum Status { get; }
        public Uri Uri { get; set; }

        /// <summary>
        /// An object was created
        /// </summary>
        /// <param name="entity">Created entity</param>
        /// <returns></returns>
        public static Result<T> Created(T entity)
        {
            return new Result<T>(StatusTypeEnum.Created, entity);
        }

        /// <summary>
        /// An object was created and you can see the result at the specified Uri
        /// </summary>
        /// <param name="entity">Created entity</param>
        /// <param name="uri">Entity details Uri</param>
        /// <returns></returns>
        public static Result<T> Created(T entity, Uri uri)
        {
            return new Result<T>(StatusTypeEnum.Created, entity, uri);
        }

        /// <summary>
        /// An object was created and you can see the result at the specified Uri with a personalized message
        /// </summary>
        /// <param name="entity">Created entity</param>
        /// <param name="uri">Entity details Uri</param>
        /// <param name="message">Message</param>
        /// <returns></returns>
        public static Result<T> Created(T entity, Uri uri, string message)
        {
            return new Result<T>(StatusTypeEnum.Created, entity, uri, message);
        }

        /// <summary>
        /// The process failed but is not an error, please verify your parameters
        /// </summary>
        /// <param name="message">Detailed Error</param>
        /// <returns></returns>
        public static Result<T> Failed(string message = null)
        {
            return new Result<T>(StatusTypeEnum.Failed, message);
        }

        /// <summary>
        /// The process failed but is not an error, please verify your parameters
        /// </summary>
        /// <param name="entity">Expected object</param>
        /// <param name="message">Detailed Error</param>
        /// <returns></returns>
        public static Result<T> Failed(T entity, string message)
        {
            return new Result<T>(StatusTypeEnum.Failed, entity, message);
        }

        /// <summary>
        /// Used when the user is authenticated but has not permissions
        /// </summary>
        /// <returns></returns>
        public static Result<T> Forbidden()
        {
            return new Result<T>(StatusTypeEnum.Forbidden);
        }

        /// <summary>
        /// Should be used for URLs not objects
        /// </summary>
        /// <returns></returns>
        public static Result<T> NotFound()
        {
            return new Result<T>(StatusTypeEnum.NotFound);
        }

        /// <summary>
        /// Process executed succesfully without returning any object
        /// </summary>
        /// <returns></returns>
        public static Result<T> Ok()
        {
            return new Result<T>(StatusTypeEnum.Ok);
        }

        /// <summary>
        /// Process executed succesfully returning an object based on the call
        /// </summary>
        /// <param name="entity">Expected Object</param>
        /// <returns></returns>
        public static Result<T> Ok(T entity)
        {
            return new Result<T>(StatusTypeEnum.Ok, entity);
        }

        /// <summary>
        /// Process executed succesfully returning an object based on the call and a description
        /// </summary>
        /// <param name="entity">Expected Object</param>
        /// <param name="message">Server Message</param>
        /// <returns></returns>
        public static Result<T> Ok(T entity, string message = null)
        {
            return new Result<T>(StatusTypeEnum.Ok, entity, message);
        }

        /// <summary>
        /// Used when the user is not authenticated
        /// </summary>
        /// <returns></returns>
        public static Result<T> Unauthorized()
        {
            return new Result<T>(StatusTypeEnum.Unauthorized);
        }
    }
