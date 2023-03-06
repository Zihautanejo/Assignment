namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            oper1 = new Button();
            oper2 = new Button();
            oper3 = new Button();
            oper4 = new Button();
            calculator = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // oper1
            // 
            oper1.Location = new Point(52, 62);
            oper1.Name = "oper1";
            oper1.Size = new Size(112, 34);
            oper1.TabIndex = 9;
            oper1.Text = "+";
            oper1.UseVisualStyleBackColor = true;
            oper1.Click += oper1_Click;
            // 
            // oper2
            // 
            oper2.Location = new Point(52, 135);
            oper2.Name = "oper2";
            oper2.Size = new Size(112, 34);
            oper2.TabIndex = 10;
            oper2.Text = "-";
            oper2.UseVisualStyleBackColor = true;
            oper2.Click += oper2_Click_1;
            // 
            // oper3
            // 
            oper3.Location = new Point(203, 62);
            oper3.Name = "oper3";
            oper3.Size = new Size(112, 34);
            oper3.TabIndex = 11;
            oper3.Text = "*";
            oper3.UseVisualStyleBackColor = true;
            oper3.Click += oper3_Click_1;
            // 
            // oper4
            // 
            oper4.Location = new Point(203, 135);
            oper4.Name = "oper4";
            oper4.Size = new Size(112, 34);
            oper4.TabIndex = 12;
            oper4.Text = "/";
            oper4.UseVisualStyleBackColor = true;
            oper4.Click += oper4_Click_1;
            // 
            // calculator
            // 
            calculator.Location = new Point(633, 62);
            calculator.Name = "calculator";
            calculator.Size = new Size(112, 107);
            calculator.TabIndex = 13;
            calculator.Text = "Calculator";
            calculator.UseVisualStyleBackColor = true;
            calculator.Click += calculator_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(446, 62);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 30);
            textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(446, 137);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 30);
            textBox2.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 140);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 17;
            label2.Text = "第二个数字";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(340, 65);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 18;
            label1.Text = "第一个数字";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 211);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(calculator);
            Controls.Add(oper4);
            Controls.Add(oper3);
            Controls.Add(oper2);
            Controls.Add(oper1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button oper1;
        private Button oper2;
        private Button oper3;
        private Button oper4;
        private Button calculator;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label1;
    }
}