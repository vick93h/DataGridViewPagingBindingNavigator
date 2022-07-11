using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewPagingBindingNavigator
{
    public class PageOffsetList : IListSource
    {
        public bool ContainsListCollection
        {
            get;
            protected set;
        }

        public System.Collections.IList GetList()
        {
            // Return a list of page offsets based on "totalRecords" and "pageSize"
            var pageOffsets = new List<int>();
            for (int offset = 0; offset <= Form1.totalRecords; offset = offset +Form1.pageSize)
            {
                pageOffsets.Add(offset);
            }

            return pageOffsets;
        }
    }
}
