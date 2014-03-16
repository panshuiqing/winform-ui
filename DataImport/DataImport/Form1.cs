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
            return new Configuration(this.txtNewDb.Text).AddAssemblyFile("Tlw.ZPG.Domain.dll").BuildDbContextFactory().GetDbContext();
        }

        private void Import_Affiche()
        {
            var db = GetDbContext();
            string sql = @"select t1.*,t2.AfficheNum,t2.AfficheOther,t2.AffichePassCode,t2.AffichePassUnit,t2.Require,t3.updatedatetime
                        from afficheall t1
                        left join AfficheContent t2 on t1.AfficheId=t2.AfficheId 
                        left join affiche t3 on t1.afficheid=t3.afficheid order by allid";
            var dt = GetTableBySelectSql(sql);
            var query = dt.AsEnumerable().GroupBy((r) => { return (int)r["AfficheId"]; }).Where(t => t.Count() == 1).ToList();
            foreach (var item in query)
            {
                var afficheId = item.Key;
                if (item.Count() == 1)
                {
                    try
                    {
                        //没有补充的公告，补充公告需要手动录入
                        Affiche affiche = CreateAffiche(item.First());
                        db.Set<Affiche>().Add(affiche);
                        db.SaveChanges();
                    }
                    catch
                    { 
                    }
                }
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
            affiche.IsRelease = Convert.ToInt32(dr["IsRelease"]) == 1;
            affiche.Notice = dr["Notice"].ToString();
            affiche.OtherContent = dr["afficheOther"].ToString();
            affiche.QualificationRequire = dr["Require"].ToString();
            affiche.RatificationNumber = dr["AffichePassCode"].ToString();
            affiche.RatificationOrg = dr["AffichePassUnit"].ToString();
            affiche.ReleaseTime = Convert.ToDateTime(dr["updatedatetime"]);
            affiche.SellModel = "网上挂牌";
            affiche.SignBeginTime = Convert.ToDateTime(dr["SignBeginTime"]);
            affiche.SignEndTime = Convert.ToDateTime(dr["SignEndTime"]);
            affiche.TradeBeginTime = Convert.ToDateTime(dr["TradeBeginTime"]);
            affiche.TradeEndTime = Convert.ToDateTime(dr["TradeEndTime"]);
            affiche.Title = dr["Title"].ToString();
            affiche.VerifyStatus = Tlw.ZPG.Domain.Enums.AfficheVerifyStatus.None;
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
    }
}
