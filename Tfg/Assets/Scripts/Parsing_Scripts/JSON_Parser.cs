using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSON_Parser : MonoBehaviour
{
    //This is temporal while I try to introduce Chatgpt into the project
    private string FileName = "\\Universidad\\tfg\\Tfg\\Tfg\\Assets\\testing_Json\\prueba.Json";


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

    /*
     * Creo que para hacer la busqueda lo mas eficiente posible
     * lo suyo seria añadirle al mensaje que el usuario manda al chatgpt
     * un añadido de "Estructuramelo como este ejemplo
     */

    public void LoadJson(string file)
    {
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(FileName);
            string line;
            line = parseNumberOfPlanets(sr);

            planets = new Planet[n_planets];

        }
        else
        {
            Debug.LogError("Path doesn´t exist");
        }
        
    }

    private string parseNumberOfPlanets(StreamReader sr)
    {
        string line;
        sr.ReadLine();   //We remove the first character ({)

        line = sr.ReadLine();

        string[] firstSplit = line.Split(":");
        string[] secondSplit = firstSplit[1].Split(","); //Number and ,


        n_planets = int.Parse(secondSplit[0]);
        return line;
    }
}
