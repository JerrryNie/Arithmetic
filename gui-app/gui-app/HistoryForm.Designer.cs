namespace gui_app
{
    partial class HistoryForm
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
            this.components = new System.ComponentModel.Container();
            this.UserNameReadOnly = new System.Windows.Forms.TextBox();
            this.UserNameText = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PresentTimeText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timerAtPresent = new System.Windows.Forms.Timer(this.components);
            this.Ans_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ques_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Ans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correct_Ans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.True_Or_False = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameReadOnly
            // 
            this.UserNameReadOnly.BackColor = System.Drawing.SystemColors.Control;
            this.UserNameReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameReadOnly.Location = new System.Drawing.Point(25, 29);
            this.UserNameReadOnly.Name = "UserNameReadOnly";
            this.UserNameReadOnly.ReadOnly = true;
            this.UserNameReadOnly.Size = new System.Drawing.Size(63, 18);
            this.UserNameReadOnly.TabIndex = 0;
            this.UserNameReadOnly.Text = "用户名：";
            // 
            // UserNameText
            // 
            this.UserNameText.BackColor = System.Drawing.SystemColors.Control;
            this.UserNameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserNameText.Location = new System.Drawing.Point(94, 29);
            this.UserNameText.Multiline = true;
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.ReadOnly = true;
            this.UserNameText.Size = new System.Drawing.Size(340, 18);
            this.UserNameText.TabIndex = 1;
            this.UserNameText.Text = "Here is user\'s name";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(542, 29);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(82, 18);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "当前时间：";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // PresentTimeText
            // 
            this.PresentTimeText.BackColor = System.Drawing.SystemColors.Control;
            this.PresentTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PresentTimeText.Location = new System.Drawing.Point(630, 29);
            this.PresentTimeText.Multiline = true;
            this.PresentTimeText.Name = "PresentTimeText";
            this.PresentTimeText.ReadOnly = true;
            this.PresentTimeText.Size = new System.Drawing.Size(158, 18);
            this.PresentTimeText.TabIndex = 3;
            this.PresentTimeText.Text = "Present Time";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ans_Date,
            this.Ques_Content,
            this.User_Ans,
            this.Correct_Ans,
            this.True_Or_False});
            this.dataGridView1.Location = new System.Drawing.Point(25, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(744, 277);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // timerAtPresent
            // 
            this.timerAtPresent.Tick += new System.EventHandler(this.timerAtPresent_Tick);
            // 
            // Ans_Date
            // 
            this.Ans_Date.HeaderText = "答题日期";
            this.Ans_Date.Name = "Ans_Date";
            this.Ans_Date.ReadOnly = true;
            this.Ans_Date.Width = 200;
            // 
            // Ques_Content
            // 
            this.Ques_Content.HeaderText = "题目";
            this.Ques_Content.Name = "Ques_Content";
            this.Ques_Content.ReadOnly = true;
            this.Ques_Content.Width = 200;
            // 
            // User_Ans
            // 
            this.User_Ans.HeaderText = "用户答案";
            this.User_Ans.Name = "User_Ans";
            this.User_Ans.ReadOnly = true;
            // 
            // Correct_Ans
            // 
            this.Correct_Ans.HeaderText = "正确答案";
            this.Correct_Ans.Name = "Correct_Ans";
            this.Correct_Ans.ReadOnly = true;
            // 
            // True_Or_False
            // 
            this.True_Or_False.HeaderText = "正误情况";
            this.True_Or_False.Name = "True_Or_False";
            this.True_Or_False.ReadOnly = true;
            this.True_Or_False.Width = 95;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PresentTimeText);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.UserNameText);
            this.Controls.Add(this.UserNameReadOnly);
            this.Name = "HistoryForm";
            this.Text = "答题历史记录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistoryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameReadOnly;
        private System.Windows.Forms.TextBox UserNameText;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox PresentTimeText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timerAtPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ans_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ques_Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Ans;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correct_Ans;
        private System.Windows.Forms.DataGridViewTextBoxColumn True_Or_False;
    }
}