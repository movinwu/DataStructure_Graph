/************************************
* 创建人：movin
* 创建时间：2021/7/3 17:03:16
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 十字链表顶点
    /// </summary>
    public class OrthogonalListVertex
    {
        /// <summary>
        /// 顶点中可以存储数据,目前暂定存储int类型,可以根据需要自行修改
        /// </summary>
        public int Content { get; set; }
        /// <summary>
        /// 第一个边表节点的指针
        /// </summary>
        public OrthogonalListEdgeNode firstIn;
        /// <summary>
        /// 第一个边表节点的指针
        /// </summary>
        public OrthogonalListEdgeNode firstOut;
        public OrthogonalListVertex(int content, OrthogonalListEdgeNode firstIn = null, OrthogonalListEdgeNode firstOut = null)
        {
            Content = content;
            this.firstIn = firstIn;
            this.firstOut = firstOut;
        }
    }
}
