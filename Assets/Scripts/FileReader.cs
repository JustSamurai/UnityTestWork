using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
public class FileReader : MonoBehaviour
{
    string Path = "C:\\Users\\User\\Desktop\\TestWork";
    // Start is called before the first frame update
    void Start()
    {
        ConvertToDescription<Description>(Path);
    }

    // Update is called once per frame
    public static T ConvertToDescription<T>(string path) 
    {
        T t = new();
        t = JsonConvert.DeserializeObject<T>(path);
        return ;
    }
}
