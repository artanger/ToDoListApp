namespace ToDoListApp
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
            txtTask = new TextBox();
            lstTasks = new ListBox();
            btnSave = new Button();
            btnLoad = new Button();
            lblStatistics = new Label();
            label1 = new Label();
            labelDate = new Label();
            lblDate = new Label();
            btnDelete = new Button();
            calendarPanel = new Panel();
            monthLabel = new Label();
            prevButton = new Button();
            nextButton = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTask
            // 
            txtTask.Location = new Point(12, 367);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(370, 25);
            txtTask.TabIndex = 0;
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.Location = new Point(12, 17);
            lstTasks.Name = "lstTasks";
            lstTasks.SelectionMode = SelectionMode.MultiExtended;
            lstTasks.Size = new Size(182, 344);
            lstTasks.TabIndex = 1;
            lstTasks.DoubleClick += lstTasks_DoubleClick;
            lstTasks.KeyDown += lstTasks_KeyDown;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(200, 336);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 25);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSaveTask_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(200, 307);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(182, 25);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click_1;
            // 
            // lblStatistics
            // 
            lblStatistics.AutoSize = true;
            lblStatistics.Location = new Point(200, 17);
            lblStatistics.Name = "lblStatistics";
            lblStatistics.Size = new Size(143, 17);
            lblStatistics.TabIndex = 6;
            lblStatistics.Text = "ForStatistics and Errors";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 47);
            label1.Name = "label1";
            label1.Size = new Size(0, 17);
            label1.TabIndex = 7;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(200, 67);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(38, 17);
            labelDate.TabIndex = 8;
            labelDate.Text = "Date:";
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.None;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Location = new Point(244, 67);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 17);
            lblDate.TabIndex = 9;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(200, 279);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(182, 25);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // calendarPanel
            // 
            tableLayoutPanel1.SetColumnSpan(calendarPanel, 7);
            calendarPanel.Dock = DockStyle.Top;
            calendarPanel.Location = new Point(3, 103);
            calendarPanel.Name = "calendarPanel";
            calendarPanel.Size = new Size(313, 300);
            calendarPanel.TabIndex = 16;
            // 
            // monthLabel
            // 
            monthLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(monthLabel, 2);
            monthLabel.Dock = DockStyle.Fill;
            monthLabel.Location = new Point(48, 0);
            monthLabel.Name = "monthLabel";
            monthLabel.Size = new Size(84, 50);
            monthLabel.TabIndex = 12;
            monthLabel.Text = "monthLabel";
            monthLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // prevButton
            // 
            prevButton.Dock = DockStyle.Fill;
            prevButton.Location = new Point(3, 3);
            prevButton.Name = "prevButton";
            prevButton.Size = new Size(39, 44);
            prevButton.TabIndex = 13;
            prevButton.Text = "<";
            prevButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            nextButton.Dock = DockStyle.Fill;
            nextButton.Location = new Point(138, 3);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(39, 44);
            nextButton.TabIndex = 14;
            nextButton.Text = ">";
            nextButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(270, 50);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(49, 50);
            label8.TabIndex = 6;
            label8.Text = "Вс";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(225, 50);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(45, 50);
            label7.TabIndex = 5;
            label7.Text = "Сб";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(180, 50);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(45, 50);
            label6.TabIndex = 4;
            label6.Text = "Пт";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(135, 50);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(45, 50);
            label5.TabIndex = 3;
            label5.Text = "Чт";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(90, 50);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(45, 50);
            label4.TabIndex = 2;
            label4.Text = "Ср";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(45, 50);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(45, 50);
            label3.TabIndex = 1;
            label3.Text = "Вт";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(0, 50);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(45, 50);
            label2.TabIndex = 0;
            label2.Text = "Пн";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel1.Controls.Add(label8, 6, 1);
            tableLayoutPanel1.Controls.Add(label7, 5, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label6, 4, 1);
            tableLayoutPanel1.Controls.Add(label3, 1, 1);
            tableLayoutPanel1.Controls.Add(label5, 3, 1);
            tableLayoutPanel1.Controls.Add(label4, 2, 1);
            tableLayoutPanel1.Controls.Add(calendarPanel, 0, 2);
            tableLayoutPanel1.Controls.Add(prevButton, 0, 0);
            tableLayoutPanel1.Controls.Add(nextButton, 3, 0);
            tableLayoutPanel1.Controls.Add(monthLabel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Right;
            tableLayoutPanel1.Location = new Point(412, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.000008F));
            tableLayoutPanel1.Size = new Size(319, 414);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // Form1
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 414);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(btnDelete);
            Controls.Add(lblDate);
            Controls.Add(labelDate);
            Controls.Add(label1);
            Controls.Add(lblStatistics);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(lstTasks);
            Controls.Add(txtTask);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTask;
        private ListBox lstTasks;
        private Button btnSave;
        private Button btnLoad;
        private Label lblStatistics;
        private Label label1;
        private Label labelDate;
        private Label lblDate;
        private Button btnDelete;
        private Panel calendarPanel;
        private Label monthLabel;
        private Button prevButton;
        private Button nextButton;
        private Label dayLabel2;
        private Label dayLabel1;
        private Label dayLabel5;
        private Label dayLabel4;
        private Label dayLabel3;
     
        private Label dayLabel7;
        private Label dayLabel6;
      
        private Button dayButton4;
        private Button dayButton3;
        private Button dayButton2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
