/************************************
* 创建人：movin
* 创建时间：2021/7/3 15:50:19
* 版权所有：个人
***********************************/
using System;

namespace GraphCore
{
    /// <summary>
    /// 邻接矩阵结构的图
    /// </summary>
    public class AdjacencyMatrixGraph
    {
        /// <summary>
        /// 图的类型,有向图或无向图
        /// </summary>
        public EGraphType type;
        /// <summary>
        /// 所有的顶点存储为一个一维数组
        /// </summary>
        public AdjacencyMatrixVertex[] vertices;
        /// <summary>
        /// 邻接矩阵,存储所有顶点的连接信息
        /// </summary>
        public int[,] adjacencyMatrix;
        /// <summary>
        /// 顶点数量
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="vertexCount">顶点数量</param>
        public AdjacencyMatrixGraph(int vertexCount,EGraphType type)
        {
            //参数校验不合格抛出参数异常
            if(vertexCount <= 0)
            {
                throw new ArgumentException();
            }
            vertices = new AdjacencyMatrixVertex[vertexCount];
            adjacencyMatrix = new int[vertexCount, vertexCount];
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if(i == j)
                    {
                        adjacencyMatrix[i, j] = 0;
                    }
                    else
                    {
                        adjacencyMatrix[i, j] = int.MaxValue;
                    }
                }
            }
            Count = vertexCount;
            this.type = type;
        }
        /// <summary>
        /// 添加一条边/弧
        /// </summary>
        /// <param name="startIndex">起始顶点下标</param>
        /// <param name="endIndex">终止顶点下标</param>
        /// <param name="power">权重</param>
        public void AddEdgeOrArc(int startIndex,int endIndex,int weight = 1)
        {
            if (startIndex < 0 || endIndex < 0 || startIndex >= Count || endIndex >= Count || weight == int.MaxValue)
            {
                return;
            }
            switch (type)
            {
                case EGraphType.DirectedGraph:
                    adjacencyMatrix[startIndex, endIndex] = weight;
                    break;
                case EGraphType.UndirectedGraph:
                    adjacencyMatrix[startIndex, endIndex] = weight;
                    adjacencyMatrix[endIndex, startIndex] = weight;
                    break;
            }
        }
    }
}
