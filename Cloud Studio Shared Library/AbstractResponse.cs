using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary {
    
    public abstract class AbstractResponse {

        /// <summary>
        /// Gets and sets the success of the response.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets and sets an exception for the response.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets and sets an error for the event.
        /// </summary>
        public EventError EventError { get; set; }

        /// <summary>
        /// Gets and sets an HTTP status code for the response.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }        

        /// <summary>
        /// Creates a new response with success set to true by default.
        /// </summary>
        public AbstractResponse() {

            this.Success = true;

        }

        /// <summary>
        /// Creates an error for the event. The response's success property
        /// is set to false.
        /// </summary>
        /// <param name="error">A description of the error.</param>
        /// <param name="message">A message for the user describing the error.</param>
        public void CreateEventError(string error, string message) {

            this.EventError = new EventError(error, message);
            this.Success = false;

        }

    }

}
