using System;
using System.Windows.Forms;
using MqttSender.manager;
using MqttSender.model;
using MqttSender.util;

namespace MqttSender
{
    public class VSSMenuBar : MenuStrip
    {
        private readonly PresetLoadManager presetLoadManager;
        
        public VSSMenuBar()
        {
            presetLoadManager = PresetLoadManager.GetInstance();
            InitializeMenu();
        }
        
        private void InitializeMenu()
        {
            // Create the "File" menu
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("New", null, OnNewClick);
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save", null, OnSaveClick);
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open", null, OnOpenClick);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", null, OnExitClick);

            // Add menu items to the "File" menu
            fileMenu.DropDownItems.Add(newMenuItem);
            fileMenu.DropDownItems.Add(saveMenuItem);
            fileMenu.DropDownItems.Add(openMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator()); // Add a separator
            fileMenu.DropDownItems.Add(exitMenuItem);

            // Add the "File" menu to the menu bar
            this.Items.Add(fileMenu);

            // Create and add additional menus as needed (e.g., Edit, Help)
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Edit");
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Copy", null, OnCopyClick);
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Paste", null, OnPasteClick);

            editMenu.DropDownItems.Add(copyMenuItem);
            editMenu.DropDownItems.Add(pasteMenuItem);

            this.Items.Add(editMenu);

            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Help");
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("About", null, OnAboutClick);

            helpMenu.DropDownItems.Add(aboutMenuItem);

            this.Items.Add(helpMenu);
        }

        // Event Handlers for Menu Item Clicks
        private void OnNewClick(object sender, EventArgs e)
        {
            MessageBox.Show("New clicked");
        }
        
        private void OnSaveClick(object sender, EventArgs e)
        {
            MessageBox.Show("Save complete");
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            if (presetLoadManager == null)
            {
                MessageBox.Show("Error: PresetLoadManager has not been initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filePath = FileUtil.GetFilePath();
            RobotDataCollection data = presetLoadManager.LoadPresetData(filePath);
            if (data == null)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                MessageBox.Show(data.ToString());
                //Todo: inject robot data into manager and refresh window to reflect the change
            }
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void OnCopyClick(object sender, EventArgs e)
        {
            MessageBox.Show("Copy clicked");
        }

        private static void OnPasteClick(object sender, EventArgs e)
        {
            MessageBox.Show("Paste clicked");
        }

        private static void OnAboutClick(object sender, EventArgs e)
        {
            MessageBox.Show("About this application");
        }
    }
}