using mediatR.Business.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace mediatR.Business.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
