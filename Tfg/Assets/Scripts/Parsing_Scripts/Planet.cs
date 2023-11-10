using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script used to store the information about the planet and to parse it
 *  from Json format
 */

enum resources { Food, Minerals, Magic, Weapons, Slaves}

public struct Caracteristics
{
    string surface;
    int temperature;

    resources[] res;
}

public class Planet : MonoBehaviour
{
    string Name;

    Caracteristics car;

    int satelites;
}
