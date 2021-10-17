using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var vacuum = GameObject.Find("Vacuum");
        vacuum.GetComponent<VacuumScript>().RunVacuum(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
