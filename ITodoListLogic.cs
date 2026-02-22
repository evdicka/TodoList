using System.Collections.Generic;

namespace TodoList;

public interface ITodoListLogic
{
    List<TodoItem> ReadAll();
    void SaveTodoList(List<TodoItem> items);
}