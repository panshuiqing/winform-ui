using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Enums;
using Tlw.ZPG.Domain.Models;
using Tlw.ZPG.Domain.Models.Bid;
using Tlw.ZPG.Services.Common;

namespace Tlw.ZPG.Services.Bid
{
    public class AccountService : ServiceBase<Account>
    {
        public override void Insert(Tlw.ZPG.Domain.Models.Bid.Account entity)
        {
            if (entity == null) throw new ServiceException("entity");
            entity.Apply();
            base.Insert(entity);
        }

        /// <summary>
        /// 竞买人提交审核
        /// </summary>
        /// <param name="randomNumber"></param>
        /// <param name="content"></param>
        public void SubmitVerify(string randomNumber)
        {
            var account = this.Where(t => t.RandomNumber == randomNumber).FirstOrDefault();
            if (account == null) throw new ServiceException("随机码不存在");
            account.SubmitVerify();
        }

        /// <summary>
        /// 竞买人提交审核内容
        /// </summary>
        /// <param name="randomNumber"></param>
        /// <param name="content"></param>
        public void SubmitVerify(string randomNumber,string content)
        {
            var account = this.Where(t => t.RandomNumber == randomNumber).FirstOrDefault();
            if (account == null) throw new ServiceException("随机码不存在");
            account.SubmitVerifyContent(content);
        }

        /// <summary>
        /// 挂牌人审核
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="content"></param>
        /// <param name="verifyType"></param>
        public void VerifyByUser(int userId, string content, VerifyType verifyType)
        {
            var account = this.FindById(userId);
            if (account == null) throw new ServiceException("不存在此用户");
            account.VerifyByUser(userId, content, verifyType);
        }

        /// <summary>
        /// 发放竞买号
        /// </summary>
        public void GrantApplyNumber(int userId,int accountId)
        {
            var account = this.FindById(accountId);
            if (account == null) throw new ServiceException("不存在此用户");
            var applyNumber = new ApplyNumberService().GetUnUsedApplyNumber();
            account.GrantApplyNumber(userId, applyNumber.Number);
            applyNumber.IsUsed = true;
            applyNumber.UsedTime = DateTime.Now;
            applyNumber.GrantUserId = userId;
            applyNumber.TradeId = account.TradeId;
        }

        /// <summary>
        /// 冻结竞买号
        /// </summary>
        public void Froze(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            if (account == null) throw new ServiceException("不存在此用户");
            account.Froze(userId);
        }

        /// <summary>
        /// 解冻（恢复）
        /// </summary>
        public void Recover(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            if (account == null) throw new ServiceException("不存在此用户");
            account.Recover(userId);
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        public void ResetPassword(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            if (account == null) throw new ServiceException("不存在此用户");
            account.ResetPassword(userId);
        }

        /// <summary>
        /// 挂失竞买号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="accountId"></param>
        public void LossAccount(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            if (account == null) throw new ServiceException("不存在此用户");
            account.Loss(userId);
        }

        public IList<Account> Find(AccountRequest request)
        {
            if (request.VerifyStatus.HasValue)
            {
                return this.Where(t => t.VerifyStatus == request.VerifyStatus).Page(request).ToList();
            }
            else
            {
                return this.DbSet.Page(request).ToList();
            }
        }
    }
}
