using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;
using Tlw.ZPG.Domain.Models.Enums;
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

        private static void WriteLog(EntityBase entity, SystemLogType logType)
        {
            SystemLogService service = new SystemLogService();
            service.Insert(new Domain.Models.SystemLog()
            {
                CreateTime = DateTime.Now,
                Ip = Application.UserContext.Ip,
                Url = Application.UserContext.Url,
                UserId = Application.UserContext.UserId,
                UserName = Application.UserContext.UserName,
                Remark = GetActionName(logType) + GetEntityCName(entity.GetType()),
                LogType = logType,
            });
        }

        private static string GetActionName(SystemLogType logType)
        {
            string actionName = string.Empty;
            switch (logType)
            {
                case SystemLogType.Insert:
                    actionName = "新增";
                    break;
                case SystemLogType.Delete:
                    actionName = "删除";
                    break;
                case SystemLogType.Update:
                    actionName = "修改";
                    break;
                case SystemLogType.Validate:
                    actionName = "验证";
                    break;
                case SystemLogType.Error:
                    actionName = "错误、异常";
                    break;
                default:
                    break;
            }
            return actionName;
        }

        public static void WriteInsertLog(EntityBase entity)
        {
            WriteLog(entity, SystemLogType.Insert);
        }

        public static void WriteDeleteLog(EntityBase entity)
        {
            WriteLog(entity, SystemLogType.Delete);
        }

        public static void WriteUpdateLog(EntityBase entity)
        {
            WriteLog(entity, SystemLogType.Update);
        }
    }
}
