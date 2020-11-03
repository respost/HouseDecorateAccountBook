using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 装修记账
{
    public partial class FrmAddType : Form
    {
        public FrmAddType()
        {
            InitializeComponent();
        }
        DBhelper db = new DBhelper();
        public string order = "";//接收其他窗体给的指令

        //显示类型列表
        public void ShowType()
        {
            db.SelectType();
            this.dataGridView1.DataSource=db.ds.Tables["newType"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.txtTypeName.Text.Trim();
            if (name==string.Empty)
            {
                MessageBox.Show("类名不能为空");
                this.txtTypeName.Focus();
                return;
            }
            if (this.button1.Text=="修 改")
            {
                int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
                if (db.UpdateType(name,id)==true)
                {
                        MessageBox.Show("修改成功！");
                    this.txtTypeName.Text = "";
                    this.button1.Text = "添 加";
                    ShowType();
                    if (order=="新增类型")
                    {
                        Common.fa.TypeShow();
                    }                 
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            else
            {
                if (db.AddType(name) == true)
                {
                    MessageBox.Show("添加成功！");
                    this.txtTypeName.Text = "";
                    ShowType();
                    if (order == "新增类型")
                    {
                        Common.fa.TypeShow();
                    } 
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }

        }

        private void FrmAddType_Load(object sender, EventArgs e)
        {
            //窗体加载
            ShowType();

        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count<=0)
            {
                MessageBox.Show("请先选择要修改的类名");
                return;
            }
            this.txtTypeName.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.button1.Text = "修 改";
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtTypeName.Text = "";
            this.button1.Text = "添 加";
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择要删除的类名");
                return;
            }
            int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
            string name = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show("确定要删除 ["+name+"] 这个类型吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result==DialogResult.OK)
            {
                if (db.DeleteType(id)==true)
                {
                    MessageBox.Show("删除成功！");
                    ShowType();
                    if (order == "新增类型")
                    {
                        Common.fa.TypeShow();
                    } 
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
        }

    }
}
