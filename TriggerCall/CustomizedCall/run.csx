#r "System.Runtime"
#r "Newtonsoft.Json"

using System.Net;
using System.Text;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Newtonsoft.Json;

    static void Main()
    {
        var response = new VoiceResponse();
        response.Say("Hi Bilal");

        Console.WriteLine(response.ToString());
        
    }
