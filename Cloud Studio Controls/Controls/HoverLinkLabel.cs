using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudStudio.GUI.Controls
{

    public class HoverLinkLabel : LinkLabel
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public HoverLinkLabel()
        {
            InitializeComponent();
        }         

        protected override void OnMouseEnter(EventArgs e)
        {
            this.LinkColor = System.Drawing.Color.Blue;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.LinkColor = System.Drawing.Color.DarkBlue;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

    }

}
