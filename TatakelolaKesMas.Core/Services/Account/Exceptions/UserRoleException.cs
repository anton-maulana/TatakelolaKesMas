﻿// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

namespace TatakelolaKesMas.Core.Services.Account.Exceptions
{
    /// <summary>
    /// Represents errors that occur with user role related operations.
    /// </summary>
    public class UserRoleException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="UserRoleException" /> class.</summary>
        public UserRoleException() : base("A User Role Exception has occured.")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UserRoleException(string? message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleException" /> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference (<see langword="Nothing" /> 
        /// in Visual Basic) if no inner exception is specified.
        /// </param>
        public UserRoleException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
