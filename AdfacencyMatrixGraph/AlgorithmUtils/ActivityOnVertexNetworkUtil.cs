/************************************
* 创建人：movin
* 创建时间：2021/7/20 8:35:37
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// AOV网工具,提供对AOV网进行拓扑排序和关键路径计算的方法
    /// </summary>
    public class ActivityOnVertexNetworkUtil
    {
        /// <summary>
        /// 拓扑排序算法
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="findAVertexCallback">将顶点加入拓扑序列后的回调</param>
        /// <returns></returns>
        public static int[] TopologicalSort(AdjacencyListGraph graph,Action<int,AdjacencyListVertex> findAVertexCallback = null)
        {
            //存储运算结果的数组
            int[] topologicalQueue = new int[graph.Count];
            //已经加入数组的顶点下标个数
            int hasFoundCount = 0;
            //已经遍历了边表的顶点个数
            int hasSearchedCount = 0;
            //将所有顶点的入度转存到一个数组中(为了不破坏原有的图数据)
            int[] allInDegree = new int[graph.Count];
            //初始化
            for (int i = 0; i < graph.Count; i++)
            {
                allInDegree[i] = graph.vertices[i].InDegree;
                //将入度为0的下标加入数组中
                if(allInDegree[i] == 0)
                {
                    topologicalQueue[hasFoundCount++] = i;
                }
            }
            
            //循环遍历
            while(hasFoundCount != hasSearchedCount)
            {
                var node = graph.vertices[hasSearchedCount].firstEdge;
                while (node != null)
                {
                    int tempIndex = node.vertexIndex;
                    allInDegree[tempIndex]--;
                    if(allInDegree[tempIndex] == 0)
                    {
                        topologicalQueue[hasFoundCount++] = tempIndex;
                    }
                    node = node.next;
                }
                if(findAVertexCallback != null)
                {
                    findAVertexCallback(hasSearchedCount, graph.vertices[hasSearchedCount]);
                }
                hasSearchedCount++;
            }
            return topologicalQueue;
        }
        /// <summary>
        /// 关键路径算法
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="findAArcCallback">找到一条在关键路径中的边后的回调</param>
        public static void CriticalPath(AdjacencyListGraph graph,Action<int,AdjacencyListEdgeNode> findAArcCallback = null)
        {
            //事件的最早开始时间
            int[] earliestTimeOfVertex = new int[graph.Count];
            //事件的最晚开始时间
            int[] latestTimeOfVertex = new int[graph.Count];
            //对顶点进行拓扑排序,得到排序后的顶点下标
            //顶点拓扑排序的回调函数中就直接遍历求得事件的最早开始时间
            int[] topologicalSortIndex = TopologicalSort(graph, (index, vertex) => 
            {
                //初始化事件的最早开始事件,所有值置为0(可以不初始化,默认初始值就是0)
                //earliestTimeOfVertex[index] = 0;
                //遍历这个顶点的边表
                for(AdjacencyListEdgeNode node = vertex.firstEdge;node != null;node = node.next)
                {
                    int tempEarliestTimeOfVertex = earliestTimeOfVertex[index] + node.weight;
                    if(tempEarliestTimeOfVertex > earliestTimeOfVertex[node.vertexIndex])
                    {
                        earliestTimeOfVertex[node.vertexIndex] = tempEarliestTimeOfVertex;
                    }
                }
                //初始化事件的最晚开始时间,所有值置为最大值
                latestTimeOfVertex[index] = int.MaxValue;
            });
            //拓扑序列最后一个顶点的最晚开始时间等于最早开始时间
            int lastVertexIndex = topologicalSortIndex[topologicalSortIndex.Length - 1];
            latestTimeOfVertex[lastVertexIndex] = earliestTimeOfVertex[lastVertexIndex];
            //逆序遍历拓扑序列,得到最晚开始时间,并计算弧的冗余时间
            for (int i = graph.Count - 2; i >= 0; i--)
            {
                int currentVertexIndex = topologicalSortIndex[i];
                for (AdjacencyListEdgeNode node = graph.vertices[currentVertexIndex].firstEdge;node != null;node = node.next)
                {
                    int tempLatestTimeOfVertex = latestTimeOfVertex[node.vertexIndex] - node.weight;
                    if (tempLatestTimeOfVertex < latestTimeOfVertex[currentVertexIndex])
                    {
                        latestTimeOfVertex[currentVertexIndex] = tempLatestTimeOfVertex;
                    }
                    //计算并判断遍历到的弧的冗余时间
                    //冗余时间为0,这条弧在关键路径上,调用回调函数
                    if(tempLatestTimeOfVertex - earliestTimeOfVertex[currentVertexIndex] == 0 && findAArcCallback != null)
                    {
                        findAArcCallback(currentVertexIndex, node);
                    }
                }
            }
        }
    }
}
