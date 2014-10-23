using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoklenSodigerLight
{
    public class Utility
    {
        public static void AddEnterTabOrder(Control containerControl)
        {
            foreach(Control c in containerControl.Controls)
            {
                c.GotFocus += c_GotFocus;
                c.LostFocus += c_LostFocus;
                c.KeyDown += c_KeyDown;
            }
        }

        static void c_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        static void c_LostFocus(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.White;
        }

        static void c_GotFocus(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Cyan;
        }
    }
}
