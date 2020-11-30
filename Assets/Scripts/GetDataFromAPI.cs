using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;
using SimpleJSON;
using OWMap;


public class GetDataFromAPI : MonoBehaviour
{
    [System.NonSerialized]
    public string GetData ="";
    public float lon;
    public float lat;
    public string city;
    public string weatherDescription;
    public string _icon;
    public int temp;
    public float feels_like;
    public float wind_speed;
    public float wind_deg;
    public int clouds;
    public string country;
    
    public Text[] Textboxs = new Text[10];
    public RawImage icon;
  
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


        //OWMap
            var weather = new Weather(JSON.Parse(jsonString));
            Textboxs[0].text = weather.description;
            var api = new API("");
             api.keyApi = "" ;
        //OWMap
        /*
       
            v
            lon = float.Parse(weatherJson["coord"]["lon"].Value);
            lat = float.Parse(weatherJson["coord"]["lat"].Value);
            city = weatherJson["name"].Value;
            weatherDescription = weatherJson["weather"][0]["description"].Value;
            _icon = weatherJson["weather"][0]["icon"].Value;
            temp = weatherJson["main"]["temp"].AsInt;
            feels_like = float.Parse(weatherJson["main"]["feels_like"].Value) / 100;
            wind_speed = float.Parse(weatherJson["wind"]["speed"].Value);
            wind_deg = float.Parse(weatherJson["wind"]["deg"].Value);
            clouds = int.Parse(weatherJson["clouds"]["all"].Value);
            country = weatherJson["sys"]["country"].Value;
            // get icon
            StartCoroutine(getIcon(_icon));
            Debug.Log("City: " + CapitalizeString(city) + " Description: " + weatherDescription);
            ShowOnScreen();
        */
    }
    public IEnumerator getIcon(string url)
    {
        using (UnityWebRequest IconRequest =  UnityWebRequestTexture.GetTexture("http://openweathermap.org/img/wn/"+url+".png",false))
        {
            yield return IconRequest.SendWebRequest();
            if(IconRequest.isNetworkError)
            {
                Debug.Log(IconRequest.error);
            }
            else
            {
                icon.texture = ((DownloadHandlerTexture)IconRequest.downloadHandler).texture;
            }
        }
    }
    public string CapitalizeString(string capitalize)
    {

        string str = char.ToUpper(capitalize[0]) + capitalize.Substring(1);
        return str;
    }

   public void ShowOnScreen()
    {
        Textboxs[0].text = lon.ToString();
        Textboxs[1].text = lat.ToString();
        Textboxs[2].text = city.ToString();
        Textboxs[3].text = weatherDescription;
        Textboxs[4].text = temp.ToString();
        Textboxs[5].text = feels_like.ToString();
        Textboxs[6].text = wind_speed.ToString();
        Textboxs[7].text = wind_deg.ToString();
        Textboxs[8].text = clouds.ToString();
        Textboxs[9].text = country.ToString();
    }
}


