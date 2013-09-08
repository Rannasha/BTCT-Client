namespace BTCTC
{
    partial class BTCTC_MainWindow
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
            this.btnPortfolioOAuth = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tbApiKey = new System.Windows.Forms.TextBox();
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
            this.cbGlobalDataSelect = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbSingleTicker = new System.Windows.Forms.ComboBox();
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSingleTicker = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.tbTransferUser = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbTransferSecurity = new System.Windows.Forms.TextBox();
            this.lbTransferSecurity = new System.Windows.Forms.Label();
            this.tbTransferAmount = new System.Windows.Forms.TextBox();
            this.cbTransferType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDepHist = new System.Windows.Forms.Button();
            this.btnWithdrHist = new System.Windows.Forms.Button();
            this.btnPortfolioApi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(265, 22);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 36);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // btnPortfolioOAuth
            // 
            this.btnPortfolioOAuth.Location = new System.Drawing.Point(331, 665);
            this.btnPortfolioOAuth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPortfolioOAuth.Name = "btnPortfolioOAuth";
            this.btnPortfolioOAuth.Size = new System.Drawing.Size(100, 28);
            this.btnPortfolioOAuth.TabIndex = 8;
            this.btnPortfolioOAuth.Text = "Portf. (OA)";
            this.btnPortfolioOAuth.UseVisualStyleBackColor = true;
            this.btnPortfolioOAuth.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(5, 74);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(633, 554);
            this.tbOutput.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(448, 4);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 28);
            this.button5.TabIndex = 11;
            this.button5.Text = "Save Token";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(437, 665);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 28);
            this.button7.TabIndex = 13;
            this.button7.Text = "Trade Hist.";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(64, 10);
            this.tbApiKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(265, 22);
            this.tbApiKey.TabIndex = 14;
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
            this.textBox2.Location = new System.Drawing.Point(101, 665);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 666);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Auth status";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 57);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 28);
            this.button8.TabIndex = 18;
            this.button8.Text = "Submit";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tbSecurity
            // 
            this.tbSecurity.Location = new System.Drawing.Point(100, 25);
            this.tbSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSecurity.Name = "tbSecurity";
            this.tbSecurity.Size = new System.Drawing.Size(168, 22);
            this.tbSecurity.TabIndex = 19;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(100, 52);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(168, 22);
            this.tbAmount.TabIndex = 20;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(100, 80);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.label5.Location = new System.Drawing.Point(40, 57);
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
            this.cbOrderType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.cbExpiry.Location = new System.Drawing.Point(100, 135);
            this.cbExpiry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.btnSubmitOrder.Location = new System.Drawing.Point(12, 167);
            this.btnSubmitOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.groupBox1.Location = new System.Drawing.Point(656, 202);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.groupBox2.Location = new System.Drawing.Point(656, 414);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(280, 92);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancel Order";
            // 
            // tbCancelOrderId
            // 
            this.tbCancelOrderId.Location = new System.Drawing.Point(100, 25);
            this.tbCancelOrderId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.button6.Location = new System.Drawing.Point(544, 665);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 28);
            this.button6.TabIndex = 33;
            this.button6.Text = "Div. Hist.";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // cbGlobalDataSelect
            // 
            this.cbGlobalDataSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGlobalDataSelect.FormattingEnabled = true;
            this.cbGlobalDataSelect.Items.AddRange(new object[] {
            "Tickers",
            "Trade history (48h)",
            "Dividends (48h)"});
            this.cbGlobalDataSelect.Location = new System.Drawing.Point(100, 20);
            this.cbGlobalDataSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbGlobalDataSelect.Name = "cbGlobalDataSelect";
            this.cbGlobalDataSelect.Size = new System.Drawing.Size(168, 24);
            this.cbGlobalDataSelect.TabIndex = 32;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.cbGlobalDataSelect);
            this.groupBox3.Location = new System.Drawing.Point(656, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(280, 89);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Global data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "Data";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(11, 54);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 28);
            this.button9.TabIndex = 36;
            this.button9.Text = "Submit";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbSingleTicker);
            this.groupBox4.Controls.Add(this.tbTicker);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnSingleTicker);
            this.groupBox4.Location = new System.Drawing.Point(656, 108);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(280, 89);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Single ticker";
            // 
            // cbSingleTicker
            // 
            this.cbSingleTicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSingleTicker.FormattingEnabled = true;
            this.cbSingleTicker.Items.AddRange(new object[] {
            "Ticker",
            "Order book",
            "Trade history",
            "Trade history (all)",
            "Dividend history",
            "Contract data"});
            this.cbSingleTicker.Location = new System.Drawing.Point(117, 54);
            this.cbSingleTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSingleTicker.Name = "cbSingleTicker";
            this.cbSingleTicker.Size = new System.Drawing.Size(147, 24);
            this.cbSingleTicker.TabIndex = 32;
            // 
            // tbTicker
            // 
            this.tbTicker.Location = new System.Drawing.Point(96, 25);
            this.tbTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.Size = new System.Drawing.Size(168, 22);
            this.tbTicker.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Ticker";
            // 
            // btnSingleTicker
            // 
            this.btnSingleTicker.Location = new System.Drawing.Point(11, 54);
            this.btnSingleTicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSingleTicker.Name = "btnSingleTicker";
            this.btnSingleTicker.Size = new System.Drawing.Size(100, 28);
            this.btnSingleTicker.TabIndex = 34;
            this.btnSingleTicker.Text = "Submit";
            this.btnSingleTicker.UseVisualStyleBackColor = true;
            this.btnSingleTicker.Click += new System.EventHandler(this.btnSingleTicker_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.tbTransferUser);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.tbTransferSecurity);
            this.groupBox5.Controls.Add(this.lbTransferSecurity);
            this.groupBox5.Controls.Add(this.tbTransferAmount);
            this.groupBox5.Controls.Add(this.cbTransferType);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(656, 512);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox5.Size = new System.Drawing.Size(280, 177);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Transfer";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(11, 143);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 28);
            this.button10.TabIndex = 33;
            this.button10.Text = "Submit";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // tbTransferUser
            // 
            this.tbTransferUser.Location = new System.Drawing.Point(101, 113);
            this.tbTransferUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTransferUser.Name = "tbTransferUser";
            this.tbTransferUser.Size = new System.Drawing.Size(168, 22);
            this.tbTransferUser.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 17);
            this.label15.TabIndex = 39;
            this.label15.Text = "Username";
            // 
            // tbTransferSecurity
            // 
            this.tbTransferSecurity.Location = new System.Drawing.Point(101, 59);
            this.tbTransferSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTransferSecurity.Name = "tbTransferSecurity";
            this.tbTransferSecurity.Size = new System.Drawing.Size(168, 22);
            this.tbTransferSecurity.TabIndex = 32;
            // 
            // lbTransferSecurity
            // 
            this.lbTransferSecurity.AutoSize = true;
            this.lbTransferSecurity.Location = new System.Drawing.Point(37, 63);
            this.lbTransferSecurity.Name = "lbTransferSecurity";
            this.lbTransferSecurity.Size = new System.Drawing.Size(59, 17);
            this.lbTransferSecurity.TabIndex = 34;
            this.lbTransferSecurity.Text = "Security";
            // 
            // tbTransferAmount
            // 
            this.tbTransferAmount.Location = new System.Drawing.Point(101, 86);
            this.tbTransferAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTransferAmount.Name = "tbTransferAmount";
            this.tbTransferAmount.Size = new System.Drawing.Size(168, 22);
            this.tbTransferAmount.TabIndex = 33;
            // 
            // cbTransferType
            // 
            this.cbTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransferType.FormattingEnabled = true;
            this.cbTransferType.Items.AddRange(new object[] {
            "Coins",
            "Assets"});
            this.cbTransferType.Location = new System.Drawing.Point(132, 26);
            this.cbTransferType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTransferType.Name = "cbTransferType";
            this.cbTransferType.Size = new System.Drawing.Size(131, 24);
            this.cbTransferType.TabIndex = 36;
            this.cbTransferType.SelectedIndexChanged += new System.EventHandler(this.cbTransferType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 17);
            this.label14.TabIndex = 35;
            this.label14.Text = "Amount";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "Coins / assets";
            // 
            // btnDepHist
            // 
            this.btnDepHist.Location = new System.Drawing.Point(437, 636);
            this.btnDepHist.Margin = new System.Windows.Forms.Padding(4);
            this.btnDepHist.Name = "btnDepHist";
            this.btnDepHist.Size = new System.Drawing.Size(100, 28);
            this.btnDepHist.TabIndex = 38;
            this.btnDepHist.Text = "Deposit Hist.";
            this.btnDepHist.UseVisualStyleBackColor = true;
            this.btnDepHist.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnWithdrHist
            // 
            this.btnWithdrHist.Location = new System.Drawing.Point(544, 636);
            this.btnWithdrHist.Margin = new System.Windows.Forms.Padding(4);
            this.btnWithdrHist.Name = "btnWithdrHist";
            this.btnWithdrHist.Size = new System.Drawing.Size(100, 28);
            this.btnWithdrHist.TabIndex = 39;
            this.btnWithdrHist.Text = "Withdr. Hist.";
            this.btnWithdrHist.UseVisualStyleBackColor = true;
            this.btnWithdrHist.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnPortfolioApi
            // 
            this.btnPortfolioApi.Location = new System.Drawing.Point(331, 636);
            this.btnPortfolioApi.Margin = new System.Windows.Forms.Padding(4);
            this.btnPortfolioApi.Name = "btnPortfolioApi";
            this.btnPortfolioApi.Size = new System.Drawing.Size(100, 28);
            this.btnPortfolioApi.TabIndex = 40;
            this.btnPortfolioApi.Text = "Portf. (key)";
            this.btnPortfolioApi.UseVisualStyleBackColor = true;
            this.btnPortfolioApi.Click += new System.EventHandler(this.btnPortfolioApi_Click);
            // 
            // BTCTC_MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 697);
            this.Controls.Add(this.btnPortfolioApi);
            this.Controls.Add(this.btnWithdrHist);
            this.Controls.Add(this.btnDepHist);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btnPortfolioOAuth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BTCTC_MainWindow";
            this.Text = "BTCT-Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPortfolioOAuth;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox tbApiKey;
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
        private System.Windows.Forms.ComboBox cbGlobalDataSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbSingleTicker;
        private System.Windows.Forms.TextBox tbTicker;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSingleTicker;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbTransferSecurity;
        private System.Windows.Forms.Label lbTransferSecurity;
        private System.Windows.Forms.TextBox tbTransferAmount;
        private System.Windows.Forms.ComboBox cbTransferType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox tbTransferUser;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDepHist;
        private System.Windows.Forms.Button btnWithdrHist;
        private System.Windows.Forms.Button btnPortfolioApi;
    }
}

