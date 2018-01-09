using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests
{
    public sealed class PostConditionExceptionTests
    {
        [Fact]
        [Description("Checks whether the default constructor of the PostconditionException constructs the expected exception message.")]
        public void PostConditionExceptionTest02()
        {
            try
            {
                throw new PostconditionException();
            }
            catch (PostconditionException pex)
            {
                pex.Message.ShouldBe("Postcondition failed.");
            }
        }

        // TODO
        // [Fact]
        // [Description("Okay, I admit: This test is simply to get 100% code coverage :-). This method should fail.")]
        // public void PostConditionExceptionTest03()
        // {

        //     Assert.Throws<PostconditionException>(() =>
        //     {
        //         throw new PostconditionException(String.Empty, new Exception());
        //     });

        // }
    }
}
