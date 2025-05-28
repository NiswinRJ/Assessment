using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Xml.Schema;


struct Task{
    public string TaskName;
    public string Description;
    int number;
}

public class Todo{
    List<String>li=new List<string>();
    
    public void AddTask(){
        li.Add("Hit the Gym");
        li.Add("Shower");
        li.Add("Learn New Skill");
        li.Add("Do skin care");
        li.Add("Eat Healthy");
        li.Add("Early to bed");
    }

    public virtual void DisplayTasks(){
        Console.WriteLine("Your tasks are...");
        Console.WriteLine();
        foreach(string s in li){
            Console.WriteLine(s);
            
        }
    }
    public void ViewCompletedTasks(){

        List<string> completed=new List<string>();
        completed.Add("Shower");
        completed.Add("Learn New Skill");
        completed.Add("Eat Healthy");
        Console.WriteLine();
        Console.WriteLine("Your Completed Tasks are:");
        Console.WriteLine();
        
        foreach (string s in completed){
            Console.WriteLine(s);
            //completed.Remove(s);
        }
    }

    public virtual void RemoveTasks(){
        li.Remove("Hit the Gym");
    }

}

class Tasks:Todo{
    public override void DisplayTasks()
    {
        Console.WriteLine("Displaying Tasks");
    }

}

public abstract class Manager{
    public abstract void DisplayTasks();
}
   
class Program{
     public static void Main(){


        Todo todo=new Todo() ;

        

        
        todo.AddTask();
        

        
        todo.DisplayTasks();
        
        
        
        todo.RemoveTasks();
        

        
        todo.ViewCompletedTasks();
        

        
        
    }
}


