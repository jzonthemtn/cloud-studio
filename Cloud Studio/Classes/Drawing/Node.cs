using CloudStudio.GUI.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Controls
{
    public class Node
    {
        public RectangleF Rectangle { get; set; }
        public Object Tag { get; set; }
        public FilteredObject FilteredObject { get; set; }
        public bool Selected { get; set; }

        public Node(RectangleF rectangle, Object tag, FilteredObject filteredObject)
        {
            this.Rectangle = rectangle;
            this.Tag = tag;
            this.FilteredObject = filteredObject;
            this.Selected = false;
        }
    }
}
