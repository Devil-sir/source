using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.utilties
{
    public class jsonReader
    {
        public jsonReader()
        {

        }

        public string extractData(String tokenName)
        {
            String myJsonString = File.ReadAllText("Data/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
        public string[] extractDataArray(String tokenName)
        {
            String myJsonString = File.ReadAllText("Data/testData.json");

            var jsonObject = JToken.Parse(myJsonString);
            List<string> productsList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return productsList.ToArray();
            
        }

    }
}
