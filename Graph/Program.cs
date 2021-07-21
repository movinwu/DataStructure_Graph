/************************************
* 创建人：movin
* 创建时间：2021/7/3 15:50:19
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using GraphCore;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdjacencyMatrixGraph mGraph = new AdjacencyMatrixGraph(6, EGraphType.UndirectedGraph);
            //InitMGraph(mGraph);
            /*DepthFirstSearchUtil.DFS(mGraph, (vertex) =>
            {
                Console.Write("  " + vertex.Content);
            },null,1);
            Console.WriteLine();
            BreadthFirstSearchUtil.BFS(mGraph, (vertex) =>
             {
                 Console.Write("  " + vertex.Content);
             }, 1);*/
            /*MinimumCostSpanningTreeUtil.MiniSpanTree_Prim(mGraph, (a, b, c) =>
             {
                 Console.Write(a + "-" + b + ":" + c + "    ");
             });*/
           /* int[,] paths;
            int[,] minDistances = ShortestPathUtil.ShortestPath_Floyd(mGraph, out paths);
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                for (int j = 0; j < paths.GetLength(1); j++)
                {
                    Console.Write(paths[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < paths.GetLength(0); i++)
            {
                for (int j = 0; j < paths.GetLength(1); j++)
                {
                    Console.Write(minDistances[i, j] + " ");
                }
                Console.WriteLine();
            }*/
            AdjacencyListGraph lGraph = new AdjacencyListGraph(10);
            InitLGraph(lGraph);
            ActivityOnVertexNetworkUtil.CriticalPath(lGraph, (startIndex, node) =>
             {
                 Console.WriteLine(startIndex + "---" + node.vertexIndex + "--->" + node.weight);
             });
            /*DepthFirstSearchUtil.DFS(lGraph, (vertex) =>
            {
                Console.Write("  " + vertex.Content);
            }, null, 1);
            Console.WriteLine();
            BreadthFirstSearchUtil.BFS(lGraph, (vertex) =>
            {
                Console.Write("  " + vertex.Content);
            }, 1);*/
            //转存
            /*for(int i = 0;i < mGraph.Count; i++)
            {
                lGraph.vertices[i] = new EdgesetArrayVertex(mGraph.vertices[i].Content);
            }
            List<EdgesetArrayEdgeNode> nodeList = new List<EdgesetArrayEdgeNode>();
            for(int i = 0;i < mGraph.Count; i++)
            {
                for(int j = 0;j < i; j++)
                {
                    if(mGraph.adjacencyMatrix[i,j] != int.MaxValue)
                    {
                        nodeList.Add(new EdgesetArrayEdgeNode(i, j, mGraph.adjacencyMatrix[i, j]));
                    }
                }
            }
            lGraph.edgeNodes = new EdgesetArrayEdgeNode[nodeList.Count];
            for (int i = 0; i < nodeList.Count; i++)
            {
                lGraph.edgeNodes[i] = nodeList[i];
            }
            MinimumCostSpanningTreeUtil.MinSpanTree_Kruskal(lGraph, (a, b, c) =>
            {
                Console.Write(a + "-" + b + ":" + c + "    ");
            });*/
            Console.ReadKey();
        }
        private static void InitMGraph(AdjacencyMatrixGraph mGraph)
        {
            for(int i = 0;i < mGraph.Count; i++)
            {
                mGraph.vertices[i].Content = i + 1;
            }
            mGraph.AddEdgeOrArc(0, 1, 1);
            mGraph.AddEdgeOrArc(0, 2, 12);
            mGraph.AddEdgeOrArc(1, 3, 3);
            mGraph.AddEdgeOrArc(1, 2, 9);
            mGraph.AddEdgeOrArc(2, 3, 4);
            mGraph.AddEdgeOrArc(2, 4, 5);
            mGraph.AddEdgeOrArc(3, 4, 13);
            mGraph.AddEdgeOrArc(4, 5, 4);
            mGraph.AddEdgeOrArc(3, 5, 15);

        }
        private static void InitLGraph(AdjacencyListGraph lGraph)
        {
            for (int i = 0; i < lGraph.Count; i++)
            {
                lGraph.vertices[i].Content = i;
            }
            lGraph.AddEdgeOrArc(0, 1, 3);
            lGraph.AddEdgeOrArc(0, 2, 4);
            lGraph.AddEdgeOrArc(1, 3, 5);
            lGraph.AddEdgeOrArc(1, 4, 6);
            lGraph.AddEdgeOrArc(2, 3, 8);
            lGraph.AddEdgeOrArc(2, 5, 7);
            lGraph.AddEdgeOrArc(3, 4, 3);
            lGraph.AddEdgeOrArc(4, 6, 9);
            lGraph.AddEdgeOrArc(4, 7, 4);
            lGraph.AddEdgeOrArc(5, 7, 6);
            lGraph.AddEdgeOrArc(6, 9, 2);
            lGraph.AddEdgeOrArc(7, 8, 5);
            lGraph.AddEdgeOrArc(8, 9, 3);
        }
    }
}
