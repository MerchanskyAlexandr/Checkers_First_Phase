using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.DesktopUI
{
    public static class SoundEffect
    {
        public static SoundPlayer Click { get; private set; }
        public static SoundPlayer Drop { get; private set; }
        public static SoundPlayer Win { get; private set; }

        static SoundEffect()
        {
            Click = new SoundPlayer(Properties.Resources.Click);
            Drop = new SoundPlayer(Properties.Resources.Drop);
            Win = new SoundPlayer(Properties.Resources.Win);
        }
    }
}
