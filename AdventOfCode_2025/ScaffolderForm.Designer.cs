namespace AdventOfCode_2025_Interface
{
    partial class ScaffolderForm
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
            lblDay = new Label();
            txtDay = new TextBox();
            btnGenerate = new Button();
            lblPart = new Label();
            txtPart = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            SuspendLayout();
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Location = new Point(71, 76);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(35, 20);
            lblDay.TabIndex = 7;
            lblDay.Text = "Day";
            // 
            // txtDay
            // 
            txtDay.Location = new Point(112, 73);
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(38, 27);
            txtDay.TabIndex = 6;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(369, 118);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(94, 29);
            btnGenerate.TabIndex = 5;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblPart
            // 
            lblPart.AutoSize = true;
            lblPart.Location = new Point(384, 76);
            lblPart.Name = "lblPart";
            lblPart.Size = new Size(34, 20);
            lblPart.TabIndex = 9;
            lblPart.Text = "Part";
            // 
            // txtPart
            // 
            txtPart.Location = new Point(425, 73);
            txtPart.Name = "txtPart";
            txtPart.Size = new Size(38, 27);
            txtPart.TabIndex = 8;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(156, 76);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(200, 73);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(178, 27);
            txtTitle.TabIndex = 10;
            // 
            // ScaffolderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 198);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblPart);
            Controls.Add(txtPart);
            Controls.Add(lblDay);
            Controls.Add(txtDay);
            Controls.Add(btnGenerate);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ScaffolderForm";
            Text = "ScaffolderForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDay;
        private TextBox txtDay;
        private Button btnGenerate;
        private Label lblPart;
        private TextBox txtPart;
        private Label lblTitle;
        private TextBox txtTitle;
    }
}