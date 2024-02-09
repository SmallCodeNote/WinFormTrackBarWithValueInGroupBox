using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TrackBarWithValueInGroupBox;


namespace TrackBarWithValueInGroupBox
{
    public partial class Form1 : Form
    {
        TrackBarWithValue trackBarWithValue;
        public Form1()
        {
            InitializeComponent();
            trackBarWithValue = new TrackBarWithValue(groupBox1);

        }
    }
}
