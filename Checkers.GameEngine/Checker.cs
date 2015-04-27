using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.GameEngine
{
    public abstract class Checker
    {
        public ColorType Color { get; private set; }
        public CheckerStatus Status { get; set; }

        public Checker(ColorType color, CheckerStatus status)
        {
            this.Color = color;
            this.Status = status;
        }
    }
}
