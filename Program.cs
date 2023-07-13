using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Xml.Linq;
using System.Reflection.PortableExecutable;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;


namespace ProjectZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Добавяне  на ново животно:");
            Console.WriteLine("2. Промяна на статуса на наличност:");
            Console.WriteLine("3. Проверка на наличността и информация за животното:");
            Console.WriteLine("4. Справка за всички животни:");
            Console.WriteLine("5. Край!");
            Console.WriteLine("Избор на опция:");
            MenuPrint();
            

        }
        static void MenuPrint()
        {

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddAnimal();
                    break;
                case "2":
                    ChangeStatus();
                    break;
                case "3":
                    CheckStatusInfo();
                    break;
                case "4":
                    ReferenceAllAnimals();
                    break;
                case "5":
                    Console.WriteLine("Няма повече опции!!");
                    Console.WriteLine("Извършва се актуализация...");
                    UpdateListOfAnimals();
                    break;
                default:
                    break;
            }

            static void AddAnimal()
            {
                Console.WriteLine("Добавете новото животно: ");
                StreamReader read = new StreamReader("animals.txt");
                string line;
                string info = read.ReadToEnd();
                while ((line = read.ReadLine()) != null)
                {

                    Console.WriteLine(line);

                }
                string newAnimalInfo = Console.ReadLine();
                read.Close();
                StreamWriter write = new StreamWriter("output.txt");
                using (write)
                {

                    write.WriteLine(info);
                    write.WriteLine(newAnimalInfo);

                }


            }

            static void ChangeStatus()
            {
                Console.WriteLine("Въвдете ID и Променете статуса:");
                string Status = "output.txt";
                string animalID = Console.ReadLine();
                string[] status = File.ReadAllLines(Status);
                bool findanimal = false;

                for (int i = 0; i < status.Length; i++)
                {
                    string[] info = status[i].Split(',');
                    if (info[0] == animalID)
                    {
                        findanimal = true;
                        string currentStatus = Console.ReadLine();
                        if (currentStatus == "True" || currentStatus == "False")
                        {
                            bool currentStats = bool.Parse(currentStatus);
                            info[5] = currentStatus.ToString();
                            string newData = string.Join(",", info);
                            status[i] = newData;
                            File.WriteAllLines(Status, status);

                        }
                        else
                        {
                            Console.WriteLine("Невалидно!");
                        }

                        break;
                    }
                }
                if (!findanimal)
                {
                    Console.WriteLine("Грешка!");

                }


            }

            static void CheckStatusInfo()
            {
                Console.WriteLine("Проверете наличнсотта и информацията:");
                StreamReader read = new StreamReader("output.txt");
                string line;
                string animalID = Console.ReadLine();
                List<string> updatedLines = new List<string>();
                while ((line = read.ReadLine()) != null)
                {
                    string[] idx = line.Split(",");
                    if (idx.Length >= 6 && idx[0] == animalID)
                    {
                        string species = idx[1];
                        string name = idx[2];
                        int age = int.Parse(idx[3]);
                        string habitat = idx[4];
                        string availability = idx[5];
                        Console.WriteLine($"{species},{name},{age},{habitat},{availability}");
                    }

                    updatedLines.Add(string.Join(",", idx));
                }
                read.Close();


            }
            static void ReferenceAllAnimals()
            {
                Console.WriteLine("Направете справка:");
                StreamReader reader = new StreamReader("output.txt");
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                reader.Close();


            }


        }
        static void UpdateListOfAnimals()
        {
         
            string inputFile = "animals.txt";
            string outputFile = "output.txt";

            string[] lines = File.ReadAllLines(outputFile);

            File.WriteAllLines(inputFile, lines);
            Console.WriteLine("Актуализацията на входния файл е успешна.");
        }




    }

}
