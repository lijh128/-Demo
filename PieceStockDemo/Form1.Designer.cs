namespace PieceToStock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnArrangeFIrstGroup = new System.Windows.Forms.Button();
            this.lsbArrange = new System.Windows.Forms.ListBox();
            this.btnArrangeSecondGroup = new System.Windows.Forms.Button();
            this.txtArrange = new System.Windows.Forms.TextBox();
            this.lsbSumInfo = new System.Windows.Forms.ListBox();
            this.lblArrange = new System.Windows.Forms.Label();
            this.lblSumInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnArrangeFIrstGroup
            // 
            this.btnArrangeFIrstGroup.Location = new System.Drawing.Point(233, 525);
            this.btnArrangeFIrstGroup.Name = "btnArrangeFIrstGroup";
            this.btnArrangeFIrstGroup.Size = new System.Drawing.Size(138, 49);
            this.btnArrangeFIrstGroup.TabIndex = 0;
            this.btnArrangeFIrstGroup.Text = "对L160x10进行排料";
            this.btnArrangeFIrstGroup.UseVisualStyleBackColor = true;
            this.btnArrangeFIrstGroup.Click += new System.EventHandler(this.button1_Click);
            // 
            // lsbArrange
            // 
            this.lsbArrange.FormattingEnabled = true;
            this.lsbArrange.ItemHeight = 12;
            this.lsbArrange.Location = new System.Drawing.Point(69, 46);
            this.lsbArrange.Name = "lsbArrange";
            this.lsbArrange.ScrollAlwaysVisible = true;
            this.lsbArrange.Size = new System.Drawing.Size(590, 244);
            this.lsbArrange.TabIndex = 1;
            // 
            // btnArrangeSecondGroup
            // 
            this.btnArrangeSecondGroup.Location = new System.Drawing.Point(521, 525);
            this.btnArrangeSecondGroup.Name = "btnArrangeSecondGroup";
            this.btnArrangeSecondGroup.Size = new System.Drawing.Size(138, 48);
            this.btnArrangeSecondGroup.TabIndex = 2;
            this.btnArrangeSecondGroup.Text = "对L100x7进行排料";
            this.btnArrangeSecondGroup.UseVisualStyleBackColor = true;
            this.btnArrangeSecondGroup.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtArrange
            // 
            this.txtArrange.Location = new System.Drawing.Point(69, 296);
            this.txtArrange.Multiline = true;
            this.txtArrange.Name = "txtArrange";
            this.txtArrange.Size = new System.Drawing.Size(590, 223);
            this.txtArrange.TabIndex = 4;
            // 
            // lsbSumInfo
            // 
            this.lsbSumInfo.FormattingEnabled = true;
            this.lsbSumInfo.ItemHeight = 12;
            this.lsbSumInfo.Location = new System.Drawing.Point(665, 70);
            this.lsbSumInfo.Name = "lsbSumInfo";
            this.lsbSumInfo.Size = new System.Drawing.Size(137, 448);
            this.lsbSumInfo.TabIndex = 3;
            // 
            // lblArrange
            // 
            this.lblArrange.AutoSize = true;
            this.lblArrange.Location = new System.Drawing.Point(67, 31);
            this.lblArrange.Name = "lblArrange";
            this.lblArrange.Size = new System.Drawing.Size(53, 12);
            this.lblArrange.TabIndex = 5;
            this.lblArrange.Text = "排料方案";
            // 
            // lblSumInfo
            // 
            this.lblSumInfo.AutoSize = true;
            this.lblSumInfo.Location = new System.Drawing.Point(665, 46);
            this.lblSumInfo.Name = "lblSumInfo";
            this.lblSumInfo.Size = new System.Drawing.Size(53, 12);
            this.lblSumInfo.TabIndex = 6;
            this.lblSumInfo.Text = "汇总信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 586);
            this.Controls.Add(this.lblSumInfo);
            this.Controls.Add(this.lblArrange);
            this.Controls.Add(this.txtArrange);
            this.Controls.Add(this.lsbSumInfo);
            this.Controls.Add(this.btnArrangeSecondGroup);
            this.Controls.Add(this.lsbArrange);
            this.Controls.Add(this.btnArrangeFIrstGroup);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnArrangeFIrstGroup;
        private System.Windows.Forms.ListBox lsbArrange;
        private System.Windows.Forms.Button btnArrangeSecondGroup;
        private System.Windows.Forms.TextBox txtArrange;
        private System.Windows.Forms.ListBox lsbSumInfo;
        private System.Windows.Forms.Label lblArrange;
        private System.Windows.Forms.Label lblSumInfo;
    }
}

