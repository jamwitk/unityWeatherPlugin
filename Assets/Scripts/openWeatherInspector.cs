using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class openWeatherInspector : EditorWindow
{
    string _url = "";
    public string _api = "";
    public string _city = "";
    public Texture icon;
    GetDataFromAPI giveData;

    [MenuItem("Tools/Open Window")]
    public static void ShowWindow(){
        GetWindow(typeof(openWeatherInspector));
    }
    
    private void OnGUI()
    {

        GUILayout.Label("Connect To The OpenWeither", EditorStyles.boldLabel);
        // Constrain all drawing to be within a 800x600 pixel area centered on the screen.
        giveData = GameObject.Find("GetDataFromApi").GetComponent<GetDataFromAPI>(); // with giveData this will give url to GetData string in GetDataFromApi.cs

        _api = EditorGUILayout.TextField("Api Key", _api);
        _city= EditorGUILayout.TextField("City Name ", _city);

        if(GUILayout.Button("Add key"))
        {
            _url = "api.openweathermap.org/data/2.5/weather?q=" + CapitalizeString(_city) + "&appid=" + _api;
            giveData.GetData = _url;
            Debug.Log(giveData.GetData);
        }
       
       
    }

    public string CapitalizeString(string capitalize)
    {
        
        string str = char.ToUpper(capitalize[0]) + capitalize.Substring(1);
        return str;
    }

}
