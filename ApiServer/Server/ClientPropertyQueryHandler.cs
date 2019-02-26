using ClientPropertyEndpoint;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ClientPropertyQueryHandler : IRequestHandler<ClientPropertyQuery, PropertyReply>
    {
        private readonly ClientPropertyStore _store;

        public ClientPropertyQueryHandler(ClientPropertyStore store)
        {
            _store = store;
        }

        public Task<PropertyReply> Handle(ClientPropertyQuery request, CancellationToken cancellationToken)
        {
            var property = _store.ClientProperties.FirstOrDefault(x => x.Id == request.ClientPropertyId);
               
            if (property != null)
            {                
                return Task.FromResult(new PropertyReply
                {
                    ClientName = property.Client.Name,
                    OrganisationName = property.Client.Organisation.Name,
                    ProductName = property.Product.Name
                });
            }

            return Task.FromResult((PropertyReply)null);
        }
    }
}
