using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private float walkSpeed = 5.0f;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.position = gameObject.transform.position;

        if (Input.GetKey(KeyCode.UpArrow)) {
            this.position.y += walkSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.position.y += walkSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.position.y += walkSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.position.y += walkSpeed * Time.deltaTime;
        }

        gameObject.transform.position = this.position;
    }
}
