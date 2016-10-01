using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Controls
{
    public class ElbLine
    {

        public Pen Pen { get; set; }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public ElbLine(Pen pen, Point point1, Point point2)
        {
            this.Pen = pen;
            this.Point1 = point1;
            this.Point2 = point2;
        }

    }
}
