/************************************
* 创建人：movin
* 创建时间：2021/7/3 19:33:52
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接多重表顶点
    /// </summary>
    public class AdjacencyMultiListVertex
    {
        /// <summary>
        /// 顶点中可以存储数据,目前暂定存储int类型,可以根据需要自行修改
        /// </summary>
        public int Content { get; set; }
        /// <summary>
        /// 第一个边表节点的指针
        /// </summary>
        public AdjacencyMultiListEdgeNode firstEdge;
        public AdjacencyMultiListVertex(int content, AdjacencyMultiListEdgeNode firstEdge = null)
        {
            Content = content;
            this.firstEdge = firstEdge;
        }
    }
}
