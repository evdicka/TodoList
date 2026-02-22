namespace TodoList;

class Program
{
    static void Main(string[] args)
    {
        Menue m = new Menue(new  TodoListLogic());
        m.Show();
    }
}