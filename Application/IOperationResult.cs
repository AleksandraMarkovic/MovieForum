using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
        /// <summary>
        /// Operation result interface
        /// </summary>
        public interface IOperationResult
        {
            /// <summary>
            /// Operation success result
            /// </summary>
            bool Result { get; set; }

            /// <summary>
            /// In a list of results find if any is true
            /// </summary>
            bool IsAnyResult { get; }

            /// <summary>
            /// Custom mesage key to be used in consuming class
            /// </summary>
            string MessageKey { get; set; }

            /// <summary>
            /// Return message to describe result
            /// </summary>
            string Message { get; set; }

            /// <summary>
            /// Return Data resulted from operation
            /// </summary>
            object Data { get; set; }

            /// <summary>
            /// Return data of all operations.
            /// Recommanded content is a list of IOperationResult objects
            /// </summary>
            object AllData { get; set; }

            /// <summary>
            /// Exception that terminated operation
            /// </summary>
            Exception Exception { get; set; }

            /// <summary>
            /// Slot for additional data that could be passed to caller
            /// </summary>
            object AditionalData { get; set; }

            /// <summary>
            /// Should return Data object casted into type T
            /// </summary>
            /// <typeparam name="T">cast to type</typeparam>
            /// <returns></returns>
            T Get<T>();
        }
}
