using System.Collections;
using Xunit;

namespace Envoice.Conditions.Tests.CollectionTests
{
    /// <summary>
    /// Helper class that implements <see cref="IEnumerable"/> and can be used to simulate an empty collection.
    /// </summary>
    internal sealed class EmptyTestEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield break;
        }
    }
}
