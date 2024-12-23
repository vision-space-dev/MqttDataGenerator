using System.Windows.Forms;

namespace MqttSender.util
{
    public class JsonFormatter
    {
        public static void ShowJsonInScrollableForm(string jsonData)
        {
            // Create a new form
            Form jsonForm = new Form
            {
                Text = "Loaded Data (JSON)",
                Width = 600,
                Height = 400,
                StartPosition = FormStartPosition.CenterParent
            };

            // Create a scrollable TextBox
            TextBox textBox = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                WordWrap = false,
                Dock = DockStyle.Fill,
                Text = jsonData,
                Font = new System.Drawing.Font("Consolas", 10) // Use a monospaced font for better JSON readability
            };

            // Add the TextBox to the form
            jsonForm.Controls.Add(textBox);

            // Show the form
            jsonForm.ShowDialog();
        }
    }
}