using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MB_TEST.unit
{
    public class MBUnitTest
    {
        [Fact]
        public async Task CanGetJsphResponse()
        {
            using (MBTestManager manager = new MBTestManager())
            {
                var posts = await manager.GetPosts();
                Assert.NotEmpty((IEnumerable<JsonPlaceHolderResponse>)posts);
                Assert.True(0 < posts.Count);
            }
        }

        [Fact]
        public void CanFilterJsphList()
        {
            List<JsonPlaceHolderResponse> items = new List<JsonPlaceHolderResponse>
            {
                new JsonPlaceHolderResponse{ Id = 1 },
                new JsonPlaceHolderResponse{ Id = 1 },
                new JsonPlaceHolderResponse{ Id = 1 },
                new JsonPlaceHolderResponse{ Id = 2 },
                new JsonPlaceHolderResponse{ Id = 2 },
                new JsonPlaceHolderResponse{ Id = 3 },
                new JsonPlaceHolderResponse{ Id = 3 },
                new JsonPlaceHolderResponse{ Id = 3 }
            };

            List<JsonPlaceHolderResponse> filteredItems = items.Filter(Predicates.FilterById);
            Assert.Equal(3, filteredItems.Count);
        }
    }
}
