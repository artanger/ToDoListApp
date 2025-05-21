
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
            btnAdd = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            lblStatistics = new Label();
            label1 = new Label();
            labelDate = new Label();
            lblDate = new Label();
            btnDelete = new Button();
            chkServer = new CheckBox();
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
            // btnAdd
            // 
            btnAdd.Location = new Point(200, 334);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(182, 27);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Task";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(200, 303);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 25);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(200, 274);
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
            labelDate.Location = new Point(200, 64);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(38, 17);
            labelDate.TabIndex = 8;
            labelDate.Text = "Date:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(244, 64);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(0, 17);
            lblDate.TabIndex = 9;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(200, 246);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(182, 25);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // chkServer
            // 
            chkServer.AutoSize = true;
            chkServer.Location = new Point(200, 103);
            chkServer.Name = "chkServer";
            chkServer.Size = new Size(15, 14);
            chkServer.TabIndex = 11;
            chkServer.UseVisualStyleBackColor = true;
            chkServer.CheckedChanged += ChkServer_CheckedChanged;
            // 
            // Form1
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 408);
            Controls.Add(chkServer);
            Controls.Add(btnDelete);
            Controls.Add(lblDate);
            Controls.Add(labelDate);
            Controls.Add(label1);
            Controls.Add(lblStatistics);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(lstTasks);
            Controls.Add(txtTask);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox txtTask;
        private ListBox lstTasks;
        private Button btnAdd;
        private Button btnSave;
        private Button btnLoad;
        private Label lblStatistics;
        private Label label1;
        private Label labelDate;
        private Label lblDate;
        private Button btnDelete;
        private CheckBox chkServer;
    }
}
