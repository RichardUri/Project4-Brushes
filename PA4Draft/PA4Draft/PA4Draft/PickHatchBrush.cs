using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA4Draft
{

    //LIST BOX IS TO SELECT DIFFERENT HATCH BRUSHES FROM A LIST
    //SO CREATE A HATCHBRUSH STYLE VARIABLE IN THE DESIGNER
    public partial class PickHatchBrush : Form
    {
        public PickHatchBrush()
        {
            InitializeComponent();
            foregroundColor = SystemColors.ButtonFace;
            backgroundColor = SystemColors.ButtonFace;

            foreach (string styleName in Enum.GetNames(typeof(HatchStyle)))
            {
                hatchStyleList.Items.Add(styleName);
                
            }
        }

        private void foregroundButton_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog1.ShowDialog();
            if (d == DialogResult.OK)
                foregroundColor = colorDialog1.Color;
            foregroundColor = Color.FromArgb(/*(byte)opacity.Value,*/ foregroundColor.R, foregroundColor.G, foregroundColor.B);
            foregroundButton.BackColor = foregroundColor;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog2.ShowDialog();
            if (d == DialogResult.OK)
                backgroundColor = colorDialog2.Color;
            backgroundColor = Color.FromArgb(/*(byte)opacity.Value,*/ backgroundColor.R, backgroundColor.G, backgroundColor.B);
            backgroundButton.BackColor = backgroundColor;
        }

        private void hatchStyleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            hatchStyleText = hatchStyleList.GetItemText(hatchStyleList.SelectedIndex);
            hs = (HatchStyle)Enum.Parse(typeof(HatchStyle), hatchStyleText, true);
        }
    }
}
