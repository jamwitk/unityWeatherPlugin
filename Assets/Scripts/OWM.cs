using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

namespace OWMap
{
    public class Inputs : MonoBehaviour
    {
        public string city { get; }
        
        private string url;
        public Inputs( string _city) => ( city) = (_city); //setting attributes to Input variables
        
        private IEnumerator GetRequest(string _api)
        {

            url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + " &units=metric&appid= " + _api;
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.isNetworkError)
                {
                    Debug.Log(webRequest.error);
                }
                else                
                {
                    // get data here or send data
                    var request = new Request(webRequest.downloadHandler.text);
                    Debug.Log("çalışıyor");
                }
            }
        }
        public void getRequest(string _api)
        {
            //getting request with this method
            StartCoroutine(GetRequest(_api));
        }
    }
    public class Request
    {
        //This stage is for return request JSONNODE
        public JSONNode request { get; }

        public Request(JSONNode _request)
        {
            request = _request;
        }
    }
    public class Weather
    {
        //This stage is for return Weather variables
        public int id { get; }
        public string main { get; }
        public string description { get; }
        public string icon { get; }
        
        public Weather(JSONNode request)
        {
            if (request is null)
                throw new System.ArgumentNullException(nameof(request));

            main = request["weather"][0]["main"].Value;
            description = request["weather"][0]["description"].Value;
        }
    }

    public class API 
    {
        // This stage is for input api key then return it
        public string keyApi;
      
        public API(string APIkey)
        {
            keyApi = APIkey;
        }
        
    }
}

