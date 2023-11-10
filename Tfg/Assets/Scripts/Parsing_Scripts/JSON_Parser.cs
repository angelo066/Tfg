using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSON_Parser : MonoBehaviour
{
    //This is temporal while I try to introduce Chatgpt into the project
    private string FileName = "\\Universidad\\tfg\\Tfg\\Tfg\\Assets\\testing_Json";


    int n_planets;
    int[] sateliteNumbers;

    Planet[] planets;

    // Start is called before the first frame update
    void Start()
    {
        LoadJson(FileName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadJson(string file)
    {
        Debug.Log(file);
        string text = File.ReadAllText(file);

    }
}
