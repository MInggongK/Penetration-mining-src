namespace 渗透测试漏洞挖掘src集成版
{
    partial class Form2
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 28);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 0;
            label1.Text = "localhost:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(120, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 90);
            label2.Name = "label2";
            label2.Size = new Size(36, 17);
            label2.TabIndex = 2;
            label2.Text = "port:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(120, 87);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 23);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(120, 157);
            button1.Name = "button1";
            button1.Size = new Size(162, 32);
            button1.TabIndex = 4;
            button1.Text = "全局代理";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 165);
            label3.Name = "label3";
            label3.Size = new Size(0, 17);
            label3.TabIndex = 5;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 226);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form2";
            Text = "本地代理";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Button button1;
        private Label label3;
    }
}