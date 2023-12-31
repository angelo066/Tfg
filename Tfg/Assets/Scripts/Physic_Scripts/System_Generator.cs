using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class System_Generator : MonoBehaviour
{
    //Prefabs of the celestial bodies
    [SerializeField]
    private GameObject celestialObject;
    [SerializeField]
    private GameObject star;

    [SerializeField] float starRadious;

    //Materiales to asign to planets depending of their proximity to the star/ size / composition/ etc
    [SerializeField]
    private Material hotPlanet;
    [SerializeField]
    private Material waterPlanet;
    [SerializeField]
    private Material gasPlanet;
    [SerializeField]
    private Material frozenPlanet;

    //Number of planets and stars that we want in our system
    [SerializeField]
    private int N_Planets;
    [SerializeField]
    private int N_stars;

    //Distances and sizes of the planets.
    //Distances counting from point (0,0,0) the main star
    //Each of this arrays is in order. Meaning, first distances, first radious and first mass all correspond to the first planet
    [SerializeField]
    private Vector3[] planet_Distances;
    [SerializeField]
    private float[] planet_Radious;
    [SerializeField]
    private float[] planet_Masses;

    /// <summary>
    /// Information of satelites for each planet
    /// </summary>
    [SerializeField]
    private int[] satelites;
    [SerializeField]
    private int[] satelites_Distances;
    [SerializeField]
    private float[] satelites_Rads;
    [SerializeField]
    private float[] satelites_Masses;


    //Mininum habitable distance with Sun  = 1200 (Unity units)
    //Maximum distance with Sun = 2000(Unity units)
    //Sun size 696(Unity units)
    private const float Sun_max_hab_distance = 2000;
    private const float Sun_min_hab_distance = 1200;
    private const float sun_Radious = 696;

    public void generate()
    {
        checkArraySizes();

        generateStars();

        generatePlanets();
    }

    private void generatePlanets()
    {
        int last_index = 0; //Tracks the satelite information
        //Generate planets
        for (int i = 0; i < N_Planets; i++)
        {
            //Instantiate and report the identety
            GameObject g = Instantiate(celestialObject, planet_Distances[i], Quaternion.identity);
            g.GetComponent<celestial>().report();

            //Change radioues according to user input
            float planetRad = planet_Radious[i];
            g.transform.localScale = new Vector3(planetRad, planetRad, planetRad);

            //Change mass according to user input
            g.GetComponent<Rigidbody>().mass = planet_Masses[i];


            setMaterials(i, g);

            //Generation of satelites
            last_index = generateSatelites(last_index, i, g);
        }
    }

    private int generateSatelites(int last_index, int i, GameObject g)
    {
        int n_satelites = satelites[i];

        int[] positions = new int[n_satelites];
        float[] masses = new float[n_satelites];
        float[] rads = new float[n_satelites];

        int p;
        for (p = 0; p < n_satelites; p++)
        {
            positions[p] = satelites_Distances[last_index + p];
            masses[p] = satelites_Masses[last_index + p];
            rads[p] = satelites_Rads[last_index + p];

        }
        last_index += p;

        Satelite_Generator sat_Gen = g.GetComponent<Satelite_Generator>();

        sat_Gen.satelites = n_satelites;
        sat_Gen.satelites_Dist = positions;
        sat_Gen.satelites_Masses = masses;
        sat_Gen.satelites_Rads = rads;

        sat_Gen.Generate();
        return last_index;
    }

    private void setMaterials(int i, GameObject g)
    {
        //calculated in base of our sun
        float minDist = (starRadious * Sun_min_hab_distance) / sun_Radious;
        float maxDist = (starRadious * Sun_max_hab_distance) / sun_Radious;

        float planetDist = planet_Distances[i].x;
        //Is closer to star
        if (planetDist < minDist) g.GetComponent<Renderer>().material = hotPlanet;
        //Far, but not far enough to be frozen
        else if (planetDist > maxDist && planetDist < maxDist * 2) g.GetComponent<Renderer>().material = gasPlanet;
        //Frozen
        else if (planetDist >= maxDist * 2) g.GetComponent<Renderer>().material = frozenPlanet;
        //Habitable planet
        else if (planetDist > minDist && planetDist < maxDist) g.GetComponent<Renderer>().material = waterPlanet;
    }

    private void generateStars()
    {
        //Generate stars
        for (int i = 0; i < N_stars; i++)
        {
            GameObject g = Instantiate(star, new Vector3(0, 0, 0), Quaternion.identity);
            g.transform.localScale = new Vector3(starRadious, starRadious, starRadious);
            g.GetComponent<celestial>().report();
        }
    }

    private void checkArraySizes()
    {
        if (planet_Distances.Length != N_Planets)
        {
            Debug.LogError("Number of distances must be the same as number of planets");
            Debug.Break();
        }

        if (planet_Radious.Length != N_Planets)
        {
            Debug.LogError("Number of radious must be the same as number of planets");
            Debug.Break();
        }

        if (planet_Masses.Length != N_Planets)
        {
            Debug.LogError("Number of masses must be the same as number of planets");
            Debug.Break();
        }
    }

}
