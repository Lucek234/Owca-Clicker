using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumScript : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float TimeA;
    public float TimeB;
    public float TimeC;
    public GameObject Egg;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (TimeA == 0) TimeA = 0.01f;
        if (TimeB == 0) TimeB = 0.01f;
        if (TimeC == 0) TimeC = 0.01f;
    }

    public bool isActive = false;
    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        time += Time.deltaTime;

        if (time < TimeA)
        {
            gameObject.transform.localPosition = StartPosition + (EndPosition-StartPosition)*(time / TimeA);
        }
        else if (time < TimeA + TimeB)
        {
            Destroy(Egg);
        }
        else if (time < TimeA + TimeB + TimeC)
        {
            gameObject.transform.localPosition =
                EndPosition + (StartPosition - EndPosition) * (time - TimeA - TimeB) / TimeC;
        }
    }

    public void RunVacuum(GameObject egg)
    {
        isActive = true;
        time = 0;
        Egg = egg;
    }
}
