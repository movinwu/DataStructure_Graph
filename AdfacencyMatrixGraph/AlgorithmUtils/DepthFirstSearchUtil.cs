/************************************
* 创建人：movin
* 创建时间：2021/7/4 8:41:02
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 深度优先遍历算法工具
    /// </summary>
    public class DepthFirstSearchUtil
    {
        /// <summary>
        /// 邻接矩阵的深度优先遍历
        /// 访问与给定下标顶点相连通的所有顶点
        /// 无向图
        /// </summary>
        /// <param name="graph">邻接矩阵形式存储的图</param>
        /// <param name="whenVisited">当遍历到顶点后的回调</param>
        /// <param name="whenVisited">记录顶点是否访问过的数组</param>
        /// <param name="index">当前遍历的顶点下标,默认0</param>
        public static void DFS(AdjacencyMatrixGraph graph,Action<AdjacencyMatrixVertex> whenVisited,bool[] visited = null,int index = 0)
        {
            if(visited == null)
            {
                visited = new bool[graph.Count];
            }
            if(index >= graph.Count || index < 0)
            {
                return;
            }
            visited[index] = true;
            if(whenVisited != null)
            {
                whenVisited(graph.vertices[index]);
            }
            for(int i = 0;i < graph.adjacencyMatrix.GetLength(1); i++)
            {
                //在满足条件时才会进入递归,否则终止递归
                if(graph.adjacencyMatrix[index,i] != 0 && !visited[i])
                {
                    DFS(graph, whenVisited, visited, i);
                }
            }
        }
        /// <summary>
        /// 邻接表的深度优先遍历
        /// 访问与给定下标顶点相连通的所有顶点
        /// 无向图
        /// </summary>
        /// <param name="graph">邻接表形式存储的图</param>
        /// <param name="whenVisited">当遍历到顶点后的回调</param>
        /// <param name="visited">记录顶点是否访问过的数组</param>
        /// <param name="index">当前遍历的顶点下标,默认0</param>
        public static void DFS(AdjacencyListGraph graph, Action<AdjacencyListVertex> whenVisited, bool[] visited = null, int index = 0)
        {

            if (visited == null)
            {
                visited = new bool[graph.Count];
            }
            if (index >= graph.Count || index < 0)
            {
                return;
            }
            //递归终止条件
            if (visited[index])
            {
                return;
            }
            visited[index] = true;
            if (whenVisited != null)
            {
                whenVisited(graph.vertices[index]);
            }
            AdjacencyListEdgeNode node = graph.vertices[index].firstEdge;
            //遍历链表的所有结点并递归
            while(node != null)
            {
                DFS(graph, whenVisited, visited, node.vertexIndex);
                node = node.next;
            }
        }
    }
}
