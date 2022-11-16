using System;
using System.Threading.Tasks;
using LabCRUD.DAL.Repositories;
using LabCRUD.Service;
using LabCRUD.Domain.Entity;

namespace LabCRUD
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Create backery\n" +
                                  "2. Read backery\n" +
                                  "3. Update backery\n" +
                                  "4. Delete backery\n" +
                                  "5. Create works\n" +
                                  "6. Read works\n" +
                                  "7. Update works\n" +
                                  "8. Delete works");

                Console.WriteLine("Введите номер задачи:");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        await CreateBackery();
                        break;
                    case "2":
                        await ReadBackery();
                        break;
                    case "3":
                        await UpdateBackery();
                        break;
                    case "4":
                        await DeleteBackery();
                        break;
                    case "5":
                        await CreateWorks();
                        break;
                    case "6":
                        await ReadWorks();
                        break;
                    case "7":
                        await UpdateWorks();
                        break;
                    case "8":
                        await DeleteWorks();
                        break;
                    default:
                        return;
                }
            }
        }
        
        private static async Task CreateBackery()
        {
            var bakery = new BakeryService(new BakeryRepositories());

            Console.WriteLine("Введите номер пекарни:");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();
            
            Console.WriteLine("Введите номер телефона:");
            var number = Console.ReadLine();
            
            Console.WriteLine("Введите улицу:");
            var street = Console.ReadLine();

            Console.WriteLine("Введите номер дома:");
            var house = Console.ReadLine();

            var response = await bakery.CreateBackery(id, name, number, street, house);
            Console.WriteLine(response.Message);
        }
        
        private static async Task ReadBackery()
        {
            var bakery = new BakeryService(new BakeryRepositories());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            var bakeryInfo = (await bakery.GetBackery(name)).Data as Bakery;
            Console.WriteLine(bakeryInfo?.ToString());
        }

        private static async Task UpdateBackery()
        {
            var bakery = new BakeryService(new BakeryRepositories());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите новое имя:");
            var newName = Console.ReadLine();

            var response = await bakery.UpdateBackery(name, newName);
            Console.WriteLine(response.Message);
        }
        
        private static async Task DeleteBackery()
        {
            var bakery = new BakeryService(new BakeryRepositories());
            
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            var response = await bakery.DeleteBackery(name);
            Console.WriteLine(response.Message);
        }

        private static async Task CreateWorks()
        {
            var works = new WorksService(new WorksRepositories());

            Console.WriteLine("Введите уникальный номер услуги:");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите название услуги:");
            var actions = Console.ReadLine();

            Console.WriteLine("Введите имя сотрудника:");
            var worker = Console.ReadLine();

            Console.WriteLine("Введите номер пекарни, в которой данная услуга выполняется:");
            var bakeryId = Convert.ToInt32(Console.ReadLine());

            var response = await works.CreateWorks(id, actions, worker, bakeryId);
            Console.WriteLine(response.Message);
        }

        private static async Task ReadWorks()
        {
            var works = new WorksService(new WorksRepositories());

            Console.WriteLine("Введите название услуги:");
            var name = Console.ReadLine();

            var worksInfo = (await works.GetWorks(name)).Data as Works;
            Console.WriteLine(worksInfo?.ToString());
        }

        private static async Task UpdateWorks()
        {
            var works = new WorksService(new WorksRepositories());

            Console.WriteLine("Введите название услуги:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите новое название услуги:");
            var newName = Console.ReadLine();

            var response = await works.UpdateWorks(name, newName);
            Console.WriteLine(response.Message);
        }

        private static async Task DeleteWorks()
        {
            var works = new WorksService(new WorksRepositories());

            Console.WriteLine("Введите название услуги, которое вы хотите удалить:");
            var name = Console.ReadLine();

            var response = await works.DeleteWorks(name);
            Console.WriteLine(response.Message);
        }
    }
}