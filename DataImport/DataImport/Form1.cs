using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tlw.ZPG.Domain.Models.Trading;
using Tlw.ZPG.Infrastructure.DbContext;

namespace DataImport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.progressBar1.Visible = false;
            this.label1.Text = "数据迁移提示：\r\n1、本工具为招拍挂旧数据迁移到新系统，迁移成功后请不要再使用此工具；\r\n2、其中本工具不会导入补充公告，补充公告需要手动录入。";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtNewDb.Text))
            {
                MessageBox.Show("原数据库连接字符串不能为空");
                return;
            }
            if (string.IsNullOrEmpty(this.txtOldDb.Text))
            {
                MessageBox.Show("新数据库连接字符串不能为空");
                return;
            }
            Import_Affiche();
        }

        private EFDbContext GetDbContext()
        {
            return new Configuration(this.txtNewDb.Text).AddAssembly("Tlw.ZPG.Domain.dll").BuildDbContextFactory().GetDbContext();
        }

        private void Import_Affiche()
        {
            try
            {
                var db = GetDbContext();
                string sql = @"select t1.*,t2.AfficheNum,t2.AfficheOther,t2.AffichePassCode,t2.AffichePassUnit,t2.Require
                        from afficheall t1
                        left join AfficheContent t2 on t1.AfficheId=t2.AfficheId 
                        order by allid";
                var dt = GetTableBySelectSql(sql);
                var query = dt.AsEnumerable().GroupBy((r) => { return (int)r["AfficheId"]; }).ToList();
                foreach (var item in query)
                {
                    var afficheId = item.Key;
                    if (item.Count() == 1)
                    {
                        //没有补充的公告，补充公告需要手动录入
                        Affiche affiche = CreateAffiche(item.First());
                        SetAfficheContent(affiche);
                        db.Set<Affiche>().Add(affiche);
                        db.SaveChanges();
                    }
                    else if (item.Count() == 2)
                    {
                        var first = item.First();
                        Affiche affiche = CreateAffiche(item.First());
                        SetAfficheContent(affiche);
                        db.Set<Affiche>().Add(affiche);
                        db.SaveChanges();
                        var second = item.Skip(1).First();
                        var affiche_bc = CreateAfficheBC(second);
                        affiche_bc.ParentId = affiche.ID;
                        affiche_bc.Content = second["Content"].ToString();
                        //SetAfficheContent(affiche_bc);
                        db.Set<Affiche>().Add(affiche_bc);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.StackTrace + Environment.NewLine + ex.Message);
            }
        }

        private Affiche CreateAffiche(DataRow dr)
        {
            Affiche affiche = new Affiche();
            affiche.AfficheNumber = dr["AfficheNum"].ToString();
            affiche.CountyId = Convert.ToInt32(dr["CountyId"]);
            affiche.CreateTime = Convert.ToDateTime(dr["CreateDatetime"]);
            affiche.CreatorId = Convert.ToInt32(dr["CreatorId"]);
            affiche.AfficheType = "网上交易公告";
            affiche.ComeForm = dr["ComeForm"].ToString();
            affiche.IsRelease = Convert.ToInt32(dr["IsRelease"]) == 1;
            affiche.Notice = dr["Notice"].ToString();
            affiche.OtherContent = dr["afficheOther"].ToString();
            affiche.QualificationRequire = dr["Require"].ToString();
            affiche.RatificationNumber = dr["AffichePassCode"].ToString();
            affiche.RatificationOrg = dr["AffichePassUnit"].ToString();
            affiche.ReleaseTime = Convert.ToDateTime(dr["updatedatetime"]);
            if (dr["ReleasedateTime"] != DBNull.Value)
            {
                affiche.UpdateTime = Convert.ToDateTime(dr["ReleasedateTime"]);
            }
            affiche.SellModel = "网上挂牌";
            affiche.SignBeginTime = Convert.ToDateTime(dr["SignBeginTime"]);
            affiche.SignEndTime = Convert.ToDateTime(dr["SignEndTime"]);
            affiche.TradeBeginTime = Convert.ToDateTime(dr["TradeBeginTime"]);
            affiche.TradeEndTime = Convert.ToDateTime(dr["TradeEndTime"]);
            affiche.Title = dr["Title"].ToString();
            affiche.VerifyStatus = Tlw.ZPG.Domain.Enums.AfficheVerifyStatus.None;
            return affiche;
        }

        private Affiche CreateAfficheBC(DataRow dr)
        {
            var affiche = CreateAffiche(dr);
            string sql = "select * from AfficheAlertMsg where Afficheid=" + dr["Afficheid"];
            var dt = GetTableBySelectSql(sql);
            if (dt.Rows.Count > 0)
            {
                affiche.AfficheNumber = dt.Rows[0]["AfficheNum"].ToString();
                affiche.RatificationNumber = dt.Rows[0]["AffichePassNum"].ToString();
                affiche.RatificationOrg = dt.Rows[0]["AffichePassUnit"].ToString();
            }
            return affiche;
        }

        private DataTable GetTableByTableName(string tableName)
        {
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM " + tableName, this.txtOldDb.Text);
            DataTable dt = new DataTable(tableName);
            adapter.Fill(dt);
            return dt;
        }

        private DataTable GetTableBySelectSql(string sql)
        {
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(sql, this.txtOldDb.Text);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private void SetAfficheContent(Affiche affiche)
        {
           var templete = System.IO.File.ReadAllText("affiche.html");
           affiche.FormatContent(templete);
           affiche.Content = affiche.Content.Replace("{Affiche_HandModeAndBidMethod}", "1、采取在“福建省国有建设用地使用权出让网上交易系统”挂牌的方式进行。 竞买申请人登录“福建省国有建设用地使用权出让网上交易系统”（以下简称网上交易系统）注册登记，提出竞买申请，经挂牌人审查确认，获得登录网上交易系统的竞买号和初始交易密码，在规定的期间内登录网上交易系统进行网上报价和竞买等。<br/>&nbsp;&nbsp;&nbsp;2、竞买人初次报价可等于或大于挂牌起始价，之后每次报价必须比当前最高报价递增一个加价幅度以上的价格（不要求按加价幅度的整数倍报价）。挂牌出让按照价高者得的原则确定竞得人。");

        }

        private void WriteLog(string message)
        {
            System.IO.File.AppendAllLines("log.txt", new string[]{ message});
        }
    }
}
