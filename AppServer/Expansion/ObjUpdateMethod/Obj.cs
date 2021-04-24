using System;
using System.Collections.Generic;
using System.Text;

namespace Expansion.ObjUpdateMethod
{
    public class Obj
    {
        /// <summary>
        /// 更新对象属性
        /// </summary>
        /// <param name="old_obj">被更新对象(数据库中的数据)</param>
        /// <param name="new_obj">更新对象(前端传来的数据)</param>
        public static void Update(object old_obj, object new_obj)
        {
            Type targetType = old_obj.GetType();
            Type sourceType = new_obj.GetType();
            foreach (var mi in sourceType.GetProperties())
            {
                var des = targetType.GetProperty(mi.Name);
                if (des != null)
                {
                    des.SetValue(old_obj, mi.GetValue(new_obj));
                }
            }
        }
    }
}
