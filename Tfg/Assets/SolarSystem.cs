using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Clase encargada de llevar a cabo la física entre los cuerpos de un sistema solar
/// </summary>
public class SolarSystem : MonoBehaviour
{
    public static SolarSystem instance;

    //Variables físicas
    const float G = 100f; //Constante gravitacional

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
        InitialVelocity(); //Si es solo en el start pues no da problema
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        Gravity();

    }

    //Métodos físicos

    //Atracción entre cuerpos
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

                    //Fórmula de la fuerza gravitatoria
                    Vector3 grav = (b.transform.position - a.transform.position).normalized * (G * (mass1 * mass2) / (r * r));
                    a.GetComponent<Rigidbody>().AddForce(grav);
                }
            }
        }
    }

    //Rotación entre cuerpos
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
                    a.transform.LookAt(b.transform); //Esto es sospechoso, quizás haya que cambiarlo (Puede producir que no roten sobre si mismos los planetas)
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * mass2) / r);
                }
            }
        }
    }

    //Métodos publicos

    //Para que los cuerpos celestiales se apunten a la lista
    public void reportCelestial(GameObject c)
    {
        celestials[N_celestials] = c;
        N_celestials++;
    }
}
