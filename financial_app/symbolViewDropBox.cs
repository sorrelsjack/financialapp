using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace financial_app {
    public partial class viewDropBox : Form {
        private List<string> passedSymbolList;
        public string selectedSymbol;

        public viewDropBox(List<string> symbolList, string labelText, string title) {
            passedSymbolList = symbolList;
            this.Text = "Choose " + title;
            InitializeComponent();
        }

        private void populateComboBox() {
            this.comboBox1.DataSource = passedSymbolList;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void symbolViewDropBox_Load(object sender, EventArgs e) {
            populateComboBox();
        }

        private void button1_Click(object sender, EventArgs e) {
            selectedSymbol = comboBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}
