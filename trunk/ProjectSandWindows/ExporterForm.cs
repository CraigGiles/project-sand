using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SandTileEngine;
using System.IO;


namespace ProjectSandWindows
{
    public partial class ExporterForm : Form
    {
        #region Constructor(s)

        /// <summary>
        /// Creates a new ExporterForm object
        /// </summary>
        //public ExporterForm()
        //{            
        //    InitializeComponent();
        //    Form.ActiveForm.AutoScroll = true;
        //    LoadExporterSettings();
        //}

        TileMap tileMap;

        /// <summary>
        /// Creates a new ExporterForm object
        /// </summary>
        public ExporterForm(TileMap map)
        {
            InitializeComponent();
            Form.ActiveForm.AutoScroll = true; 
            tileMap = map;
        }

        /// <summary>
        /// Creates a new ExporterForm object
        /// </summary>
        public ExporterForm(List<TileMap> maps)
        {
            InitializeComponent();
            Form.ActiveForm.AutoScroll = true;
        }



        private void exportXmlButton_Click(object sender, EventArgs e)
        {
            Exporter exporter = new Exporter();
            exporter.ExportXml(tileMap);
        }
        #endregion
    }
}