using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Clase encargada de llevar a cabo la f�sica entre los cuerpos de un sistema solar
/// </summary>
public class SolarSystem_Physics : MonoBehaviour
{
    public static SolarSystem_Physics instance;

    //Physics
    const float G = 100f; //Gravitational constant

    //Array de cuerpos
    const int max_Bodies = 100;
    int N_celestials = 0;
    GameObject[] celestials = new GameObject[max_Bodies];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //We generate the system in order to star physics with it
        GetComponent<System_Generator>().generate();

        InitialVelocity(); //Si es solo en el start pues no da problema
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        Gravity();

    }

    //M�todos f�sicos

    //Atracci�n entre cuerpos
    private void Gravity()
    {
        for (int i = 0; i < N_celestials; i++)
        {
            for (int j = 0; j < N_celestials; j++)
            {
                GameObject a = celestials[i];
                GameObject b = celestials[j];
                if (a != b)
                {
                    float mass1 = a.GetComponent<Rigidbody>().mass;
                    float mass2 = b.GetComponent<Rigidbody>().mass;

                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    //F�rmula de la fuerza gravitatoria
                    Vector3 grav = (b.transform.position - a.transform.position).normalized * (G * (mass1 * mass2) / (r * r));
                    a.GetComponent<Rigidbody>().AddForce(grav);
                }
            }
        }
    }

    //Rotation between bodies
    void InitialVelocity()
    {
        for (int i = 0; i < N_celestials; i++)
        {
            for (int j = 0; j < N_celestials; j++)
            {
                GameObject a = celestials[i];
                GameObject b = celestials[j];
                if (a != b)
                {

                    float mass2 = b.GetComponent<Rigidbody>().mass;

                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform); //Esto es sospechoso, quiz�s haya que cambiarlo (Puede producir que no roten sobre si mismos los planetas)
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * mass2) / r);
                }
            }
        }
    }

    //Public methods

    //Celestial bodies report their existence
    public void reportCelestial(GameObject c)
    {
        celestials[N_celestials] = c;
        N_celestials++;
    }
}
