using System;
using System.Collections.Generic;

namespace Server
{
    public class ClientPropertyStore
    {
        private static readonly Product _jbeProduct = new Product
        {
            Id = new Guid("2f184072-c607-45cf-9742-33324123970d"),
            Name = "Job Board Enterprise"
        };

        private static readonly List<Property> clientProperties = new List<Property>
        {
            new Property
            {
                Id = new Guid("ac516792-94fc-4e0c-b39c-59b2fcd58a4e"),
                Client = new Client
                {
                    Id = new Guid("3c0ea81b-5314-4fa8-ade3-18acc1be75d8"),
                    Name = "Madgex",
                    BrandName = "Madgex",
                    Organisation = new Organisation
                    {
                        Id = new Guid("880bd36b-534a-4fb9-b886-0822ceaf9088"),
                        Name = "Madgex Ltd"
                    }                    
                },
                Product = _jbeProduct
            },
            new Property
            {
                Id = new Guid("cda214a4-b909-464b-9593-e76a92a55be2"),
                Client = new Client
                {
                    Id = new Guid("7f89dcc0-aa57-4d22-a96e-3c35a8081009"),
                    Name = "Acme Ltd",
                    BrandName = "Acme Incorported Jobs",
                    Organisation = new Organisation
                    {
                        Id = new Guid("07fea438-3cd4-42d0-b479-9b89d0559ad6"),
                        Name = "Acme Ltd"
                    }
                },
                Product = _jbeProduct
            }
        };

        public IEnumerable<Property> ClientProperties => clientProperties;
    }
}
