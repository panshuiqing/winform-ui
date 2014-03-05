using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;
using Tlw.ZPG.Infrastructure;
using Tlw.ZPG.Services.Common;

namespace Tlw.ZPG.Services
{
    public static class LogerManager
    {
        private static string GetEntityCName(Type type)
        {
            Dictionary<Type, string> map = new Dictionary<Type, string>();
            map[typeof(Affiche)] = "公告";
            map[typeof(Land)] = "宗地";
            map[typeof(TradeResult)] = "公示";
            map[typeof(User)] = "用户";
            
            if (map.ContainsKey(type))
            {
                return map[type];
            }
            return type.Name;
        }

        private static void WriteLog(EntityBase entity, string actionName)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = Application.UserContext.Ip,
                Url = Application.UserContext.Url,
                UserId = Application.UserContext.UserId,
                UserName = Application.UserContext.UserName,
                Remark = actionName + GetEntityCName(entity.GetType()),
                LogType = Domain.Models.Enums.SystemLogType.Default,
            });
        }

        public static void WriteInsertLog(EntityBase entity)
        {
            WriteLog(entity, "新增");
        }

        public static void WriteDeleteLog(EntityBase entity)
        {
            WriteLog(entity, "删除");
        }

        public static void WriteUpdateLog(EntityBase entity)
        {
            WriteLog(entity, "修改");
        }
    }
}
