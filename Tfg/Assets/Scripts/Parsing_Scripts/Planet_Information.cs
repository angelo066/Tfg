using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script that stores the information about the planet while parsing
 * So we can later add it to the Monobehaviout script
 */
public class Planet_Information
{
    //Public variables because user is not going to going to have access to this class
    public enum resources { Food, Minerals, Magic, Weapons, Slaves }

    public struct Caracteristics
    {
        public string surface;
        public string temperature;

        public resources[] res;
    }

    public string Name;

    public Caracteristics car;

    public int satelites;
}
