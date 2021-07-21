/************************************
* 创建人：movin
* 创建时间：2021/7/4 19:55:02
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 最小生成树算法
    /// </summary>
    public class MinimumCostSpanningTreeUtil
    {
        /// <summary>
        /// 计算最小生成树-普里姆算法
        /// 要求参数必须是一个连通图,此处没有校验参数graph是否是连通图的过程,可自行添加
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="findAEdgeCallBack">找到一条边后的回调函数,参数为边的两个关联点下标和权值</param>
        public static void MiniSpanTree_Prim(AdjacencyMatrixGraph graph,Action<int,int,int> findAEdgeCallBack = null)
        {
            //数组lowcast,数组的长度和顶点的个数一致,数组中每个下标的值和顶点一一对应
            //lowcast的作用有两个,以lowcast[1] = 5为例,意思是当前已经找过的顶点中到1顶点的最短路径权值为5
            //所以作用一是某下标对应值不为0时代表当前已经生成的部分最小生成树到某下标对应顶点的权值最小的边的权值
            //作用二是某下标对应值为0时代表此下标对应顶点已经在最小生成树中,不再参与继续生成最小生成树
            int[] lowcast = new int[graph.Count];
            //数组adjvex,这个数组作用是对应记录lowcast中最小权值边的另一个依附顶点下标(一个依附顶点下标就是lowcast下标)
            int[] adjvex = new int[graph.Count];

            lowcast[0] = 0;//从0号顶点开始生成最小生成树,首先将0号顶点对应位置置为0
            //adjvex[0] = 0;//这句代码加不加都ok,0号位已经加入最小生成树,这个值也就用不上了
            //初始化lowcast数组的其他下标值
            for(int i = 1;i < lowcast.Length; i++)
            {
                //当前最小生成树中只有0号顶点,所以以0号顶点到i号顶点的边的权值就是当前的最小边权值
                lowcast[i] = graph.adjacencyMatrix[0, i];
                //这些边的另一个依附顶点当然是0号顶点
                adjvex[i] = 0;
            }

            //开始计算最小生成树,结果存储到result中

            int min = int.MaxValue;//用来存储找到的最小权值边的权值的临时变量
            int tempIndex = 0;//用来存储即将加入最小生成树的边的顶点(也就是即将加入最小生成树的顶点)的临时变量,另一个顶点存储在adjvex数组中
            //循环length-1次,每次将一个顶点和一条边加入最小生成树中
            for(int i = 1;i < graph.Count; i++)
            {
                //循环在当前的lowcast中找到非0的最小值(到没有找过的顶点中的最小边)
                min = int.MaxValue;
                tempIndex = 0;
                for(int j = 1;j < lowcast.Length; j++)
                {
                    if(lowcast[j] != 0 && lowcast[j] < min)
                    {
                        min = lowcast[j];
                        tempIndex = j;
                    }
                }
                //找到边后调用回调函数
                if(findAEdgeCallBack != null)
                {
                    findAEdgeCallBack(tempIndex, adjvex[tempIndex], lowcast[tempIndex]);
                }
                //更新lowcast数组
                lowcast[tempIndex] = 0;

                //每次延申了最小生成树后需要将lowcast中的值更新,方便下次继续延申最小生成树
                //刚才将下标为tempIndex的顶点和一条边加入了最小生成树,接下来只需要更新这个顶点相关的边即可
                for(int j = 1;j < lowcast.Length;j++)
                {
                    //判断顶点tempIndex和顶点j之间的边
                    //j顶点不在最小生成树中且这条边的权值比lowcast中记录的最小权值要小时
                    //更新到顶点j的最小权值边的权值,并且记录到顶点j的最小权值边的另一个顶点为tempIndex
                    if(lowcast[j] != 0 && lowcast[j] > graph.adjacencyMatrix[tempIndex, j])
                    {
                        lowcast[j] = graph.adjacencyMatrix[tempIndex, j];
                        adjvex[j] = tempIndex;
                    }
                }
            }

        }
        /// <summary>
        /// 计算最小生成树-克鲁斯卡尔算法
        /// 要求参数必须是连通图
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="findAEdgeCallBack">找到一条边后的回调函数,参数为边的两个关联点下标和权值</param>
        public static void MinSpanTree_Kruskal(EdgesetArrayGraph graph, Action<int, int, int> findAEdgeCallBack = null)
        {
            //将边集数组排序
            SortEdgeNode(graph.edgeNodes);
            //声明一个数组,数组下标对应顶点下标
            //数组中值为-1时代表对应顶点还没有加入最小生成树
            //当某个顶点被加入最小生成树后,将数组中对应的下标的值修改,修改后的值指向下一个加入最小生成树的顶点下标
            //如vertices[5] = 7代表5号顶点和7号顶点都在最小生成树中,其中5号顶点的下一个顶点是7号顶点
            //在构建最小生成树的过程中会通过这个数组检验当前边添加进数组是否会构成环
            //分析后面的代码可以知道,最终数组中length-1个值会被修改,刚好对应添加到最小生成树中的length-1条边
            int[] vertices = new int[graph.edgeNodes.Length];
            //数组初始值都为-1
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = -1;
            }

            //下面构建最小生成树

            //循环遍历所有边,一一校验是否可以加入最小生成树
            for (int i = 0; i < graph.edgeNodes.Length; i++)
            {
                EdgesetArrayEdgeNode node = graph.edgeNodes[i];
                int startIndex = GetNextVertex(vertices, node.headIndex);
                int endIndex = GetNextVertex(vertices, node.tailIndex);
                //检验是否成环,不成环则这条边可以加入最小生成树
                if (startIndex != endIndex)
                {
                    vertices[startIndex] = endIndex;
                    if(findAEdgeCallBack != null)
                    {
                        findAEdgeCallBack(node.headIndex, node.tailIndex, node.weight);
                    }
                }
            }
        }
        /// <summary>
        /// 在vertices中,顶点之间的先后次序最终的存储方式类似于一颗倒过来的树,根顶点在最下方,存储时会一直向下找,直到找到根顶点,存储时会将下一个存储到最小生成树中的顶点挂到根顶点下方成为新的根顶点
        /// 查找时看此顶点是否有后继顶点,如果有那么继续查找后继顶点的后继顶点...以此类推,直到某个顶点对应下标值为-1,即没有后继顶点,返回这个顶点下标
        /// 如果两个顶点之间会构成环路,那么它们所在的顶点的后继中一定会有相同的顶点,最终查找下去得到的值为顶点相同
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int GetNextVertex(int[] vertices,int index)
        {
            while(vertices[index] != -1)
            {
                index = vertices[index];
            }
            return index;
        }
        /// <summary>
        /// 将给定边集数组按照从小到达排序
        /// 采用选择排序
        /// </summary>
        /// <param name="graph"></param>
        private static void SortEdgeNode(EdgesetArrayEdgeNode[] edgeNodes)
        {
            for (int i = 0; i < edgeNodes.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < edgeNodes.Length; j++)
                {
                    if(edgeNodes[minIndex].weight > edgeNodes[j].weight)
                    {
                        minIndex = j;
                    }
                }
                if(minIndex != i)
                {
                    EdgesetArrayEdgeNode temp = edgeNodes[i];
                    edgeNodes[i] = edgeNodes[minIndex];
                    edgeNodes[minIndex] = temp;
                }
            }
        }
    }
}
