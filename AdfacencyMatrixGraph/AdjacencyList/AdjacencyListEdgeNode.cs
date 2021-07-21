/************************************
* 创建人：movin
* 创建时间：2021/7/3 16:34:09
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接表的边表节点
    /// </summary>
    public class AdjacencyListEdgeNode
    {
        /// <summary>
        /// 指向的顶点下标
        /// </summary>
        public int vertexIndex;
        /// <summary>
        /// 权重
        /// </summary>
        public int weight;
        /// <summary>
        /// 下一个节点的指针
        /// </summary>
        public AdjacencyListEdgeNode next;
        public AdjacencyListEdgeNode(int vertexIndex, int weight = 1, AdjacencyListEdgeNode next = null)
        {
            this.vertexIndex = vertexIndex;
            this.weight = weight;
            this.next = next;
        }
    }
}
