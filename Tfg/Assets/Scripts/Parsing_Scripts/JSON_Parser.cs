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

    Planet_Information[] planets;

    // Start is called before the first frame update
    void Start()
    {
        LoadJson(FileName);
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
            parseNumberOfPlanets(sr);
            planets = new Planet_Information[n_planets];

            sr.ReadLine(); //Remove "Planets"
            sr.ReadLine(); //Remove "{"
            for(int i=0; i < n_planets; i++)
            {
                planets[i] = new Planet_Information(); //Initizalitation of the information class
                string line = sr.ReadLine();

                ParseName(i, line);

                sr.ReadLine(); //Remove "Characteristics"

                line = sr.ReadLine();

                ParseSurface(i, line);

                line = sr.ReadLine();

                ParseTemperatura(i, line);

                //ParseResources

                line = sr.ReadLine(); //Remove "},"

                line = sr.ReadLine();

                ParseSatelites(i, line);

                sr.ReadLine(); //Remover "},"
                sr.ReadLine(); //Remover "{"
            }
            sr.ReadLine(); //Remover "],"
        }
        else
        {
            Debug.LogError("Path doesn´t exist");
        }

        Debug.Log("Debug");
        
    }

    private void ParseSatelites(int i, string line)
    {
        string[] parameterSplit = line.Split(":");

        planets[i].satelites = int.Parse(parameterSplit[1]);
    }

    private void ParseTemperatura(int i, string line)
    {
        string[] parameterSplit = line.Split(":");

        planets[i].car.temperature = parameterSplit[1];
    }

    private void ParseSurface(int i, string line)
    {
        string[] parameterSplit = line.Split(":");
        string[] valueSplit = parameterSplit[1].Split(",");

        planets[i].car.surface = valueSplit[0];
    }

    private void ParseName(int i, string line)
    {
        string[] parameterSplit = line.Split(":"); //We split the value from the parameter
        string[] valueSplit = parameterSplit[1].Split(","); //We split the value from the , character 

        planets[i].Name = valueSplit[0]; // name of the planet 
        Debug.Log(planets[i].Name);
    }

    private void parseNumberOfPlanets(StreamReader sr)
    {
        string line;
        sr.ReadLine();   //We remove the first character ({)

        line = sr.ReadLine();

        string[] firstSplit = line.Split(":");
        string[] secondSplit = firstSplit[1].Split(","); //Number and ,


        n_planets = int.Parse(secondSplit[0]);
    }
}
