using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TextFileSearch
{
    public static class ControlExtensions
    {
        public static void EnebleDoubleBuffer(this Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });

            foreach (Control childControl in control.Controls)
            {
                childControl.EnebleDoubleBuffer();
            }
        }

        public static void DisableSelectStyles(this Control control)
        {
            if (control is Button)
            {
                typeof(Button).InvokeMember("SetStyle",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                    null, control, new object[] { ControlStyles.Selectable, false });
            }

            foreach (Control childControl in control.Controls)
            {
                childControl.DisableSelectStyles();
            }
        }
    }
}
