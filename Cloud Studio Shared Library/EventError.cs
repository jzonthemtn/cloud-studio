using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary {
    
    /// <summary>
    /// Represents an error that occurred during the execution
    /// of an event.
    /// </summary>
    public class EventError {

        /// <summary>
        /// Gets and sets the text of the event's error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets and sets the message to be shown to the user
        /// to describe the exception and any fixes or
        /// workarounds.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Creates a new EventError.
        /// </summary>
        /// <param name="error">The text of the error.</param>
        /// <param name="message">A description of the error for the user.</param>
        public EventError(string error, string message) {

            this.Error = error;
            this.Message = message;

        }

        /// <summary>
        /// Returns a string representation of the EventError.
        /// </summary>
        /// <returns>The format is error: message</returns>
        public override string ToString() {

            return this.Error + ": " + this.Message;

        }

    }

}
