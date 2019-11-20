using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerLogic _this;
    public float walkSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _this = new PlayerLogic(name: "Flo le boss");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = movement();
    }

    private Vector3 movement()
    {
        Vector3 position = gameObject.transform.position;

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                position.y += walkSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                position.y -= walkSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                position.x += walkSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                position.x -= walkSpeed * Time.deltaTime;
            }
        }
        
        return position;
    }
}
