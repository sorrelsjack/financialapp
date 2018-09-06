namespace financial_app
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bySymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marquee = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RefreshColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ActualDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HighValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LowValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolumeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financedataDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.financedataDataSet = new financial_app.financedataDataSet();
            this.historicDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historicDataTableAdapter = new financial_app.financedataDataSetTableAdapters.HistoricDataTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financedataDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financedataDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicDataBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.bySymbolToolStripMenuItem,
            this.byDateToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // bySymbolToolStripMenuItem
            // 
            this.bySymbolToolStripMenuItem.Name = "bySymbolToolStripMenuItem";
            this.bySymbolToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.bySymbolToolStripMenuItem.Text = "By Symbol";
            this.bySymbolToolStripMenuItem.Click += new System.EventHandler(this.bySymbolToolStripMenuItem_Click);
            // 
            // byDateToolStripMenuItem
            // 
            this.byDateToolStripMenuItem.Name = "byDateToolStripMenuItem";
            this.byDateToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.byDateToolStripMenuItem.Text = "By Date";
            this.byDateToolStripMenuItem.Click += new System.EventHandler(this.byDateToolStripMenuItem_Click);
            // 
            // marquee
            // 
            this.marquee.AutoSize = true;
            this.marquee.BackColor = System.Drawing.Color.Black;
            this.marquee.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marquee.ForeColor = System.Drawing.Color.Lime;
            this.marquee.Location = new System.Drawing.Point(766, 11);
            this.marquee.Name = "marquee";
            this.marquee.Size = new System.Drawing.Size(189, 20);
            this.marquee.TabIndex = 1;
            this.marquee.Text = "Hey I\'m a marquee!";
            this.marquee.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(11, 623);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 37);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefreshColumn,
            this.ActualDate,
            this.StockSymbol,
            this.StockName,
            this.OpenValue,
            this.HighValue,
            this.LowValue,
            this.CloseValue,
            this.VolumeValue});
            this.dataGridView1.DataSource = this.financedataDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1201, 533);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RefreshColumn
            // 
            this.RefreshColumn.HeaderText = "Ref";
            this.RefreshColumn.Name = "RefreshColumn";
            this.RefreshColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RefreshColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RefreshColumn.Text = "↻";
            this.RefreshColumn.UseColumnTextForButtonValue = true;
            this.RefreshColumn.Width = 40;
            // 
            // ActualDate
            // 
            this.ActualDate.DataPropertyName = "ActualDate";
            this.ActualDate.HeaderText = "Date";
            this.ActualDate.Name = "ActualDate";
            // 
            // StockSymbol
            // 
            this.StockSymbol.DataPropertyName = "StockSymbol";
            this.StockSymbol.HeaderText = "Symbol";
            this.StockSymbol.Name = "StockSymbol";
            // 
            // StockName
            // 
            this.StockName.DataPropertyName = "StockName";
            this.StockName.HeaderText = "Company";
            this.StockName.Name = "StockName";
            // 
            // OpenValue
            // 
            this.OpenValue.DataPropertyName = "OpenValue";
            this.OpenValue.HeaderText = "Open";
            this.OpenValue.Name = "OpenValue";
            // 
            // HighValue
            // 
            this.HighValue.DataPropertyName = "HighValue";
            this.HighValue.HeaderText = "High";
            this.HighValue.Name = "HighValue";
            // 
            // LowValue
            // 
            this.LowValue.DataPropertyName = "LowValue";
            this.LowValue.HeaderText = "Low";
            this.LowValue.Name = "LowValue";
            // 
            // CloseValue
            // 
            this.CloseValue.DataPropertyName = "CloseValue";
            this.CloseValue.HeaderText = "Close";
            this.CloseValue.Name = "CloseValue";
            // 
            // VolumeValue
            // 
            this.VolumeValue.DataPropertyName = "VolumeValue";
            this.VolumeValue.HeaderText = "Volume";
            this.VolumeValue.Name = "VolumeValue";
            // 
            // financedataDataSetBindingSource
            // 
            this.financedataDataSetBindingSource.DataSource = this.financedataDataSet;
            this.financedataDataSetBindingSource.Position = 0;
            // 
            // financedataDataSet
            // 
            this.financedataDataSet.DataSetName = "financedataDataSet";
            this.financedataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // historicDataBindingSource
            // 
            this.historicDataBindingSource.DataMember = "HistoricData";
            this.historicDataBindingSource.DataSource = this.financedataDataSetBindingSource;
            // 
            // historicDataTableAdapter
            // 
            this.historicDataTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.marquee);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(9000, 43);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 671);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Tracker App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financedataDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financedataDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicDataBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label marquee;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bySymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource financedataDataSetBindingSource;
        private financedataDataSet financedataDataSet;
        private System.Windows.Forms.BindingSource historicDataBindingSource;
        private financedataDataSetTableAdapters.HistoricDataTableAdapter historicDataTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn RefreshColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn HighValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CloseValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumeValue;
        private System.Windows.Forms.Panel panel1;
    }
}

