// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimulatedFailureException.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.Diagnostics.Domain
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Custom exception to use for testing failures in a way that is easy to identify later.
    /// </summary>
    [Serializable]
    public class SimulatedFailureException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulatedFailureException"/> class.
        /// </summary>
        public SimulatedFailureException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulatedFailureException"/> class.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected SimulatedFailureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulatedFailureException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public SimulatedFailureException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimulatedFailureException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public SimulatedFailureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}