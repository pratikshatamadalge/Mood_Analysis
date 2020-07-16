// <copyright file="MoodAnalyserException.cs" company="Bridgelabz">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MoodAnalysis
{
    using System;

    /// <summary>
    /// MoodAnalyser Exception class.
    /// </summary>
    public class MoodAnalyserException : Exception
    {
        /// <summary>
        /// TypeofException declared.
        /// </summary>
        public TypeOfException ExceptionType;

        /// <summary>
        /// Declared string message.
        /// </summary>
        public string Message;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyserException"/> class.
        /// </summary>
        /// <param name="typeOfException">Gives type of exception.</param>
        /// <param name="message">Message.</param>
        public MoodAnalyserException(TypeOfException typeOfException, string message)
            : base(message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Enum for all types of Exception.
        /// </summary>
        public enum TypeOfException
        {
            /// <summary>
            /// Null ponter exception
            /// </summary>
            NULL_POINTER_EXCEPTION,

            /// <summary>
            /// If empty string is passed
            /// </summary>
            EMPTY_STRING_EXCEPTION,

            /// <summary>
            /// If class not found
            /// </summary>
            NO_CLASS_FOUND,

            /// <summary>
            /// If constructor is not defined
            /// </summary>
            NO_CONSTRUCTOR_FOUND,

            /// <summary>
            /// If instance is not created
            /// </summary>
            OBJECT_NOT_CREATED,

            /// <summary>
            /// If non defined constructor parameter is passed.
            /// </summary>
            NO_CONSTRUCTOR_WITH_SUCH_PARAMETER,

            /// <summary>
            /// If method is not defined or present.
            /// </summary>
            NO_METHOD_FOUND,

            /// <summary>
            /// If field is not defined
            /// </summary>
            NO_SUCH_FIELD,
        }
    }
}