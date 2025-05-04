using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Inscribed")]
    public int speed;

    public GameObject PlayerObject;
    private GameObject playerGO;
    
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (hAxis > 0){
            playerGO.transform.eulerAngles = new Vector3(-105,0,180);
        } else if (hAxis < 0){
            playerGO.transform.eulerAngles = new Vector3(75,0,0);
        }

        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.z += vAxis * speed * Time.deltaTime;
        transform.position = pos;
    }

    void Start(){
        playerGO = Instantiate(PlayerObject, transform.GetChild(1).position, transform.GetChild(1).rotation);
        playerGO.transform.parent = transform;
    }
}
