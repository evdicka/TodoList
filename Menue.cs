namespace TodoList;

public class Menue
{
    private ITodoListLogic tll;

    public Menue(ITodoListLogic tll)
    {
        this.tll = tll;
    }
    public void Show()

    {
        
        int choice = 0;
        while (choice != 5)
        {
            Console.Clear();
            Console.WriteLine("1. Show all Todos");
            Console.WriteLine("2. Create New ToDo");
            Console.WriteLine("3. Mark ToDo as Completed");
            Console.WriteLine("4. Delete ToDo");
            Console.WriteLine("5. Exit");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowAllTodos();
                    break;
                case 2:
                    CreateNewTodo();
                    break;
                case 3:
                    MarkTodoAsCompleted();
                    break;
                case 4:
                    DeleteTodo();
                    break;
            }     
        }
        
        
    }
    
    
    public void ShowAllTodos()
    {
        Console.Clear();
        foreach(var item in tll.ReadAll())
        {
            Console.WriteLine($"ID: {item.Id}");
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Description: {item.Description}");
            Console.WriteLine($"CompleteStatus: {item.IsCompleted}");
            Console.WriteLine($"Created: {item.Created.ToShortDateString()}");
        }
        Console.ReadKey();
    }
    
    public void CreateNewTodo()
    {
        List<TodoItem> items = tll.ReadAll();
        Console.WriteLine("Enter Title:");
        string title = Console.ReadLine();
        Console.WriteLine("Enter Description:");
        string description = Console.ReadLine();
        
        TodoItem newItem = new TodoItem()
        {
            Id = items.Count + 1,
            Title = title,
            Description = description,
            IsCompleted = false
        };
        
        items.Add(newItem);
        tll.SaveTodoList(items);
    }

    public void MarkTodoAsCompleted()
    {
        bool found = false;
        Console.WriteLine("Enter ID of ToDo to mark as completed:");
        int id = Convert.ToInt32(Console.ReadLine());
        List<TodoItem> items = tll.ReadAll();
        foreach (var item in items)
        {
            if (id == item.Id)
            {
                found = true;
                item.IsCompleted = true;
                tll.SaveTodoList(items);
                break;
            }
        }

        if (found)
        {
            Console.WriteLine("ToDo marked as completed.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"ToDo with Id {id} not Found");
            Console.ReadKey();
        }
        
    }

    public void DeleteTodo()
    {
        bool found = false;
        Console.WriteLine("Enter ID of ToDo to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        List<TodoItem> items = tll.ReadAll();
        foreach(var item in items)
        {
            if (id == item.Id)
            {
                found = true;
                items.Remove(item);
                tll.SaveTodoList(items);
                break;
            }
        }
        if (found)
        {
            Console.WriteLine("ToDo deleted.");
            Console.ReadKey();     
        }
        else
        {
            Console.WriteLine($"ToDo with Id {id} not Found");
            Console.ReadKey();
        }
       
    }
}