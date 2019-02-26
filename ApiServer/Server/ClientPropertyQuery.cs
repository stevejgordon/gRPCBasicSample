using ClientPropertyEndpoint;
using MediatR;
using System;

namespace Server
{
    public class ClientPropertyQuery : IRequest<PropertyReply>
    {
        public ClientPropertyQuery(string clientPropertyId)
        {
            if (Guid.TryParse(clientPropertyId, out var guidId))
            {
                ClientPropertyId = guidId;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(clientPropertyId));
            }
        }

        public Guid ClientPropertyId { get; }
    }
}
