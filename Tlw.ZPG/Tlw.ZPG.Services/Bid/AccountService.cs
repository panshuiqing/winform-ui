using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tlw.ZPG.Domain.Models;
using Tlw.ZPG.Domain.Models.Bid;
using Tlw.ZPG.Services.Common;

namespace Tlw.ZPG.Services.Bid
{
    public class AccountService : ServiceBase<Account>
    {
        public override void Insert(Tlw.ZPG.Domain.Models.Bid.Account entity)
        {
            entity.Apply();
            base.Insert(entity);
        }

        public void SubmitVerify(string randomNumber,string content)
        {
            var account = this.Where(t => t.RandomNumber == randomNumber).FirstOrDefault();
            account.SubmitVerify(content);
        }

        public void VerifyByUser(int userId, string content, VerifyType verifyType)
        {
            var account = this.FindById(userId);
            account.VerifyByUser(userId, content, account.GetAccountName(), verifyType);
        }

        /// <summary>
        /// 发放竞买号
        /// </summary>
        public void GrantApplyNumber(int userId,int accountId)
        {
            var account = this.FindById(accountId);
            var applyNumber = new ApplyNumberService().GetUnUsedApplyNumber();
            account.GrantApplyNumber(userId, applyNumber.Number);
            applyNumber.IsUsed = true;
            applyNumber.UsedTime = DateTime.Now;
            applyNumber.GrantUserId = userId;
        }

        /// <summary>
        /// 冻结竞买号
        /// </summary>
        public void Froze(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            account.Froze(userId);
        }

        /// <summary>
        /// 解冻（恢复）
        /// </summary>
        public void Recover(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            account.Recover(userId);
        }

        public void ResetPassword(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            account.ResetPassword(userId);
        }

        public void LossAccount(int userId, int accountId)
        {
            var account = this.FindById(accountId);
            account.LossAccount(userId);
        }
    }
}
