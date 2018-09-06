using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace financial_app {
    public partial class multipleResultsMsgBox : Form {
        Dictionary<string, Dictionary<string, string>> passedSymbolCompany;
        public string[] selectedSymbolCompany { get; private set; }
        private List<string> passedSymbolList;

        public multipleResultsMsgBox(Dictionary<string, Dictionary<string, string>> symbolCompany, List<string> symbolList) {
            passedSymbolCompany = symbolCompany;
            passedSymbolList = symbolList;
            InitializeComponent();
        }

        private void createListView() {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (Dictionary<string, string> innerDict in passedSymbolCompany.Values) {
                foreach (KeyValuePair<string, string> kvp in innerDict) {
                    ListViewItem itm = new ListViewItem(kvp.Key);
                    itm.SubItems.Add(kvp.Value);
                    listView1.Items.Add(itm);
                }
            }
        }

        private void multipleResultsMsgBox_Load(object sender, EventArgs e) {
            createListView();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection selected = this.listView1.SelectedItems;
        }

        private void button1_Click(object sender, EventArgs e) {
            string[] tableSymbolCompany = new string[2];
            if (listView1.SelectedItems.Count > 0) {
                ListViewItem item = listView1.SelectedItems[0];
                tableSymbolCompany[0] = item.Text;
                tableSymbolCompany[1] = item.SubItems[1].Text;
                this.selectedSymbolCompany = tableSymbolCompany;
                if (passedSymbolList.Where(o => string.Equals (selectedSymbolCompany[0], o, StringComparison.OrdinalIgnoreCase)).Any()) {
                    MessageBox.Show("The symbol " + selectedSymbolCompany[0] + " is already in the database.");
                    this.selectedSymbolCompany = null;
                }
                else {
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
