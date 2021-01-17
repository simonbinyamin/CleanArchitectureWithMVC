using mediatR.DomainLayer.Common;
using mediatR.DomainLayer.Entities;

namespace mediatR.DomainLayer.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
