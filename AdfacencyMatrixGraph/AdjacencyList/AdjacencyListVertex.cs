/************************************
* 创建人：movin
* 创建时间：2021/7/3 16:29:30
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接表顶点
    /// </summary>
    public struct AdjacencyListVertex
    {
        /// <summary>
        /// 顶点中可以存储数据,目前暂定存储int类型,可以根据需要自行修改
        /// </summary>
        public int Content { get; set; }
        /// <summary>
        /// 第一个边表节点的指针
        /// </summary>
        public AdjacencyListEdgeNode firstEdge;
        /// <summary>
        /// 存储入度的指针
        /// </summary>
        public int InDegree { get; set; }
        public AdjacencyListVertex(int content,AdjacencyListEdgeNode firstEdge = null)
        {
            Content = content;
            this.firstEdge = firstEdge;
            InDegree = 0;
        }
    }
}
