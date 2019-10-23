using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCheckers : MonoBehaviour {
    public BirdDeath BirdJ1;
    public BirdDeath BirdJ2;
    public BirdDeath BirdJ3;
    public BirdDeath BirdJ4;

    public Text Sign;

    void Update() {
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
            Sign.text = "3 Birds Remaining";
        else if (Counter == 2)
            Sign.text = "2 Birds Remaining";
        else if (Counter == 3)
            Sign.text = "Only 1 Bird Remaining";
        else if (Counter == 4)
            Sign.text = "Thanos was Inevitable";
    }
}
