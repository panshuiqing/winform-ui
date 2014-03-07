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
        private static string GetEntityCName(EntityBase entity)
        {
            var type = entity.GetType();
            Dictionary<Type, string> map = new Dictionary<Type, string>();
            map[typeof(Affiche)] = "公告";
            map[typeof(Land)] = "宗地";
            map[typeof(Trade)] = "宗地";
            map[typeof(TradeResult)] = "公示";
            map[typeof(User)] = "用户";
            map[typeof(FeedBook)] = "投诉";
            map[typeof(GuestBook)] = "留言";
            map[typeof(Download)] = "格式文书下注";
            if (entity is News)
            {
                var news = entity as News;
                if (news.NewsType == NewsType.FAQ)
                {
                    map[typeof(News)] = "常见问题解答";
                }
                else if (news.NewsType == NewsType.Info)
                {
                    map[typeof(News)] = "政策法规资讯";
                }
                else if (news.NewsType == NewsType.QA)
                {
                    map[typeof(News)] = "知识问答";
                }
            }
            
            if (map.ContainsKey(type))
            {
                return map[type];
            }
            return type.Name;
        }

        private static void WriteLog(EntityBase entity, SystemLogType logType)
        {
            var name = GetEntityCName(entity);
            if (!string.IsNullOrEmpty(name))
            {
                SystemLogService service = new SystemLogService();
                service.Insert(new Domain.Models.SystemLog()
                {
                    CreateTime = DateTime.Now,
                    Ip = Application.UserContext.Ip,
                    Url = Application.UserContext.Url,
                    UserId = Application.UserContext.UserId,
                    UserName = Application.UserContext.UserName,
                    Remark = GetActionName(logType) + name,
                    LogType = logType,
                    EntityName = entity.GetType().Name,
                });
            }
        }

        private static string GetActionName(SystemLogType logType)
        {
            string actionName = "其他";
            switch (logType)
            {
                case SystemLogType.Add:
                    actionName = "新增";
                    break;
                case SystemLogType.Delete:
                    actionName = "删除";
                    break;
                case SystemLogType.Update:
                    actionName = "修改";
                    break;
                case SystemLogType.Exception:
                    actionName = "错误、异常";
                    break;
                default:
                    break;
            }
            return actionName;
        }

        public static void WriteInsertLog(EntityBase entity)
        {
            WriteLog(entity, SystemLogType.Add);
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
