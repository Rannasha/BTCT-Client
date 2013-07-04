namespace BTCTC
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.tbSecurity = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOrderType = new System.Windows.Forms.ComboBox();
            this.cbExpiry = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbCancelOrderId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(64, 39);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(265, 22);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 36);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Authorize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Verifier";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(656, 76);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "Get Portfolio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(11, 74);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(633, 430);
            this.textBox4.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(448, 4);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Load Token";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(448, 36);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 28);
            this.button5.TabIndex = 11;
            this.button5.Text = "Save Token";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(656, 108);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 28);
            this.button7.TabIndex = 13;
            this.button7.Text = "Trade Hist.";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 22);
            this.textBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "API Key";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 512);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Auth status";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 56);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 28);
            this.button8.TabIndex = 18;
            this.button8.Text = "Cancel Order";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tbSecurity
            // 
            this.tbSecurity.Location = new System.Drawing.Point(100, 24);
            this.tbSecurity.Name = "tbSecurity";
            this.tbSecurity.Size = new System.Drawing.Size(168, 22);
            this.tbSecurity.TabIndex = 19;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(100, 52);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(168, 22);
            this.tbAmount.TabIndex = 20;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(100, 80);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(168, 22);
            this.tbPrice.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Security";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Price";
            // 
            // cbOrderType
            // 
            this.cbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderType.FormattingEnabled = true;
            this.cbOrderType.Items.AddRange(new object[] {
            "Buy",
            "Sell"});
            this.cbOrderType.Location = new System.Drawing.Point(100, 108);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(168, 24);
            this.cbOrderType.TabIndex = 26;
            // 
            // cbExpiry
            // 
            this.cbExpiry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExpiry.FormattingEnabled = true;
            this.cbExpiry.Items.AddRange(new object[] {
            "0",
            "1",
            "7",
            "14",
            "30",
            "90"});
            this.cbExpiry.Location = new System.Drawing.Point(100, 136);
            this.cbExpiry.Name = "cbExpiry";
            this.cbExpiry.Size = new System.Drawing.Size(168, 24);
            this.cbExpiry.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Order Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "Expiry (days)";
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Location = new System.Drawing.Point(12, 168);
            this.btnSubmitOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(100, 28);
            this.btnSubmitOrder.TabIndex = 31;
            this.btnSubmitOrder.Text = "Submit";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            this.btnSubmitOrder.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSecurity);
            this.groupBox1.Controls.Add(this.btnSubmitOrder);
            this.groupBox1.Controls.Add(this.tbAmount);
            this.groupBox1.Controls.Add(this.tbPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbExpiry);
            this.groupBox1.Controls.Add(this.cbOrderType);
            this.groupBox1.Location = new System.Drawing.Point(656, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 204);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Submit Order";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCancelOrderId);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Location = new System.Drawing.Point(656, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 92);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancel Order";
            // 
            // tbCancelOrderId
            // 
            this.tbCancelOrderId.Location = new System.Drawing.Point(100, 24);
            this.tbCancelOrderId.Name = "tbCancelOrderId";
            this.tbCancelOrderId.Size = new System.Drawing.Size(168, 22);
            this.tbCancelOrderId.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Order ID";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(656, 140);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 28);
            this.button6.TabIndex = 33;
            this.button6.Text = "Div. Hist.";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 540);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "BTCT-Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tbSecurity;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOrderType;
        private System.Windows.Forms.ComboBox cbExpiry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbCancelOrderId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button6;
    }
}

