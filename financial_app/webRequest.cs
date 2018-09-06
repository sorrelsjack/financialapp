using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace financial_app {
    public class webRequest {
        HttpClient client = new HttpClient();

        public webRequest() {
            
        }

        public Quote callAlphaVantage(string symbol) {
            string baseUrl = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY";
            const string API_KEY = "U2L23UQ44BABBXJS";
            string fullUrl = baseUrl + "&symbol=" + symbol + "&apikey=" + API_KEY;
            webRequest webRequest = new webRequest();
            string result = webRequest.perfWebCall(fullUrl);

            Quote currQuote = new Quote();
            currQuote = currQuote.parseMyJson(result);

            return currQuote;
        }

        public Dictionary<string, Dictionary <string, string>> callTicker(string input) {
            string baseUrl = "https://www.tickerapi.com/lookup.php?";
            const string API_KEY = "HKLVR6TKXJXVKD3GLV7W";
            string fullUrl = baseUrl + "ticker=" + input + "&key=" + API_KEY;
            Dictionary<string, Dictionary <string, string>> symbolCompany = null;

            webRequest webRequest = new webRequest();
            string result = webRequest.perfWebCall(fullUrl);

            if (input != "") {
                if (result.Contains("No results")) {
                    fullUrl = baseUrl + "company=" + input + "&key=" + API_KEY;
                    result = webRequest.perfWebCall(fullUrl);
                    if (!result.Contains("no match")) {
                        symbolCompany = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(result);
                    }
                }
                else {
                    symbolCompany = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(result);
                }
            }
            else {
                symbolCompany = new Dictionary<string, Dictionary<string, string>>();
                symbolCompany.Add("PLEASE CLOSE THE WINDOW", null);
            }
            return symbolCompany;
        }

        public string perfWebCall(string fullUrl) {
            try {
                Uri url = new Uri(fullUrl);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                request.Method = "GET";
                request.ContentType = "application/json";

                WebResponse serverResponse = (WebResponse)request.GetResponse();
                Stream newStream = serverResponse.GetResponseStream(); //getting webresponse as a stream (series of chars)
                StreamReader sr = new StreamReader(newStream); //makes it look like a txt file
                var result = sr.ReadToEnd(); //putting streamreader info into string

                serverResponse.Close();

                return result;
            }
            catch (Exception e) {
                Console.Write(e.StackTrace);
                string result = e.ToString(); //TODO handle
                return result;
            }
        }
    }
}
