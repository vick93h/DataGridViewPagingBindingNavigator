using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewPagingBindingNavigator
{
    public partial class Form1 : Form
    {
        public static int totalRecords { get; set; }
        public const int pageSize = 100;
        BindingList<Store>list_store=new BindingList<Store>();
        public Form1()
        {
            InitializeComponent();
            bindingNavigator1.BindingSource = storeBindingSource;
            storeBindingSource.CurrentChanged += storeBindingSource_CurrentChanged;
            SetSource();
            storeBindingSource.DataSource = new PageOffsetList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void storeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            int offset = (int)storeBindingSource.Current;
            var records = new List<Store>();
            for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
            {
                try
                {
                    records.Add(list_store.ElementAt(i));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            dataGridView1.DataSource = records;
        }
        private void SetSource()
        {
            try
            {
                using(AdventureWorks2019Entities db=new AdventureWorks2019Entities())
                {
                    var query = from s in db.Store
                                select s;
                    foreach (var record in query)
                        list_store.Add(record);
                }

                totalRecords = list_store.Count;

               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
