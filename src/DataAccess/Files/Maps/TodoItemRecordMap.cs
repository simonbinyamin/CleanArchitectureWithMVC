using mediatR.Business.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;
using System.Globalization;

namespace mediatR.DataAccess.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
