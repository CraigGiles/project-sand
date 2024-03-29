namespace ProjectSandWindows
{
    partial class frmTileProperties
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.txtTileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numTileWidth = new System.Windows.Forms.NumericUpDown();
            this.numTileHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numHorizSpace = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.numVerticalSpace = new System.Windows.Forms.NumericUpDown();
            this.numClipLeft = new System.Windows.Forms.NumericUpDown();
            this.numClipTop = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSizePosition = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picTransparent = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.picTilePreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticalSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClipLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClipTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransparent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTilePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPreview.Location = new System.Drawing.Point(2, 2);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(208, 267);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picPreview_MouseClick);
            // 
            // txtTileName
            // 
            this.txtTileName.Location = new System.Drawing.Point(291, 6);
            this.txtTileName.MaxLength = 20;
            this.txtTileName.Multiline = true;
            this.txtTileName.Name = "txtTileName";
            this.txtTileName.Size = new System.Drawing.Size(100, 20);
            this.txtTileName.TabIndex = 1;
            this.txtTileName.Text = "Tile1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tile Name:";
            // 
            // numTileWidth
            // 
            this.numTileWidth.Location = new System.Drawing.Point(337, 42);
            this.numTileWidth.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTileWidth.Name = "numTileWidth";
            this.numTileWidth.Size = new System.Drawing.Size(54, 20);
            this.numTileWidth.TabIndex = 2;
            this.numTileWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numTileHeight
            // 
            this.numTileHeight.Location = new System.Drawing.Point(337, 68);
            this.numTileHeight.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTileHeight.Name = "numTileHeight";
            this.numTileHeight.Size = new System.Drawing.Size(54, 20);
            this.numTileHeight.TabIndex = 3;
            this.numTileHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tile Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tile Height:";
            // 
            // numHorizSpace
            // 
            this.numHorizSpace.Location = new System.Drawing.Point(337, 94);
            this.numHorizSpace.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numHorizSpace.Name = "numHorizSpace";
            this.numHorizSpace.Size = new System.Drawing.Size(54, 20);
            this.numHorizSpace.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Horizontal space:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vertical space:";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(2, 252);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(188, 17);
            this.hScrollBar1.TabIndex = 5;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(190, 2);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 250);
            this.vScrollBar1.TabIndex = 6;
            // 
            // numVerticalSpace
            // 
            this.numVerticalSpace.Location = new System.Drawing.Point(337, 120);
            this.numVerticalSpace.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numVerticalSpace.Name = "numVerticalSpace";
            this.numVerticalSpace.Size = new System.Drawing.Size(54, 20);
            this.numVerticalSpace.TabIndex = 5;
            // 
            // numClipLeft
            // 
            this.numClipLeft.Location = new System.Drawing.Point(337, 146);
            this.numClipLeft.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numClipLeft.Name = "numClipLeft";
            this.numClipLeft.Size = new System.Drawing.Size(54, 20);
            this.numClipLeft.TabIndex = 6;
            // 
            // numClipTop
            // 
            this.numClipTop.Location = new System.Drawing.Point(337, 172);
            this.numClipTop.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numClipTop.Name = "numClipTop";
            this.numClipTop.Size = new System.Drawing.Size(54, 20);
            this.numClipTop.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Clip from left:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Clip from top:";
            // 
            // lblSizePosition
            // 
            this.lblSizePosition.Location = new System.Drawing.Point(0, 269);
            this.lblSizePosition.Name = "lblSizePosition";
            this.lblSizePosition.Size = new System.Drawing.Size(208, 13);
            this.lblSizePosition.TabIndex = 7;
            this.lblSizePosition.Text = "Size (400, 600), Position (25, 125)";
            this.lblSizePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(13, 292);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(94, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picTransparent
            // 
            this.picTransparent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picTransparent.Location = new System.Drawing.Point(337, 200);
            this.picTransparent.Name = "picTransparent";
            this.picTransparent.Size = new System.Drawing.Size(54, 22);
            this.picTransparent.TabIndex = 9;
            this.picTransparent.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Transparent Color:";
            // 
            // picTilePreview
            // 
            this.picTilePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picTilePreview.Location = new System.Drawing.Point(233, 232);
            this.picTilePreview.Name = "picTilePreview";
            this.picTilePreview.Size = new System.Drawing.Size(158, 83);
            this.picTilePreview.TabIndex = 10;
            this.picTilePreview.TabStop = false;
            // 
            // frmTileProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 327);
            this.Controls.Add(this.picTilePreview);
            this.Controls.Add(this.picTransparent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblSizePosition);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numClipTop);
            this.Controls.Add(this.numClipLeft);
            this.Controls.Add(this.numVerticalSpace);
            this.Controls.Add(this.numHorizSpace);
            this.Controls.Add(this.numTileHeight);
            this.Controls.Add(this.numTileWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTileName);
            this.Controls.Add(this.picPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTileProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Properties";
            this.Load += new System.EventHandler(this.frmTileSheetProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHorizSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVerticalSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClipLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClipTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransparent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTilePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.TextBox txtTileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTileWidth;
        private System.Windows.Forms.NumericUpDown numTileHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numHorizSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.NumericUpDown numVerticalSpace;
        private System.Windows.Forms.NumericUpDown numClipLeft;
        private System.Windows.Forms.NumericUpDown numClipTop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSizePosition;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picTransparent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picTilePreview;
    }
}