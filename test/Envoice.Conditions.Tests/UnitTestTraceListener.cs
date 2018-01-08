﻿using System.Diagnostics;
using Xunit;

namespace Envoice.Conditions.Tests
{
    /// <summary>
    /// This trace listener ensures that all failing Debug.Assert and Trace.Assert calls and calls to
    /// Debug.Fail and Trace.Fail are routed to the Assert.Fail call of the Microsoft UnitTesting framework.
    /// </summary>
    public class UnitTestTraceListener : DefaultTraceListener
    {
        /// <summary>
        /// Emits or displays detailed messages and a stack trace for an assertion that always fails.
        /// </summary>
        /// <param name="message">The message to emit or display.</param>
        /// <param name="detailMessage">The detailed message to emit or display.</param>
        public override void Fail(string message, string detailMessage)
        {
            string failMessage = message;

            if (detailMessage != null)
            {
                failMessage += " " + detailMessage;
            }

            Assert.True(false, failMessage);
        }
    }
}
