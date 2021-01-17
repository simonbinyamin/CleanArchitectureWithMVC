using mediatR.DomainLayer.Common;
using System.Threading.Tasks;

namespace mediatR.Business.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
