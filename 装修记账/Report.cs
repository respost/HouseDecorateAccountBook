using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 装修记账
{
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();

        }
        DBhelper db = new DBhelper();
        public string startTime = "1900/1/1";//起始时间
        public string endTime = DateTime.Now.ToString("yyyy/M/d");//结束时间
        public string title = "全部";//默认

        private void Report_Load(object sender, EventArgs e)
        {
            ShowAllPay();
            ShowPayByType();
        }
        //显示总支出
        private void ShowAllPay()
        {
            OleDbDataReader dr = db.SumAllPay(startTime, endTime);
            while (dr.Read())
            {
               
                if (dr[0].ToString()=="")
                {
                   this.lbMoney.Text = title+" 总支出：0 元";
                }
                else
                {
                    this.lbMoney.Text = title + " 总支出：" + dr[0].ToString() + "元";
                }
            }
            dr.Close();
        }
        //按类型显示支出
        private void ShowPayByType()
        {
            OleDbDataReader dr=db.SumPayByType(startTime,endTime);
            this.listView1.Clear();//先清空
            this.listView1.Columns.Add("类型", 200, HorizontalAlignment.Center);
            this.listView1.Columns.Add("总支出", 200, HorizontalAlignment.Center);
            while (dr.Read())
            {                         
                ListViewItem lvi = new ListViewItem();
                lvi.Text = dr[0].ToString();
                lvi.SubItems.Add(dr[1].ToString()+"元");
                this.listView1.Items.Add(lvi);
            }
            dr.Close();
        }

        //按月份显示支出
        private void ShowPayByMonth()
        {
            OleDbDataReader dr = db.TjPayByMonth();
            this.listView1.Clear();//先清空
            this.listView1.Columns.Add("月份", 200, HorizontalAlignment.Center);
            this.listView1.Columns.Add("总支出", 200, HorizontalAlignment.Center);
            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = dr[0].ToString()+"年"+dr[1].ToString()+"月";
                lvi.SubItems.Add(dr[2].ToString() + "元");
                this.listView1.Items.Add(lvi);
            }
            dr.Close();
        }

        private void rbToDay_CheckedChanged(object sender, EventArgs e)
        {
            //今日
            if (rbToDay.Checked == true)
            {
                startTime = endTime = DateTime.Now.ToString("yyyy/M/d"); //截取 年/月/日
                title = "今日";
                ShowAllPay();
                ShowPayByType();

            }
        }

        private void rbWeek_CheckedChanged(object sender, EventArgs e)
        {
            //本周
            if (rbWeek.Checked == true)
            {
                startTime = DateTime.Now.AddDays(-7).ToString("yyyy/M/d");
                endTime = DateTime.Now.ToString("yyyy/M/d");
                title = "本周";
                ShowAllPay();
                ShowPayByType();
            }
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            //本月
            if (rbMonth.Checked == true)
            {
                startTime = DateTime.Now.AddDays(-30).ToString("yyyy/M/d");
                endTime = DateTime.Now.ToString("yyyy/M/d");
                title = "本月";
                ShowAllPay();
                ShowPayByType();
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            //全部
            if (rbAll.Checked == true)
            {
                startTime = "1900/1/1";//起始时间
                endTime = DateTime.Now.ToString("yyyy/M/d");//结束时间
                title = "全部";
                ShowAllPay();
                ShowPayByType();
            }
        }

        private void rbTjByMonth_CheckedChanged(object sender, EventArgs e)
        {
            ShowPayByMonth();
        }
    }
}
