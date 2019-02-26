using System;

namespace Server
{
    public class Property
    {
        public Guid Id { get; set; }

        public Client Client { get; set; }

        public Product Product { get; set; }
    }
}
