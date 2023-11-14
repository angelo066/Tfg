using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script defines Clases so we can parse Json with the JsonUtility
 * function "FromJson"
 */

/*
 * The following clases are used to store
 * the information directly from the Json
 */
[System.Serializable]
public class SolarSystem
{
    public int Number_of_Planets;

    public Planet[] Planets;

    public string History;
}

[System.Serializable]
public class Planet
{
    public string Name;

    public PlanetCharacteristics Characteristics;

    public int Satellites;
}

[System.Serializable]
public class PlanetCharacteristics
{
    public string Surface;

    public string Temperature;
}
