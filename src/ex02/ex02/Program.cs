using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph kolchugino = new Graph();
            kolchugino.SetKolchugino();
            kolchugino.InputKolchugino();

            Console.WriteLine("\n-- Нахождение кратчайшего пути и расхода топлива на нем --\n");
            Console.WriteLine("Введите расход топлива (литры на 100 км)");
            double consumption = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите начальную точку: ");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную точку: ");
            int end = int.Parse(Console.ReadLine());
            double distance = kolchugino.FindShortestPath(start - 1, end - 1);

            double distanceFuelConsumption = FindFuelConsumption(distance, consumption);

            Console.WriteLine($"Расстояние от точки {start} до точки {end}: {distance} км \nПри этом израсходуется топлива: {distanceFuelConsumption}");
            Console.Read();
        }

        //Метод нахождения расхода топлива
        private static double FindFuelConsumption(double distance, double consumption)
        {
            return (distance * consumption) / 100;
        }
    }
}
