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
            this.StartButton = new System.Windows.Forms.Button();
            this.TimeCnt = new System.Windows.Forms.TextBox();
            this.CountDown = new System.Windows.Forms.TextBox();
            this.QuestionText = new System.Windows.Forms.TextBox();
            this.AnsText = new System.Windows.Forms.TextBox();
            this.TextReadOnly1 = new System.Windows.Forms.TextBox();
            this.QuesNum = new System.Windows.Forms.TextBox();
            this.ConfirmAnsButton = new System.Windows.Forms.Button();
            this.FinishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(686, 24);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "开始答题";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // TimeCnt
            // 
            this.TimeCnt.Location = new System.Drawing.Point(31, 75);
            this.TimeCnt.Name = "TimeCnt";
            this.TimeCnt.Size = new System.Drawing.Size(100, 25);
            this.TimeCnt.TabIndex = 1;
            // 
            // CountDown
            // 
            this.CountDown.Location = new System.Drawing.Point(558, 22);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(100, 25);
            this.CountDown.TabIndex = 2;
            // 
            // QuestionText
            // 
            this.QuestionText.Location = new System.Drawing.Point(2, 223);
            this.QuestionText.Name = "QuestionText";
            this.QuestionText.Size = new System.Drawing.Size(414, 25);
            this.QuestionText.TabIndex = 3;
            // 
            // AnsText
            // 
            this.AnsText.Location = new System.Drawing.Point(545, 223);
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
            this.ConfirmAnsButton.Location = new System.Drawing.Point(686, 279);
            this.ConfirmAnsButton.Name = "ConfirmAnsButton";
            this.ConfirmAnsButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmAnsButton.TabIndex = 7;
            this.ConfirmAnsButton.Text = "确认答案";
            this.ConfirmAnsButton.UseVisualStyleBackColor = true;
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(341, 369);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(101, 36);
            this.FinishButton.TabIndex = 8;
            this.FinishButton.Text = "答题结束";
            this.FinishButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

