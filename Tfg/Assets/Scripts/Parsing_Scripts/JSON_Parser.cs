using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSON_Parser : MonoBehaviour
{
    //This is temporal while I try to introduce Chatgpt into the project
    private string FileName = "\\Universidad\\tfg\\Tfg\\Tfg\\Assets\\testing_Json\\prueba.Json";

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
            try
            {
                StreamReader sr = new StreamReader(file);

                string json = sr.ReadToEnd();

                SolarSystem solarSytemParsed =
                    JsonUtility.FromJson<SolarSystem>(json);

                Debug.Log("Debug");
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error al deserializar el JSON: " + ex.Message);
            }
        }
        else
        {
            Debug.LogError("Path doesn´t exist");
        }

        
    }
}
