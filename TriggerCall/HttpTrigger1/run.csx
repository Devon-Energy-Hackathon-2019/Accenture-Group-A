#r "System.Runtime"
#r "Newtonsoft.Json"

 

using System.Net;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
// using Twilio.TwiML;
// using Twilio.Types;
using Newtonsoft.Json;

 

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
    var data = await req.Content.ReadAsStringAsync();
    
    // var formValues = data.Split('&').Select(value => value.Split('#'))
    //                 .ToDictionary(pair => Uri.UnescapeDataString(pair[0]).Replace("+"," "),
    //                             pair => Uri.UnescapeDataString(pair[1]).Replace("+"," "));

 

    var accountSid = "ACa13740f62f2b18e81b51c5f989ca7842";//formValues["SID"];
    var authToken = "cf4e5b8e9dc0d4ca2234a45db213c00f";//formValues["Token"];
    var toNum = new Twilio.Types.PhoneNumber("+14057609252");
    var fromNum = new Twilio.Types.PhoneNumber("+13346036820");
    TwilioClient.Init(accountSid, authToken);
    var call = CallResource.Create(toNum, fromNum, url: new Uri("https://demo.twilio.com/welcome/voice/")); 
    //var call = CallResource.Create(toNum, fromNum, url: new Uri("https://accentapublic.blob.core.windows.net/public/file1.xml")); 

 

    var twiml = call.ToString();
    
    twiml = twiml.Replace("utf-16", "utf-8");
    log.LogInformation(twiml );

 

    return new HttpResponseMessage
    {
        Content = new StringContent(twiml, Encoding.UTF8, "application/json")
    };
}