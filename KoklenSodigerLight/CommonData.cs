using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KoklenSodigerLight
{
    public class CommonData
    {
        public static DataTable GetShangpinXinxi()
        {
            return DbHelperSQL.Query("SELECT 商品信息.ID, 商品信息.名称, 商品信息.分类, 商品信息.规格型号, 商品单位.名称 AS 单位名称, 商品信息.条码, 商品信息.单位, 商品信息.品牌, 商品信息.进价, 商品信息.售价, 商品信息.类型, 商品信息.自设编号,isnull(库存明细.数量,0) as 库存数量, 商品信息.是否称重, 商品信息.备注, 商品信息.操作时间, 商品信息.操作用户, 商品信息.状态, 商品分类.名称 AS 分类名称 FROM 商品信息 LEFT OUTER JOIN (select 商品信息,sum(数量) as 数量 from 库存明细 where 状态=1 group by 商品信息 ) AS 库存明细 ON 商品信息.ID = 库存明细.商品信息 LEFT OUTER JOIN 商品单位 ON 商品信息.单位 = 商品单位.ID LEFT OUTER JOIN 商品分类 ON 商品信息.分类 = 商品分类.ID WHERE (商品信息.状态 = 1)").Tables[0];
        }
    }
}
