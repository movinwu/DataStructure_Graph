/************************************
* 创建人：movin
* 创建时间：2021/7/3 17:04:45
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 十字链表的边表节点
    /// </summary>
    public class OrthogonalListEdgeNode
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
        /// 下一个入节点的指针
        /// </summary>
        public OrthogonalListEdgeNode headNext;
        /// <summary>
        /// 下一个出节点的指针
        /// </summary>
        public OrthogonalListEdgeNode tailNext;
        public OrthogonalListEdgeNode(int vertexIndex, int weight = 0, OrthogonalListEdgeNode headNext = null, OrthogonalListEdgeNode tailNext = null)
        {
            this.vertexIndex = vertexIndex;
            this.weight = weight;
            this.headNext = headNext;
            this.tailNext = tailNext;
        }
    }
}
