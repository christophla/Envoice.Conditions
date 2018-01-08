using System.Collections;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Helper class that implements <see cref="IEnumerable"/> and can be used to simulate an non-empty
    /// collection.
    /// </summary>
    internal sealed class NonEmptyTestEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            // Return one element
            yield return null;
        }
    }
}
