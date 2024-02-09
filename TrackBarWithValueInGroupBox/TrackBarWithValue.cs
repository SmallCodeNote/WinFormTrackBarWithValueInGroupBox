using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace TrackBarWithValueInGroupBox
{
    class TrackBarWithValue
    {
        public GroupBox parentGroupBox;
        public TrackBar trackBar;
        public Label labelValue;
        
        double valueFactor;
        public string labelFormat = "";

        public TrackBarWithValue(GroupBox parentGroupBox, double valueFactor = 1.0)
        {
            this.parentGroupBox = parentGroupBox;
            this.valueFactor = valueFactor;
            

            Initialize();

        }

        private void Initialize()
        {
            parentGroupBox.Controls.Clear();

            parentGroupBox.Height = 80;

            trackBar = new TrackBar();
            this.trackBar.Location = new System.Drawing.Point(10, 18);
            this.trackBar.Name = parentGroupBox.Name + "_trackBar";
            this.trackBar.Size = new System.Drawing.Size(parentGroupBox.Width - 50, 56);
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_LabelUpdate);
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_LabelUpdate);

            labelValue = new Label();
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(parentGroupBox.Width - 40, 18);
            this.labelValue.Name = parentGroupBox.Name + "_labelValue";
            this.labelValue.Size = new System.Drawing.Size(15, 15);
            this.labelValue.Text = "-";

            parentGroupBox.Controls.Add(trackBar);
            parentGroupBox.Controls.Add(labelValue);

        }

        private void trackBar_LabelUpdate(object sender, EventArgs e)
        {
            labelValue.Text = (trackBar.Value * valueFactor).ToString(labelFormat);
        }

        public double Value
        {
            get { return trackBar.Value * valueFactor; }
            set { trackBar.Value = (int)(value / valueFactor); }
        }

        public void Refresh()
        {
            parentGroupBox.Refresh();

        }

    }

}
