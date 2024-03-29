﻿using System;
using System.ComponentModel;

namespace WcfServiceDirectory
{
    public class CallCompleteEventArgs<T> : AsyncCompletedEventArgs
    {
        public CallCompleteEventArgs(T result, AsyncCompletedEventArgs sourceEventArgs)
            : base(sourceEventArgs.Error, sourceEventArgs.Cancelled, sourceEventArgs.UserState)
        {
            Result = result;
        }

        public CallCompleteEventArgs(T result, Exception exception, bool cancelled, object userState)
            : base(exception, cancelled, userState)
        {
            Result = result;
        }

        public T Result { get; private set; }
    }
}
