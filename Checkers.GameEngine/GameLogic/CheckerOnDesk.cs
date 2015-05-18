using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Checkers.GameEngine
{
    public class CheckerOnDesk : Checker, IEquatable<CheckerOnDesk>
    {
        #region Public Properties

        public Point Point { get; set; }
        
        #endregion

        #region Constructors

        public CheckerOnDesk(ColorType color, CheckerStatus status, Point point) : base (color, status)
        {
            this.Point = point;
        }

        #endregion

        public bool Equals(CheckerOnDesk other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                if (this.Color == other.Color && this.Status == other.Status
                    && this.Point.X == other.Point.X && this.Point.Y == other.Point.Y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return base.Equals(obj);
            }

            if (!(obj is CheckerOnDesk))
            {
                throw new InvalidCastException("The 'obj' argument is not a CheckerOnDesk object.");
            }
            else
            {
                return Equals(obj as CheckerOnDesk);
            }
        }

        public override int GetHashCode()
        {
            return (int)this.Color ^ (int)this.Status ^ this.Point.X ^ this.Point.Y;
        } 

        public ColorType EnemyColor()
        {
            return this.Color == ColorType.Black ? ColorType.White : ColorType.Black;            
        }
    }
}
