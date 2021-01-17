using mediatR.DomainLayer.Common;
using mediatR.DomainLayer.Entities;

namespace mediatR.DomainLayer.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
