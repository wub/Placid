
using System.Collections;
// using FluentAssertions;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using Flurl.Http.Testing;
using Placid;

namespace Placid.UnitTests
{
    public class SmokeTests
    {
        [Fact]
        public void Test_Client()
        {
            using var httpTest = new HttpTest();

            var client = new PlacidClient("placid-foobar");
            client.GenerateImage(new()
            {
                
            });

            httpTest.ShouldNotHaveMadeACall();
        }
    }
}
