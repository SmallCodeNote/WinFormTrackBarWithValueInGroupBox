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

        public double _valueFactor=1.0;
        public string labelFormat = "";

        public TrackBarWithValue(GroupBox parentGroupBox, double valueFactor = 1.0)
        {
            this.parentGroupBox = parentGroupBox;
            
            Initialize();

            this.valueFactor = valueFactor;

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

        public double valueFactor
        {
            get { return _valueFactor; }
            set
            {
                double maxValue = trackBar.Maximum / valueFactor;
                double minValue = trackBar.Minimum / valueFactor;
                double trackValue = trackBar.Value / valueFactor;

                _valueFactor = value;

                trackBar.Maximum = (int)(maxValue * valueFactor);
                trackBar.Minimum = (int)(minValue * valueFactor);
                trackBar.Value = (int)(trackValue * valueFactor);

            }

        }

        public double Value
        {
            get { return trackBar.Value * valueFactor; }
            set { trackBar.Value = (int)(value / valueFactor); }
        }

        public int Maximum
        {
            get { return trackBar.Maximum; }
            set
            {
                trackBar.Maximum = (int)(value/valueFactor);
                int TickFrequency = (trackBar.Maximum - trackBar.Minimum) / 10;
                if (TickFrequency < 1) TickFrequency = 1;
                trackBar.TickFrequency = TickFrequency;
            }
        }

        public int Minimum
        {
            get { return trackBar.Minimum; }
            set
            {
                trackBar.Minimum = (int)(value / valueFactor);
                int TickFrequency = (trackBar.Maximum - trackBar.Minimum) / 10;
                if (TickFrequency < 1) TickFrequency = 1;
                trackBar.TickFrequency = TickFrequency;
            }
        }
        public int LargeChange
        {
            get { return trackBar.LargeChange; }
            set { trackBar.LargeChange = (int)(value / valueFactor); }
        }
        public int TickFrequency
        {
            get { return trackBar.TickFrequency; }
            set
            {
                trackBar.TickFrequency = (int)(value / valueFactor);
            }
        }
        public bool Enabled
        {
            get { return trackBar.Enabled; }
            set
            {
                trackBar.Enabled = value;
                labelValue.Enabled = value;
                parentGroupBox.Enabled = value;
            }
        }

        public void Refresh()
        {
            parentGroupBox.Refresh();

        }

    }

}