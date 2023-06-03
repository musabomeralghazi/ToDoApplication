using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean isNotExit = true;

            while (isNotExit)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("| Welcome to our Todo application. |");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Please select one option from the following:");

                Console.WriteLine("[1] Add Task.");
                Console.WriteLine("[2] List all tasks.");
                Console.WriteLine("[3] Search for Task.");
                Console.WriteLine("[4] Delete Task.");
                Console.WriteLine("[5] Exit.");

                String cmd = Console.ReadLine();

                if(cmd.Equals("5"))
                {
                    isNotExit = false;
                }

                if(cmd.Equals("1"))
                {
                    Console.WriteLine("Please enter the name of the task: ");

                    String taskName = Console.ReadLine();
                    TaskManager.addTask(taskName);

                    Console.WriteLine("Your Task with name "+taskName+" has been created successfully.");

                }

                if(cmd.Equals("2"))
                {
                    ArrayList tasks = TaskManager.listAllTasks();
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Task task = (Task)tasks[i];
                        Console.WriteLine("("+i+") "+task.printTask());
                    }

                }

                if (cmd.Equals("4"))
                {
                    Console.WriteLine("Please give us the name of the task to be deleted: ");

                    String taskName = Console.ReadLine();
                    int delTask = TaskManager.deleteTask(taskName);
                    if (delTask == 0)
                    {
                        Console.WriteLine("Your Task with name " + taskName + " has been deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Your Task with name " + taskName + " is not in the list.");
                    }
                }

                if (cmd.Equals("3"))
                {
                    Console.WriteLine("Please give us the name of the task to seach for it: ");

                    String taskName = Console.ReadLine();
                    int searchTask = TaskManager.searchForTask(taskName);
                    if (searchTask == -1)
                    {
                        Console.WriteLine("Your Task with name " + taskName + " does not exist.");
                    }
                    else
                    {
                        Console.WriteLine("Your Task with name " + taskName + " has index value "+searchTask+" in the list.");
                    }
                }
                
            }
        }
    }

    class Task
    {
        public String name;
        public Task(String n)
        {
            name = n;
        }

        public String printTask()
        {
            return name;
        }
    }

    static class TaskManager
    {
       private static ArrayList tasks = new ArrayList();

        public static void addTask(String name)
        {
            Task task = new Task(name);
            tasks.Add(task);
               
        }

        public static int deleteTask(String name)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Task task = (Task)tasks[i];
                if (task.name.Equals(name))
                {
                    tasks.RemoveAt(i);
                    return 0;
                }
            }
            return -1;
        }

        public static int searchForTask(String name)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Task task = (Task)tasks[i];
                if (task.name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }

        public static ArrayList listAllTasks()
        {
            return tasks;
        }
    }
}
