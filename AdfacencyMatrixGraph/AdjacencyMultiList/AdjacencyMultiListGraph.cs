/************************************
* 创建人：movin
* 创建时间：2021/7/3 19:31:48
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 邻接多重表结构的图
    /// 无向图
    /// </summary>
    public class AdjacencyMultiListGraph
    {
        /// <summary>
        /// 所有的顶点存储为一个一维数组
        /// </summary>
        public AdjacencyMultiListVertex[] vertices;
        /// <summary>
        /// 顶点数量
        /// </summary>
        public int Count { get; private set; }

        public AdjacencyMultiListGraph(int vertexCount)
        {
            //参数校验不合格抛出参数异常
            if (vertexCount <= 0)
            {
                throw new ArgumentException();
            }
            vertices = new AdjacencyMultiListVertex[vertexCount];
            Count = vertexCount;
        }
    }
}
