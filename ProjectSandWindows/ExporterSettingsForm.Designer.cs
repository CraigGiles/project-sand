namespace ProjectSandWindows
{
    partial class ExporterSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExporterSettingsForm));
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exportMapNameCheckBox = new System.Windows.Forms.CheckBox();
            this.mapNameOutput = new System.Windows.Forms.Label();
            this.mapNameInput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xnaDataOutput = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.projectMapClassInput = new System.Windows.Forms.TextBox();
            this.projectDataNamespaceInput = new System.Windows.Forms.TextBox();
            this.xmlFileNameInput = new System.Windows.Forms.TextBox();
            this.tileDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.tileDimensionsHeightInput = new System.Windows.Forms.TextBox();
            this.tileDimensionsWidthInput = new System.Windows.Forms.TextBox();
            this.tileDimensionsOutputTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.tileDimensionsCustomButton = new System.Windows.Forms.RadioButton();
            this.tileDimensionsPointButton = new System.Windows.Forms.RadioButton();
            this.tileDimensionsInput = new System.Windows.Forms.TextBox();
            this.tileDimensionsOutput = new System.Windows.Forms.Label();
            this.exportTileDimensionsCheckBox = new System.Windows.Forms.CheckBox();
            this.tileSheetGroupBox = new System.Windows.Forms.GroupBox();
            this.exportTileSheetCheckBox = new System.Windows.Forms.CheckBox();
            this.tileSheetOutput = new System.Windows.Forms.Label();
            this.tileSheetContentInput = new System.Windows.Forms.TextBox();
            this.layerInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.mapLayersBaseElement = new System.Windows.Forms.TextBox();
            this.mapLayersOutputTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.mapLayersIndividualButton = new System.Windows.Forms.RadioButton();
            this.mapLayersGroupedButton = new System.Windows.Forms.RadioButton();
            this.mapLayerOutput = new System.Windows.Forms.Label();
            this.collisionLayerInput = new System.Windows.Forms.TextBox();
            this.atmosphereLayerInput = new System.Windows.Forms.TextBox();
            this.topLayerInput = new System.Windows.Forms.TextBox();
            this.middleLayerInput = new System.Windows.Forms.TextBox();
            this.baseLayerInput = new System.Windows.Forms.TextBox();
            this.mapLayerCheckBoxCollisionLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxAtmosphereLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxTopLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxMiddleLayer = new System.Windows.Forms.CheckBox();
            this.mapLayerCheckBoxBaseLayer = new System.Windows.Forms.CheckBox();
            this.mapDimensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.exportMapDimensionsCheckBox = new System.Windows.Forms.CheckBox();
            this.mapDimensionsHeightInput = new System.Windows.Forms.TextBox();
            this.mapDimensionsWidthInput = new System.Windows.Forms.TextBox();
            this.mapDimensionsOutputTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.mapDimensionsCustomButton = new System.Windows.Forms.RadioButton();
            this.mapDimensionsPointButton = new System.Windows.Forms.RadioButton();
            this.mapDimensionsOutput = new System.Windows.Forms.Label();
            this.mapDimensionsInput = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tileDimensionsGroupBox.SuspendLayout();
            this.tileDimensionsOutputTypeGroupBox.SuspendLayout();
            this.tileSheetGroupBox.SuspendLayout();
            this.layerInformationGroupBox.SuspendLayout();
            this.mapLayersOutputTypeGroupBox.SuspendLayout();
            this.mapDimensionsGroupBox.SuspendLayout();
            this.mapDimensionsOutputTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(371, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "XML Output";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exportMapNameCheckBox);
            this.groupBox2.Controls.Add(this.mapNameOutput);
            this.groupBox2.Controls.Add(this.mapNameInput);
            this.groupBox2.Location = new System.Drawing.Point(12, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 49);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Map Name";
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
            this.mapNameInput.TextChanged += new System.EventHandler(this.ChangeMapNameOutputText);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(104, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Element Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xnaDataOutput);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.projectMapClassInput);
            this.groupBox1.Controls.Add(this.projectDataNamespaceInput);
            this.groupBox1.Controls.Add(this.xmlFileNameInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 175);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XNA Data";
            // 
            // xnaDataOutput
            // 
            this.xnaDataOutput.AutoSize = true;
            this.xnaDataOutput.Location = new System.Drawing.Point(230, 20);
            this.xnaDataOutput.Name = "xnaDataOutput";
            this.xnaDataOutput.Size = new System.Drawing.Size(298, 91);
            this.xnaDataOutput.TabIndex = 6;
            this.xnaDataOutput.Text = "Filename: filename.xml\r\n\r\n<XnaContent>\r\n     <Asset Type=\"ProjectDataNamespace.Pr" +
                "ojectMapClass\">\r\n\r\n     </Asset>\r\n</XnaContent>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Projects Map Class Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Projects Data namespace";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "XML Name";
            // 
            // projectMapClassInput
            // 
            this.projectMapClassInput.Location = new System.Drawing.Point(68, 137);
            this.projectMapClassInput.Name = "projectMapClassInput";
            this.projectMapClassInput.Size = new System.Drawing.Size(150, 20);
            this.projectMapClassInput.TabIndex = 2;
            this.projectMapClassInput.Text = "ProjectMapClass";
            this.projectMapClassInput.TextChanged += new System.EventHandler(this.ChangeXnaDataOutputText);
            // 
            // projectDataNamespaceInput
            // 
            this.projectDataNamespaceInput.Location = new System.Drawing.Point(68, 82);
            this.projectDataNamespaceInput.Name = "projectDataNamespaceInput";
            this.projectDataNamespaceInput.Size = new System.Drawing.Size(150, 20);
            this.projectDataNamespaceInput.TabIndex = 1;
            this.projectDataNamespaceInput.Text = "ProjectDataNamespace";
            this.projectDataNamespaceInput.TextChanged += new System.EventHandler(this.ChangeXnaDataOutputText);
            // 
            // xmlFileNameInput
            // 
            this.xmlFileNameInput.Location = new System.Drawing.Point(68, 32);
            this.xmlFileNameInput.Name = "xmlFileNameInput";
            this.xmlFileNameInput.Size = new System.Drawing.Size(150, 20);
            this.xmlFileNameInput.TabIndex = 0;
            this.xmlFileNameInput.Text = "filename";
            this.xmlFileNameInput.TextChanged += new System.EventHandler(this.ChangeXnaDataOutputText);
            // 
            // tileDimensionsGroupBox
            // 
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsHeightInput);
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsWidthInput);
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsOutputTypeGroupBox);
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsInput);
            this.tileDimensionsGroupBox.Controls.Add(this.tileDimensionsOutput);
            this.tileDimensionsGroupBox.Controls.Add(this.exportTileDimensionsCheckBox);
            this.tileDimensionsGroupBox.Location = new System.Drawing.Point(12, 512);
            this.tileDimensionsGroupBox.Name = "tileDimensionsGroupBox";
            this.tileDimensionsGroupBox.Size = new System.Drawing.Size(610, 184);
            this.tileDimensionsGroupBox.TabIndex = 24;
            this.tileDimensionsGroupBox.TabStop = false;
            this.tileDimensionsGroupBox.Text = "Tile Dimensions";
            // 
            // tileDimensionsHeightInput
            // 
            this.tileDimensionsHeightInput.Location = new System.Drawing.Point(96, 148);
            this.tileDimensionsHeightInput.Name = "tileDimensionsHeightInput";
            this.tileDimensionsHeightInput.Size = new System.Drawing.Size(122, 20);
            this.tileDimensionsHeightInput.TabIndex = 5;
            this.tileDimensionsHeightInput.Text = "TileHeight";
            this.tileDimensionsHeightInput.TextChanged += new System.EventHandler(this.ChangeTileDimensionsOutputText);
            // 
            // tileDimensionsWidthInput
            // 
            this.tileDimensionsWidthInput.Location = new System.Drawing.Point(96, 121);
            this.tileDimensionsWidthInput.Name = "tileDimensionsWidthInput";
            this.tileDimensionsWidthInput.Size = new System.Drawing.Size(122, 20);
            this.tileDimensionsWidthInput.TabIndex = 4;
            this.tileDimensionsWidthInput.Text = "TileWidth";
            this.tileDimensionsWidthInput.TextChanged += new System.EventHandler(this.ChangeTileDimensionsOutputText);
            // 
            // tileDimensionsOutputTypeGroupBox
            // 
            this.tileDimensionsOutputTypeGroupBox.Controls.Add(this.tileDimensionsCustomButton);
            this.tileDimensionsOutputTypeGroupBox.Controls.Add(this.tileDimensionsPointButton);
            this.tileDimensionsOutputTypeGroupBox.Location = new System.Drawing.Point(69, 20);
            this.tileDimensionsOutputTypeGroupBox.Name = "tileDimensionsOutputTypeGroupBox";
            this.tileDimensionsOutputTypeGroupBox.Size = new System.Drawing.Size(149, 68);
            this.tileDimensionsOutputTypeGroupBox.TabIndex = 3;
            this.tileDimensionsOutputTypeGroupBox.TabStop = false;
            this.tileDimensionsOutputTypeGroupBox.Text = "Output Type";
            // 
            // tileDimensionsCustomButton
            // 
            this.tileDimensionsCustomButton.AutoSize = true;
            this.tileDimensionsCustomButton.Location = new System.Drawing.Point(6, 43);
            this.tileDimensionsCustomButton.Name = "tileDimensionsCustomButton";
            this.tileDimensionsCustomButton.Size = new System.Drawing.Size(60, 17);
            this.tileDimensionsCustomButton.TabIndex = 1;
            this.tileDimensionsCustomButton.Text = "Custom";
            this.tileDimensionsCustomButton.UseVisualStyleBackColor = true;
            this.tileDimensionsCustomButton.CheckedChanged += new System.EventHandler(this.ChangeTileDimensionsOutputText);
            // 
            // tileDimensionsPointButton
            // 
            this.tileDimensionsPointButton.AutoSize = true;
            this.tileDimensionsPointButton.Checked = true;
            this.tileDimensionsPointButton.Location = new System.Drawing.Point(7, 20);
            this.tileDimensionsPointButton.Name = "tileDimensionsPointButton";
            this.tileDimensionsPointButton.Size = new System.Drawing.Size(49, 17);
            this.tileDimensionsPointButton.TabIndex = 0;
            this.tileDimensionsPointButton.TabStop = true;
            this.tileDimensionsPointButton.Text = "Point";
            this.tileDimensionsPointButton.UseVisualStyleBackColor = true;
            this.tileDimensionsPointButton.CheckedChanged += new System.EventHandler(this.ChangeTileDimensionsOutputText);
            // 
            // tileDimensionsInput
            // 
            this.tileDimensionsInput.Location = new System.Drawing.Point(69, 94);
            this.tileDimensionsInput.Name = "tileDimensionsInput";
            this.tileDimensionsInput.Size = new System.Drawing.Size(149, 20);
            this.tileDimensionsInput.TabIndex = 2;
            this.tileDimensionsInput.Text = "TileDimensions";
            this.tileDimensionsInput.TextChanged += new System.EventHandler(this.ChangeTileDimensionsOutputText);
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
            // tileSheetGroupBox
            // 
            this.tileSheetGroupBox.Controls.Add(this.exportTileSheetCheckBox);
            this.tileSheetGroupBox.Controls.Add(this.tileSheetOutput);
            this.tileSheetGroupBox.Controls.Add(this.tileSheetContentInput);
            this.tileSheetGroupBox.Location = new System.Drawing.Point(12, 454);
            this.tileSheetGroupBox.Name = "tileSheetGroupBox";
            this.tileSheetGroupBox.Size = new System.Drawing.Size(610, 51);
            this.tileSheetGroupBox.TabIndex = 23;
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
            this.tileSheetOutput.Size = new System.Drawing.Size(408, 13);
            this.tileSheetOutput.TabIndex = 1;
            this.tileSheetOutput.Text = "<TileSheetContentName>ProjectsContentPath//TileSheet</TileSheetContentName>";
            // 
            // tileSheetContentInput
            // 
            this.tileSheetContentInput.Location = new System.Drawing.Point(69, 19);
            this.tileSheetContentInput.Name = "tileSheetContentInput";
            this.tileSheetContentInput.Size = new System.Drawing.Size(150, 20);
            this.tileSheetContentInput.TabIndex = 0;
            this.tileSheetContentInput.Text = "TileSheetContentName";
            this.tileSheetContentInput.TextChanged += new System.EventHandler(this.ChangeTileSheetOutputText);
            // 
            // layerInformationGroupBox
            // 
            this.layerInformationGroupBox.Controls.Add(this.mapLayersBaseElement);
            this.layerInformationGroupBox.Controls.Add(this.mapLayersOutputTypeGroupBox);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerOutput);
            this.layerInformationGroupBox.Controls.Add(this.collisionLayerInput);
            this.layerInformationGroupBox.Controls.Add(this.atmosphereLayerInput);
            this.layerInformationGroupBox.Controls.Add(this.topLayerInput);
            this.layerInformationGroupBox.Controls.Add(this.middleLayerInput);
            this.layerInformationGroupBox.Controls.Add(this.baseLayerInput);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxCollisionLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxAtmosphereLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxTopLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxMiddleLayer);
            this.layerInformationGroupBox.Controls.Add(this.mapLayerCheckBoxBaseLayer);
            this.layerInformationGroupBox.Location = new System.Drawing.Point(12, 703);
            this.layerInformationGroupBox.Name = "layerInformationGroupBox";
            this.layerInformationGroupBox.Size = new System.Drawing.Size(610, 258);
            this.layerInformationGroupBox.TabIndex = 25;
            this.layerInformationGroupBox.TabStop = false;
            this.layerInformationGroupBox.Text = "Map Layers";
            // 
            // mapLayersBaseElement
            // 
            this.mapLayersBaseElement.Location = new System.Drawing.Point(69, 98);
            this.mapLayersBaseElement.Name = "mapLayersBaseElement";
            this.mapLayersBaseElement.Size = new System.Drawing.Size(150, 20);
            this.mapLayersBaseElement.TabIndex = 16;
            this.mapLayersBaseElement.Text = "MapLayers";
            this.mapLayersBaseElement.TextChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayersOutputTypeGroupBox
            // 
            this.mapLayersOutputTypeGroupBox.Controls.Add(this.mapLayersIndividualButton);
            this.mapLayersOutputTypeGroupBox.Controls.Add(this.mapLayersGroupedButton);
            this.mapLayersOutputTypeGroupBox.Location = new System.Drawing.Point(69, 20);
            this.mapLayersOutputTypeGroupBox.Name = "mapLayersOutputTypeGroupBox";
            this.mapLayersOutputTypeGroupBox.Size = new System.Drawing.Size(150, 72);
            this.mapLayersOutputTypeGroupBox.TabIndex = 15;
            this.mapLayersOutputTypeGroupBox.TabStop = false;
            this.mapLayersOutputTypeGroupBox.Text = "Output Type";
            // 
            // mapLayersIndividualButton
            // 
            this.mapLayersIndividualButton.AutoSize = true;
            this.mapLayersIndividualButton.Checked = true;
            this.mapLayersIndividualButton.Location = new System.Drawing.Point(7, 44);
            this.mapLayersIndividualButton.Name = "mapLayersIndividualButton";
            this.mapLayersIndividualButton.Size = new System.Drawing.Size(70, 17);
            this.mapLayersIndividualButton.TabIndex = 1;
            this.mapLayersIndividualButton.TabStop = true;
            this.mapLayersIndividualButton.Text = "Individual";
            this.mapLayersIndividualButton.UseVisualStyleBackColor = true;
            this.mapLayersIndividualButton.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayersGroupedButton
            // 
            this.mapLayersGroupedButton.AutoSize = true;
            this.mapLayersGroupedButton.Location = new System.Drawing.Point(7, 20);
            this.mapLayersGroupedButton.Name = "mapLayersGroupedButton";
            this.mapLayersGroupedButton.Size = new System.Drawing.Size(66, 17);
            this.mapLayersGroupedButton.TabIndex = 0;
            this.mapLayersGroupedButton.Text = "Grouped";
            this.mapLayersGroupedButton.UseVisualStyleBackColor = true;
            this.mapLayersGroupedButton.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayerOutput
            // 
            this.mapLayerOutput.AutoSize = true;
            this.mapLayerOutput.Location = new System.Drawing.Point(227, 20);
            this.mapLayerOutput.Name = "mapLayerOutput";
            this.mapLayerOutput.Size = new System.Drawing.Size(257, 65);
            this.mapLayerOutput.TabIndex = 10;
            this.mapLayerOutput.Text = resources.GetString("mapLayerOutput.Text");
            // 
            // collisionLayerInput
            // 
            this.collisionLayerInput.Location = new System.Drawing.Point(95, 228);
            this.collisionLayerInput.Name = "collisionLayerInput";
            this.collisionLayerInput.Size = new System.Drawing.Size(123, 20);
            this.collisionLayerInput.TabIndex = 9;
            this.collisionLayerInput.Text = "CollisionLayer";
            this.collisionLayerInput.TextChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // atmosphereLayerInput
            // 
            this.atmosphereLayerInput.Location = new System.Drawing.Point(95, 202);
            this.atmosphereLayerInput.Name = "atmosphereLayerInput";
            this.atmosphereLayerInput.Size = new System.Drawing.Size(123, 20);
            this.atmosphereLayerInput.TabIndex = 8;
            this.atmosphereLayerInput.Text = "AtmosphereLayer";
            this.atmosphereLayerInput.TextChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // topLayerInput
            // 
            this.topLayerInput.Location = new System.Drawing.Point(95, 176);
            this.topLayerInput.Name = "topLayerInput";
            this.topLayerInput.Size = new System.Drawing.Size(123, 20);
            this.topLayerInput.TabIndex = 7;
            this.topLayerInput.Text = "TopLayer";
            this.topLayerInput.TextChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // middleLayerInput
            // 
            this.middleLayerInput.Location = new System.Drawing.Point(95, 150);
            this.middleLayerInput.Name = "middleLayerInput";
            this.middleLayerInput.Size = new System.Drawing.Size(123, 20);
            this.middleLayerInput.TabIndex = 6;
            this.middleLayerInput.Text = "MiddleLayer";
            this.middleLayerInput.TextChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // baseLayerInput
            // 
            this.baseLayerInput.Location = new System.Drawing.Point(95, 124);
            this.baseLayerInput.Name = "baseLayerInput";
            this.baseLayerInput.Size = new System.Drawing.Size(123, 20);
            this.baseLayerInput.TabIndex = 5;
            this.baseLayerInput.Text = "BaseLayer";
            this.baseLayerInput.TextChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayerCheckBoxCollisionLayer
            // 
            this.mapLayerCheckBoxCollisionLayer.AutoSize = true;
            this.mapLayerCheckBoxCollisionLayer.Checked = true;
            this.mapLayerCheckBoxCollisionLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxCollisionLayer.Location = new System.Drawing.Point(7, 231);
            this.mapLayerCheckBoxCollisionLayer.Name = "mapLayerCheckBoxCollisionLayer";
            this.mapLayerCheckBoxCollisionLayer.Size = new System.Drawing.Size(64, 17);
            this.mapLayerCheckBoxCollisionLayer.TabIndex = 4;
            this.mapLayerCheckBoxCollisionLayer.Text = "Collision";
            this.mapLayerCheckBoxCollisionLayer.UseVisualStyleBackColor = true;
            this.mapLayerCheckBoxCollisionLayer.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayerCheckBoxAtmosphereLayer
            // 
            this.mapLayerCheckBoxAtmosphereLayer.AutoSize = true;
            this.mapLayerCheckBoxAtmosphereLayer.Checked = true;
            this.mapLayerCheckBoxAtmosphereLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxAtmosphereLayer.Location = new System.Drawing.Point(7, 205);
            this.mapLayerCheckBoxAtmosphereLayer.Name = "mapLayerCheckBoxAtmosphereLayer";
            this.mapLayerCheckBoxAtmosphereLayer.Size = new System.Drawing.Size(82, 17);
            this.mapLayerCheckBoxAtmosphereLayer.TabIndex = 3;
            this.mapLayerCheckBoxAtmosphereLayer.Text = "Atmosphere";
            this.mapLayerCheckBoxAtmosphereLayer.UseVisualStyleBackColor = true;
            this.mapLayerCheckBoxAtmosphereLayer.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayerCheckBoxTopLayer
            // 
            this.mapLayerCheckBoxTopLayer.AutoSize = true;
            this.mapLayerCheckBoxTopLayer.Checked = true;
            this.mapLayerCheckBoxTopLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxTopLayer.Location = new System.Drawing.Point(7, 179);
            this.mapLayerCheckBoxTopLayer.Name = "mapLayerCheckBoxTopLayer";
            this.mapLayerCheckBoxTopLayer.Size = new System.Drawing.Size(45, 17);
            this.mapLayerCheckBoxTopLayer.TabIndex = 2;
            this.mapLayerCheckBoxTopLayer.Text = "Top";
            this.mapLayerCheckBoxTopLayer.UseVisualStyleBackColor = true;
            this.mapLayerCheckBoxTopLayer.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayerCheckBoxMiddleLayer
            // 
            this.mapLayerCheckBoxMiddleLayer.AutoSize = true;
            this.mapLayerCheckBoxMiddleLayer.Checked = true;
            this.mapLayerCheckBoxMiddleLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxMiddleLayer.Location = new System.Drawing.Point(7, 153);
            this.mapLayerCheckBoxMiddleLayer.Name = "mapLayerCheckBoxMiddleLayer";
            this.mapLayerCheckBoxMiddleLayer.Size = new System.Drawing.Size(57, 17);
            this.mapLayerCheckBoxMiddleLayer.TabIndex = 1;
            this.mapLayerCheckBoxMiddleLayer.Text = "Middle";
            this.mapLayerCheckBoxMiddleLayer.UseVisualStyleBackColor = true;
            this.mapLayerCheckBoxMiddleLayer.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapLayerCheckBoxBaseLayer
            // 
            this.mapLayerCheckBoxBaseLayer.AutoSize = true;
            this.mapLayerCheckBoxBaseLayer.Checked = true;
            this.mapLayerCheckBoxBaseLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mapLayerCheckBoxBaseLayer.Location = new System.Drawing.Point(7, 127);
            this.mapLayerCheckBoxBaseLayer.Name = "mapLayerCheckBoxBaseLayer";
            this.mapLayerCheckBoxBaseLayer.Size = new System.Drawing.Size(50, 17);
            this.mapLayerCheckBoxBaseLayer.TabIndex = 0;
            this.mapLayerCheckBoxBaseLayer.Text = "Base";
            this.mapLayerCheckBoxBaseLayer.UseVisualStyleBackColor = true;
            this.mapLayerCheckBoxBaseLayer.CheckedChanged += new System.EventHandler(this.ChangeMapLayersOutputText);
            // 
            // mapDimensionsGroupBox
            // 
            this.mapDimensionsGroupBox.Controls.Add(this.exportMapDimensionsCheckBox);
            this.mapDimensionsGroupBox.Controls.Add(this.mapDimensionsHeightInput);
            this.mapDimensionsGroupBox.Controls.Add(this.mapDimensionsWidthInput);
            this.mapDimensionsGroupBox.Controls.Add(this.mapDimensionsOutputTypeGroupBox);
            this.mapDimensionsGroupBox.Controls.Add(this.mapDimensionsOutput);
            this.mapDimensionsGroupBox.Controls.Add(this.mapDimensionsInput);
            this.mapDimensionsGroupBox.Location = new System.Drawing.Point(12, 268);
            this.mapDimensionsGroupBox.Name = "mapDimensionsGroupBox";
            this.mapDimensionsGroupBox.Size = new System.Drawing.Size(610, 179);
            this.mapDimensionsGroupBox.TabIndex = 22;
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
            // mapDimensionsHeightInput
            // 
            this.mapDimensionsHeightInput.Location = new System.Drawing.Point(96, 150);
            this.mapDimensionsHeightInput.Name = "mapDimensionsHeightInput";
            this.mapDimensionsHeightInput.Size = new System.Drawing.Size(123, 20);
            this.mapDimensionsHeightInput.TabIndex = 4;
            this.mapDimensionsHeightInput.Text = "Height";
            this.mapDimensionsHeightInput.TextChanged += new System.EventHandler(this.ChangeMapDimensionsOutputText);
            // 
            // mapDimensionsWidthInput
            // 
            this.mapDimensionsWidthInput.Location = new System.Drawing.Point(96, 124);
            this.mapDimensionsWidthInput.Name = "mapDimensionsWidthInput";
            this.mapDimensionsWidthInput.Size = new System.Drawing.Size(123, 20);
            this.mapDimensionsWidthInput.TabIndex = 3;
            this.mapDimensionsWidthInput.Text = "Width";
            this.mapDimensionsWidthInput.TextChanged += new System.EventHandler(this.ChangeMapDimensionsOutputText);
            // 
            // mapDimensionsOutputTypeGroupBox
            // 
            this.mapDimensionsOutputTypeGroupBox.Controls.Add(this.mapDimensionsCustomButton);
            this.mapDimensionsOutputTypeGroupBox.Controls.Add(this.mapDimensionsPointButton);
            this.mapDimensionsOutputTypeGroupBox.Location = new System.Drawing.Point(69, 19);
            this.mapDimensionsOutputTypeGroupBox.Name = "mapDimensionsOutputTypeGroupBox";
            this.mapDimensionsOutputTypeGroupBox.Size = new System.Drawing.Size(149, 71);
            this.mapDimensionsOutputTypeGroupBox.TabIndex = 2;
            this.mapDimensionsOutputTypeGroupBox.TabStop = false;
            this.mapDimensionsOutputTypeGroupBox.Text = "Output Type";
            // 
            // mapDimensionsCustomButton
            // 
            this.mapDimensionsCustomButton.AutoSize = true;
            this.mapDimensionsCustomButton.Checked = true;
            this.mapDimensionsCustomButton.Location = new System.Drawing.Point(7, 44);
            this.mapDimensionsCustomButton.Name = "mapDimensionsCustomButton";
            this.mapDimensionsCustomButton.Size = new System.Drawing.Size(60, 17);
            this.mapDimensionsCustomButton.TabIndex = 1;
            this.mapDimensionsCustomButton.TabStop = true;
            this.mapDimensionsCustomButton.Text = "Custom";
            this.mapDimensionsCustomButton.UseVisualStyleBackColor = true;
            this.mapDimensionsCustomButton.CheckedChanged += new System.EventHandler(this.ChangeMapDimensionsOutputText);
            // 
            // mapDimensionsPointButton
            // 
            this.mapDimensionsPointButton.AutoSize = true;
            this.mapDimensionsPointButton.Location = new System.Drawing.Point(7, 20);
            this.mapDimensionsPointButton.Name = "mapDimensionsPointButton";
            this.mapDimensionsPointButton.Size = new System.Drawing.Size(49, 17);
            this.mapDimensionsPointButton.TabIndex = 0;
            this.mapDimensionsPointButton.Text = "Point";
            this.mapDimensionsPointButton.UseVisualStyleBackColor = true;
            this.mapDimensionsPointButton.CheckedChanged += new System.EventHandler(this.ChangeMapDimensionsOutputText);
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
            // mapDimensionsInput
            // 
            this.mapDimensionsInput.Location = new System.Drawing.Point(69, 96);
            this.mapDimensionsInput.Name = "mapDimensionsInput";
            this.mapDimensionsInput.Size = new System.Drawing.Size(150, 20);
            this.mapDimensionsInput.TabIndex = 0;
            this.mapDimensionsInput.Text = "MapDimensions";
            this.mapDimensionsInput.TextChanged += new System.EventHandler(this.ChangeMapDimensionsOutputText);
            // 
            // ExporterSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(647, 466);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tileDimensionsGroupBox);
            this.Controls.Add(this.tileSheetGroupBox);
            this.Controls.Add(this.layerInformationGroupBox);
            this.Controls.Add(this.mapDimensionsGroupBox);
            this.Name = "ExporterSettingsForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Text = "ExporterSettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tileDimensionsGroupBox.ResumeLayout(false);
            this.tileDimensionsGroupBox.PerformLayout();
            this.tileDimensionsOutputTypeGroupBox.ResumeLayout(false);
            this.tileDimensionsOutputTypeGroupBox.PerformLayout();
            this.tileSheetGroupBox.ResumeLayout(false);
            this.tileSheetGroupBox.PerformLayout();
            this.layerInformationGroupBox.ResumeLayout(false);
            this.layerInformationGroupBox.PerformLayout();
            this.mapLayersOutputTypeGroupBox.ResumeLayout(false);
            this.mapLayersOutputTypeGroupBox.PerformLayout();
            this.mapDimensionsGroupBox.ResumeLayout(false);
            this.mapDimensionsGroupBox.PerformLayout();
            this.mapDimensionsOutputTypeGroupBox.ResumeLayout(false);
            this.mapDimensionsOutputTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox exportMapNameCheckBox;
        private System.Windows.Forms.Label mapNameOutput;
        private System.Windows.Forms.TextBox mapNameInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label xnaDataOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox projectMapClassInput;
        private System.Windows.Forms.TextBox projectDataNamespaceInput;
        private System.Windows.Forms.TextBox xmlFileNameInput;
        private System.Windows.Forms.GroupBox tileDimensionsGroupBox;
        private System.Windows.Forms.TextBox tileDimensionsHeightInput;
        private System.Windows.Forms.TextBox tileDimensionsWidthInput;
        private System.Windows.Forms.GroupBox tileDimensionsOutputTypeGroupBox;
        private System.Windows.Forms.RadioButton tileDimensionsCustomButton;
        private System.Windows.Forms.RadioButton tileDimensionsPointButton;
        private System.Windows.Forms.TextBox tileDimensionsInput;
        private System.Windows.Forms.Label tileDimensionsOutput;
        private System.Windows.Forms.CheckBox exportTileDimensionsCheckBox;
        private System.Windows.Forms.GroupBox tileSheetGroupBox;
        private System.Windows.Forms.CheckBox exportTileSheetCheckBox;
        private System.Windows.Forms.Label tileSheetOutput;
        private System.Windows.Forms.TextBox tileSheetContentInput;
        private System.Windows.Forms.GroupBox layerInformationGroupBox;
        private System.Windows.Forms.TextBox mapLayersBaseElement;
        private System.Windows.Forms.GroupBox mapLayersOutputTypeGroupBox;
        private System.Windows.Forms.RadioButton mapLayersIndividualButton;
        private System.Windows.Forms.RadioButton mapLayersGroupedButton;
        private System.Windows.Forms.Label mapLayerOutput;
        private System.Windows.Forms.TextBox collisionLayerInput;
        private System.Windows.Forms.TextBox atmosphereLayerInput;
        private System.Windows.Forms.TextBox topLayerInput;
        private System.Windows.Forms.TextBox middleLayerInput;
        private System.Windows.Forms.TextBox baseLayerInput;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxCollisionLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxAtmosphereLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxTopLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxMiddleLayer;
        private System.Windows.Forms.CheckBox mapLayerCheckBoxBaseLayer;
        private System.Windows.Forms.GroupBox mapDimensionsGroupBox;
        private System.Windows.Forms.CheckBox exportMapDimensionsCheckBox;
        private System.Windows.Forms.TextBox mapDimensionsHeightInput;
        private System.Windows.Forms.TextBox mapDimensionsWidthInput;
        private System.Windows.Forms.GroupBox mapDimensionsOutputTypeGroupBox;
        private System.Windows.Forms.RadioButton mapDimensionsCustomButton;
        private System.Windows.Forms.RadioButton mapDimensionsPointButton;
        private System.Windows.Forms.Label mapDimensionsOutput;
        private System.Windows.Forms.TextBox mapDimensionsInput;
    }
}