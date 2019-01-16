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
            this.StartButton = new System.Windows.Forms.Button();
            this.TimeCnt = new System.Windows.Forms.TextBox();
            this.CountDown = new System.Windows.Forms.TextBox();
            this.QuestionText = new System.Windows.Forms.TextBox();
            this.AnsText = new System.Windows.Forms.TextBox();
            this.TextReadOnly1 = new System.Windows.Forms.TextBox();
            this.QuesNum = new System.Windows.Forms.TextBox();
            this.ConfirmAnsButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.TextReadOnly2 = new System.Windows.Forms.TextBox();
            this.TextReadOnly3 = new System.Windows.Forms.TextBox();
            this.TextReadOnly4 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(688, 50);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 36);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "开始答题";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // TimeCnt
            // 
            this.TimeCnt.Location = new System.Drawing.Point(545, 61);
            this.TimeCnt.Name = "TimeCnt";
            this.TimeCnt.ReadOnly = true;
            this.TimeCnt.Size = new System.Drawing.Size(100, 25);
            this.TimeCnt.TabIndex = 1;
            // 
            // CountDown
            // 
            this.CountDown.Location = new System.Drawing.Point(69, 61);
            this.CountDown.Name = "CountDown";
            this.CountDown.ReadOnly = true;
            this.CountDown.Size = new System.Drawing.Size(100, 25);
            this.CountDown.TabIndex = 2;
            this.CountDown.TextChanged += new System.EventHandler(this.CountDown_TextChanged);
            // 
            // QuestionText
            // 
            this.QuestionText.Location = new System.Drawing.Point(2, 223);
            this.QuestionText.Name = "QuestionText";
            this.QuestionText.ReadOnly = true;
            this.QuestionText.Size = new System.Drawing.Size(414, 25);
            this.QuestionText.TabIndex = 3;
            this.QuestionText.TextChanged += new System.EventHandler(this.QuestionText_TextChanged);
            // 
            // AnsText
            // 
            this.AnsText.Location = new System.Drawing.Point(463, 223);
            this.AnsText.Name = "AnsText";
            this.AnsText.Size = new System.Drawing.Size(100, 25);
            this.AnsText.TabIndex = 4;
            // 
            // TextReadOnly1
            // 
            this.TextReadOnly1.BackColor = System.Drawing.SystemColors.Control;
            this.TextReadOnly1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextReadOnly1.Location = new System.Drawing.Point(12, 173);
            this.TextReadOnly1.Name = "TextReadOnly1";
            this.TextReadOnly1.ReadOnly = true;
            this.TextReadOnly1.Size = new System.Drawing.Size(51, 18);
            this.TextReadOnly1.TabIndex = 5;
            this.TextReadOnly1.Text = "题号：";
            // 
            // QuesNum
            // 
            this.QuesNum.BackColor = System.Drawing.SystemColors.Control;
            this.QuesNum.Location = new System.Drawing.Point(69, 166);
            this.QuesNum.Name = "QuesNum";
            this.QuesNum.Size = new System.Drawing.Size(100, 25);
            this.QuesNum.TabIndex = 6;
            // 
            // ConfirmAnsButton
            // 
            this.ConfirmAnsButton.Location = new System.Drawing.Point(613, 226);
            this.ConfirmAnsButton.Name = "ConfirmAnsButton";
            this.ConfirmAnsButton.Size = new System.Drawing.Size(100, 36);
            this.ConfirmAnsButton.TabIndex = 7;
            this.ConfirmAnsButton.Text = "确认答案";
            this.ConfirmAnsButton.UseVisualStyleBackColor = true;
            this.ConfirmAnsButton.Click += new System.EventHandler(this.ConfirmAnsButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(341, 369);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(101, 36);
            this.FinishButton.TabIndex = 8;
            this.FinishButton.Text = "答题结束";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // TextReadOnly2
            // 
            this.TextReadOnly2.BackColor = System.Drawing.SystemColors.Control;
            this.TextReadOnly2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextReadOnly2.Location = new System.Drawing.Point(12, 27);
            this.TextReadOnly2.Name = "TextReadOnly2";
            this.TextReadOnly2.ReadOnly = true;
            this.TextReadOnly2.Size = new System.Drawing.Size(51, 18);
            this.TextReadOnly2.TabIndex = 9;
            this.TextReadOnly2.Text = "倒计时：";
            // 
            // TextReadOnly3
            // 
            this.TextReadOnly3.BackColor = System.Drawing.SystemColors.Control;
            this.TextReadOnly3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextReadOnly3.Location = new System.Drawing.Point(458, 27);
            this.TextReadOnly3.Multiline = true;
            this.TextReadOnly3.Name = "TextReadOnly3";
            this.TextReadOnly3.ReadOnly = true;
            this.TextReadOnly3.Size = new System.Drawing.Size(105, 25);
            this.TextReadOnly3.TabIndex = 10;
            this.TextReadOnly3.Text = "答题已用时：";
            // 
            // TextReadOnly4
            // 
            this.TextReadOnly4.BackColor = System.Drawing.SystemColors.Control;
            this.TextReadOnly4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextReadOnly4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextReadOnly4.Location = new System.Drawing.Point(438, 226);
            this.TextReadOnly4.Multiline = true;
            this.TextReadOnly4.Name = "TextReadOnly4";
            this.TextReadOnly4.ReadOnly = true;
            this.TextReadOnly4.Size = new System.Drawing.Size(18, 22);
            this.TextReadOnly4.TabIndex = 11;
            this.TextReadOnly4.Text = "=";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextReadOnly4);
            this.Controls.Add(this.TextReadOnly3);
            this.Controls.Add(this.TextReadOnly2);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.ConfirmAnsButton);
            this.Controls.Add(this.QuesNum);
            this.Controls.Add(this.TextReadOnly1);
            this.Controls.Add(this.AnsText);
            this.Controls.Add(this.QuestionText);
            this.Controls.Add(this.CountDown);
            this.Controls.Add(this.TimeCnt);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox TimeCnt;
        private System.Windows.Forms.TextBox CountDown;
        private System.Windows.Forms.TextBox QuestionText;
        private System.Windows.Forms.TextBox AnsText;
        private System.Windows.Forms.TextBox TextReadOnly1;
        private System.Windows.Forms.TextBox QuesNum;
        private System.Windows.Forms.Button ConfirmAnsButton;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.TextBox TextReadOnly2;
        private System.Windows.Forms.TextBox TextReadOnly3;
        private System.Windows.Forms.TextBox TextReadOnly4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

