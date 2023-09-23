using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celestial : MonoBehaviour
{
    //Bool only useful if we are testing creating planets by hand
    //Remove later probably
    bool reported = false;

    public void report()
    {
        SolarSystem.instance.reportCelestial(gameObject);
        reported = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!reported)SolarSystem.instance.reportCelestial(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
