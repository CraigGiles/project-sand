namespace ProjectSandWindows
{
    partial class ExporterForm
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
            this.exportXmlButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportXmlButton
            // 
            this.exportXmlButton.Location = new System.Drawing.Point(267, 19);
            this.exportXmlButton.Name = "exportXmlButton";
            this.exportXmlButton.Size = new System.Drawing.Size(75, 23);
            this.exportXmlButton.TabIndex = 7;
            this.exportXmlButton.Text = "Export XML";
            this.exportXmlButton.UseVisualStyleBackColor = true;
            this.exportXmlButton.Click += new System.EventHandler(this.exportXmlButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exportXmlButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 53);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export";
            // 
            // ExporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(647, 466);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(655, 500);
            this.MinimumSize = new System.Drawing.Size(655, 500);
            this.Name = "ExporterForm";
            this.Text = "ExporterForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exportXmlButton;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}