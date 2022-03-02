using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1500;
    public float directionalSpeed = 20;


    void Update()
    {
        //editor and debugging controls
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

        float moveHorizontal = Input.GetAxis("Horizontal");

        //allows us to move and clamps us in between two values (-2.5 2.5)
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z), directionalSpeed * Time.deltaTime);
        

#endif

        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;

        //Mobile controls

        //gets where we touch on screen and stores it in variable touch
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));

        //if player is touching we move ball in that direction
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }
}
