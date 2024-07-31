namespace QuickGrocery
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblOutOfStock = new System.Windows.Forms.Label();
            this.chartDashboard = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTopSellingProducts = new System.Windows.Forms.DataGridView();
            this.dgvRecentTransactions = new System.Windows.Forms.DataGridView();
            this.lblTodaySales = new System.Windows.Forms.Label();
            this.lblWeekSales = new System.Windows.Forms.Label();
            this.lblMonthSales = new System.Windows.Forms.Label();
            this.lblYearSales = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSellingProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcomeMessage
            // 
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeMessage.Location = new System.Drawing.Point(1135, 41);
            this.lblWelcomeMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(2, 23);
            this.lblWelcomeMessage.TabIndex = 0;
            this.lblWelcomeMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem,
            this.checkOutToolStripMenuItem,
            this.orderHistoryToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1386, 27);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // checkOutToolStripMenuItem
            // 
            this.checkOutToolStripMenuItem.Name = "checkOutToolStripMenuItem";
            this.checkOutToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.checkOutToolStripMenuItem.Text = "Check out";
            this.checkOutToolStripMenuItem.Click += new System.EventHandler(this.checkOutToolStripMenuItem_Click);
            // 
            // orderHistoryToolStripMenuItem
            // 
            this.orderHistoryToolStripMenuItem.Name = "orderHistoryToolStripMenuItem";
            this.orderHistoryToolStripMenuItem.Size = new System.Drawing.Size(105, 21);
            this.orderHistoryToolStripMenuItem.Text = "Order History";
            this.orderHistoryToolStripMenuItem.Click += new System.EventHandler(this.orderHistoryToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // lblLowStock
            // 
            this.lblLowStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.Location = new System.Drawing.Point(44, 27);
            this.lblLowStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(293, 46);
            this.lblLowStock.TabIndex = 0;
            // 
            // lblOutOfStock
            // 
            this.lblOutOfStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOutOfStock.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutOfStock.Location = new System.Drawing.Point(44, 32);
            this.lblOutOfStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Size = new System.Drawing.Size(293, 46);
            this.lblOutOfStock.TabIndex = 0;
            // 
            // chartDashboard
            // 
            chartArea9.Name = "ChartArea1";
            this.chartDashboard.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.chartDashboard.Legends.Add(legend9);
            this.chartDashboard.Location = new System.Drawing.Point(875, 135);
            this.chartDashboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartDashboard.Name = "chartDashboard";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series";
            this.chartDashboard.Series.Add(series9);
            this.chartDashboard.Size = new System.Drawing.Size(462, 526);
            this.chartDashboard.TabIndex = 5;
            this.chartDashboard.Text = "Revenue Chart";
            // 
            // dgvTopSellingProducts
            // 
            this.dgvTopSellingProducts.AllowUserToAddRows = false;
            this.dgvTopSellingProducts.AllowUserToDeleteRows = false;
            this.dgvTopSellingProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTopSellingProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTopSellingProducts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTopSellingProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopSellingProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSellingProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvTopSellingProducts.Location = new System.Drawing.Point(17, 25);
            this.dgvTopSellingProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvTopSellingProducts.MultiSelect = false;
            this.dgvTopSellingProducts.Name = "dgvTopSellingProducts";
            this.dgvTopSellingProducts.ReadOnly = true;
            this.dgvTopSellingProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSellingProducts.Size = new System.Drawing.Size(309, 167);
            this.dgvTopSellingProducts.TabIndex = 6;
            // 
            // dgvRecentTransactions
            // 
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.AllowUserToResizeColumns = false;
            this.dgvRecentTransactions.AllowUserToResizeRows = false;
            this.dgvRecentTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRecentTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecentTransactions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRecentTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvRecentTransactions.Location = new System.Drawing.Point(7, 35);
            this.dgvRecentTransactions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRecentTransactions.MultiSelect = false;
            this.dgvRecentTransactions.Name = "dgvRecentTransactions";
            this.dgvRecentTransactions.ReadOnly = true;
            this.dgvRecentTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentTransactions.Size = new System.Drawing.Size(429, 167);
            this.dgvRecentTransactions.TabIndex = 6;
            // 
            // lblTodaySales
            // 
            this.lblTodaySales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTodaySales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaySales.Location = new System.Drawing.Point(44, 31);
            this.lblTodaySales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodaySales.Name = "lblTodaySales";
            this.lblTodaySales.Size = new System.Drawing.Size(293, 46);
            this.lblTodaySales.TabIndex = 0;
            // 
            // lblWeekSales
            // 
            this.lblWeekSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblWeekSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeekSales.Location = new System.Drawing.Point(32, 31);
            this.lblWeekSales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWeekSales.Name = "lblWeekSales";
            this.lblWeekSales.Size = new System.Drawing.Size(293, 46);
            this.lblWeekSales.TabIndex = 0;
            // 
            // lblMonthSales
            // 
            this.lblMonthSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMonthSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthSales.Location = new System.Drawing.Point(32, 21);
            this.lblMonthSales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthSales.Name = "lblMonthSales";
            this.lblMonthSales.Size = new System.Drawing.Size(293, 46);
            this.lblMonthSales.TabIndex = 0;
            // 
            // lblYearSales
            // 
            this.lblYearSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblYearSales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearSales.Location = new System.Drawing.Point(32, 32);
            this.lblYearSales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYearSales.Name = "lblYearSales";
            this.lblYearSales.Size = new System.Drawing.Size(293, 46);
            this.lblYearSales.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTopSellingProducts);
            this.groupBox2.Location = new System.Drawing.Point(41, 443);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 218);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Top Selling Products";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvRecentTransactions);
            this.groupBox3.Location = new System.Drawing.Point(406, 443);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 218);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recent Transactions";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblMonthSales);
            this.groupBox5.Location = new System.Drawing.Point(467, 234);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(346, 82);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Month Sales";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblWeekSales);
            this.groupBox6.Location = new System.Drawing.Point(467, 322);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(346, 92);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Week Sales";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblYearSales);
            this.groupBox7.Location = new System.Drawing.Point(467, 135);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(346, 92);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Year Sales";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblTodaySales);
            this.groupBox8.Location = new System.Drawing.Point(46, 322);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(346, 92);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Today Sales";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblOutOfStock);
            this.groupBox9.Location = new System.Drawing.Point(46, 135);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(346, 92);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Out Of Stock";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblLowStock);
            this.groupBox10.Location = new System.Drawing.Point(46, 234);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(346, 82);
            this.groupBox10.TabIndex = 10;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Low Stock";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "QuickGrocery Dashboard - Overview of Store Metrics";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chartDashboard);
            this.Controls.Add(this.lblWelcomeMessage);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSellingProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentTransactions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblOutOfStock;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDashboard;
        private System.Windows.Forms.DataGridView dgvTopSellingProducts;
        private System.Windows.Forms.DataGridView dgvRecentTransactions;
        private System.Windows.Forms.Label lblTodaySales;
        private System.Windows.Forms.Label lblWeekSales;
        private System.Windows.Forms.Label lblMonthSales;
        private System.Windows.Forms.Label lblYearSales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label1;
    }
}