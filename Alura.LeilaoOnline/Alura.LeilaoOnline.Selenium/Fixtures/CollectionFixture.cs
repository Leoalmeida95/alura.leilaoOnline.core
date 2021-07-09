using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    [CollectionDefinition("Chrome Drive")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}
