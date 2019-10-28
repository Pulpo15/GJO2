using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    public float afterHowLongTime;
    void Start()
    {
        Destroy(this.gameObject, afterHowLongTime);
    }
}
