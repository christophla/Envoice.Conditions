using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Envoice.Conditions;
using Shouldly;
using Xunit;

namespace Envoice.Conditions.Tests
{
    /// <summary>
    /// Validates the SR class and the existence of string resources.
    /// </summary>
    public class StringResourcesTests
    {
        private static readonly Type SrType = (
            from conditionType in typeof(Condition).Assembly.GetTypes()
            where conditionType.Name == "SR"
            select conditionType).SingleOrDefault();

        [Fact]
        [Description("This test validates whether the defined string consts in the SR class have a value that equals it's name.")]
        public void Fact01()
        {
            Assert.NotNull(SrType);

            foreach (var field in GetSrStringFields())
            {
                string resourceKey = (string)field.GetValue(null);

                // The value should be equal to it's name. The C# compiler ensures names are unique, and this
                // way we know for sure that the values are also defined once. This prevents the fields
                // pointing at the wrong resource.
                string assertExplanation = String.Format(CultureInfo.InvariantCulture,
                    "Name of SR.{0} should match it's value", field.Name);

                field.Name.ShouldBe(resourceKey); //TODO
            }
        }

        [Fact]
        [Description("This test validates whether the const string fields of the SR class reference an existing string resource.")]
        public void Fact02()
        {
            foreach (var field in GetSrStringFields())
            {
                string resourceKey = (string)field.GetValue(null);
                string resourceValue = GetResourceValue(resourceKey);

                string assertExplanation = String.Format(CultureInfo.InvariantCulture,
                    "The resource with key '{0}' could not be found.", resourceKey);

                resourceValue.ShouldNotBeNullOrWhiteSpace(assertExplanation);
            }
        }

        private static FieldInfo[] GetSrStringFields()
        {
            Assert.NotNull(SrType);

            BindingFlags fieldFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

            var resourceFields =
                from field in SrType.GetFields(fieldFlags)
                where field.FieldType == typeof(string)
                select field;

            resourceFields.Count().ShouldNotBe(0);

            return resourceFields.ToArray();
        }

        private static string GetResourceValue(string resourceKey)
        {
            BindingFlags methodFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            var getStringMethod = SrType.GetMethod("GetString", methodFlags, null, new Type[] { typeof(string) }, null);

            Assert.NotNull(getStringMethod);

            return (string)getStringMethod.Invoke(null, new object[] { resourceKey });
        }
    }
}
