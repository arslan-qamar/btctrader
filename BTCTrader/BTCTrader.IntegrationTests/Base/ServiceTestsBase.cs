using System;
using System.Collections.Generic;
using Xunit;

namespace BTCTrader.IntegrationTests.Base
{
    public class ServiceTestsBase : IClassFixture<ServiceTestsFixture>
    {
        protected ServiceTestsFixture _fixture;

        public ServiceTestsBase(ServiceTestsFixture fixture)
        {
            _fixture = fixture;
        }

        protected bool AllPropertiesAreInitialized(object model, List<string> optionalFields = null)
        {
            optionalFields =  optionalFields == null ? new List<string>() : optionalFields;
            
            var props = model.GetType().GetProperties();

            foreach(var prop in props)
            {
                string val = Convert.ToString(prop.GetValue(model));
                Assert.True(optionalFields.Contains(prop.Name) || !string.IsNullOrEmpty(val), $"Model : {model.GetType().Name} Property {prop.Name} has value: {val} . It should not be null or empty.");
            }
            return true;
        }
    }
}
