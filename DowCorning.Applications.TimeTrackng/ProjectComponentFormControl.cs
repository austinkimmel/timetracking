using System.Collections.Generic;
using System.Windows.Forms;

namespace DowCorning.Applications.TimeTracking
{
    public class ProjectComponentFormControl
    {
        public CheckBox Include { get; set; }

        public TextBox Title { get; set; }

        public TextBox EstimatedHours { get; set; }

        public string Parent { get; set; }

        public string Key { get; set; }

        public string GUID { get; set; }

        public int Id { get; set; }

        public List<ProjectComponentFormControl> Children { get; set; }

        public double ActualHours { get; set; }

        public ProjectComponentFormControl()
        {
        }

        public ProjectComponentFormControl(string title, double estimatedHours, int left, int top, string parent)
            : this(-1, title, estimatedHours, left, top, parent, SharePointActionMode.Import)
        { }

        public ProjectComponentFormControl(int id, string title, double estimatedHours, int left, int top, string parent, SharePointActionMode mode)
        {
            this.Id = id;
            Include = new CheckBox() { Left = left, Top = top, Width = 20, Checked = true};
            Title = CreateTextBox(title);
            Title.Left = left + Include.Width;
            Title.Top = top;
            EstimatedHours = CreateTextBox(estimatedHours.ToString());
            EstimatedHours.Left = Title.Left + Title.Width + 5;
            EstimatedHours.Top = top;
            Parent = parent;
            Key = title;
        }

        private TextBox CreateTextBox(string text)
        {
            TextBox textbox = new TextBox() { Width = 200, Height = 20, Text = text };
            return textbox;
        }

        public void UpdateActualWork()
        {
            double actualHours = 0.0;
            if (double.TryParse(this.EstimatedHours.Text, out actualHours))
            {
                SharePointData.UpdateActualHours(this.Id, actualHours);
            }
        }

        //private CheckBox CreateCheckBox()
        //{
        //}
    }

    public enum SharePointActionMode
    {
        Import,
        Export
    }
}