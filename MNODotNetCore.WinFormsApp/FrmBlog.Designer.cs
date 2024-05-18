namespace MNODotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(172, 67);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(577, 30);
            txtTitle.TabIndex = 0;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(172, 144);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(577, 30);
            txtAuthor.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(172, 225);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(577, 152);
            txtContent.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(172, 40);
            label1.Name = "label1";
            label1.Size = new Size(46, 23);
            label1.TabIndex = 3;
            label1.Text = "Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 117);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 4;
            label2.Text = "Author:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 199);
            label3.Name = "label3";
            label3.Size = new Size(76, 23);
            label3.TabIndex = 5;
            label3.Text = "Content:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(57, 62, 70);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = SystemColors.ControlLight;
            btnCancel.Location = new Point(172, 396);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 42);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "C&ancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(17, 138, 126);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = SystemColors.ControlLight;
            btnSave.Location = new Point(300, 396);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 42);
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 518);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCancel;
        private Button btnSave;
    }
}
