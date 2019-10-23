using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCheckers : MonoBehaviour
{
    public BirdDeath BirdJ1;
    public BirdDeath BirdJ2;
    public BirdDeath BirdJ3;
    public BirdDeath BirdJ4;

    void Update()
    {
        int Counter = 0;

        if (BirdJ1.Dead) 
            Counter++;
        if (BirdJ2.Dead)
            Counter++;
        if (BirdJ3.Dead)
            Counter++;
        if (BirdJ4.Dead)
            Counter++;



        if (Counter == 1)
            Debug.Log("3 Birds Remaining");
        else if (Counter == 2)
            Debug.Log("2 Birds Remaining");
        else if (Counter == 3)
            Debug.Log("Only 1 Bird Remaining");
        else if (Counter == 4)
            Debug.Log("Thanos was Inevitable");
    }
}
