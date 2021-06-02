// <copyright file="BusinessLogicException.cs" company="Portable">
// Copyright (c) Portable. All rights reserved.
// </copyright>

namespace Common.Exceptions
{
    using System;

    [Serializable]
    public class ServiceLayerException : Exception
    {
        public ServiceLayerException()
            : base()
        {
        }

        public ServiceLayerException(string message)
            : base(message)
        {
        }

        public ServiceLayerException(string message, Exception inner)
            : base(message, inner)
        {
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected ServiceLayerException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
