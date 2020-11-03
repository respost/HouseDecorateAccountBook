namespace 装修记账
{
    partial class Report
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbMoney = new System.Windows.Forms.Label();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbToDay = new System.Windows.Forms.RadioButton();
            this.rbTjByMonth = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listView1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(415, 200);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 316);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(1, 40);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbMoney
            // 
            this.lbMoney.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold);
            this.lbMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbMoney.Location = new System.Drawing.Point(0, 140);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(1230, 27);
            this.lbMoney.TabIndex = 2;
            this.lbMoney.Text = "全部 总支出：加载中！";
            this.lbMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAll.Location = new System.Drawing.Point(816, 47);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(70, 25);
            this.rbAll.TabIndex = 7;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "全部";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbMonth.Location = new System.Drawing.Point(719, 47);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(70, 25);
            this.rbMonth.TabIndex = 8;
            this.rbMonth.Text = "本月";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbWeek.Location = new System.Drawing.Point(622, 47);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(70, 25);
            this.rbWeek.TabIndex = 9;
            this.rbWeek.Text = "本周";
            this.rbWeek.UseVisualStyleBackColor = true;
            this.rbWeek.CheckedChanged += new System.EventHandler(this.rbWeek_CheckedChanged);
            // 
            // rbToDay
            // 
            this.rbToDay.AutoSize = true;
            this.rbToDay.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbToDay.Location = new System.Drawing.Point(525, 47);
            this.rbToDay.Name = "rbToDay";
            this.rbToDay.Size = new System.Drawing.Size(70, 25);
            this.rbToDay.TabIndex = 10;
            this.rbToDay.Text = "今日";
            this.rbToDay.UseVisualStyleBackColor = true;
            this.rbToDay.CheckedChanged += new System.EventHandler(this.rbToDay_CheckedChanged);
            // 
            // rbTjByMonth
            // 
            this.rbTjByMonth.AutoSize = true;
            this.rbTjByMonth.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbTjByMonth.Location = new System.Drawing.Point(344, 47);
            this.rbTjByMonth.Name = "rbTjByMonth";
            this.rbTjByMonth.Size = new System.Drawing.Size(154, 25);
            this.rbTjByMonth.TabIndex = 7;
            this.rbTjByMonth.Text = "按月份来统计";
            this.rbTjByMonth.UseVisualStyleBackColor = true;
            this.rbTjByMonth.CheckedChanged += new System.EventHandler(this.rbTjByMonth_CheckedChanged);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbTjByMonth);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.rbWeek);
            this.Controls.Add(this.rbToDay);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbMoney);
            this.Name = "Report";
            this.Size = new System.Drawing.Size(1230, 770);
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbToDay;
        private System.Windows.Forms.RadioButton rbTjByMonth;
    }
}
