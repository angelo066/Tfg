using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script used to store the information about the planet and to show it
 * when neccesary
 */

public class Planet_Information : MonoBehaviour
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
