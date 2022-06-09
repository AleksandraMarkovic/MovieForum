using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Operation result to be used for passing result and data together from method call
    /// </summary>
    [Serializable]
    [DataContract]
    public class OperationResult : IOperationResult
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public OperationResult()
        {
        }

        /// <summary>
        /// Constructor to be used with exception
        /// </summary>
        /// <param name="e"></param>
        public OperationResult(Exception e)
        {
            Result = false;
            Exception = e;
            Message = e.Message;
        }

        /// <summary>
        /// Operation success result
        /// </summary>
        [DataMember]
        public bool Result { get; set; }

        /// <summary>
        /// In a list of results find if any is true
        /// </summary>
        public bool IsAnyResult
        {
            get
            {
                if (Data is List<OperationResult>)
                {
                    return (Data as List<OperationResult>).Any(r => r.Result);
                }
                else
                {
                    return Result;
                }
            }
        }

        /// <summary>
        /// Custom mesage key to be used in consuming class
        /// </summary>
        [DataMember]
        public string MessageKey { get; set; } = "";

        /// <summary>
        /// Return message to describe result
        /// </summary>
        [DataMember]
        public string Message { get; set; } = "";

        /// <summary>
        /// Return Data resulted from operation
        /// </summary>
        [DataMember]
        public object Data { get; set; }

        /// <summary>
        /// Return data of all operations.
        /// Recommanded content is a list of IOperationResult objects
        /// </summary>
        [DataMember]
        public object AllData { get; set; }

        /// <summary>
        /// Slot for additional data that could be passed to caller
        /// </summary>
        [DataMember]
        public object AditionalData { get; set; }

        /// <summary>
        /// Exception that terminated operation
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Returns empty operation result
        /// </summary>
        public static IOperationResult Empty
        {
            get
            {
                return new OperationResult
                {
                    Result = false,
                    Data = null,
                    Message = "",
                    MessageKey = "",
                    Exception = null
                };
            }
        }

        /// <summary>
        /// Returns empty operation result
        /// </summary>
        public static IOperationResult EmptyOK
        {
            get
            {
                return new OperationResult
                {
                    Result = true,
                    Data = null,
                    Message = "",
                    MessageKey = "",
                    Exception = null
                };
            }
        }

        /// <summary>
        /// Returns error operation result
        /// </summary>
        public static IOperationResult Error(string message, object data = null, Exception exception = null)
        {
            return new OperationResult
            {
                Result = false,
                Data = data,
                Message = message,
                Exception = exception
            };
        }

        /// <summary>
        /// Returns data in positive operation result
        /// </summary>
        public static IOperationResult Success(object data = null, string message = "")
        {
            return new OperationResult
            {
                Result = true,
                Data = data,
                Message = message,
            };
        }

        /// <summary>
        /// Concatenate results
        /// </summary>
        /// <param name="results">Results array</param>
        /// <returns>Operation result object with all operation results in one data object</returns>
        public static IOperationResult Join(params IOperationResult[] results)
        {
            IOperationResult result = new OperationResult
            {
                Result = true,
                Data = null,
                Message = "",
                MessageKey = "",
                Exception = null
            };

            // flatten results into one list
            List<OperationResult> data = new List<OperationResult>();
            foreach (OperationResult r in results)
            {
                if (r.Data is List<OperationResult>)
                {
                    foreach (OperationResult dr in (r.Data as List<OperationResult>))
                    {
                        data.Add(dr);
                    }
                }
                else
                {
                    data.Add(r);
                }
            }

            // all operation results as a list in data property of new operation result 
            result.Data = data;
            result.AllData = data;

            StringBuilder messages = new StringBuilder();
            StringBuilder messagekeys = new StringBuilder();
            int msgCount = 0;
            foreach (OperationResult r in data)
            {
                msgCount++;

                // logicaly add all results 
                result.Result = result.Result && r.Result;

                // concat all messages
                if (!string.IsNullOrEmpty(r.Message))
                    messages.AppendLine(msgCount.ToString() + ". " + r.Message);

                if (!string.IsNullOrEmpty(r.MessageKey))
                    messagekeys.AppendLine(msgCount.ToString() + ". " + r.MessageKey);
            }

            result.Message = messages.ToString();
            result.MessageKey = messagekeys.ToString();

            return result;
        }

        /// <summary>
        /// Data object casted into type T
        /// </summary>
        /// <typeparam name="T">cast to type</typeparam>
        /// <returns></returns>
        public T Get<T>()
        {
            if (Data == null)
                return default(T);

            return (T)Data;
        }

        /// <summary>
        /// Returns string representation of operation result
        /// </summary>
        /// <returns>String representation of operation result</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Result={0}; MessageKey={1}; Message={2};", Result, MessageKey, Message));
            if (Exception != null)
                sb.AppendLine(string.Format("Exception={0}; ", Exception.Message));

            if (AllData != null)
            {
                if (AllData is List<OperationResult>)
                {
                    int count = 0;
                    foreach (OperationResult result in (AllData as List<OperationResult>))
                        sb.AppendLine(string.Format("[result {0}] {1}", ++count, result.ToString()));
                }
                else
                {
                    sb.AppendLine(string.Format("AllData={0}", AllData));
                }
            }

            if (Data != null && AllData != Data)
            {
                sb.AppendLine(string.Format("Data={0}", Data));
            }

            return sb.ToString();
        }

        //public override bool Equals(Object obj)
        //{
        //    if (obj is OperationResult)
        //    {
        //        var that = obj as OperationResult;
        //        return this.Result == that.Result && this.MessageKey == that.MessageKey && this.Message == that.Message;
        //    }

        //    return false;
        //}

    }
}
