/************************************
* 创建人：movin
* 创建时间：2021/7/4 15:23:35
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 广度优先遍历算法工具
    /// </summary>
    public class BreadthFirstSearchUtil
    {
        /// <summary>
        /// 邻接矩阵的广度优先遍历
        /// 访问与给定下标顶点相连通的所有顶点
        /// 无向图
        /// </summary>
        /// <param name="graph">图</param>
        /// <param name="whenVisited">访问到顶点后的回调</param>
        /// <param name="startIndex">开始访问的顶点下标</param>
        public static void BFS(AdjacencyMatrixGraph graph, Action<AdjacencyMatrixVertex> whenVisited, int startIndex = 0)
        {
            if(startIndex >= graph.Count || startIndex < 0)
            {
                return;
            }
            //顶点是否访问的标识
            bool[] visited = new bool[graph.Count];
            //是否遍历顶点的关联顶点的标识
            bool[] searched = new bool[graph.Count];
            //存储所有访问到的顶点的栈
            Queue<AdjacencyMatrixVertex> vertexQueue = new Queue<AdjacencyMatrixVertex>();
            //辅助栈,存储之前访问到的所有顶点的对应下标,和存储顶点的栈同存同取
            Queue<int> indexQueue = new Queue<int>();
            //开始结点入栈
            vertexQueue.Enqueue(graph.vertices[startIndex]);
            indexQueue.Enqueue(startIndex);
            visited[startIndex] = true;

            //所有顶点出栈
            while (vertexQueue.Count > 0)
            {
                AdjacencyMatrixVertex vertex = vertexQueue.Dequeue();
                int currentIndex = indexQueue.Dequeue();
                //访问顶点
                if (whenVisited != null)
                {
                    whenVisited(vertex);
                }
                //没有遍历过的情况下
                if (!searched[currentIndex])
                {
                    //遍历此下标顶点的所有关联顶点,没有访问过的入栈
                    for (int i = 0; i < graph.adjacencyMatrix.GetLength(1); i++)
                    {
                        if (graph.adjacencyMatrix[currentIndex, i] != 0 && !visited[i])
                        {
                            vertexQueue.Enqueue(graph.vertices[i]);
                            indexQueue.Enqueue(i);
                            visited[i] = true;
                        }
                    }
                    searched[currentIndex] = true;
                }
                
            }
        }
        /// <summary>
        /// 邻接矩阵的广度优先遍历
        /// 访问与给定下标顶点相连通的所有顶点
        /// 无向图
        /// </summary>
        /// <param name="graph">图</param>
        /// <param name="whenVisited">访问到顶点之后的回调</param>
        /// <param name="startIndex">开始访问的顶点下标</param>
        public static void BFS(AdjacencyListGraph graph, Action<AdjacencyListVertex> whenVisited, int startIndex = 0)
        {
            if (startIndex >= graph.Count || startIndex < 0)
            {
                return;
            }
            //顶点是否访问的标识
            bool[] visited = new bool[graph.Count];
            //是否遍历顶点的关联顶点的标识
            bool[] searched = new bool[graph.Count];
            //存储所有访问到的顶点的栈
            Queue<AdjacencyListVertex> vertexQueue = new Queue<AdjacencyListVertex>();
            //辅助栈,存储之前访问到的所有顶点的对应下标,和存储顶点的栈同存同取
            Queue<int> indexQueue = new Queue<int>();
            //开始结点入栈
            vertexQueue.Enqueue(graph.vertices[startIndex]);
            indexQueue.Enqueue(startIndex);
            visited[startIndex] = true;

            while(vertexQueue.Count > 0)
            {
                AdjacencyListVertex vertex = vertexQueue.Dequeue();
                int currentIndex = indexQueue.Dequeue();
                if(whenVisited != null)
                {
                    whenVisited(vertex);
                }
                if (!searched[currentIndex])
                {
                    //访问边表,将没有访问过的顶点加入队列
                    AdjacencyListEdgeNode node = vertex.firstEdge;
                    do
                    {
                        int vertexIndex = node.vertexIndex;
                        if (!visited[vertexIndex])
                        {
                            vertexQueue.Enqueue(graph.vertices[vertexIndex]);
                            indexQueue.Enqueue(vertexIndex);
                            visited[vertexIndex] = true;
                        }
                        node = node.next;
                    }
                    while (node != null);
                    searched[currentIndex] = true;
                }
            }
        }
    }
}
