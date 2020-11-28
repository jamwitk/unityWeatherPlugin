using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;


public class GetDataFromAPI : MonoBehaviour
{
    [System.NonSerialized]
    public string GetData ="";
    public float lon;
    public float lat;
    public string city;
    public string weatherDescription;
    public string icon;
    public float temp;
    public float feels_like;
    public float wind_speed;
    public float wind_deg;
    public int clouds;
    public string country;
  
    public IEnumerator GetWeatherData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(GetData))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                setWeatherAttributes(webRequest.downloadHandler.text);
            }
        }
    }
    void setWeatherAttributes(string jsonString)
    {
        var weatherJson = JSON.Parse(jsonString);
        city = weatherJson["name"].Value;
        weatherDescription = weatherJson["weather"][0]["description"].Value;
        Debug.Log("City: " + CapitalizeString(city) + " Description: " + weatherDescription);
    }
    public string CapitalizeString(string capitalize)
    {

        string str = char.ToUpper(capitalize[0]) + capitalize.Substring(1);
        return str;
    }
}


