using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celestial : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SolarSystem.instance.reportCelestial(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
