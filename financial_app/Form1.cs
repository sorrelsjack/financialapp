using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;

namespace financial_app
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        bool isDefaultView = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            isDefaultView = true;
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlDataAdapter stocksAdapter = new SqlDataAdapter("SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM (financedata.dbo.Stocks INNER JOIN(select HD.ActualDate, HD.DateID, HD.StockID, HD.OpenValue, HD.HighValue, HD.LowValue, HD.CloseValue, HD.VolumeValue from financedata.dbo.HistoricData HD inner join (select max(ActualDate) ActualDate, StockID from financedata.dbo.HistoricData group by StockID) HDM on HD.StockID = HDM.StockID and HD.ActualDate = HDM.ActualDate) RecentDateTable ON financedata.dbo.Stocks.StockID = RecentDateTable.StockID) ORDER BY StockSymbol ASC; ", sqlCon);
                DataTable dt = new DataTable();
                stocksAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            
            using(SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlDataAdapter marqueeTextGrabber = new SqlDataAdapter("SELECT StockSymbol, HighValue FROM (financedata.dbo.Stocks INNER JOIN(select HD.ActualDate, HD.DateID, HD.StockID, HD.OpenValue, HD.HighValue, HD.LowValue, HD.CloseValue, HD.VolumeValue from financedata.dbo.HistoricData HD inner join (select max(ActualDate) ActualDate, StockID from financedata.dbo.HistoricData group by StockID) HDM on HD.StockID = HDM.StockID and HD.ActualDate = HDM.ActualDate) RecentDateTable ON financedata.dbo.Stocks.StockID = RecentDateTable.StockID) ORDER BY StockSymbol ASC; ", sqlCon);
                DataTable marqueeTable = new DataTable();
                marqueeTextGrabber.Fill(marqueeTable);
                var output = "";

                foreach (DataRow row in marqueeTable.Rows) {
                    for (int i = 0; i < marqueeTable.Columns.Count; i++) {
                        var text = row[i].ToString();
                        output = output + text + " | ";
                    }
                }
                marquee.Text = "Highs: | " + output;
            }

            marquee.Left = this.Width;
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {
            marquee.Left-=6;
            if (marquee.Right == 1) {
                marquee.Left = this.Width;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e) {
            isDefaultView = false;
            DataTable dt = new DataTable();
            List<string> dateList = new List<string>();
            string temp = null;
            string boxSelectedDate;
            int index = 2;
            DateTime parsedDate;
            DateTime onlyDate;

            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlDataAdapter stocksAdapter = new SqlDataAdapter("SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM financedata.dbo.Stocks INNER JOIN financedata.dbo.HistoricData on financedata.dbo.Stocks.StockID = financedata.dbo.HistoricData.StockID ORDER BY ActualDate ASC", sqlCon);
                stocksAdapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows) {
                temp = row[index].ToString();
                parsedDate = DateTime.Parse(temp);
                onlyDate = parsedDate.Date;
                temp = onlyDate.ToString("M/dd/yyyy");
                dateList.Add(temp);
            }

            List<string> noDupesDateList = dateList.Distinct().ToList();
            List<string> orderedDatesList = noDupesDateList.OrderByDescending(x => DateTime.Parse(x)).ToList();

            viewDropBox dateViewDropBox = new viewDropBox(orderedDatesList, "date", "Date");
            dateViewDropBox.ShowDialog();
            if (dateViewDropBox.selectedSymbol != null) {
                boxSelectedDate = dateViewDropBox.selectedSymbol;
                dgvByDate(boxSelectedDate);
            }
        }

        private void dgvByDate(string selectedDate) {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("financedata.dbo.DGVByDate", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActualDate", selectedDate);
                SqlDataAdapter stocksAdapter = new SqlDataAdapter(cmd);
                stocksAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void bySymbolToolStripMenuItem_Click(object sender, EventArgs e) {
            isDefaultView = false;
            List<string> symbolList = new List<string>();
            DataTable dt = new DataTable();
            string temp = null;
            string boxSelectedSymbol;
            int index = 0;

            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlDataAdapter stocksAdapter = new SqlDataAdapter("SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM financedata.dbo.Stocks INNER JOIN financedata.dbo.HistoricData on financedata.dbo.Stocks.StockID = financedata.dbo.HistoricData.StockID ORDER BY StockSymbol ASC", sqlCon);
                stocksAdapter.Fill(dt);
            }

            foreach (DataRow row in dt.Rows) {
                temp = row[index].ToString();
                symbolList.Add(temp);
            }

            List<string> noDupesSymbolList = symbolList.Distinct().ToList();

            viewDropBox symbolViewDropBox = new viewDropBox(noDupesSymbolList, "symbol", "Symbol");
            symbolViewDropBox.ShowDialog();
            if (symbolViewDropBox.selectedSymbol != null) {
                boxSelectedSymbol = symbolViewDropBox.selectedSymbol;
                dgvBySymbol(boxSelectedSymbol);
            }
        }

        private void dgvBySymbol(string selectedSymbol) {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand("financedata.dbo.DGVBySymbol", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StockSymbol", selectedSymbol);
                SqlDataAdapter stocksAdapter = new SqlDataAdapter(cmd);
                stocksAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e) {
            isDefaultView = true;
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                SqlDataAdapter stocksAdapter = new SqlDataAdapter("SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM (financedata.dbo.Stocks INNER JOIN(select HD.ActualDate, HD.DateID, HD.StockID, HD.OpenValue, HD.HighValue, HD.LowValue, HD.CloseValue, HD.VolumeValue from financedata.dbo.HistoricData HD inner join (select max(ActualDate) ActualDate, StockID from financedata.dbo.HistoricData group by StockID) HDM on HD.StockID = HDM.StockID and HD.ActualDate = HDM.ActualDate) RecentDateTable ON financedata.dbo.Stocks.StockID = RecentDateTable.StockID) ORDER BY StockSymbol ASC; ", sqlCon);
                DataTable dt = new DataTable();
                stocksAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            string[] selectedSymbolCompany = null;
            Quote currentQuote = null;
            Dictionary<string, Dictionary<string, string>> symbolCompany = null;
            List<string> symbolList = new List<string>();
            string temp;
            int index = 0;

            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                DataTable dt = new DataTable();
                SqlDataAdapter stocksAdapter = new SqlDataAdapter("SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM financedata.dbo.Stocks INNER JOIN financedata.dbo.HistoricData on financedata.dbo.Stocks.StockID = financedata.dbo.HistoricData.StockID ORDER BY StockSymbol ASC", sqlCon);
                stocksAdapter.Fill(dt);

                foreach (DataRow row in dt.Rows) {
                    temp = row[index].ToString();
                    symbolList.Add(temp);
                }
            }

            List<string> noDupesSymbolList = symbolList.Distinct().ToList();

            do {
                string userInput = Interaction.InputBox("Enter a symbol or a company name.", "Add...", "", -1, -1);
                webRequest webRequest = new webRequest();
                symbolCompany = webRequest.callTicker(userInput);
                if (symbolCompany == null) {
                    MessageBox.Show("No results found. Try again.", "Error", MessageBoxButtons.OK);
                }
            } while (symbolCompany == null);

            if (!symbolCompany.ContainsKey("PLEASE CLOSE THE WINDOW")) {
                multipleResultsMsgBox multipleResultsMsgBox = new multipleResultsMsgBox(symbolCompany, noDupesSymbolList);
                multipleResultsMsgBox.ShowDialog();

                if (multipleResultsMsgBox.selectedSymbolCompany != null) {
                    selectedSymbolCompany = multipleResultsMsgBox.selectedSymbolCompany;
                    webRequest wRequest = new webRequest();
                    currentQuote = wRequest.callAlphaVantage(selectedSymbolCompany[0]);
                    if (currentQuote.tooManyCalls == true) {
                        MessageBox.Show("Too many queries! Please try again in a minute.", "Error", MessageBoxButtons.OK);
                    }
                    else {
                        currentQuote.companyName = selectedSymbolCompany[1];
                        using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                            DataTable dt = new DataTable();
                            SqlCommand cmd = new SqlCommand("financedata.dbo.InsertDGV", sqlCon);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@StockSymbol", currentQuote.symbol);
                            cmd.Parameters.AddWithValue("@StockName", currentQuote.companyName);
                            cmd.Parameters.AddWithValue("@ActualDate", currentQuote.lastRefreshed);
                            cmd.Parameters.AddWithValue("@OpenValue", currentQuote.open);
                            cmd.Parameters.AddWithValue("@HighValue", currentQuote.high);
                            cmd.Parameters.AddWithValue("@LowValue", currentQuote.low);
                            cmd.Parameters.AddWithValue("@CloseValue", currentQuote.close);
                            cmd.Parameters.AddWithValue("@VolumeValue", currentQuote.volume);

                            SqlDataAdapter inserter = new SqlDataAdapter(cmd);
                            inserter.Fill(dt);

                            SqlDataAdapter stocksAdapter = new SqlDataAdapter("SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM (financedata.dbo.Stocks INNER JOIN(select HD.ActualDate, HD.DateID, HD.StockID, HD.OpenValue, HD.HighValue, HD.LowValue, HD.CloseValue, HD.VolumeValue from financedata.dbo.HistoricData HD inner join (select max(ActualDate) ActualDate, StockID from financedata.dbo.HistoricData group by StockID) HDM on HD.StockID = HDM.StockID and HD.ActualDate = HDM.ActualDate) RecentDateTable ON financedata.dbo.Stocks.StockID = RecentDateTable.StockID) ORDER BY StockSymbol ASC; ", sqlCon);
                            stocksAdapter.Fill(dt);
                            dataGridView1.DataSource = dt; //TODO fix sql date time overflow
                            dataGridView1.Refresh();
                            isDefaultView = true;
                        }
                    }
                }
            }
        }

        private void refreshRow(string symbol, string companyName, DateTime lastRefreshed, double open, double high, double low, double close, int volume) {
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
                sqlCon.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("financedata.dbo.RefreshDGV", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StockSymbol", symbol);
                cmd.Parameters.AddWithValue("@ActualDate", lastRefreshed);
                cmd.Parameters.AddWithValue("@OpenValue", open);
                cmd.Parameters.AddWithValue("@HighValue", high);
                cmd.Parameters.AddWithValue("@LowValue", low);
                cmd.Parameters.AddWithValue("@CloseValue", close);
                cmd.Parameters.AddWithValue("@VolumeValue", volume);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        //TODO looping marquee

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {                      
            if (e.ColumnIndex == 0 && isDefaultView) {
                int indexRow;
                webRequest webRequest = new webRequest();
                string symbolString = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                Quote currQuote = webRequest.callAlphaVantage(symbolString);

                if (currQuote.tooManyCalls == true) {
                    MessageBox.Show("Too many queries! Please try again in a minute.", "Error", MessageBoxButtons.OK);
                }

                else {
                    indexRow = e.RowIndex;
                    DataGridViewRow row = dataGridView1.Rows[indexRow];
                    DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
                    newDataRow.Cells[1].Value = currQuote.lastRefreshed;
                    newDataRow.Cells[4].Value = currQuote.open.ToString("0.0000");
                    newDataRow.Cells[5].Value = currQuote.high.ToString("0.0000");
                    newDataRow.Cells[6].Value = currQuote.low.ToString("0.0000");
                    newDataRow.Cells[7].Value = currQuote.close.ToString("0.0000");
                    newDataRow.Cells[8].Value = currQuote.volume;

                    refreshRow(currQuote.symbol, currQuote.companyName, currQuote.lastRefreshed, currQuote.open, currQuote.high, currQuote.low, currQuote.close, currQuote.volume);
                }
            }
            else if(e.ColumnIndex == 0 && !isDefaultView) {
                MessageBox.Show("Refresh is only enabled in the Default view.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}