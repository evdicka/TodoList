using System;
using System.Collections.Generic;
using System.IO;

namespace TodoList;

public class TodoListLogic : ITodoListLogic
{
    
    private string filePath = "TodoList.csv";
    public List<TodoItem> ReadAll()
    {
        List<TodoItem> items = new List<TodoItem>();
        
        if(!File.Exists(filePath))
        {
            return items;
        }
        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                if(values.Length == 5)
                {
                    TodoItem item = new TodoItem
                    {
                        Id = Convert.ToInt32(values[0]),
                        Title = values[1],
                        Description = values[2],
                        IsCompleted = Convert.ToBoolean(values[3]),
                        Created = Convert.ToDateTime(values[4])
                    };
                    items.Add(item);
                }
            }
        }
        return items;
    }

    public void SaveTodoList(List<TodoItem> items)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var item in items)
            {
                string zeile = String.Join(";", item.Id, item.Title, item.Description, item.IsCompleted, item.Created.ToShortDateString());
                sw.WriteLine(zeile);
            }
        }
    }
}