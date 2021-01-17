using mediatR.DomainLayer.Common;
using mediatR.DomainLayer.ValueObjects;
using System.Collections.Generic;

namespace mediatR.DomainLayer.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
