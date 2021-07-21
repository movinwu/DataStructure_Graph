/************************************
* 创建人：movin
* 创建时间：2021/7/3 16:11:36
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接表结构的图
    /// </summary>
    public class AdjacencyListGraph
    {
        /// <summary>
        /// 所有的顶点存储为一个一维数组
        /// </summary>
        public AdjacencyListVertex[] vertices;
        /// <summary>
        /// 顶点数量
        /// </summary>
        public int Count { get; private set; }

        public AdjacencyListGraph(int vertexCount)
        {
            //参数校验不合格抛出参数异常
            if (vertexCount <= 0)
            {
                throw new ArgumentException();
            }
            vertices = new AdjacencyListVertex[vertexCount];
            Count = vertexCount;
        }
        /// <summary>
        /// 添加一条弧
        /// </summary>
        /// <param name="startIndex">起始顶点下标</param>
        /// <param name="endIndex">终点下标</param>
        /// <param name="weight">权重</param>
        public void AddEdgeOrArc(int startIndex, int endIndex, int weight = 1)
        {
            if (startIndex < 0 || endIndex < 0 || startIndex >= Count || endIndex >= Count || weight == int.MaxValue)
            {
                return;
            }
            AddNodeFirst(startIndex, endIndex, weight);
        }
        /// <summary>
        /// 在指定顶点边表末尾添加一条弧
        /// </summary>
        /// <param name="index">顶点下标</param>
        /// <param name="nodeContentIndex">边表结点中保存的下标</param>
        /// <param name="weight">权重</param>
        private void AddNodeLast(int index,int nodeContentIndex,int weight = 1)
        {
            AdjacencyListEdgeNode node = new AdjacencyListEdgeNode(nodeContentIndex, weight, null);
            AdjacencyListEdgeNode temp = vertices[index].firstEdge;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = node;
            //结点对应入度指针++
            vertices[nodeContentIndex].InDegree++;
        }
        /// <summary>
        /// 在指定顶点边表头节点添加一条弧
        /// </summary>
        /// <param name="index">顶点下标</param>
        /// <param name="nodeContentIndex">边表结点中保存的下标</param>
        /// <param name="weight">权重</param>
        private void AddNodeFirst(int index,int nodeContentIndex,int weight = 1)
        {
            AdjacencyListEdgeNode node = new AdjacencyListEdgeNode(nodeContentIndex, weight, null);
            node.next = vertices[index].firstEdge;
            vertices[index].firstEdge = node;
            //结点对应入度指针++
            vertices[nodeContentIndex].InDegree++;
        }
        /// <summary>
        /// 移除一条弧
        /// </summary>
        /// <param name="index"></param>
        /// <param name="nodeContentIndex"></param>
        public void RemoveNode(int index,int nodeContentIndex)
        {
            AdjacencyListEdgeNode current = vertices[index].firstEdge;
            AdjacencyListEdgeNode last = null;
            while (current != null)
            {
                if (current.vertexIndex == nodeContentIndex)
                {
                    RemoveNode(current, last, index);
                    return;
                }
                last = current;
                current = current.next;
            }
        }
        /// <summary>
        /// 移除一条弧
        /// </summary>
        /// <param name="node">移除的node</param>
        /// <param name="last">移除node的上一个node</param>
        /// <param name="vertexIndex">弧结点所在的顶点下标</param>
        private void RemoveNode(AdjacencyListEdgeNode node,AdjacencyListEdgeNode last,int vertexIndex)
        {
            if (last != null)
            {
                last.next = node.next;
            }
            else
            {
                vertices[vertexIndex].firstEdge = null;
            }
            node.next = null;
            //对应入度指针--
            vertices[node.vertexIndex].InDegree--;
        }
    }
}
