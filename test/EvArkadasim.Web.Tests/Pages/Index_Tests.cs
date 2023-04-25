using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace EvArkadasim.Pages
{
    public class Index_Tests : EvArkadasimWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
