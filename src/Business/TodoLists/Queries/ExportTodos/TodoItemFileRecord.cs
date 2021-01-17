using mediatR.Business.Common.Mappings;
using mediatR.DomainLayer.Entities;

namespace mediatR.Business.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
