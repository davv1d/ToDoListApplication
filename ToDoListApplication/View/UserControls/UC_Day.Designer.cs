
namespace ToDoListApplication.View.UserControls
{
    partial class UC_Day
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Day));
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanelTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.labelDate.Location = new System.Drawing.Point(34, 31);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(55, 23);
            this.labelDate.TabIndex = 14;
            this.labelDate.Text = "date";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.textBoxTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTitle.Location = new System.Drawing.Point(178, 502);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTitle.MaxLength = 35;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(681, 32);
            this.textBoxTitle.TabIndex = 9;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.textBoxDesc.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDesc.Location = new System.Drawing.Point(178, 542);
            this.textBoxDesc.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDesc.MaxLength = 80;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(681, 32);
            this.textBoxDesc.TabIndex = 11;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTask.Image")));
            this.btnAddTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTask.Location = new System.Drawing.Point(726, 597);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Padding = new System.Windows.Forms.Padding(3);
            this.btnAddTask.Size = new System.Drawing.Size(133, 40);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "  Add Task";
            this.btnAddTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label1.Location = new System.Drawing.Point(34, 505);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.label2.Location = new System.Drawing.Point(34, 547);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description:";
            // 
            // flowLayoutPanelTasks
            // 
            this.flowLayoutPanelTasks.AutoScroll = true;
            this.flowLayoutPanelTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.flowLayoutPanelTasks.Controls.Add(this.panel4);
            this.flowLayoutPanelTasks.Location = new System.Drawing.Point(19, 76);
            this.flowLayoutPanelTasks.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelTasks.Name = "flowLayoutPanelTasks";
            this.flowLayoutPanelTasks.Size = new System.Drawing.Size(899, 381);
            this.flowLayoutPanelTasks.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(7, 8);
            this.panel4.TabIndex = 0;
            // 
            // UC_Tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanelTasks);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "UC_Tasks";
            this.Size = new System.Drawing.Size(937, 680);
            this.flowLayoutPanelTasks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTasks;
        private System.Windows.Forms.Panel panel4;
    }
}
