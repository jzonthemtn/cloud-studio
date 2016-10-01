using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Utils
{
    public class ClipboardUtils
    {

        private static List<string> copiedInstanceIds = null;

        public static void CopyInstances(List<string> instanceIds)
        {
            copiedInstanceIds = instanceIds;
        }

        public static List<string> GetCopiedInstances()
        {
            return copiedInstanceIds;
        }

        public static bool IsClipboardEmpty()
        {
            if (copiedInstanceIds == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
