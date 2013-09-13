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
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbVerifier = new System.Windows.Forms.TextBox();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPortfolioOAuth = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.btnLoadToken = new System.Windows.Forms.Button();
            this.btnSaveToken = new System.Windows.Forms.Button();
            this.btnTradeHist = new System.Windows.Forms.Button();
            this.tbApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAuthStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
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
            this.btnDivHist = new System.Windows.Forms.Button();
            this.cbGlobalDataSelect = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGlobalData = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbSingleTicker = new System.Windows.Forms.ComboBox();
            this.tbTicker = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSingleTicker = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTransfer = new System.Windows.Forms.Button();
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(256, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbVerifier
            // 
            this.tbVerifier.Location = new System.Drawing.Point(48, 32);
            this.tbVerifier.Name = "tbVerifier";
            this.tbVerifier.Size = new System.Drawing.Size(200, 20);
            this.tbVerifier.TabIndex = 5;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(256, 29);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 6;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Verifier";
            // 
            // btnPortfolioOAuth
            // 
            this.btnPortfolioOAuth.Location = new System.Drawing.Point(248, 540);
            this.btnPortfolioOAuth.Name = "btnPortfolioOAuth";
            this.btnPortfolioOAuth.Size = new System.Drawing.Size(75, 23);
            this.btnPortfolioOAuth.TabIndex = 8;
            this.btnPortfolioOAuth.Text = "Portf. (OA)";
            this.btnPortfolioOAuth.UseVisualStyleBackColor = true;
            this.btnPortfolioOAuth.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(4, 60);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(476, 451);
            this.tbOutput.TabIndex = 9;
            // 
            // btnLoadToken
            // 
            this.btnLoadToken.Location = new System.Drawing.Point(336, 3);
            this.btnLoadToken.Name = "btnLoadToken";
            this.btnLoadToken.Size = new System.Drawing.Size(75, 23);
            this.btnLoadToken.TabIndex = 10;
            this.btnLoadToken.Text = "Load Token";
            this.btnLoadToken.UseVisualStyleBackColor = true;
            this.btnLoadToken.Click += new System.EventHandler(this.btnLoadtoken_Click);
            // 
            // btnSaveToken
            // 
            this.btnSaveToken.Location = new System.Drawing.Point(336, 29);
            this.btnSaveToken.Name = "btnSaveToken";
            this.btnSaveToken.Size = new System.Drawing.Size(75, 23);
            this.btnSaveToken.TabIndex = 11;
            this.btnSaveToken.Text = "Save Token";
            this.btnSaveToken.UseVisualStyleBackColor = true;
            this.btnSaveToken.Click += new System.EventHandler(this.btnSaveToken_Click);
            // 
            // btnTradeHist
            // 
            this.btnTradeHist.Location = new System.Drawing.Point(328, 540);
            this.btnTradeHist.Name = "btnTradeHist";
            this.btnTradeHist.Size = new System.Drawing.Size(75, 23);
            this.btnTradeHist.TabIndex = 13;
            this.btnTradeHist.Text = "Trade Hist.";
            this.btnTradeHist.UseVisualStyleBackColor = true;
            this.btnTradeHist.Click += new System.EventHandler(this.btnTradeHist_Click);
            // 
            // tbApiKey
            // 
            this.tbApiKey.Location = new System.Drawing.Point(48, 8);
            this.tbApiKey.Name = "tbApiKey";
            this.tbApiKey.Size = new System.Drawing.Size(200, 20);
            this.tbApiKey.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "API Key";
            // 
            // tbAuthStatus
            // 
            this.tbAuthStatus.Location = new System.Drawing.Point(76, 540);
            this.tbAuthStatus.Margin = new System.Windows.Forms.Padding(2);
            this.tbAuthStatus.Name = "tbAuthStatus";
            this.tbAuthStatus.ReadOnly = true;
            this.tbAuthStatus.Size = new System.Drawing.Size(76, 20);
            this.tbAuthStatus.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 541);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Auth status";
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(6, 46);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(75, 23);
            this.btnCancelOrder.TabIndex = 18;
            this.btnCancelOrder.Text = "Submit";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // tbSecurity
            // 
            this.tbSecurity.Location = new System.Drawing.Point(75, 20);
            this.tbSecurity.Margin = new System.Windows.Forms.Padding(2);
            this.tbSecurity.Name = "tbSecurity";
            this.tbSecurity.Size = new System.Drawing.Size(127, 20);
            this.tbSecurity.TabIndex = 19;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(75, 42);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(2);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(127, 20);
            this.tbAmount.TabIndex = 20;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(75, 65);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(127, 20);
            this.tbPrice.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Security";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
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
            this.cbOrderType.Location = new System.Drawing.Point(75, 88);
            this.cbOrderType.Margin = new System.Windows.Forms.Padding(2);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(127, 21);
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
            this.cbExpiry.Location = new System.Drawing.Point(75, 110);
            this.cbExpiry.Margin = new System.Windows.Forms.Padding(2);
            this.cbExpiry.Name = "cbExpiry";
            this.cbExpiry.Size = new System.Drawing.Size(127, 21);
            this.cbExpiry.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 91);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Order Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Expiry (days)";
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Location = new System.Drawing.Point(9, 136);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(75, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(492, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(210, 166);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Submit Order";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbCancelOrderId);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnCancelOrder);
            this.groupBox2.Location = new System.Drawing.Point(492, 336);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(210, 75);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancel Order";
            // 
            // tbCancelOrderId
            // 
            this.tbCancelOrderId.Location = new System.Drawing.Point(75, 20);
            this.tbCancelOrderId.Margin = new System.Windows.Forms.Padding(2);
            this.tbCancelOrderId.Name = "tbCancelOrderId";
            this.tbCancelOrderId.Size = new System.Drawing.Size(127, 20);
            this.tbCancelOrderId.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Order ID";
            // 
            // btnDivHist
            // 
            this.btnDivHist.Location = new System.Drawing.Point(408, 540);
            this.btnDivHist.Name = "btnDivHist";
            this.btnDivHist.Size = new System.Drawing.Size(75, 23);
            this.btnDivHist.TabIndex = 33;
            this.btnDivHist.Text = "Div. Hist.";
            this.btnDivHist.UseVisualStyleBackColor = true;
            this.btnDivHist.Click += new System.EventHandler(this.btnDivHist_Click);
            // 
            // cbGlobalDataSelect
            // 
            this.cbGlobalDataSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGlobalDataSelect.FormattingEnabled = true;
            this.cbGlobalDataSelect.Items.AddRange(new object[] {
            "Tickers",
            "Trade history (48h)",
            "Dividends (48h)"});
            this.cbGlobalDataSelect.Location = new System.Drawing.Point(75, 16);
            this.cbGlobalDataSelect.Margin = new System.Windows.Forms.Padding(2);
            this.cbGlobalDataSelect.Name = "cbGlobalDataSelect";
            this.cbGlobalDataSelect.Size = new System.Drawing.Size(127, 21);
            this.cbGlobalDataSelect.TabIndex = 32;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnGlobalData);
            this.groupBox3.Controls.Add(this.cbGlobalDataSelect);
            this.groupBox3.Location = new System.Drawing.Point(492, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 72);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Global data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Data";
            // 
            // btnGlobalData
            // 
            this.btnGlobalData.Location = new System.Drawing.Point(8, 44);
            this.btnGlobalData.Name = "btnGlobalData";
            this.btnGlobalData.Size = new System.Drawing.Size(75, 23);
            this.btnGlobalData.TabIndex = 36;
            this.btnGlobalData.Text = "Submit";
            this.btnGlobalData.UseVisualStyleBackColor = true;
            this.btnGlobalData.Click += new System.EventHandler(this.btnGlobalData_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbSingleTicker);
            this.groupBox4.Controls.Add(this.tbTicker);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnSingleTicker);
            this.groupBox4.Location = new System.Drawing.Point(492, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 72);
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
            this.cbSingleTicker.Location = new System.Drawing.Point(88, 44);
            this.cbSingleTicker.Margin = new System.Windows.Forms.Padding(2);
            this.cbSingleTicker.Name = "cbSingleTicker";
            this.cbSingleTicker.Size = new System.Drawing.Size(111, 21);
            this.cbSingleTicker.TabIndex = 32;
            // 
            // tbTicker
            // 
            this.tbTicker.Location = new System.Drawing.Point(72, 20);
            this.tbTicker.Margin = new System.Windows.Forms.Padding(2);
            this.tbTicker.Name = "tbTicker";
            this.tbTicker.Size = new System.Drawing.Size(127, 20);
            this.tbTicker.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Ticker";
            // 
            // btnSingleTicker
            // 
            this.btnSingleTicker.Location = new System.Drawing.Point(8, 44);
            this.btnSingleTicker.Margin = new System.Windows.Forms.Padding(2);
            this.btnSingleTicker.Name = "btnSingleTicker";
            this.btnSingleTicker.Size = new System.Drawing.Size(75, 23);
            this.btnSingleTicker.TabIndex = 34;
            this.btnSingleTicker.Text = "Submit";
            this.btnSingleTicker.UseVisualStyleBackColor = true;
            this.btnSingleTicker.Click += new System.EventHandler(this.btnSingleTicker_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTransfer);
            this.groupBox5.Controls.Add(this.tbTransferUser);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.tbTransferSecurity);
            this.groupBox5.Controls.Add(this.lbTransferSecurity);
            this.groupBox5.Controls.Add(this.tbTransferAmount);
            this.groupBox5.Controls.Add(this.cbTransferType);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(492, 416);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(210, 144);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Transfer";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(8, 116);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 33;
            this.btnTransfer.Text = "Submit";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.button10_Click);
            // 
            // tbTransferUser
            // 
            this.tbTransferUser.Location = new System.Drawing.Point(76, 92);
            this.tbTransferUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbTransferUser.Name = "tbTransferUser";
            this.tbTransferUser.Size = new System.Drawing.Size(127, 20);
            this.tbTransferUser.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 94);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Username";
            // 
            // tbTransferSecurity
            // 
            this.tbTransferSecurity.Location = new System.Drawing.Point(76, 48);
            this.tbTransferSecurity.Margin = new System.Windows.Forms.Padding(2);
            this.tbTransferSecurity.Name = "tbTransferSecurity";
            this.tbTransferSecurity.Size = new System.Drawing.Size(127, 20);
            this.tbTransferSecurity.TabIndex = 32;
            // 
            // lbTransferSecurity
            // 
            this.lbTransferSecurity.AutoSize = true;
            this.lbTransferSecurity.Location = new System.Drawing.Point(28, 51);
            this.lbTransferSecurity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTransferSecurity.Name = "lbTransferSecurity";
            this.lbTransferSecurity.Size = new System.Drawing.Size(45, 13);
            this.lbTransferSecurity.TabIndex = 34;
            this.lbTransferSecurity.Text = "Security";
            // 
            // tbTransferAmount
            // 
            this.tbTransferAmount.Location = new System.Drawing.Point(76, 70);
            this.tbTransferAmount.Margin = new System.Windows.Forms.Padding(2);
            this.tbTransferAmount.Name = "tbTransferAmount";
            this.tbTransferAmount.Size = new System.Drawing.Size(127, 20);
            this.tbTransferAmount.TabIndex = 33;
            // 
            // cbTransferType
            // 
            this.cbTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransferType.FormattingEnabled = true;
            this.cbTransferType.Items.AddRange(new object[] {
            "Coins",
            "Assets"});
            this.cbTransferType.Location = new System.Drawing.Point(99, 21);
            this.cbTransferType.Margin = new System.Windows.Forms.Padding(2);
            this.cbTransferType.Name = "cbTransferType";
            this.cbTransferType.Size = new System.Drawing.Size(99, 21);
            this.cbTransferType.TabIndex = 36;
            this.cbTransferType.SelectedIndexChanged += new System.EventHandler(this.cbTransferType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 74);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Amount";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Coins / assets";
            // 
            // btnDepHist
            // 
            this.btnDepHist.Location = new System.Drawing.Point(328, 517);
            this.btnDepHist.Name = "btnDepHist";
            this.btnDepHist.Size = new System.Drawing.Size(75, 23);
            this.btnDepHist.TabIndex = 38;
            this.btnDepHist.Text = "Deposit Hist.";
            this.btnDepHist.UseVisualStyleBackColor = true;
            this.btnDepHist.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnWithdrHist
            // 
            this.btnWithdrHist.Location = new System.Drawing.Point(408, 517);
            this.btnWithdrHist.Name = "btnWithdrHist";
            this.btnWithdrHist.Size = new System.Drawing.Size(75, 23);
            this.btnWithdrHist.TabIndex = 39;
            this.btnWithdrHist.Text = "Withdr. Hist.";
            this.btnWithdrHist.UseVisualStyleBackColor = true;
            this.btnWithdrHist.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnPortfolioApi
            // 
            this.btnPortfolioApi.Location = new System.Drawing.Point(248, 517);
            this.btnPortfolioApi.Name = "btnPortfolioApi";
            this.btnPortfolioApi.Size = new System.Drawing.Size(75, 23);
            this.btnPortfolioApi.TabIndex = 40;
            this.btnPortfolioApi.Text = "Portf. (key)";
            this.btnPortfolioApi.UseVisualStyleBackColor = true;
            this.btnPortfolioApi.Click += new System.EventHandler(this.btnPortfolioApi_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(776, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTCTC_MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 566);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPortfolioApi);
            this.Controls.Add(this.btnWithdrHist);
            this.Controls.Add(this.btnDepHist);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDivHist);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAuthStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbApiKey);
            this.Controls.Add(this.btnTradeHist);
            this.Controls.Add(this.btnSaveToken);
            this.Controls.Add(this.btnLoadToken);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btnPortfolioOAuth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.tbVerifier);
            this.Controls.Add(this.btnConnect);
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

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbVerifier;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPortfolioOAuth;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnLoadToken;
        private System.Windows.Forms.Button btnSaveToken;
        private System.Windows.Forms.Button btnTradeHist;
        private System.Windows.Forms.TextBox tbApiKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAuthStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelOrder;
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
        private System.Windows.Forms.Button btnDivHist;
        private System.Windows.Forms.ComboBox cbGlobalDataSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGlobalData;
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
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox tbTransferUser;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDepHist;
        private System.Windows.Forms.Button btnWithdrHist;
        private System.Windows.Forms.Button btnPortfolioApi;
        private System.Windows.Forms.Button button1;
    }
}

