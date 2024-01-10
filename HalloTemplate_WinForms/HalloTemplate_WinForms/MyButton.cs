using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloTemplate_WinForms
{
    internal class MyButton : Button
    {

        int c = 0;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            pevent.Graphics.FillEllipse(new LinearGradientBrush(ClientRectangle, Color.Fuchsia, Color.Aqua, 45), ClientRectangle);

            var f = new Font("Vivaldi", 18f, FontStyle.Bold);
            var sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            pevent.Graphics.DrawString(Text, f, Brushes.Firebrick, ClientRectangle, sf);

            Parent.Text = c++.ToString();
        }


    }
}
