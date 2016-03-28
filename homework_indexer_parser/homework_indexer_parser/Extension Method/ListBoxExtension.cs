using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public static class ListBoxExtension
    {
        public static List<string> ToStringList(this ListBox listbox)
        {
            return (List<string>)listbox.Items.OfType<string>();
        }
    }
}
