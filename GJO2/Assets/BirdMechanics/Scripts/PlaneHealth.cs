using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHealth : MonoBehaviour
{
    /*float PlaneHeal = 5f;
    public GameObject HPBar;

    void Update()
    {
      /*  HPBar.transform.position = new Vector3(gameObject.transform.position.x -2.5f, gameObject.transform.position.y +1.5f);
        HPBar.transform.localScale = new Vector3(PlaneHeal+0.2f, 0.5f, 1);
            Debug.Log(PlaneHeal);
        if (PlaneHeal <= 0){
            gameObject.SetActive(false);
        }
    }*/

    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            PlaneHit();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaneHit();
        }
    }

    void PlaneHit()
    {
        //
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        mesh.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        mesh.material.color = Color.red;
    }
}
