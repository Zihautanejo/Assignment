namespace OrderServiceWinForms
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            item = new ComboBox();
            text = new TextBox();
            OrderbindingSource = new BindingSource(components);
            sort = new Button();
            query = new Button();
            modify = new Button();
            delete = new Button();
            CreatDetail = new Button();
            creatorder = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            detailpanel = new Panel();
            dataGridView1 = new DataGridView();
            goodsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DetailbindingSource = new BindingSource(components);
            DetaildataGridView = new DataGridView();
            orderPanel = new Panel();
            OrderdataGridView = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            createTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            totalPriceDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            tableLayoutPanel3 = new TableLayoutPanel();
            idlable = new Label();
            IDtext = new TextBox();
            otherlabel = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderbindingSource).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            detailpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DetailbindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DetaildataGridView).BeginInit();
            orderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderdataGridView).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.Controls.Add(item, 3, 0);
            tableLayoutPanel1.Controls.Add(text, 4, 0);
            tableLayoutPanel1.Controls.Add(idlable, 0, 0);
            tableLayoutPanel1.Controls.Add(IDtext, 1, 0);
            tableLayoutPanel1.Controls.Add(otherlabel, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1358, 84);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // item
            // 
            item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            item.FormattingEnabled = true;
            item.Items.AddRange(new object[] { "All", "CustomerName", "CreatTime", "OrderTotalPrice", "GoodsName", "DetailTotalPrice", "Quantity" });
            item.Location = new Point(687, 26);
            item.Margin = new Padding(10);
            item.Name = "item";
            item.Size = new Size(251, 32);
            item.TabIndex = 0;
            item.SelectedIndexChanged += item_SelectedIndexChanged;
            // 
            // text
            // 
            text.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            text.Location = new Point(958, 27);
            text.Margin = new Padding(10);
            text.Name = "text";
            text.Size = new Size(390, 30);
            text.TabIndex = 1;
            // 
            // OrderbindingSource
            // 
            OrderbindingSource.DataSource = typeof(OrderApp.Order);
            // 
            // sort
            // 
            sort.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            sort.Location = new Point(1230, 22);
            sort.Margin = new Padding(10);
            sort.Name = "sort";
            sort.Size = new Size(118, 34);
            sort.TabIndex = 5;
            sort.Text = "排序";
            sort.UseVisualStyleBackColor = true;
            sort.Click += sort_Click;
            // 
            // query
            // 
            query.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            query.Location = new Point(986, 22);
            query.Margin = new Padding(10);
            query.Name = "query";
            query.Size = new Size(224, 34);
            query.TabIndex = 4;
            query.Text = "查询订单";
            query.UseVisualStyleBackColor = true;
            query.Click += query_Click;
            // 
            // modify
            // 
            modify.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modify.Location = new Point(742, 22);
            modify.Margin = new Padding(10);
            modify.Name = "modify";
            modify.Size = new Size(224, 34);
            modify.TabIndex = 3;
            modify.Text = "修改订单";
            modify.UseVisualStyleBackColor = true;
            modify.Click += modify_Click;
            // 
            // delete
            // 
            delete.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            delete.Location = new Point(498, 22);
            delete.Margin = new Padding(10);
            delete.Name = "delete";
            delete.Size = new Size(224, 34);
            delete.TabIndex = 2;
            delete.Text = "删除订单";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // CreatDetail
            // 
            CreatDetail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CreatDetail.Location = new Point(254, 22);
            CreatDetail.Margin = new Padding(10);
            CreatDetail.Name = "CreatDetail";
            CreatDetail.Size = new Size(224, 34);
            CreatDetail.TabIndex = 1;
            CreatDetail.Text = "创建详细";
            CreatDetail.UseVisualStyleBackColor = true;
            CreatDetail.Click += CreatDetail_Click;
            // 
            // creatorder
            // 
            creatorder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            creatorder.Location = new Point(10, 22);
            creatorder.Margin = new Padding(10);
            creatorder.Name = "creatorder";
            creatorder.Size = new Size(224, 34);
            creatorder.TabIndex = 0;
            creatorder.Text = "创建订单";
            creatorder.UseVisualStyleBackColor = true;
            creatorder.Click += creatorder_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.Controls.Add(creatorder, 0, 0);
            tableLayoutPanel2.Controls.Add(CreatDetail, 1, 0);
            tableLayoutPanel2.Controls.Add(delete, 2, 0);
            tableLayoutPanel2.Controls.Add(modify, 3, 0);
            tableLayoutPanel2.Controls.Add(query, 4, 0);
            tableLayoutPanel2.Controls.Add(sort, 5, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 84);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1358, 78);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // detailpanel
            // 
            detailpanel.BackColor = SystemColors.ControlDark;
            detailpanel.Controls.Add(dataGridView1);
            detailpanel.Controls.Add(DetaildataGridView);
            detailpanel.Dock = DockStyle.Fill;
            detailpanel.Location = new Point(689, 10);
            detailpanel.Margin = new Padding(10);
            detailpanel.Name = "detailpanel";
            detailpanel.Size = new Size(659, 520);
            detailpanel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { goodsDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn, totalPriceDataGridViewTextBoxColumn });
            dataGridView1.DataSource = DetailbindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(659, 520);
            dataGridView1.TabIndex = 3;
            // 
            // goodsDataGridViewTextBoxColumn
            // 
            goodsDataGridViewTextBoxColumn.DataPropertyName = "Goods";
            goodsDataGridViewTextBoxColumn.HeaderText = "Goods";
            goodsDataGridViewTextBoxColumn.MinimumWidth = 8;
            goodsDataGridViewTextBoxColumn.Name = "goodsDataGridViewTextBoxColumn";
            goodsDataGridViewTextBoxColumn.Width = 150;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn.MinimumWidth = 8;
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.Width = 150;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            totalPriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // DetailbindingSource
            // 
            DetailbindingSource.DataMember = "Details";
            DetailbindingSource.DataSource = OrderbindingSource;
            // 
            // DetaildataGridView
            // 
            DetaildataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DetaildataGridView.Dock = DockStyle.Fill;
            DetaildataGridView.Location = new Point(0, 0);
            DetaildataGridView.Name = "DetaildataGridView";
            DetaildataGridView.RowHeadersWidth = 62;
            DetaildataGridView.RowTemplate.Height = 32;
            DetaildataGridView.Size = new Size(659, 520);
            DetaildataGridView.TabIndex = 0;
            // 
            // orderPanel
            // 
            orderPanel.BackColor = SystemColors.ControlDark;
            orderPanel.Controls.Add(OrderdataGridView);
            orderPanel.Dock = DockStyle.Fill;
            orderPanel.Location = new Point(10, 10);
            orderPanel.Margin = new Padding(10);
            orderPanel.Name = "orderPanel";
            orderPanel.Size = new Size(659, 520);
            orderPanel.TabIndex = 0;
            // 
            // OrderdataGridView
            // 
            OrderdataGridView.AutoGenerateColumns = false;
            OrderdataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderdataGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, customerDataGridViewTextBoxColumn1, createTimeDataGridViewTextBoxColumn1, totalPriceDataGridViewTextBoxColumn1 });
            OrderdataGridView.DataSource = OrderbindingSource;
            OrderdataGridView.Dock = DockStyle.Fill;
            OrderdataGridView.Location = new Point(0, 0);
            OrderdataGridView.Name = "OrderdataGridView";
            OrderdataGridView.RowHeadersWidth = 62;
            OrderdataGridView.RowTemplate.Height = 32;
            OrderdataGridView.Size = new Size(659, 520);
            OrderdataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.MinimumWidth = 8;
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.Width = 150;
            // 
            // customerDataGridViewTextBoxColumn1
            // 
            customerDataGridViewTextBoxColumn1.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn1.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn1.MinimumWidth = 8;
            customerDataGridViewTextBoxColumn1.Name = "customerDataGridViewTextBoxColumn1";
            customerDataGridViewTextBoxColumn1.Width = 150;
            // 
            // createTimeDataGridViewTextBoxColumn1
            // 
            createTimeDataGridViewTextBoxColumn1.DataPropertyName = "CreateTime";
            createTimeDataGridViewTextBoxColumn1.HeaderText = "CreateTime";
            createTimeDataGridViewTextBoxColumn1.MinimumWidth = 8;
            createTimeDataGridViewTextBoxColumn1.Name = "createTimeDataGridViewTextBoxColumn1";
            createTimeDataGridViewTextBoxColumn1.Width = 150;
            // 
            // totalPriceDataGridViewTextBoxColumn1
            // 
            totalPriceDataGridViewTextBoxColumn1.DataPropertyName = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn1.HeaderText = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn1.MinimumWidth = 8;
            totalPriceDataGridViewTextBoxColumn1.Name = "totalPriceDataGridViewTextBoxColumn1";
            totalPriceDataGridViewTextBoxColumn1.ReadOnly = true;
            totalPriceDataGridViewTextBoxColumn1.Width = 150;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(orderPanel, 0, 0);
            tableLayoutPanel3.Controls.Add(detailpanel, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 162);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(1358, 540);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // idlable
            // 
            idlable.Anchor = AnchorStyles.Right;
            idlable.AutoSize = true;
            idlable.Location = new Point(33, 30);
            idlable.Name = "idlable";
            idlable.Size = new Size(99, 24);
            idlable.TabIndex = 2;
            idlable.Text = "Id/GoodId";
            // 
            // IDtext
            // 
            IDtext.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            IDtext.Location = new Point(138, 27);
            IDtext.Name = "IDtext";
            IDtext.Size = new Size(401, 30);
            IDtext.TabIndex = 3;
            // 
            // otherlabel
            // 
            otherlabel.Anchor = AnchorStyles.Right;
            otherlabel.AutoSize = true;
            otherlabel.Location = new Point(592, 30);
            otherlabel.Name = "otherlabel";
            otherlabel.Size = new Size(82, 24);
            otherlabel.TabIndex = 4;
            otherlabel.Text = "其他项目";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1358, 702);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OrderbindingSource).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            detailpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DetailbindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)DetaildataGridView).EndInit();
            orderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OrderdataGridView).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox item;
        private TextBox text;
        private Button sort;
        private Button query;
        private Button modify;
        private Button delete;
        private Button CreatDetail;
        private Button creatorder;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel detailpanel;
        private DataGridView DetaildataGridView;
        private Panel orderPanel;
        private DataGridView OrderdataGridView;
        private TableLayoutPanel tableLayoutPanel3;
        private BindingSource OrderbindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn goodsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private BindingSource DetailbindingSource;
        private Label idlable;
        private TextBox IDtext;
        private Label otherlabel;
    }
}