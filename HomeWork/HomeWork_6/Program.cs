using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Даны две двумерных матрицы размерностью 100х100 каждая. 
 * Задача: написать приложение, производящее их параллельное умножение. 
 * Матрицы заполняются случайными целыми числами от 0 до 10.
 */

namespace HomeWork_6
{
    class Program
    {
        static Random rand = new Random();

        static int matrixSize = 3;
        static int randRange = 10;

        static int[][] matrix1;
        static int[][] matrix2;

        static int[,] matrixResult = new int[matrixSize, matrixSize];

        static void Main(string[] args)
        {
            matrix1 = Enumerable.Range(0, matrixSize)
                .Select(e => Enumerable.Range(0, matrixSize).Select(r => rand.Next(0, randRange)).ToArray())
                .ToArray();

            matrix2 = Enumerable.Range(0, matrixSize)
                .Select(e => Enumerable.Range(0, matrixSize).Select(r => rand.Next(0, randRange)).ToArray())
                .ToArray();


            //TaskMethod();
            //Console.ReadLine();
            TaskMethodAsync();
            Console.ReadLine();
            //UsualMethod();
            //Console.ReadLine();
        }

        static void Multiplication(int rowIndex, int colIndex)
        {
            Console.WriteLine($"ThreadID = {Thread.CurrentThread.ManagedThreadId} TaskID = {Task.CurrentId} start");
            int result = 0;
            for (int i = 0; i < matrixSize; i++)
                result += matrix1[rowIndex][i] * matrix2[i][colIndex];
            

            matrixResult[rowIndex, colIndex] = result;
            Console.WriteLine($"ThreadID = {Thread.CurrentThread.ManagedThreadId} TaskID = {Task.CurrentId} end");
        }

        static void PrintMatrix(int [,] matrix)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        static void TaskMethod()
        {
            var listTasks = new List<Task>();
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    var rowIndex = i;
                    var colIndex = j;
                    listTasks.Add(Task.Run(() => Multiplication(rowIndex, colIndex)));
                }
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения\n");
            Task.WaitAll(listTasks.ToArray());
            Console.WriteLine("\nВсе задачи завершились.");

            PrintMatrix(matrixResult);
        }

        static async void TaskMethodAsync()
        {
            var listTasks = new List<Task>();
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    var rowIndex = i;
                    var colIndex = j;
                    listTasks.Add(Task.Run(() => Multiplication(rowIndex, colIndex)));
                }
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения\n");
            var awaitingAllTask = Task.WhenAll(listTasks);
            await awaitingAllTask;
            Console.WriteLine("\nВсе задачи завершились.");

            PrintMatrix(matrixResult);
        }

        static void UsualMethod()
        {
            //var listTasks = new List<Task>();
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    var rowIndex = i;
                    var colIndex = j;
                   Multiplication(rowIndex, colIndex);
                }
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения\n");
            //Task.WaitAll(listTasks.ToArray());
            Console.WriteLine("\nВсе задачи завершились.");

            PrintMatrix(matrixResult);
        }
    }
}
