using mediatR.Business.Common.Models;
using mediatR.DomainLayer.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace mediatR.Business.TodoItems.EventHandlers
{
    public class TodoItemCompletedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCompletedEvent>>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;

        public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<TodoItemCompletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("mediatR Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
