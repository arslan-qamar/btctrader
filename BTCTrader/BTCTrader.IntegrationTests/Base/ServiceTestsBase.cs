using System;
using System.Collections.Generic;
using Xunit;

namespace BTCTrader.IntegrationTests.Base
{
    public class ServiceTestsBase : IClassFixture<ServiceTestsSystem>
    {
        protected ServiceTestsSystem System;

        public ServiceTestsBase(ServiceTestsSystem system)
        {
            System = system;
        }

        protected bool AllPropertiesAreInitialized(object model, List<string> optionalProperties = null)
        {
            optionalProperties = optionalProperties == null ? new List<string>() : optionalProperties;

            var props = model.GetType().GetProperties();

            foreach (var prop in props)
            {
                string val = Convert.ToString(prop.GetValue(model));
                Assert.True(optionalProperties.Contains(prop.Name) || !string.IsNullOrEmpty(val), $"Model : {model.GetType().Name} Property {prop.Name} has value: {val} . It should not be null or empty.");
            }
            return true;
        }
    }
}
