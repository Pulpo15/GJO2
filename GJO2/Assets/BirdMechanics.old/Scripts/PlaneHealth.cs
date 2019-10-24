using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealth : MonoBehaviour
{
    float PlaneHeal = 5f;
    public GameObject HPBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.position = new Vector3(gameObject.transform.position.x -2.5f, gameObject.transform.position.y +1.5f);
        HPBar.transform.localScale = new Vector3(PlaneHeal+0.2f, 0.5f, 1);
            //Debug.Log(PlaneHeal);
        if (PlaneHeal <= 0){
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "J1Bullet(Clone)")
        {
            PlaneHeal -= 0.2f;
        }
        if (collider.gameObject.name == "J2Bullet(Clone)")
        {
            PlaneHeal -= 0.2f;
        }
        if (collider.gameObject.name == "J3Bullet(Clone)")
        {
            PlaneHeal -= 0.2f;
        }
        if (collider.gameObject.name == "J4Bullet(Clone)")
        {
            PlaneHeal -= 0.2f;
        }
    }
}
