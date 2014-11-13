﻿using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KoklenSodigerLight
{
    public class ComonData
    {
        public static DataTable GetShangpinXinxi()
        {
            return DbHelperSQL.Query("SELECT 商品信息.ID, 商品信息.名称, 商品信息.分类, 商品信息.规格型号, 商品单位.名称 AS 单位名称,商品信息.条码, 商品信息.单位, 商品信息.品牌, 商品信息.进价, 商品信息.售价, 商品信息.类型, 商品信息.自设编号, 商品信息.是否称重, 商品信息.备注, 商品信息.操作时间, 商品信息.操作用户, 商品信息.状态, 商品分类.名称 AS 分类名称 FROM  商品信息 LEFT OUTER JOIN 商品单位 ON 商品信息.单位 = 商品单位.ID LEFT OUTER JOIN 商品分类 ON 商品信息.分类 = 商品分类.ID WHERE  (商品信息.状态 = 1)").Tables[0];
        }

        public static DataTable GetFilterDataTable()
        {
            DataSet1 ds1 = new DataSet1();
            ds1.Tables["SearchFilter"].Rows.Add("تاياق كود", "条码");
            ds1.Tables["SearchFilter"].Rows.Add("تاۋار نامى", "名称");
            ds1.Tables["SearchFilter"].Rows.Add("ئۆز كود", "自设编号");
            return ds1.Tables["SearchFilter"];
        }
    }
}
