/************************************
* 创建人：movin
* 创建时间：2021/7/6 21:39:43
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    public class ShortestPathUtil
    {
        /// <summary>
        /// 最短路径问题-迪杰斯特拉算法
        /// 采用贪心策略,不可靠
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="startIndex">起始顶点下标</param>
        /// <param name="paths">存储最短路径走法的数组,下标的链式存储</param>
        /// <returns>起始点到其他点的最短距离数组</returns>
        public static int[] ShortestPath_Dijkstra(AdjacencyMatrixGraph graph,int startIndex,out int[] paths)
        {
            //数组中没有找过的顶点下标值对应临时最短路径,找过的顶点下标值对应最短路径
            //最后返回的结果数组
            int[] minDistance = new int[graph.Count];
            //存储最短路径的走法,如果要找到开始顶点到某个顶点的最短路径,遍历这个数组即可
            paths = new int[graph.Count];
            //标识顶点是否已经在最短路径中的标志位
            bool[] isSearched = new bool[graph.Count];
            //初始化
            for (int i = 0; i < graph.Count; i++)
            {
                isSearched[i] = false;
                minDistance[i] = graph.adjacencyMatrix[startIndex, i];
            }
            //开始顶点到开始顶点距离为0,已经找过
            isSearched[startIndex] = true;
            paths[0] = startIndex;
            //当前正在找的顶点下标和用来找当前最短距离的临时最小值
            int nowIndex = startIndex;
            int tempMin = int.MaxValue;
            
            //外循环,每次循环找到一个顶点
            for (int i = 1; i < graph.Count; i++)
            {
                tempMin = int.MaxValue;
                //一轮内循环,找到没有找的顶点中的路径的最小值和顶点下标
                for (int j = 0; j < graph.Count; j++)
                {
                    if(!isSearched[j] && minDistance[j] < tempMin)
                    {
                        nowIndex = j;
                        tempMin = minDistance[j];
                    }
                }
                //找到最小值后更新
                //校验最小值顶点没有更新,则说明已经找完了
                if (isSearched[nowIndex])
                {
                    break;
                }
                //更新找到的最小值
                isSearched[nowIndex] = true;
                paths[i] = nowIndex;
                //二轮内循环,更新所有的最小距离
                for(int j = 0;j < graph.Count; j++)
                {
                    //校验顶点没有找过且当前最小顶点到某顶点距离比当前存储的最短距离短,则更新最短距离
                    if(!isSearched[j] && graph.adjacencyMatrix[nowIndex,j] != int.MaxValue && (tempMin + graph.adjacencyMatrix[nowIndex,j]) < minDistance[j])
                    {
                        minDistance[j] = tempMin + graph.adjacencyMatrix[nowIndex, j];
                    }
                }
            }

            return minDistance;
        }
        /// <summary>
        /// 最短路径问题-弗洛伊德算法
        /// 采用动态规划策略
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="paths">任意两个顶点之间的最短路径走法索引表</param>
        /// <returns>任意两个顶点之间的最短路径距离</returns>
        public static int[,] ShortestPath_Floyd(AdjacencyMatrixGraph graph,out int[,] paths)
        {
            //路径数组,存储所有最短走法的路径,其中每个位置存储的都是下一个顶点的下标
            paths = new int[graph.Count, graph.Count];
            //距离数组,存储所有最短走法的距离
            int[,] distances = new int[graph.Count, graph.Count];
            //初始化两个数组
            for (int i = 0; i < graph.Count; i++)
            {
                for (int j = 0; j < graph.Count; j++)
                {
                    paths[i, j] = j;
                    distances[i, j] = graph.adjacencyMatrix[i, j];
                }
            }
            //三层循环,最外层i循环每循环一次是一次迭代
            for (int i = 0; i < graph.Count; i++)
            {
                //内部两层循环是遍历路径数组和距离数组
                for (int j = 0; j < graph.Count; j++)
                {
                    for (int k = 0; k < graph.Count; k++)
                    {
                        //每次判断经过顶点i的距离是否比直接走要短,如果更短则更新距离数组和路径数组
                        if(distances[j,i] != int.MaxValue && distances[i,k] != int.MaxValue && distances[j,k] > distances[j,i] + distances[i, k])
                        {
                            //更新最短距离
                            distances[j, k] = distances[j, i] + distances[i, k];
                            //更新路径,paths[j,k]保存的是从j到k顶点路径中j的下一个顶点
                            //这里更新的意思是将从j到i的最短路径走法中的j的下一个顶点下标赋值给从j到k的最短路径走法中j的下一个顶点下标
                            //因为从j到k的最短路径走法已经是先从j走到i再从i走到k,所以这样赋值即可
                            paths[j, k] = paths[j, i];
                        }
                    }
                }
            }
            return distances;
        }
    }
}
