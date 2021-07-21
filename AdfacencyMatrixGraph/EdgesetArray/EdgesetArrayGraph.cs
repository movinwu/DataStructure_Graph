/************************************
* 创建人：movin
* 创建时间：2021/7/3 19:50:50
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 边集数组结构的图
    /// 无向图
    /// </summary>
    public class EdgesetArrayGraph
    {
        /// <summary>
        /// 所有的顶点存储为一个一维数组
        /// </summary>
        public EdgesetArrayVertex[] vertices;
        /// <summary>
        /// 所有边集节点存储为一个数组
        /// </summary>
        public EdgesetArrayEdgeNode[] edgeNodes;
        /// <summary>
        /// 顶点数量
        /// </summary>
        public int Count { get; private set; }

        public EdgesetArrayGraph(int vertexCount)
        {
            //参数校验不合格抛出参数异常
            if (vertexCount <= 0)
            {
                throw new ArgumentException();
            }
            vertices = new EdgesetArrayVertex[vertexCount];
        }
    }
}
