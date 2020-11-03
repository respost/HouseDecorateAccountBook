using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 装修记账
{
    public partial class SelectDetails : UserControl
    {
        public SelectDetails()
        {
            InitializeComponent();
        }
        //公共区域
        DBhelper db = new DBhelper();
        public string startTime = "";//起始时间
        public string endTime = "";//结束时间

        //显示明细列表
        public void ShowDetails()
        {
            db.SelectDetails();
            DataTable dt = db.ds.Tables["newDetail"];
            DataView dv = new DataView(dt);
            dv.RowFilter = " 编号<>0";
            //按类型
            string type = this.cmbType.Text.Trim();
            if (type != "请选择")
            {
                dv.RowFilter += string.Format(" and 类型 = '{0}' ", type);

            }
            //按名称模糊查询
            string name = this.txtName.Text.Trim();
            if (name != string.Empty)
            {
                dv.RowFilter += string.Format(" and 名称 like '%{0}%'", name);
            }
            //按时间
            if (startTime != "")
            {
                dv.RowFilter += string.Format(" and 日期 >=#{0}# ", startTime);//Access的日期用#
            }
            if (endTime != "")
            {
                dv.RowFilter += string.Format(" and 日期 <=#{0}# ", endTime);
            }
            dv.Sort = " 编号 desc";
            this.dataGridView1.DataSource = dv;

            //Font font = new Font("UTF-8", 14);//UTF-8是字体的编码格式，14是字体大小
            //this.dataGridView1.Font = font;//此时dataGridView的字体就已经设置完成
            this.dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 14);
            this.dataGridView1.Columns[10].DefaultCellStyle.Format = "yy年M月d日";//设置日期显示的格式
        }

        private void SelectDetails_Load(object sender, EventArgs e)
        {
            // 窗体加载
            this.dtpStartTime.Value = dtpStartTime.Value.AddDays(-1);//开始日期减一天
            //绑定类型
            db.SelectType();
            DataTable dt = db.ds.Tables["newType"];
            //添加新行
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            this.cmbType.DataSource = dt;
            this.cmbType.ValueMember = "序号";
            this.cmbType.DisplayMember = "类名";
            ShowDetails();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbType.SelectedIndex = 0;
            this.txtName.Text = "";
            //全部
            if (rbAll.Checked == true)
            {
                startTime = "";//起始时间
                endTime = "";//结束时间
                ShowDetails();
            }

        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbType.SelectedIndex = 0;
            this.txtName.Text = "";
            //本月
            if (rbMonth.Checked == true)
            {
                startTime = DateTime.Now.AddDays(-30).ToString("yyyy/M/d");
                endTime = DateTime.Now.ToString("yyyy/M/d");
                ShowDetails();
            }

        }

        private void rbWeek_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbType.SelectedIndex = 0;
            this.txtName.Text = "";
            //本周
            if (rbWeek.Checked == true)
            {
                startTime = DateTime.Now.AddDays(-7).ToString("yyyy/M/d");
                endTime = DateTime.Now.ToString("yyyy/M/d");
                ShowDetails();
            }

        }

        private void rbToDay_CheckedChanged(object sender, EventArgs e)
        {

            this.cmbType.SelectedIndex = 0;
            this.txtName.Text = "";
            //今日
            if (rbToDay.Checked == true)
            {
                startTime = endTime = DateTime.Now.ToString("yyyy/M/d");
                ShowDetails();
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.rbAll.Checked =false;
            this.rbToDay.Checked = false;
            this.rbWeek.Checked = false;
            this.rbMonth.Checked = false;
            startTime = this.dtpStartTime.Value.ToString("yyyy/M/d");
            endTime = this.dtpEndTime.Value.ToString("yyyy/M/d");
            ShowDetails();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择要修改的一行数据");
                return;
            }
            string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            FrmtAddDetails fs = new FrmtAddDetails();
            fs.uid = id;
            Common.sd = this;
            fs.Show();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择要删除的一行数据");
                return;
            }
            int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
            string name = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            DialogResult result = MessageBox.Show("确定要删除 [" + name + "] 这一行明细记录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (db.DeleteDetails(id)==true)
                {
                    MessageBox.Show("删除成功！");
                    ShowDetails();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string name = this.txtName.Text.Trim();
            if (name!=string.Empty)
            {
                ShowDetails();
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string typeName = this.cmbType.Text.Trim();
            if (typeName!="请选择")
            {
                ShowDetails();
            }
        }

    }
}
