using System;
using System.Text.RegularExpressions;
using System.IO;

namespace financial_app {
    public class Quote {

        public string symbol { get; set; }
        public string companyName { get; set; }
        public DateTime lastRefreshed { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public int volume { get; set; }
        public bool tooManyCalls { get; set; }

        public Quote() {

        }

        public static string grabAfterColon(string line) {
            string result = "";
            string[] splitUp;

            foreach (char c in line) {
                splitUp = line.Split(':');
                result = Regex.Replace(splitUp[1], "[^A-Za-z0-9.]", "");
            }
            return result;
        }

        public Quote parseMyJson(string json) {
            int numNewLines = 0;
            DateTime dateTime = new DateTime();
            Quote currQuote = new Quote();

            if (json.Contains("Thank you for using Alpha Vantage! Please visit https://www.alphavantage.co/premium/ if you would like to have a higher API call volume.")) {
                currQuote.tooManyCalls = true;
            }

            else {
                using (StringReader reader = new StringReader(json)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        if (numNewLines == 3) {
                            currQuote.symbol = grabAfterColon(line);
                        }
                        if (numNewLines == 9) {
                            line = Regex.Replace(line, "[\"|{]", "");
                            line = line.Remove(line.Length - 2, 1);
                            dateTime = Convert.ToDateTime(line);
                            currQuote.lastRefreshed = dateTime;
                        }
                        if (numNewLines == 10) {
                            currQuote.open = Convert.ToDouble((grabAfterColon(line)));
                        }
                        if (numNewLines == 11) {
                            currQuote.high = Convert.ToDouble((grabAfterColon(line)));
                        }
                        if (numNewLines == 12) {
                            currQuote.low = Convert.ToDouble((grabAfterColon(line)));
                        }
                        if (numNewLines == 13) {
                            currQuote.close = Convert.ToDouble((grabAfterColon(line)));
                        }
                        if (numNewLines == 14) {
                            currQuote.volume = int.Parse((grabAfterColon(line)));
                        }
                        if (++numNewLines == 15) {
                            break;
                        }
                    }
                }
            }
            return currQuote;
        }
    }
}
