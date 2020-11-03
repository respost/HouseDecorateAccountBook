using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 装修记账
{
    public partial class FrmMian : Form
    {
        //声明一个数组来存放皮肤名字
        string[] skins = new string[73]; 
        public void getFileName()
        {
            //读取路径下的信息
            DirectoryInfo folder = new DirectoryInfo(@"Skins");//文件夹名为Skins，放在软件根目录下
            //循环文件夹下指定文件的信息
            for (int i = 0; i < folder.GetFiles("*.ssk").Count(); i++) // folder.GetFiles("*.txt").Count() 这个的意思是获取文件类型为txt的数量
            {
                //这里就是 给数组中指定索引来赋值了
                skins[i] = folder.GetFiles("*.ssk")[i].Name;
            }

        }

        public FrmMian()
        {
            InitializeComponent();
            this.Text = "装修明细 - 当前时间："+DateTime.Now.ToString();
            getFileName();//读取皮肤文件名
            foreach (string item in skins)
            {
                this.cmbSkins.Items.Add(item);
            }
           this.cmbSkins.SelectedIndex = 4;//默认选中
           string name = this.cmbSkins.Text.Trim();
            if (name != string.Empty)
            {
                this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/" + name;//使用的皮肤路径
            }     
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SelectDetails us = new SelectDetails();//用户控件
            this.panelMain.Controls.Clear();//先清空主面板
            us.Dock = DockStyle.Fill;//将用户控件全部填充到主面板上
            this.panelMain.Controls.Add(us);
        }

        private void FrmMian_Load(object sender, EventArgs e)
        {
            //窗体加载
            SelectDetails us = new SelectDetails();//用户控件
            this.panelMain.Controls.Clear();//先清空主面板
            us.Dock = DockStyle.Fill;//将用户控件全部填充到主面板上
            this.panelMain.Controls.Add(us);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmtAddDetails fs = new FrmtAddDetails();
            Common.fm= this;//设置为公共窗体
            fs.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmAddType fs = new FrmAddType();
            fs.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Report us = new Report();//用户控件
            this.panelMain.Controls.Clear();//先清空主面板
            us.Dock = DockStyle.Fill;//将用户控件全部填充到主面板上
            this.panelMain.Controls.Add(us);
        }

        //更换皮肤的按钮
        int i = 0;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string name = "";
            i++;
            if (i == 72)
            {
                i = 0;
            }
            name = skins[i];
            this.cmbSkins.SelectedIndex = i;
            if (name != "")
            {
                this.skinEngine1.SkinFile = Application.StartupPath + "//Skins/" + name;//使用的皮肤路径
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (result==DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

    }
}
