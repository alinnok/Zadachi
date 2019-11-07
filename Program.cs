using System;
using Zadachi;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace PROzadachi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("add - добавить задачу;");
            Console.WriteLine("list - просмотр списка задач;");
            Console.WriteLine("byName - поиск задачи по названию;");
            Console.WriteLine("byTag - поиск задачи по тегу;");            
            Console.WriteLine("delete - удалить задачу;");
            Console.WriteLine("exit - выход.");

            var ask = Console.ReadLine();
            
            List<Zadacha> SpisokZadach = new List<Zadacha>();
            
            string path = @"C:\Users\a_kli\PROzadachi\spisok.txt>";
            
            while (ask!="exit")
            {
                switch (ask)
                {  
                    case "add":
                    {                        
                        Zadacha zadachaX = new Zadacha();
                        zadachaX.Id=Guid.NewGuid();
                        Console.WriteLine("Введите название задачи");
                        zadachaX.Name=Console.ReadLine();
                        Console.WriteLine("Введите описание задачи");
                        zadachaX.Description=Console.ReadLine();
                        Console.WriteLine("Введите тэг задачи");
                        zadachaX.Tag=Console.ReadLine();                        
                        zadachaX.Date = DateTime.Now;
                        SpisokZadach.Add(zadachaX);                       
                        
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(zadachaX);
                        }                  
                        Console.WriteLine("Введите команду для продолжения");
                        ask = Console.ReadLine();
                        break;
                    }
                    case "list":
                    {
                        try
                        {
                            using (StreamReader sr = new StreamReader(path))
                                {
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                        }
                        catch
                        {
                            Console.WriteLine("Не удалось считать файл");
                        }
                            foreach (var z in SpisokZadach)
                            {
                            Console.WriteLine("ID: " + z.Id + "\n " + z.Name + " ("+ z.Description + ") Тэг: " + z.Tag + " Дата создания: " + z.Date);
                            
                            }
                        Console.WriteLine("Введите команду для продолжения");
                        ask = Console.ReadLine();
                        
                        break;
                    }
                    case "byName":
                    {   
                        Console.WriteLine("Введите название задачи");
                        var askName = Console.ReadLine();
                        //var selectedZadacha=SpisokZadach.Where(z.name => z.name==askName);
                        var selectedZadacha = from z in SpisokZadach
                                            where z.Name==askName
                                            select z;
                        foreach (var z in selectedZadacha)
                        {
                            Console.WriteLine("ID: " + z.Id + "\n " + z.Name + " ("+ z.Description + ") Тэг: " + z.Tag + " Дата создания: " + z.Date);
                            
                        }
                        Console.WriteLine("Введите команду для продолжения");
                        ask = Console.ReadLine();
                        break;
                    }
                    case "byTag":
                    {   
                        Console.WriteLine("Введите тег");
                        var askTag = Console.ReadLine();
                        var selectedZadacha = from z in SpisokZadach
                                            where z.Tag==askTag
                                            select z;
                        foreach (var z in selectedZadacha)
                        {
                            Console.WriteLine("ID: " + z.Id + "\n " + z.Name + " ("+ z.Description + ") Тэг: " + z.Tag + " Дата создания: " + z.Date);
                            
                        }
                        Console.WriteLine("Введите команду для продолжения");
                        ask = Console.ReadLine();
                        break;
                    }
                    /*case "delete":            
                    {   
                        foreach (var z in SpisokZadach)
                        {
                            Console.WriteLine("ID: " + z.Id + "\n " + z.Name + " ("+ z.Description + ") Тэг: " + z.Tag + " Дата создания: " + z.Date);
                            
                        }
                        Console.WriteLine("Скопируйте ID удаляемой задачи:");
                        var askId = Console.ReadLine();
                        var i=1;
                        foreach (var z in SpisokZadach)
                        {
                            if (Convert.ToString(z.Id)==askId)   
                            {
                                try 
                                {
                                    SpisokZadach.Remove(z);
                                    Console.WriteLine("Задача удалена.");                                    
                                }
                                catch                                
                                {
                                    Console.WriteLine("Задачу удалить невозможно.");
                                }
                                                                
                            }
                            i++;
                        }
                        Console.WriteLine("Введите команду для продолжения");
                        ask = Console.ReadLine();      
                        
                        break;
                    }*/
                    default: 
                    {
                        Console.WriteLine("Набрана неизвестная команда");
                        break;
                    }
                }

            }
        }
    }
}
