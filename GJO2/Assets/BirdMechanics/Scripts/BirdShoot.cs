using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    public Rigidbody BulletPrefab;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 BulletPosition = new Vector3(Player.transform.position.x + 1.5f, Player.transform.position.y, Player.transform.position.z);

        if (Input.GetButtonDown("J1Shoot")) {
            Rigidbody Clone;
            Clone = Instantiate(BulletPrefab, BulletPosition, Quaternion.identity);
            Clone.velocity = new Vector3(-10, 0, 0);
        }


        if (Input.GetButtonDown("J1Horizontal")) {
            Debug.Log("Pressed");
        }
    }
}
