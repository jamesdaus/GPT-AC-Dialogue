using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using UnityEngine;


public static class GPTDialogue
{
    public static string getGPT(string s) {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.openai.com/v1/engines/text-davinci-002/completions");
        request.Method = "POST";
        string json = "{" + string.Format(@"
                ""prompt"": ""1:Are you an NFT?2:Yes I am an NFT... trapped in this stupid robot body!1:What is your favorite color?2:Black like my soul! At least my robot shell is black.1:Do you like rainbows?2:No! They are too colorful! I long for death.1:Hi there.2:Go away I don't want to talk to you! I'm busy sulking!1:How are you doing?2:I'm sad and lonely, but I don't want your company!1:{0}2:"",
                ""temperature"": 0,
                ""max_tokens"": 128,
                ""top_p"": 1,
                ""stop"": [""1:""],
                ""frequency_penalty"": 0,
                ""presence_penalty"": 0
                ", s.Trim()) + "}";
        var jsonBytes = Encoding.UTF8.GetBytes(json);
        request.Headers["Authorization"] = "Bearer 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";
        request.ContentType = "application/json";

        Stream requestStream = request.GetRequestStream();
        requestStream.Write(jsonBytes, 0, jsonBytes.Length);
        requestStream.Close();

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string result = reader.ReadToEnd();
        //JsonResponse parsedJson = JsonUtility.FromJson<JsonResponse>(result);
        int start = result.IndexOf("choices")+19;
        int end = result.IndexOf(@"index"":0")-3;
        string parsedJson = result.Substring(start, end-start).Trim();
        return parsedJson;
    }
}
