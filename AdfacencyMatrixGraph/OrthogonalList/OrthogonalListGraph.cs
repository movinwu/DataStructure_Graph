/************************************
* 创建人：movin
* 创建时间：2021/7/3 17:14:46
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 十字链表结构的图
    /// 有向图
    /// </summary>
    public class OrthogonalListGraph
    {
        /// <summary>
        /// 所有的顶点存储为一个一维数组
        /// </summary>
        public OrthogonalListVertex[] vertices;
        /// <summary>
        /// 顶点数量
        /// </summary>
        public int Count { get; private set; }

        public OrthogonalListGraph(int vertexCount)
        {
            //参数校验不合格抛出参数异常
            if (vertexCount <= 0)
            {
                throw new ArgumentException();
            }
            vertices = new OrthogonalListVertex[vertexCount];
            Count = vertexCount;
        }
    }
}
