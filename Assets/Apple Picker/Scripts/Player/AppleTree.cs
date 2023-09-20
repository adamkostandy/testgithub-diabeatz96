using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour 
{


    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public float speed = 10f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;


    public Color[] colors = {Color.red, Color.green, Color.blue, Color.yellow};

    void Awake() {
        // yay learned how to get multiple different components across children!

        // Currently removing this for new assest I added
        /*
        Renderer[] colors = this.gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer color in colors) {
            color.material.color = this.colors[Random.Range(0, this.colors.Length)];
        }
        */
    }


    // Start is called before the first frame update
    void Start()
    {
     Invoke("DropApple", 2f); // Start dropping apples every second   
    }
       
    void DropApple() {
      GameObject apple = Instantiate<GameObject>(applePrefab);
      apple.transform.position = transform.position;
      Invoke("DropApple", appleDropDelay);
    }

    void FixedUpdate() {
      // Changing Direction Randomly is now time-based because of FixedUpdate()
      if (Random.value < changeDirChance) {
        speed *= -1; // Change direction
      }

    }


    // Update is called once per frame
    void Update() {
        /*
         *  The basic idea is to move the tree left and right, and drop apples
         */

        Vector3 pos = transform.position; // 1
        pos.x += speed * Time.deltaTime; // 2
        transform.position = pos; // 3


        // This is a simple way to make the tree turn around
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Move left
        }
    }
}
