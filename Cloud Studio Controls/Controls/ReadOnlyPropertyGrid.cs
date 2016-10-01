using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudStudio.GUI.Controls {

    public class ReadOnlyPropertyGrid : PropertyGrid {

        private bool isReadOnly;

        public ReadOnlyPropertyGrid() {

        }

        public bool ReadOnly {

            get { return isReadOnly; }
            set {
                isReadOnly = value;
                SetObjectAsReadOnly();
            }
        }

        public ReadOnlyPropertyGrid(IContainer container) {

            container.Add(this);

        }

        protected override void OnSelectedObjectsChanged(EventArgs e) {

            SetObjectAsReadOnly();

            base.OnSelectedObjectsChanged(e);

        }

        private void SetObjectAsReadOnly() {

            if (SelectedObject != null) {

                TypeDescriptor.AddAttributes(SelectedObject, new Attribute[] { new ReadOnlyAttribute(isReadOnly) });
                
                Refresh();

            }

        }

    }

}
