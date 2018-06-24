using Xunit;

namespace Int
{

    
        [CollectionDefinition("Integration test collection")]
        public class TestCollection : ICollectionFixture<TestSetup>
        {
        }
    


}