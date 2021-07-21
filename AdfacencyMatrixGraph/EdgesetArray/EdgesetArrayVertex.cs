/************************************
* 创建人：movin
* 创建时间：2021/7/3 19:52:55
* 版权所有：个人
***********************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCore
{
    /// <summary>
    /// 边集数组顶点
    /// </summary>
    public class EdgesetArrayVertex
    {
        /// <summary>
        /// 顶点中可以存储数据,目前暂定存储int类型,可以根据需要自行修改
        /// </summary>
        public int Content { get; set; }
        public EdgesetArrayVertex(int content)
        {
            Content = content;
        }
    }
}
