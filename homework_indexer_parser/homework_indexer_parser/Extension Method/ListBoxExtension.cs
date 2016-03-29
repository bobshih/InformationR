using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace homework_indexer_parser
{
    public static class ListBoxExtension
    {
        /// <summary>
        /// Get All Strings In ListBox
        /// </summary>
        public static List<string> GetStringList(this ListBox listbox)
        {
            return new List<string>(listbox.Items.OfType<string>());
        }

        /// <summary>
        /// Replace All Items In 'ListBox' By 'List'
        /// </summary>
        /// <param name="listbox">ListBox To Operate On</param>
        /// <param name="list">Collections To Fill ListBox</param>
        public static void SetItem(this ListBox listbox, List<string> list)
        {
            listbox.Items.Clear();
            listbox.Items.AddRange(list.ToArray());
        }

        /// <summary>
        /// Remove All Duplicated String In ListBox
        /// </summary>
        public static void RemoveDuplicate(this ListBox listbox)
        {
            var list = listbox.GetStringList();
            list.Sort();
            for (int i = 1; i < list.Count; ++i)
            {
                if (list[i] == list[i - 1])
                {
                    list.RemoveAt(i);
                }
            }
            listbox.SetItem(list);
        }
    }
}
