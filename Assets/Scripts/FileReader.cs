using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public void LoadJson() 
    {
        try
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\sevak\Desktop\UnityTestWork-main\biopunk.json"))
            {
                string json = sr.ReadToEnd();
                Debug.Log(json);
                JObject data = JsonConvert.DeserializeObject<JObject>(json);
                Debug.Log(data);
                string text = "";
                foreach (var property in data.Properties())
                {
                    text = $"<b>{property.Name}</b>: {property.Value}\n";
                    Debug.Log("«¿œ»—¿ÕŒ!!!");
                }
                textMeshPro.text = text;
                Debug.Log("“≈ —“ ¬€¬≈ƒ≈Õ!");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
