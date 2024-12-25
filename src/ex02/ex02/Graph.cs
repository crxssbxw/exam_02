using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02
{
    public class Graph
    {
        public bool[,] adjaencyMatrix; // Матрица смежности
        public double[,] weightMatrix; // Матрица весов
        public static int n = 0; // Количество вершин;

        // Метод для ввода графа
        public void InputGraph()
        {
        }

        // Метод для создания графа Кольчугино
        public void SetKolchugino()
        {
            n = 9;

            adjaencyMatrix = new bool[9, 9] {
                { false,  true, false, false, true, false, false, false, false},
                { true, false, true, false, false, false, false, false, false},
                { false, true, false, true, false, false, false, true, false},
                { false, false, true, false, true, false, true, false, false},
                { true, false, false, true, false, true, false, false, false},
                { false, false, false, false, true, false, true, false, true},
                { false, false, false, true, false, true, false, true, false },
                { false, false, true, false, false, false, true, false, true },
                { false, false, false, false, false, true, false, true, false}
            };
            weightMatrix = new double[n, n];
        }

        public void InputKolchugino()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    weightMatrix[i, j] = 0; // Вся матрица заполняется нулями
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (adjaencyMatrix[i, j] == false || weightMatrix[i, j] != 0) continue;
                    Console.WriteLine($"Введите расстояние | {i + 1} <-> {j + 1} |: "); // Заполнение расстояний между вершинами
                    double distance = Double.Parse(Console.ReadLine());
                    weightMatrix[i, j] = distance;
                    weightMatrix[j, i] = distance;
                }
            }
        }

        // Метод нахождения кратчайшего пути
        public double FindShortestPath(int start, int end)
        {
            double[] distances; //Кратчайшие расстояния;
            distances = Dijkstra(weightMatrix, start);

            double shortest = 0;
            foreach (double dist in distances)
            {
                shortest += dist;
            }
            return shortest;
        }

        // Алгоритм Дейкстры
        private static double[] Dijkstra(double[,] a, int v0)
        {
            double[] dist = new double[n];
            bool[] vis = new bool[n];
            int unvis = n;
            int v;

            for (int i = 0; i < n; i++)
                dist[i] = Double.MaxValue;
            dist[v0] = 0.0;

            while (unvis > 0)
            {
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (vis[i])
                        continue;
                    if ((v == -1) || (dist[v] > dist[i]))
                        v = i;
                }
                vis[v] = true;
                unvis--;
                for (int i = 0; i < n; i++)
                {
                    if (dist[i] > dist[v] + a[v, i])
                        dist[i] = dist[v] + a[v, i];
                }
            }
            return dist;
        }
    }
}
