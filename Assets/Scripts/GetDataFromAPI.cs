using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetDataFromAPI : MonoBehaviour
{
    [System.NonSerialized]
    public string GetData ="";
    
    
}

[SerializeField]
public class Weather
{
    public static Weather CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<Weather>(jsonString);
    }
}
