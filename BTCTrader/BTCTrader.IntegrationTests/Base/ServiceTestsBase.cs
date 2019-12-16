using System.Linq;
using Xunit;

namespace BTCTrader.IntegrationTests.Base
{
    public class ServiceTestsBase : IClassFixture<APIFixture>
    {
        protected APIFixture _fixture;

        public ServiceTestsBase(APIFixture fixture)
        {
            _fixture = fixture;
        }

        protected bool AllPropertiesAreInitialized(object model)
        {
            bool result = false;

            result = model.GetType().GetProperties()
            .Where(pi => pi.PropertyType == typeof(string))
            .Select(pi => (string)pi.GetValue(model))
            .Any(value => !string.IsNullOrEmpty(value));

            return result;
        }
    }
}
