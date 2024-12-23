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
        private readonly PresetSaveManager<AmrRobot> presetSaveManager;
        private readonly Action<RobotManager<AmrRobot>> updateRobotManagerCallback;
        private readonly Func<RobotManager<AmrRobot>> getRobotManagerFunc;
        
        public VSSMenuBar(Func<RobotManager<AmrRobot>> getRobotManagerFunc,
            Action<RobotManager<AmrRobot>> updateCallback)
        {
            presetLoadManager = PresetLoadManager.GetInstance;
            presetSaveManager = PresetSaveManager<AmrRobot>.GetInstance;
            
            this.getRobotManagerFunc = getRobotManagerFunc;
            this.updateRobotManagerCallback = updateCallback;
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
            RobotManager<AmrRobot> currentManager = getRobotManagerFunc();
            Console.WriteLine(currentManager.ToString());
            if (currentManager != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"; // File type filter
                    saveFileDialog.Title = "Save RobotManager Data";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    saveFileDialog.FileName = "RobotManagerData.json"; // Default file name

                    // Show the Save File Dialog and check if the user clicked OK
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        try
                        {
                            // Save the data using the SaveRobotData method
                            presetSaveManager.SaveRobotData(currentManager.GetRobots(), filePath);
                            MessageBox.Show($"Data successfully saved to {filePath}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            // Handle any exceptions during the save process
                            MessageBox.Show($"An error occurred while saving the data: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No RobotManager data to save.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        


        private void OnOpenClick(object sender, EventArgs e)
        {
            if (presetLoadManager == null)
            {
                MessageBox.Show("Error: PresetLoadManager has not been initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult result = MessageBox.Show(
                "Would you like to load the default file?", 
                "Load Default File", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );

            string filePath;
            if (result == DialogResult.Yes)
            {
                // Use FileUtil to get the default file path
                filePath = FileUtil.GetFilePath(null);

                // Check if the file path is valid
                if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("Default file not found or invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Use OpenFileDialog for manual file selection
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"; // Example filter
                    openFileDialog.Title = "Open Preset File";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                    else
                    {
                        MessageBox.Show("No file selected.", "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            
            RobotDataCollection data = presetLoadManager.LoadPresetData(filePath);
            if (data == null)
            {
                MessageBox.Show("Failed to load data");
            }
            else
            {
                // Convert the data to JSON format
                string jsonData;
                try
                {
                    jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to convert data to JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Display the JSON data in a scrollable form
                //JsonFormatter.ShowJsonInScrollableForm(jsonData);

                //Todo: future implementation - switch manger load based on robot types. Currently we only have AMR
                RobotManager<AmrRobot> loadedAmrRobotData = presetLoadManager.ReflectAmrRobotData(data);
                // Update the reference using the callback
                if (loadedAmrRobotData != null)
                {
                    updateRobotManagerCallback?.Invoke(loadedAmrRobotData);
                }
                //Console.WriteLine("Loaded AmrRobot Data =" + loadedAmrRobotData.ToString());
                
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