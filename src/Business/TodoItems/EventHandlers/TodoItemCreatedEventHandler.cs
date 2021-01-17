using mediatR.Business.Common.Models;
using mediatR.DomainLayer.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR.Business.TodoItems.EventHandlers
{
    public class TodoItemCreatedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;

        public TodoItemCreatedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("mediatR Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
