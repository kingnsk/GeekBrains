using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Buffers;
using System.Text.Json;
using System.Collections;

namespace lesson5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "tasks.json";
            int i=0;
            string status,json;

            List<ToDoClass> ToDoList = new List<ToDoClass>();
            
            if (File.Exists(filename))
            {
                Console.WriteLine("Файл task.json существует, читаем список задач...");
                json = File.ReadAllText(filename);
                ToDoList = JsonSerializer.Deserialize<List<ToDoClass>>(json);
            } 
            else
            {
                //Создаем базовый список задач
                ToDoList.Add(new ToDoClass() { Title = "Задание 1", IsDone = false });
                ToDoList.Add(new ToDoClass() { Title = "Задание 2", IsDone = false });
                ToDoList.Add(new ToDoClass() { Title = "Задание 3", IsDone = false });
                ToDoList.Add(new ToDoClass() { Title = "Задание 4", IsDone = true });
                ToDoList.Add(new ToDoClass() { Title = "Задание 5", IsDone = false });
            }

            //Выводим список задач
            foreach(ToDoClass toDo in ToDoList)
            {
                status=toDo.IsDone ? "[х]" : "[ ]";
                Console.WriteLine($"{status} {i}: Задача: {toDo.Title} Статус: {toDo.IsDone}");
                i++;
            }

            Console.WriteLine("Введите номер задачи:");
            int number = Convert.ToInt32(Console.ReadLine());
            ToDoList[number].IsDone = true;

            i = 0;
            foreach (ToDoClass toDo in ToDoList)
            {
                status = toDo.IsDone ? "[х]" : "[ ]";
                Console.WriteLine($"{status} {i}: Задача: {toDo.Title} Статус: {toDo.IsDone}");
                i++;
            }

            json = JsonSerializer.Serialize(ToDoList);
            File.WriteAllText(filename, json);

        }
    }
}