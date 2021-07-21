/************************************
* 创建人：movin
* 创建时间：2021/7/3 19:36:26
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接多重表边表节点
    /// </summary>
    public class AdjacencyMultiListEdgeNode
    {
        /// <summary>
        /// 关联顶点i下标
        /// </summary>
        public int iVertexIndex;
        /// <summary>
        /// 指向i的下一个节点的指针
        /// </summary>
        public AdjacencyMultiListEdgeNode iLinkNext;
        /// <summary>
        /// 关联顶点j下标
        /// </summary>
        public int jVertexIndex;
        /// <summary>
        /// 指向j的下一个节点的指针
        /// </summary>
        public AdjacencyMultiListEdgeNode jLinkNext;
        /// <summary>
        /// 权重
        /// </summary>
        public int weight;
        public AdjacencyMultiListEdgeNode(int iVertexIndex,int jVertexIndex,AdjacencyMultiListEdgeNode iLinkNext = null,AdjacencyMultiListEdgeNode jLinkNext = null,int weight = 0)
        {
            this.iVertexIndex = iVertexIndex;
            this.weight = weight;
            this.iLinkNext = iLinkNext;
            this.jVertexIndex = jVertexIndex;
            this.jLinkNext = jLinkNext;
        }
        /// <summary>
        /// 获取下一个边表节点
        /// </summary>
        /// <param name="index">获取下一个边表节点的顶点下标</param>
        /// <returns></returns>
        public AdjacencyMultiListEdgeNode GetNextEdgeNode(int index)
        {
            if(index == iVertexIndex)
            {
                return iLinkNext;
            }
            if(index == jVertexIndex)
            {
                return jLinkNext;
            }
            return null;
        }
    }
}
