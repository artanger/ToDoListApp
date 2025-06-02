namespace ToDoListApp
{
    partial class AddNewCategories
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
            tableLayoutPanel1 = new TableLayoutPanel();
            txtNewCategories = new TextBox();
            btnCancel = new Button();
            btnSaveNewCategories = new Button();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 277F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 267F));
            tableLayoutPanel1.Controls.Add(txtNewCategories, 0, 1);
            tableLayoutPanel1.Controls.Add(btnCancel, 2, 2);
            tableLayoutPanel1.Controls.Add(btnSaveNewCategories, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(608, 165);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // txtNewCategories
            // 
            txtNewCategories.Anchor = AnchorStyles.None;
            tableLayoutPanel1.SetColumnSpan(txtNewCategories, 3);
            txtNewCategories.Location = new Point(3, 62);
            txtNewCategories.Name = "txtNewCategories";
            txtNewCategories.Size = new Size(602, 25);
            txtNewCategories.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(336, 103);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(269, 44);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnSaveNewCategories
            // 
            btnSaveNewCategories.Dock = DockStyle.Fill;
            btnSaveNewCategories.Location = new Point(3, 103);
            btnSaveNewCategories.Name = "btnSaveNewCategories";
            btnSaveNewCategories.Size = new Size(271, 44);
            btnSaveNewCategories.TabIndex = 1;
            btnSaveNewCategories.Text = "Add";
            btnSaveNewCategories.UseVisualStyleBackColor = true;
            btnSaveNewCategories.Click += btnSaveNewCategories_Click_1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(271, 50);
            label1.TabIndex = 3;
            label1.Text = "Enter New Categorie";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // AddNewCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 165);
            Controls.Add(tableLayoutPanel1);
            Name = "AddNewCategories";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddNewCategories";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtNewCategories;
        private Button btnSaveNewCategories;
        private Button btnCancel;
        private Label label1;
    }
}