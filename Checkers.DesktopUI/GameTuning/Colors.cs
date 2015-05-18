using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.DesktopUI
{
    public static class Colors
    {
        public static Color DeskBlack { get; private set; }
        public static Color DeskWhite { get; private set; }
        public static Color HighLightCell { get; private set; }
        public static Color HighLightChecker { get; private set; }

        static Colors()
        {
            DeskBlack = Color.Black;
            DeskWhite = Color.LightGray;
            HighLightCell = Color.Coral;
            HighLightChecker = Color.Cyan;
        }
    }
}
