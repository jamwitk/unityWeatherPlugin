using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SimpleJSON;
using OWMap;
public class openWeatherInspector : EditorWindow 
{
    public string _api = "";
    public string _city = "";
    private bool _showBtn = true;
    public Texture icon;
    GetDataFromAPI giveData;
   
    [MenuItem("Tools/Open Window")]
    public static void ShowWindow(){
        GetWindow(typeof(openWeatherInspector));
    }
    
    private void OnGUI()
    {
       
        try
        {
            GUILayout.Label("Connect To The OpenWeither", EditorStyles.boldLabel);
            // Constrain all drawing to be within a 800x600 pixel area centered on the screen.
           // giveData = GameObject.Find("GetDataFromAPI").GetComponent<GetDataFromAPI>(); // with giveData this will give url to GetData string in GetDataFromApi.cs

            //Layout design
            _api = EditorGUILayout.TextField("Api Key", _api);
            _city = EditorGUILayout.TextField("City Name ", _city);
            _showBtn = EditorGUILayout.Toggle("Get Name ", _showBtn);

            

            if (GUILayout.Button("Add key"))
            {
                var getRequest = new Inputs(_city);
                getRequest.getRequest(_api);
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            
        }

       
    }

    public string CapitalizeString(string capitalize)
    {
        
        string str = char.ToUpper(capitalize[0]) + capitalize.Substring(1);
        return str;
    }

}
