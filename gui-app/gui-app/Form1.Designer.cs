namespace gui_app
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TextBox TextReadOnly2;
            this.StartButton = new System.Windows.Forms.Button();
            this.CountDown = new System.Windows.Forms.TextBox();
            this.QuestionText = new System.Windows.Forms.TextBox();
            this.AnsText = new System.Windows.Forms.TextBox();
            this.TextReadOnly1 = new System.Windows.Forms.TextBox();
            this.QuesNum = new System.Windows.Forms.TextBox();
            this.ConfirmAnsButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.TextReadOnly3 = new System.Windows.Forms.TextBox();
            this.TextReadOnly4 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimeCnt1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            TextReadOnly2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextReadOnly2
            // 
            TextReadOnly2.BackColor = System.Drawing.Color.Ivory;
            TextReadOnly2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextReadOnly2.Cursor = System.Windows.Forms.Cursors.No;
            TextReadOnly2.Font = new System.Drawing.Font("楷体", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            TextReadOnly2.ForeColor = System.Drawing.Color.Brown;
            TextReadOnly2.Location = new System.Drawing.Point(35, 42);
            TextReadOnly2.Multiline = true;
            TextReadOnly2.Name = "TextReadOnly2";
            TextReadOnly2.ReadOnly = true;
            TextReadOnly2.Size = new System.Drawing.Size(157, 40);
            TextReadOnly2.TabIndex = 9;
            TextReadOnly2.Text = "倒计时：";
            // 
            // StartButton
            // 
            this.StartButton.BackgroundImage = global::gui_app.Properties.Resources.Button;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Font = new System.Drawing.Font("幼圆", 12F);
            this.StartButton.Location = new System.Drawing.Point(633, 77);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(126, 51);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "开始答题";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CountDown
            // 
            this.CountDown.BackColor = System.Drawing.SystemColors.Control;
            this.CountDown.Font = new System.Drawing.Font("宋体", 19F);
            this.CountDown.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CountDown.Location = new System.Drawing.Point(159, 88);
            this.CountDown.Multiline = true;
            this.CountDown.Name = "CountDown";
            this.CountDown.ReadOnly = true;
            this.CountDown.Size = new System.Drawing.Size(117, 43);
            this.CountDown.TabIndex = 2;
            this.CountDown.TextChanged += new System.EventHandler(this.CountDown_TextChanged);
            // 
            // QuestionText
            // 
            this.QuestionText.Location = new System.Drawing.Point(12, 250);
            this.QuestionText.Multiline = true;
            this.QuestionText.Name = "QuestionText";
            this.QuestionText.ReadOnly = true;
            this.QuestionText.Size = new System.Drawing.Size(414, 43);
            this.QuestionText.TabIndex = 3;
            this.QuestionText.TextChanged += new System.EventHandler(this.QuestionText_TextChanged);
            // 
            // AnsText
            // 
            this.AnsText.Location = new System.Drawing.Point(473, 250);
            this.AnsText.Multiline = true;
            this.AnsText.Name = "AnsText";
            this.AnsText.Size = new System.Drawing.Size(100, 43);
            this.AnsText.TabIndex = 4;
            // 
            // TextReadOnly1
            // 
            this.TextReadOnly1.BackColor = System.Drawing.Color.Ivory;
            this.TextReadOnly1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly1.Cursor = System.Windows.Forms.Cursors.No;
            this.TextReadOnly1.Font = new System.Drawing.Font("楷体", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextReadOnly1.ForeColor = System.Drawing.Color.Chocolate;
            this.TextReadOnly1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextReadOnly1.Location = new System.Drawing.Point(35, 153);
            this.TextReadOnly1.Multiline = true;
            this.TextReadOnly1.Name = "TextReadOnly1";
            this.TextReadOnly1.ReadOnly = true;
            this.TextReadOnly1.Size = new System.Drawing.Size(118, 40);
            this.TextReadOnly1.TabIndex = 5;
            this.TextReadOnly1.Text = "题号：";
            // 
            // QuesNum
            // 
            this.QuesNum.BackColor = System.Drawing.SystemColors.Control;
            this.QuesNum.Font = new System.Drawing.Font("宋体", 19F);
            this.QuesNum.Location = new System.Drawing.Point(159, 177);
            this.QuesNum.Multiline = true;
            this.QuesNum.Name = "QuesNum";
            this.QuesNum.ReadOnly = true;
            this.QuesNum.Size = new System.Drawing.Size(117, 43);
            this.QuesNum.TabIndex = 6;
            // 
            // ConfirmAnsButton
            // 
            this.ConfirmAnsButton.BackgroundImage = global::gui_app.Properties.Resources.Button;
            this.ConfirmAnsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConfirmAnsButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ConfirmAnsButton.Location = new System.Drawing.Point(630, 235);
            this.ConfirmAnsButton.Name = "ConfirmAnsButton";
            this.ConfirmAnsButton.Size = new System.Drawing.Size(126, 51);
            this.ConfirmAnsButton.TabIndex = 7;
            this.ConfirmAnsButton.Text = "确认答案";
            this.ConfirmAnsButton.UseVisualStyleBackColor = true;
            this.ConfirmAnsButton.Click += new System.EventHandler(this.ConfirmAnsButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.BackgroundImage = global::gui_app.Properties.Resources.Button;
            this.FinishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FinishButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FinishButton.Location = new System.Drawing.Point(354, 332);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(126, 51);
            this.FinishButton.TabIndex = 8;
            this.FinishButton.Text = "答题结束";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // TextReadOnly3
            // 
            this.TextReadOnly3.BackColor = System.Drawing.Color.Ivory;
            this.TextReadOnly3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly3.Cursor = System.Windows.Forms.Cursors.No;
            this.TextReadOnly3.Font = new System.Drawing.Font("楷体", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextReadOnly3.ForeColor = System.Drawing.Color.DarkGreen;
            this.TextReadOnly3.Location = new System.Drawing.Point(302, 39);
            this.TextReadOnly3.Multiline = true;
            this.TextReadOnly3.Name = "TextReadOnly3";
            this.TextReadOnly3.ReadOnly = true;
            this.TextReadOnly3.Size = new System.Drawing.Size(204, 40);
            this.TextReadOnly3.TabIndex = 10;
            this.TextReadOnly3.Text = "答题已用时：";
            // 
            // TextReadOnly4
            // 
            this.TextReadOnly4.BackColor = System.Drawing.Color.Ivory;
            this.TextReadOnly4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly4.Cursor = System.Windows.Forms.Cursors.No;
            this.TextReadOnly4.Font = new System.Drawing.Font("宋体", 19F);
            this.TextReadOnly4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextReadOnly4.Location = new System.Drawing.Point(443, 253);
            this.TextReadOnly4.Multiline = true;
            this.TextReadOnly4.Name = "TextReadOnly4";
            this.TextReadOnly4.ReadOnly = true;
            this.TextReadOnly4.Size = new System.Drawing.Size(24, 43);
            this.TextReadOnly4.TabIndex = 11;
            this.TextReadOnly4.Text = "=";
            this.TextReadOnly4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.BackgroundImage = global::gui_app.Properties.Resources.BackGround1;
            this.panel1.Controls.Add(this.TimeCnt1);
            this.panel1.Controls.Add(this.TextReadOnly4);
            this.panel1.Controls.Add(this.TextReadOnly3);
            this.panel1.Controls.Add(TextReadOnly2);
            this.panel1.Controls.Add(this.FinishButton);
            this.panel1.Controls.Add(this.ConfirmAnsButton);
            this.panel1.Controls.Add(this.QuesNum);
            this.panel1.Controls.Add(this.TextReadOnly1);
            this.panel1.Controls.Add(this.AnsText);
            this.panel1.Controls.Add(this.QuestionText);
            this.panel1.Controls.Add(this.CountDown);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Font = new System.Drawing.Font("宋体", 19F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 451);
            this.panel1.TabIndex = 12;
            // 
            // TimeCnt1
            // 
            this.TimeCnt1.BackColor = System.Drawing.SystemColors.Control;
            this.TimeCnt1.Font = new System.Drawing.Font("宋体", 19F);
            this.TimeCnt1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TimeCnt1.Location = new System.Drawing.Point(482, 85);
            this.TimeCnt1.Multiline = true;
            this.TimeCnt1.Name = "TimeCnt1";
            this.TimeCnt1.ReadOnly = true;
            this.TimeCnt1.Size = new System.Drawing.Size(117, 43);
            this.TimeCnt1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 451);
            this.panel2.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "答题界面";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox CountDown;
        private System.Windows.Forms.TextBox QuestionText;
        private System.Windows.Forms.TextBox AnsText;
        private System.Windows.Forms.TextBox QuesNum;
        private System.Windows.Forms.Button ConfirmAnsButton;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.TextBox TextReadOnly3;
        private System.Windows.Forms.TextBox TextReadOnly4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox TextReadOnly1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TimeCnt1;
    }
}

