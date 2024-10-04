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
    [SerializeField]    
    TextMeshProUGUI TextOutput;

    Description description;
    private void Start()
    {
        if (TextOutput == null)
        {
            TextOutput = GetComponent<TextMeshProUGUI>();
        }
        Debug.Log("TextOutput initialized: " + (TextOutput != null));
    }
    public void LoadJson()
    {
        try
        {
            var path = Path.Combine(Application.dataPath, "description.json");
            Debug.Log(path);

            var jsonText = File.ReadAllText(path);
            Debug.Log(jsonText);

            var jsonObject = JObject.Parse(jsonText);
            Debug.Log(jsonObject);

            string name = (string)jsonObject["name"];
            string birthday = (string)jsonObject["birthday"];
            string description = (string)jsonObject["description"];
            JArray skills = (JArray)jsonObject["skills"];
            string skillsText = string.Join(", ", skills.ToObject<List<string>>());

            Debug.Log("Before assigning text to TextOutput");

            if (TextOutput != null)
            {
                TextOutput.text = $"Имя: {name}\nДата рождения: {birthday}\nНавыки: {skillsText}\nОписание: {description}";
            }
            else
            {
                Debug.LogError("TextOutput is null");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
