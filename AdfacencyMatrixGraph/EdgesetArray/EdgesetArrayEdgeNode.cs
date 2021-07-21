/************************************
* 创建人：movin
* 创建时间：2021/7/3 19:52:23
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 边集数组的边表节点
    /// </summary>
    public class EdgesetArrayEdgeNode
    {
        /// <summary>
        /// 尾节点下标
        /// </summary>
        public int tailIndex;
        /// <summary>
        /// 头节点下标
        /// </summary>
        public int headIndex;
        /// <summary>
        /// 权重
        /// </summary>
        public int weight;
        public EdgesetArrayEdgeNode(int tailIndex, int headIndex, int weight = 0)
        {
            this.tailIndex = tailIndex;
            this.headIndex = headIndex;
            this.weight = weight;
        }
    }
}
