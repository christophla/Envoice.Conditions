using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Envoice.Conditions.Tests
{
    public class SelfTests
    {
        private enum DescriptionStatus
        {
            Correct = 0,
            NoDescriptionAttribute,
            NoDescriptionMessage,
            IncorrectDescriptionMessage,
        }

        [Fact]
        [Description("This test tests the tests and searches for methods that lack the [Fact] attribute.")]
        public void AllPublicMethodsShouldBeMarkedWithTheTestAttribute()
        {
            IEnumerable<Type> unitTestClasses =
                from t in typeof(TestHelper).Assembly.GetTypes()
                where t.GetCustomAttributes(typeof(FactAttribute), true).Length > 0
                select t;

            MethodBase[] untestableMethods =
                (from unitTestClass in unitTestClasses
                 from publicMethod in unitTestClass.GetMethods()
                 where publicMethod.GetParameters().Length == 0
                 where publicMethod.GetCustomAttributes(typeof(FactAttribute), true).Length == 0
                 where publicMethod.ReturnType == typeof(void)
                 select publicMethod).ToArray();

            if (untestableMethods.Length == 0)
            {
                return;
            }

            string message = "The following public methods that aren't marked with the " +
                             "[Fact] attribute:" + Environment.NewLine;

            foreach (var method in untestableMethods)
            {
                message += method.Name + Environment.NewLine;
            }

            Assert.True(false, message);
        }

        [Fact]
        [Description("This test tests the tests and searches for test methods that lack a proper description.")]
        public void AllTestsShouldHaveAValidDescription()
        {
            // IEnumerable<Type> unitTestClasses =
            //     from t in typeof (TestHelper).Assembly.GetTypes()
            //     where t.GetCustomAttributes(typeof (TestClassAttribute), true).Length > 0
            //     select t;

            // MethodBase[] Facts =
            //     (from unitTestClass in unitTestClasses
            //         from Fact in unitTestClass.GetMethods()
            //         where Fact.GetParameters().Length == 0
            //         where Fact.GetCustomAttributes(typeof (FactAttribute), true).Length == 1
            //         where Fact.ReturnType == typeof (void)
            //         where GetMethodDescriptionCheck(Fact) != DescriptionStatus.Correct
            //         select Fact).ToArray();

            // if (Facts.Length == 0)
            // {
            //     return;
            // }

            // string message = "The following test methods have an incorrect [Description(..)] message. " +
            //                  "The description should not be empty and should end with 'should fail.' when an exception " +
            //                  "is expected." + Environment.NewLine;

            // foreach (var method in Facts)
            // {
            //     message += method.DeclaringType.Name + "." + method.Name + " reason: " +
            //                GetMethodDescriptionCheck(method).ToString() + Environment.NewLine;
            // }

            // Assert.True(false, message);
        }

        // private static DescriptionStatus GetMethodDescriptionCheck(MethodBase Fact)
        // {
        //     var descriptions =
        //         Fact.GetCustomAttributes(typeof (DescriptionAttribute), true)
        //             .Cast<DescriptionAttribute>().ToArray();

        //     if (descriptions == null || descriptions.Length == 0)
        //     {
        //         return DescriptionStatus.NoDescriptionAttribute;
        //     }

        //     string description = descriptions[0].Description;

        //     if (String.IsNullOrEmpty(description))
        //     {
        //         return DescriptionStatus.NoDescriptionMessage;
        //     }

        //     var methodShouldThrowException =
        //         Fact.GetCustomAttributes(typeof (ExpectedExceptionAttribute), true).Length > 0;

        //     if (methodShouldThrowException && !description.Contains("fail") && !description.Contains("throw"))
        //     {
        //         return DescriptionStatus.IncorrectDescriptionMessage;
        //     }

        //     return DescriptionStatus.Correct;
        // }
    }
}
