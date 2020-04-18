using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DS_IP92_LR6._2_ZalizchukD
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "input.txt", choice;
            Graph graph = new Graph(file);
            
        }
    }

    class Graph
    {
        private int n, m;
        private int[,] mSmezh;
        private int[] vertexPowers;
        private bool[] visited;

        public Graph(string path)
        {
            StreamReader sr = new StreamReader(path);
            string read = sr.ReadLine();
            string[] temp = read.Split(' ');
            n = Convert.ToInt32(temp[0]);
            m = Convert.ToInt32(temp[1]);
            mSmezh = new int[n, n];
            vertexPowers = new int[n];
            visited = new bool[n];

            for (int i = 0; i < m; i++)
            {
                read = sr.ReadLine();
                temp = read.Split(' ');
                int a = Convert.ToInt32(temp[0]) - 1, b = Convert.ToInt32(temp[1]) - 1;
                mSmezh[a, b] = 1;
                mSmezh[b, a] = 1;
            }

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (mSmezh[i, j] == 1)
                        vertexPowers[i]++;
            
            sr.Close();
        }
        
        private void sortVertexPowers()
        {
            List<int> array = new List<int>();

            int max = vertexPowers.Max();

            while (max > 0)
            {
                for (int i = 0; i < n; i++)
                    if (vertexPowers[i] == max)
                        array.Add(i);

                max--;
            }

            vertexPowers = array.ToArray();
        }

    }
    
}