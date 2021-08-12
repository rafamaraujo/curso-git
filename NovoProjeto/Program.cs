using System;
using NovoProjeto.Entities;
using NovoProjeto.Entities.Enums;
using System.Globalization;

namespace NovoProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Level(Junior / MidLevel / Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salario Base: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, salary, dept);

            Console.WriteLine("Quantos contratos serão adicionados: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Entre com os dados do contrato #" + i);
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Quantidade de horas: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Entre com o mês e ano para calcular o ganho (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Ganhos em " + monthAndYear + ": " + worker.Income(month, year));
        }
    }
}
