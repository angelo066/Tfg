using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Satelites : MonoBehaviour
{
    [SerializeField]
    private int satelites;
    [SerializeField]
    private int[] satelites_Distances;
    [SerializeField]
    private int[] satelites_Rads;
    [SerializeField]
    private int[] satelites_Masses;
    [SerializeField]
    private GameObject moon;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < satelites; i++)
        {
            GameObject s = Instantiate(moon, new Vector3(satelites_Distances[i], 0, 0), Quaternion.identity);

            s.transform.localScale = new Vector3(satelites_Rads[i], satelites_Rads[i], satelites_Rads[i]);

            gameObject.GetComponent<Rigidbody>().mass = satelites_Masses[i];
        }
    }

}
