using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update

    /*
     *  Messing with mass to cmake it heavier and drop the apple faster
     */
    public static float bottomY = -20f;
    public float speed = 10f;
    public float leftEdge = 30f;
    public float rightEdge = -30f;


    void Start()
    {
        Debug.Log(this.gameObject.transform.position.x);

        float angle = UnityEngine.Random.Range(-90f, 90f);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) {

            float angleInRadians = angle * Mathf.Deg2Rad;

            if (GlobalData.getLevel() == 2) {
                Vector3 newDirection = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);
                Debug.Log("Angle: " + angle);
                Debug.Log("Angle in Radians: " + angleInRadians);
                rb.AddForce(newDirection * speed, ForceMode.VelocityChange);
            }

            if (GlobalData.getLevel() == 3) {
                Vector3 newDirection = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0);
                rb.AddForce(newDirection * speed * 2, ForceMode.VelocityChange);
            }
        Debug.Log("Level: " + GlobalData.getLevel());
        }

       
    }

    // Update is called once per frame
    void Update()
    {

        /*
         * if else to increase gravity of falling apples based on levels
         * using GlobalData.cs
         *     
         */

        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();
        }

        // check if apple is out of bounds

        if (transform.position.x > leftEdge) {
            Destroy(this.gameObject);
        }

        if (transform.position.x < rightEdge) {
            Destroy(this.gameObject);
        }
          
    }
}
