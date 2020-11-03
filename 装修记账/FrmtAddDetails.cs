using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 装修记账
{
    public partial class FrmtAddDetails : Form
    {
        public FrmtAddDetails()
        {
            InitializeComponent();
        }

        DBhelper db = new DBhelper();
        public string uid = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            //名称
            string name = this.txtName.Text.Trim();
            if (name==string.Empty)
            {
                MessageBox.Show("名称不能为空");
                this.txtName.Focus();
                return;
            }
           
            //单价
            string price = this.txtPrice.Text.Trim();
            if (price==string.Empty)
            {
                MessageBox.Show("单价不能为空");
                this.txtPrice.Focus();
                return;
            }
            Regex dj = new Regex("^[0-9]{1,8}([.][0-9]{1,5})?$");//定义正则表达式

            if (dj.IsMatch(price) == false)//判断，如果不满足正则表达式(结果为flase)，给出提示
            {
                MessageBox.Show("单价只能输入整数或小数");
                this.txtPrice.Focus();
                return;
            }
            if (Convert.ToDouble(price)<=0)
            {
                MessageBox.Show("单价必须大于0");
                this.txtPrice.Focus();
                return;
            }
          
            //数量
            string num = this.txtNum.Text.Trim();
            if (num==string.Empty)
            {
                num = "1";//用户没有输入时，默认为1
            }
            Regex sz = new Regex("^[0-9]{1,8}([.][0-9]{1,5})?$");//定义正则表达式
            if (sz.IsMatch(num) == false)//判断，如果不满足正则表达式(结果为flase)，给出提示
            {
                MessageBox.Show("数量只能输入整数或小数");
                this.txtNum.Focus();
                return;
            }
          
            //总计
           string sumPrice =this.txtSumPrice.Text.Trim();
           if (sumPrice == string.Empty)
           {
               MessageBox.Show("总计不能为空");
               this.txtSumPrice.Focus();
               return;
           }
           Regex zj = new Regex("^[0-9]{1,8}([.][0-9]{1,5})?$");//定义正则表达式

           if (zj.IsMatch(sumPrice) == false)//判断，如果不满足正则表达式(结果为flase)，给出提示
           {
               MessageBox.Show("总计只能输入整数或小数");
               this.txtSumPrice.Focus();
               return;
           }
           if (Convert.ToDouble(sumPrice) < 0)
           {
               MessageBox.Show("总计不能小于0");
               this.txtPrice.Focus();
               return;
           }
            //类型
            string type = this.cmbType.Text.Trim();
            int typeId = 0;//默认给0,类型为空时，插入0
            if (type!=string.Empty)
            {
                typeId = db.GetTypeIdByName(type);
            }
          
            //店铺
            string store = this.txtStore.Text.Trim();

            //地址
            string address = this.txtAddress.Text.Trim();

            //联系人
            string user = this.txtUser.Text.Trim();
  
            //电话
            string phone = this.txtPhone.Text.Trim();

            //日期
            string date = this.dateTimePicker1.Value.ToString();

            if (uid!="")
            {
                if (db.UpdateDetails(name, Convert.ToDouble(price), Convert.ToDouble(num), Convert.ToDouble(sumPrice), typeId, store, address, user, phone, date, Convert.ToInt32(uid)) == true)
                {
                  MessageBox.Show("修改成功！");
                    ////清空
                    //this.txtName.Text = "";
                    //this.txtPrice.Text = "";
                    //this.txtNum.Text = "";
                    //this.txtSumPrice.Text = "";
                    //this.txtStore.Text = "";
                    //this.txtAddress.Text = "";
                    //this.txtUser.Text = "";
                    //this.txtPhone.Text = "";
                    //this.cmbType.Text = "";
                    //重新加载查询窗体
                    Common.sd.ShowDetails();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            else
            {
                if (db.AddDetails(name, Convert.ToDouble(price), Convert.ToDouble(num), Convert.ToDouble(sumPrice), typeId, store, address, user, phone, date) == true)
                {
                    MessageBox.Show("添加成功！");
                    ////清空
                    //this.txtName.Text = "";
                    //this.txtPrice.Text = "";
                    //this.txtNum.Text = "";
                    //this.txtSumPrice.Text = "";
                    //this.txtStore.Text = "";
                    //this.txtAddress.Text = "";
                    //this.txtUser.Text = "";
                    //this.txtPhone.Text = "";
                    //this.cmbType.Text = "";
                    //重新加载查询窗体
                    SelectDetails us = new SelectDetails();//用户控件
                    Common.fm.panelMain.Controls.Clear();//先清空主面板
                    us.Dock = DockStyle.Fill;//将用户控件全部填充到主面板上
                    Common.fm.panelMain.Controls.Add(us);
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }

            }


        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            string price = this.txtPrice.Text.Trim();//单价
            string num = this.txtNum.Text.Trim();//数量
            if (num == string.Empty)
            {
                this.lbNum.Visible = false;
            }
            else
            {
                this.lbNum.Visible = true;
            }
            Regex sz = new Regex("^[0-9]{1,8}([.][0-9]{1,5})?$");//定义正则表达式
            if (sz.IsMatch(num) == false)//判断，如果不满足正则表达式(结果为flase)，给出提示
            {
                this.lbNum.Text = "只能输入整数或小数";
                this.lbNum.ForeColor = Color.Red;
                return;
            }
            else
            {
                this.lbNum.Text = "";
                this.lbNum.ForeColor = Color.Green;
            }
            if (price != string.Empty&&num!=string.Empty)
            {
                double sumPrice = Convert.ToDouble(price) * Convert.ToDouble(num);   //总计
                this.txtSumPrice.Text = sumPrice.ToString();
            }         
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清空
            this.txtName.Text = "";
            this.txtPrice.Text = "";
            this.txtNum.Text = "";
            this.txtSumPrice.Text = "";
            this.txtStore.Text = "";
            this.txtAddress.Text = "";
            this.txtUser.Text = "";
            this.txtPhone.Text = "";
            this.cmbType.Text = "";
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            this.txtNum.Text = "";
            this.txtSumPrice.Text = "";
            string price = this.txtPrice.Text.Trim();
            if (price==string.Empty)
            {
                this.lbPrice.Visible = false;
            }
            else
            {
                this.lbPrice.Visible =true;
            }
            Regex sz = new Regex("^[0-9]{1,8}([.][0-9]{1,5})?$");//定义正则表达式

            if (sz.IsMatch(price) == false)//判断，如果不满足正则表达式(结果为flase)，给出提示
            {
                this.lbPrice.Text = "只能输入整数或小数";
                this.lbPrice.ForeColor = Color.Red;
            }
            else
            {
                this.lbPrice.Text = "";
                this.lbPrice.ForeColor = Color.Green;
            }
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            FrmAddType fs = new FrmAddType();
            fs.order = "新增类型";
            Common.fa = this;
            fs.Show();
        }

        private void FrmtAddDetails_Load(object sender, EventArgs e)
        {
            //窗体加载
            if (uid!="")
            {
                OleDbDataReader dr = db.GetDetailsById(Convert.ToInt32(uid));
                while (dr.Read())
                {
                    this.txtName.Text = dr[0].ToString();
                    this.txtPrice.Text = dr[1].ToString();
                    this.txtNum.Text = dr[2].ToString();
                    this.txtSumPrice.Text = dr[3].ToString();
                    this.cmbType.Text = dr[4].ToString();
                    this.txtStore.Text = dr[5].ToString();
                    this.txtAddress.Text = dr[6].ToString();
                    this.txtUser.Text = dr[7].ToString();
                    this.txtPhone.Text = dr[8].ToString();
                    this.dateTimePicker1.Value = Convert.ToDateTime(dr[9]);
                }
                dr.Close();
                this.lbPrice.Visible = false;
                this.lbNum.Visible = false;
                this.btnSave.Text = "修 改";
            }
            
           
        }

        //绑定类型
        public void TypeShow()
        {    
     
            db.SelectType();
            DataTable dt = db.ds.Tables["newType"];
            //添加新行
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "";
            dt.Rows.InsertAt(dr, 0);
            this.cmbType.DataSource = dt;
            this.cmbType.ValueMember = "序号";
            this.cmbType.DisplayMember = "类名";
        }

        private void cmbType_MouseClick(object sender, MouseEventArgs e)
        {
            TypeShow();//当用户单击组合框时，加载类型
        }

        private void txtPrice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtPrice.Text = "";
        }

        private void txtName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.txtName.Text = "";
        }

    }
}
