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
            this.elementNameLabel = new System.Windows.Forms.Label();
            this.xmlOutputLabel = new System.Windows.Forms.Label();
            this.mapNameGroupBox = new System.Windows.Forms.GroupBox();
            this.exportMapNameCheckBox = new System.Windows.Forms.CheckBox();
            this.mapNameOutput = new System.Windows.Forms.Label();
            this.mapNameInput = new System.Windows.Forms.TextBox();
            this.mapDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.exportMapDimensionsCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customButton = new System.Windows.Forms.RadioButton();
            this.pointButton = new System.Windows.Forms.RadioButton();
            this.mapDimensionsOutput = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tileSheetGroupBox = new System.Windows.Forms.GroupBox();
            this.exportTileSheetCheckBox = new System.Windows.Forms.CheckBox();
            this.tileSheetOutput = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tileDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.tileDimensionsHeightTextBox = new System.Windows.Forms.TextBox();
            this.tileDimensionsWidthTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tileDimensionsCustom = new System.Windows.Forms.RadioButton();
            this.tileDimensionsPoint = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tileDimensionsOutput = new System.Windows.Forms.Label();
            this.exportTileDimensionsCheckBox = new System.Windows.Forms.CheckBox();
            this.layerInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.collisionLayerTextBox = new System.Windows.Forms.TextBox();
            this.atmosphereLayerTextBox = new System.Windows.Forms.TextBox();
            this.topLayerTextBox = new System.Windows.Forms.TextBox();
            this.middleLayerTextBox = new System.Windows.Forms.TextBox();
            this.baseLayerTextBox = new System.Windows.Forms.TextBox();
            this.mapLayerCheckBoxCollisionLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxAtmosphereLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxTopLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxMiddleLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxBaseLayer = new System.Windows.Forms.CheckBox();
            this.baseLayerOutput = new System.Windows.Forms.Label();
            this.middleLayerOutput = new System.Windows.Forms.Label();
            this.topLayerOutput = new System.Windows.Forms.Label();
            this.atmosphereLayerOutput = new System.Windows.Forms.Label();
            this.collisionLayerOutput = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.mapNameGroupBox.SuspendLayout();
            this.mapDimensionsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tileSheetGroupBox.SuspendLayout();
            this.tileDimensionsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.layerInformationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // elementNameLabel
            // 
            this.elementNameLabel.AutoSize = true;
            this.elementNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementNameLabel.Location = new System.Drawing.Point(103, 9);
            this.elementNameLabel.Name = "elementNameLabel";
            this.elementNameLabel.Size = new System.Drawing.Size(114, 20);
            this.elementNameLabel.TabIndex = 0;
            this.elementNameLabel.Text = "Element Name";
            // 
            // xmlOutputLabel
            // 
            this.xmlOutputLabel.AutoSize = true;
            this.xmlOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlOutputLabel.Location = new System.Drawing.Point(370, 9);
            this.xmlOutputLabel.Name = "xmlOutputLabel";
            this.xmlOutputLabel.Size = new System.Drawing.Size(95, 20);
            this.xmlOutputLabel.TabIndex = 1;
            this.xmlOutputLabel.Text = "XML Output";
            // 
            // mapNameGroupBox
            // 
            this.mapNameGroupBox.Controls.Add(this.exportMapNameCheckBox);
            this.mapNameGroupBox.Controls.Add(this.mapNameOutput);
            this.mapNameGroupBox.Controls.Add(this.mapNameInput);
            this.mapNameGroupBox.Location = new System.Drawing.Point(12, 32);
            this.mapNameGroupBox.Name = "mapNameGroupBox";
            this.mapNameGroupBox.Size = new System.Drawing.Size(610, 49);
            this.mapNameGroupBox.TabIndex = 2;
            this.mapNameGroupBox.TabStop = false;
            this.mapNameGroupBox.Text = "Map Name";
            // 
            // exportMapNameCheckBox
            // 
            this.exportMapNameCheckBox.AutoSize = true;
            this.exportMapNameCheckBox.Checked = true;
            this.exportMapNameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportMapNameCheckBox.Location = new System.Drawing.Point(7, 20);
            this.exportMapNameCheckBox.Name = "exportMapNameCheckBox";
            this.exportMapNameCheckBox.Size = new System.Drawing.Size(56, 17);
            this.exportMapNameCheckBox.TabIndex = 2;
            this.exportMapNameCheckBox.Text = "Export";
            this.exportMapNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // mapNameOutput
            // 
            this.mapNameOutput.AutoSize = true;
            this.mapNameOutput.Location = new System.Drawing.Point(225, 15);
            this.mapNameOutput.Name = "mapNameOutput";
            this.mapNameOutput.Size = new System.Drawing.Size(141, 13);
            this.mapNameOutput.TabIndex = 1;
            this.mapNameOutput.Text = "<Name>MapName</Name>";
            // 
            // mapNameInput
            // 
            this.mapNameInput.Location = new System.Drawing.Point(69, 18);
            this.mapNameInput.Name = "mapNameInput";
            this.mapNameInput.Size = new System.Drawing.Size(150, 20);
            this.mapNameInput.TabIndex = 0;
            this.mapNameInput.Text = "Name";
            // 
            // mapDimensionsGroupBox
            // 
            this.mapDimensionsGroupBox.Controls.Add(this.exportMapDimensionsCheckBox);
            this.mapDimensionsGroupBox.Controls.Add(this.textBox3);
            this.mapDimensionsGroupBox.Controls.Add(this.widthBox);
            this.mapDimensionsGroupBox.Controls.Add(this.groupBox1);
            this.mapDimensionsGroupBox.Controls.Add(this.mapDimensionsOutput);
            this.mapDimensionsGroupBox.Controls.Add(this.textBox1);
            this.mapDimensionsGroupBox.Location = new System.Drawing.Point(12, 88);
            this.mapDimensionsGroupBox.Name = "mapDimensionsGroupBox";
            this.mapDimensionsGroupBox.Size = new System.Drawing.Size(610, 179);
            this.mapDimensionsGroupBox.TabIndex = 3;
            this.mapDimensionsGroupBox.TabStop = false;
            this.mapDimensionsGroupBox.Text = "Map Dimensions";
            // 
            // exportMapDimensionsCheckBox
            // 
            this.exportMapDimensionsCheckBox.AutoSize = true;
            this.exportMapDimensionsCheckBox.Checked = true;
            this.exportMapDimensionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportMapDimensionsCheckBox.Location = new System.Drawing.Point(7, 20);
            this.exportMapDimensionsCheckBox.Name = "exportMapDimensionsCheckBox";
            this.exportMapDimensionsCheckBox.Size = new System.Drawing.Size(56, 17);
            this.exportMapDimensionsCheckBox.TabIndex = 5;
            this.exportMapDimensionsCheckBox.Text = "Export";
            this.exportMapDimensionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(96, 150);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(123, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Height";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(96, 124);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(123, 20);
            this.widthBox.TabIndex = 3;
            this.widthBox.Text = "Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customButton);
            this.groupBox1.Controls.Add(this.pointButton);
            this.groupBox1.Location = new System.Drawing.Point(69, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Type";
            // 
            // customButton
            // 
            this.customButton.AutoSize = true;
            this.customButton.Checked = true;
            this.customButton.Location = new System.Drawing.Point(7, 44);
            this.customButton.Name = "customButton";
            this.customButton.Size = new System.Drawing.Size(60, 17);
            this.customButton.TabIndex = 1;
            this.customButton.TabStop = true;
            this.customButton.Text = "Custom";
            this.customButton.UseVisualStyleBackColor = true;
            // 
            // pointButton
            // 
            this.pointButton.AutoSize = true;
            this.pointButton.Location = new System.Drawing.Point(7, 20);
            this.pointButton.Name = "pointButton";
            this.pointButton.Size = new System.Drawing.Size(49, 17);
            this.pointButton.TabIndex = 0;
            this.pointButton.Text = "Point";
            this.pointButton.UseVisualStyleBackColor = true;
            // 
            // mapDimensionsOutput
            // 
            this.mapDimensionsOutput.AutoSize = true;
            this.mapDimensionsOutput.Location = new System.Drawing.Point(224, 16);
            this.mapDimensionsOutput.Name = "mapDimensionsOutput";
            this.mapDimensionsOutput.Size = new System.Drawing.Size(120, 52);
            this.mapDimensionsOutput.TabIndex = 1;
            this.mapDimensionsOutput.Text = "<MapDimensions>\r\n     <Width>X</Width>\r\n     <Height>Y</Height>\r\n</MapDimensions>" +
                "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "MapDimensions";
            // 
            // tileSheetGroupBox
            // 
            this.tileSheetGroupBox.Controls.Add(this.exportTileSheetCheckBox);
            this.tileSheetGroupBox.Controls.Add(this.tileSheetOutput);
            this.tileSheetGroupBox.Controls.Add(this.textBox2);
            this.tileSheetGroupBox.Location = new System.Drawing.Point(12, 274);
            this.tileSheetGroupBox.Name = "tileSheetGroupBox";
            this.tileSheetGroupBox.Size = new System.Drawing.Size(610, 51);
            this.tileSheetGroupBox.TabIndex = 4;
            this.tileSheetGroupBox.TabStop = false;
            this.tileSheetGroupBox.Text = "Tile Sheet";
            // 
            // exportTileSheetCheckBox
            // 
            this.exportTileSheetCheckBox.AutoSize = true;
            this.exportTileSheetCheckBox.Checked = true;
            this.exportTileSheetCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportTileSheetCheckBox.Location = new System.Drawing.Point(7, 20);
            this.exportTileSheetCheckBox.Name = "exportTileSheetCheckBox";
            this.exportTileSheetCheckBox.Size = new System.Drawing.Size(56, 17);
            this.exportTileSheetCheckBox.TabIndex = 2;
            this.exportTileSheetCheckBox.Text = "Export";
            this.exportTileSheetCheckBox.UseVisualStyleBackColor = true;
            // 
            // tileSheetOutput
            // 
            this.tileSheetOutput.AutoSize = true;
            this.tileSheetOutput.Location = new System.Drawing.Point(225, 15);
            this.tileSheetOutput.Name = "tileSheetOutput";
            this.tileSheetOutput.Size = new System.Drawing.Size(418, 13);
            this.tileSheetOutput.TabIndex = 1;
            this.tileSheetOutput.Text = "<TileSheetContentName>Content//Textures//TextureName</TileSheetContentName>";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "TileSheetContentName";
            // 
            // tileDimensionsGroupBox
            // 
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsHeightTextBox);
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsWidthTextBox);
            this.tileDimensionsGroupBox.Controls.Add(this.groupBox2);
            this.tileDimensionsGroupBox.Controls.Add(this.textBox4);
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsOutput);
            this.tileDimensionsGroupBox.Controls.Add(this.exportTileDimensionsCheckBox);
            this.tileDimensionsGroupBox.Location = new System.Drawing.Point(12, 332);
            this.tileDimensionsGroupBox.Name = "tileDimensionsGroupBox";
            this.tileDimensionsGroupBox.Size = new System.Drawing.Size(610, 184);
            this.tileDimensionsGroupBox.TabIndex = 5;
            this.tileDimensionsGroupBox.TabStop = false;
            this.tileDimensionsGroupBox.Text = "Tile Dimensions";
            // 
            // tileDimensionsHeightTextBox
            // 
            this.tileDimensionsHeightTextBox.Location = new System.Drawing.Point(96, 148);
            this.tileDimensionsHeightTextBox.Name = "tileDimensionsHeightTextBox";
            this.tileDimensionsHeightTextBox.Size = new System.Drawing.Size(122, 20);
            this.tileDimensionsHeightTextBox.TabIndex = 5;
            this.tileDimensionsHeightTextBox.Text = "TileHeight";
            // 
            // tileDimensionsWidthTextBox
            // 
            this.tileDimensionsWidthTextBox.Location = new System.Drawing.Point(96, 121);
            this.tileDimensionsWidthTextBox.Name = "tileDimensionsWidthTextBox";
            this.tileDimensionsWidthTextBox.Size = new System.Drawing.Size(122, 20);
            this.tileDimensionsWidthTextBox.TabIndex = 4;
            this.tileDimensionsWidthTextBox.Text = "TileWidth";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tileDimensionsCustom);
            this.groupBox2.Controls.Add(this.tileDimensionsPoint);
            this.groupBox2.Location = new System.Drawing.Point(69, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // tileDimensionsCustom
            // 
            this.tileDimensionsCustom.AutoSize = true;
            this.tileDimensionsCustom.Location = new System.Drawing.Point(6, 43);
            this.tileDimensionsCustom.Name = "tileDimensionsCustom";
            this.tileDimensionsCustom.Size = new System.Drawing.Size(60, 17);
            this.tileDimensionsCustom.TabIndex = 1;
            this.tileDimensionsCustom.Text = "Custom";
            this.tileDimensionsCustom.UseVisualStyleBackColor = true;
            // 
            // tileDimensionsPoint
            // 
            this.tileDimensionsPoint.AutoSize = true;
            this.tileDimensionsPoint.Checked = true;
            this.tileDimensionsPoint.Location = new System.Drawing.Point(7, 20);
            this.tileDimensionsPoint.Name = "tileDimensionsPoint";
            this.tileDimensionsPoint.Size = new System.Drawing.Size(49, 17);
            this.tileDimensionsPoint.TabIndex = 0;
            this.tileDimensionsPoint.TabStop = true;
            this.tileDimensionsPoint.Text = "Point";
            this.tileDimensionsPoint.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(69, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 20);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "TileDimensions";
            // 
            // tileDimensionsOutput
            // 
            this.tileDimensionsOutput.AutoSize = true;
            this.tileDimensionsOutput.Location = new System.Drawing.Point(227, 20);
            this.tileDimensionsOutput.Name = "tileDimensionsOutput";
            this.tileDimensionsOutput.Size = new System.Drawing.Size(195, 13);
            this.tileDimensionsOutput.TabIndex = 1;
            this.tileDimensionsOutput.Text = "<TileDimensions>X Y</TileDimensions>";
            // 
            // exportTileDimensionsCheckBox
            // 
            this.exportTileDimensionsCheckBox.AutoSize = true;
            this.exportTileDimensionsCheckBox.Checked = true;
            this.exportTileDimensionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportTileDimensionsCheckBox.Location = new System.Drawing.Point(7, 20);
            this.exportTileDimensionsCheckBox.Name = "exportTileDimensionsCheckBox";
            this.exportTileDimensionsCheckBox.Size = new System.Drawing.Size(56, 17);
            this.exportTileDimensionsCheckBox.TabIndex = 0;
            this.exportTileDimensionsCheckBox.Text = "Export";
            this.exportTileDimensionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // layerInformationGroupBox
            // 
            this.layerInformationGroupBox.Controls.Add(this.collisionLayerOutput);
            this.layerInformationGroupBox.Controls.Add(this.atmosphereLayerOutput);
            this.layerInformationGroupBox.Controls.Add(this.topLayerOutput);
            this.layerInformationGroupBox.Controls.Add(this.middleLayerOutput);
            this.layerInformationGroupBox.Controls.Add(this.baseLayerOutput);
            this.layerInformationGroupBox.Controls.Add(this.collisionLayerTextBox);
            this.layerInformationGroupBox.Controls.Add(this.atmosphereLayerTextBox);
            this.layerInformationGroupBox.Controls.Add(this.topLayerTextBox);
            this.layerInformationGroupBox.Controls.Add(this.middleLayerTextBox);
            this.layerInformationGroupBox.Controls.Add(this.baseLayerTextBox);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxCollisionLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxAtmosphereLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxTopLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxMiddleLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxBaseLayer);
            this.layerInformationGroupBox.Location = new System.Drawing.Point(12, 523);
            this.layerInformationGroupBox.Name = "layerInformationGroupBox";
            this.layerInformationGroupBox.Size = new System.Drawing.Size(610, 181);
            this.layerInformationGroupBox.TabIndex = 6;
            this.layerInformationGroupBox.TabStop = false;
            this.layerInformationGroupBox.Text = "Map Layers";
            // 
            // collisionLayerTextBox
            // 
            this.collisionLayerTextBox.Location = new System.Drawing.Point(95, 120);
            this.collisionLayerTextBox.Name = "collisionLayerTextBox";
            this.collisionLayerTextBox.Size = new System.Drawing.Size(123, 20);
            this.collisionLayerTextBox.TabIndex = 9;
            this.collisionLayerTextBox.Text = "CollisionLayer";
            // 
            // atmosphereLayerTextBox
            // 
            this.atmosphereLayerTextBox.Location = new System.Drawing.Point(95, 94);
            this.atmosphereLayerTextBox.Name = "atmosphereLayerTextBox";
            this.atmosphereLayerTextBox.Size = new System.Drawing.Size(123, 20);
            this.atmosphereLayerTextBox.TabIndex = 8;
            this.atmosphereLayerTextBox.Text = "AtmosphereLayer";
            // 
            // topLayerTextBox
            // 
            this.topLayerTextBox.Location = new System.Drawing.Point(95, 68);
            this.topLayerTextBox.Name = "topLayerTextBox";
            this.topLayerTextBox.Size = new System.Drawing.Size(123, 20);
            this.topLayerTextBox.TabIndex = 7;
            this.topLayerTextBox.Text = "TopLayer";
            // 
            // middleLayerTextBox
            // 
            this.middleLayerTextBox.Location = new System.Drawing.Point(95, 42);
            this.middleLayerTextBox.Name = "middleLayerTextBox";
            this.middleLayerTextBox.Size = new System.Drawing.Size(123, 20);
            this.middleLayerTextBox.TabIndex = 6;
            this.middleLayerTextBox.Text = "MiddleLayer";
            // 
            // baseLayerTextBox
            // 
            this.baseLayerTextBox.Location = new System.Drawing.Point(95, 16);
            this.baseLayerTextBox.Name = "baseLayerTextBox";
            this.baseLayerTextBox.Size = new System.Drawing.Size(123, 20);
            this.baseLayerTextBox.TabIndex = 5;
            this.baseLayerTextBox.Text = "BaseLayer";
            // 
            // mapLayerCheckBoxCollisionLayer
            // 
            this.mapLayerCheckBoxCollisionLayer.AutoSize = true;
            this.mapLayerCheckBoxCollisionLayer.Checked = true;
            this.mapLayerCheckBoxCollisionLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxCollisionLayer.Location = new System.Drawing.Point(7, 123);
            this.mapLayerCheckBoxCollisionLayer.Name = "mapLayerCheckBoxCollisionLayer";
            this.mapLayerCheckBoxCollisionLayer.Size = new System.Drawing.Size(64, 17);
            this.mapLayerCheckBoxCollisionLayer.TabIndex = 4;
            this.mapLayerCheckBoxCollisionLayer.Text = "Collision";
            this.mapLayerCheckBoxCollisionLayer.UseVisualStyleBackColor = true;
            // 
            // mapLayerCheckBoxAtmosphereLayer
            // 
            this.mapLayerCheckBoxAtmosphereLayer.AutoSize = true;
            this.mapLayerCheckBoxAtmosphereLayer.Checked = true;
            this.mapLayerCheckBoxAtmosphereLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxAtmosphereLayer.Location = new System.Drawing.Point(7, 97);
            this.mapLayerCheckBoxAtmosphereLayer.Name = "mapLayerCheckBoxAtmosphereLayer";
            this.mapLayerCheckBoxAtmosphereLayer.Size = new System.Drawing.Size(82, 17);
            this.mapLayerCheckBoxAtmosphereLayer.TabIndex = 3;
            this.mapLayerCheckBoxAtmosphereLayer.Text = "Atmosphere";
            this.mapLayerCheckBoxAtmosphereLayer.UseVisualStyleBackColor = true;
            // 
            // mapLayerCheckBoxTopLayer
            // 
            this.mapLayerCheckBoxTopLayer.AutoSize = true;
            this.mapLayerCheckBoxTopLayer.Checked = true;
            this.mapLayerCheckBoxTopLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxTopLayer.Location = new System.Drawing.Point(7, 71);
            this.mapLayerCheckBoxTopLayer.Name = "mapLayerCheckBoxTopLayer";
            this.mapLayerCheckBoxTopLayer.Size = new System.Drawing.Size(45, 17);
            this.mapLayerCheckBoxTopLayer.TabIndex = 2;
            this.mapLayerCheckBoxTopLayer.Text = "Top";
            this.mapLayerCheckBoxTopLayer.UseVisualStyleBackColor = true;
            // 
            // mapLayerCheckBoxMiddleLayer
            // 
            this.mapLayerCheckBoxMiddleLayer.AutoSize = true;
            this.mapLayerCheckBoxMiddleLayer.Checked = true;
            this.mapLayerCheckBoxMiddleLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxMiddleLayer.Location = new System.Drawing.Point(7, 45);
            this.mapLayerCheckBoxMiddleLayer.Name = "mapLayerCheckBoxMiddleLayer";
            this.mapLayerCheckBoxMiddleLayer.Size = new System.Drawing.Size(57, 17);
            this.mapLayerCheckBoxMiddleLayer.TabIndex = 1;
            this.mapLayerCheckBoxMiddleLayer.Text = "Middle";
            this.mapLayerCheckBoxMiddleLayer.UseVisualStyleBackColor = true;
            // 
            // mapLayerCheckBoxBaseLayer
            // 
            this.mapLayerCheckBoxBaseLayer.AutoSize = true;
            this.mapLayerCheckBoxBaseLayer.Checked = true;
            this.mapLayerCheckBoxBaseLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxBaseLayer.Location = new System.Drawing.Point(7, 19);
            this.mapLayerCheckBoxBaseLayer.Name = "mapLayerCheckBoxBaseLayer";
            this.mapLayerCheckBoxBaseLayer.Size = new System.Drawing.Size(50, 17);
            this.mapLayerCheckBoxBaseLayer.TabIndex = 0;
            this.mapLayerCheckBoxBaseLayer.Text = "Base";
            this.mapLayerCheckBoxBaseLayer.UseVisualStyleBackColor = true;
            // 
            // baseLayerOutput
            // 
            this.baseLayerOutput.AutoSize = true;
            this.baseLayerOutput.Location = new System.Drawing.Point(227, 19);
            this.baseLayerOutput.Name = "baseLayerOutput";
            this.baseLayerOutput.Size = new System.Drawing.Size(178, 13);
            this.baseLayerOutput.TabIndex = 10;
            this.baseLayerOutput.Text = "<BaseLayer>layer info</BaseLayer>";
            // 
            // middleLayerOutput
            // 
            this.middleLayerOutput.AutoSize = true;
            this.middleLayerOutput.Location = new System.Drawing.Point(227, 45);
            this.middleLayerOutput.Name = "middleLayerOutput";
            this.middleLayerOutput.Size = new System.Drawing.Size(192, 13);
            this.middleLayerOutput.TabIndex = 11;
            this.middleLayerOutput.Text = "<MiddleLayer>layer info</MiddleLayer>";
            // 
            // topLayerOutput
            // 
            this.topLayerOutput.AutoSize = true;
            this.topLayerOutput.Location = new System.Drawing.Point(227, 71);
            this.topLayerOutput.Name = "topLayerOutput";
            this.topLayerOutput.Size = new System.Drawing.Size(168, 13);
            this.topLayerOutput.TabIndex = 12;
            this.topLayerOutput.Text = "<TopLayer>layer info</TopLayer>";
            // 
            // atmosphereLayerOutput
            // 
            this.atmosphereLayerOutput.AutoSize = true;
            this.atmosphereLayerOutput.Location = new System.Drawing.Point(227, 97);
            this.atmosphereLayerOutput.Name = "atmosphereLayerOutput";
            this.atmosphereLayerOutput.Size = new System.Drawing.Size(242, 13);
            this.atmosphereLayerOutput.TabIndex = 13;
            this.atmosphereLayerOutput.Text = "<AtmosphereLayer>layer info</AtmosphereLayer>";
            // 
            // collisionLayerOutput
            // 
            this.collisionLayerOutput.AutoSize = true;
            this.collisionLayerOutput.Location = new System.Drawing.Point(227, 123);
            this.collisionLayerOutput.Name = "collisionLayerOutput";
            this.collisionLayerOutput.Size = new System.Drawing.Size(206, 13);
            this.collisionLayerOutput.TabIndex = 14;
            this.collisionLayerOutput.Text = "<CollisionLayer>layer info</CollisionLayer>";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(632, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 466);
            this.vScrollBar1.TabIndex = 7;
            // 
            // ExporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 466);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.layerInformationGroupBox);
            this.Controls.Add(this.tileDimensionsGroupBox);
            this.Controls.Add(this.tileSheetGroupBox);
            this.Controls.Add(this.mapDimensionsGroupBox);
            this.Controls.Add(this.mapNameGroupBox);
            this.Controls.Add(this.xmlOutputLabel);
            this.Controls.Add(this.elementNameLabel);
            this.Name = "ExporterForm";
            this.Text = "ExporterForm";
            this.mapNameGroupBox.ResumeLayout(false);
            this.mapNameGroupBox.PerformLayout();
            this.mapDimensionsGroupBox.ResumeLayout(false);
            this.mapDimensionsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tileSheetGroupBox.ResumeLayout(false);
            this.tileSheetGroupBox.PerformLayout();
            this.tileDimensionsGroupBox.ResumeLayout(false);
            this.tileDimensionsGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.layerInformationGroupBox.ResumeLayout(false);
            this.layerInformationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label elementNameLabel;
        private System.Windows.Forms.Label xmlOutputLabel;
        private System.Windows.Forms.GroupBox mapNameGroupBox;
        private System.Windows.Forms.Label mapNameOutput;
        private System.Windows.Forms.TextBox mapNameInput;
        private System.Windows.Forms.GroupBox mapDimensionsGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton customButton;
        private System.Windows.Forms.RadioButton pointButton;
        private System.Windows.Forms.Label mapDimensionsOutput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.GroupBox tileSheetGroupBox;
        private System.Windows.Forms.Label tileSheetOutput;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox exportMapNameCheckBox;
        private System.Windows.Forms.CheckBox exportMapDimensionsCheckBox;
        private System.Windows.Forms.CheckBox exportTileSheetCheckBox;
        private System.Windows.Forms.GroupBox tileDimensionsGroupBox;
        private System.Windows.Forms.TextBox tileDimensionsHeightTextBox;
        private System.Windows.Forms.TextBox tileDimensionsWidthTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton tileDimensionsCustom;
        private System.Windows.Forms.RadioButton tileDimensionsPoint;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label tileDimensionsOutput;
        private System.Windows.Forms.CheckBox exportTileDimensionsCheckBox;
        private System.Windows.Forms.GroupBox layerInformationGroupBox;
        private System.Windows.Forms.TextBox collisionLayerTextBox;
        private System.Windows.Forms.TextBox atmosphereLayerTextBox;
        private System.Windows.Forms.TextBox topLayerTextBox;
        private System.Windows.Forms.TextBox middleLayerTextBox;
        private System.Windows.Forms.TextBox baseLayerTextBox;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxCollisionLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxAtmosphereLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxTopLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxMiddleLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxBaseLayer;
        private System.Windows.Forms.Label collisionLayerOutput;
        private System.Windows.Forms.Label atmosphereLayerOutput;
        private System.Windows.Forms.Label topLayerOutput;
        private System.Windows.Forms.Label middleLayerOutput;
        private System.Windows.Forms.Label baseLayerOutput;
        private System.Windows.Forms.VScrollBar vScrollBar1;

    }
}