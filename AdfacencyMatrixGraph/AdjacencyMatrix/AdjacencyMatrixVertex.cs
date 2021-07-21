/************************************
* 创建人：movin
* 创建时间：2021/7/3 15:57:42
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接矩阵顶点
    /// </summary>
    public struct AdjacencyMatrixVertex
    {
        /// <summary>
        /// 顶点中可以存储数据,目前暂定存储int类型,可以根据需要自行修改
        /// </summary>
        public int Content { get; set; }
        public AdjacencyMatrixVertex(int content)
        {
            Content = content;
        }
    }
}
