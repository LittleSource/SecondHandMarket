namespace SecondHandMarket.ViewController
{
    partial class GoodsCard
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelGoodsName = new System.Windows.Forms.Label();
            this.labelOldPirce = new System.Windows.Forms.Label();
            this.labelNewPirce = new System.Windows.Forms.Label();
            this.labelAddDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGoodsName
            // 
            this.labelGoodsName.AutoSize = true;
            this.labelGoodsName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGoodsName.Location = new System.Drawing.Point(9, 149);
            this.labelGoodsName.Name = "labelGoodsName";
            this.labelGoodsName.Size = new System.Drawing.Size(74, 21);
            this.labelGoodsName.TabIndex = 1;
            this.labelGoodsName.Text = "商品名称";
            // 
            // labelOldPirce
            // 
            this.labelOldPirce.AutoSize = true;
            this.labelOldPirce.Font = new System.Drawing.Font("Cambria", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOldPirce.ForeColor = System.Drawing.Color.Red;
            this.labelOldPirce.Location = new System.Drawing.Point(8, 186);
            this.labelOldPirce.Name = "labelOldPirce";
            this.labelOldPirce.Size = new System.Drawing.Size(147, 41);
            this.labelOldPirce.TabIndex = 2;
            this.labelOldPirce.Text = "￥88.88";
            this.labelOldPirce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNewPirce
            // 
            this.labelNewPirce.AutoSize = true;
            this.labelNewPirce.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNewPirce.ForeColor = System.Drawing.Color.LightSlateGray;
            this.labelNewPirce.Location = new System.Drawing.Point(147, 194);
            this.labelNewPirce.Name = "labelNewPirce";
            this.labelNewPirce.Size = new System.Drawing.Size(70, 24);
            this.labelNewPirce.TabIndex = 4;
            this.labelNewPirce.Text = "199.8";
            this.labelNewPirce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAddDate
            // 
            this.labelAddDate.AutoSize = true;
            this.labelAddDate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAddDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelAddDate.Location = new System.Drawing.Point(9, 256);
            this.labelAddDate.Name = "labelAddDate";
            this.labelAddDate.Size = new System.Drawing.Size(74, 17);
            this.labelAddDate.TabIndex = 5;
            this.labelAddDate.Text = "2018-12-18";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SecondHandMarket.Properties.Resources.art;
            this.pictureBox2.Location = new System.Drawing.Point(159, 222);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SecondHandMarket.Properties.Resources.TB2uvHId;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GoodsCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SecondHandMarket.Properties.Resources.cardbg;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelAddDate);
            this.Controls.Add(this.labelNewPirce);
            this.Controls.Add(this.labelGoodsName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelOldPirce);
            this.Name = "GoodsCard";
            this.Size = new System.Drawing.Size(220, 278);
            this.Load += new System.EventHandler(this.GoodsCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelGoodsName;
        private System.Windows.Forms.Label labelOldPirce;
        private System.Windows.Forms.Label labelNewPirce;
        private System.Windows.Forms.Label labelAddDate;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
