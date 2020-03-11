using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "EntranceTP")
        {
            
            Vector3 temp = GameObject.FindGameObjectWithTag("1stRoomRightTP").transform.position;
            gameObject.transform.position = temp + new Vector3(-0.8f, 0.3f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "1stRoomRightTP")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("EntranceTP").transform.position;
            gameObject.transform.position = temp + new Vector3(0.8f, 0.3f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "2ndRoomTP")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("EntranceTP2").transform.position;
            gameObject.transform.position = temp + new Vector3(0, 1, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "EntranceTP2")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("2ndRoomTP").transform.position;
            gameObject.transform.position = temp + new Vector3(0, -0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "3rdRoomTP")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("2ndRoomTP2").transform.position;
            gameObject.transform.position = temp + new Vector3(0.8f, 0.3f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "2ndRoomTP2")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("3rdRoomTP").transform.position;
            gameObject.transform.position = temp + new Vector3(-0.8f, 0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "IsleRoom")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("3rdRoomTP2").transform.position;
            gameObject.transform.position = temp + new Vector3(-0.8f, 0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "3rdRoomTP2")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("IsleRoom").transform.position;
            gameObject.transform.position = temp + new Vector3(0.8f, 0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "Stairs")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("3rdRoomTP2-2").transform.position;
            gameObject.transform.position = temp + new Vector3(0.8f, 0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "3rdRoomTP2-2")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("Stairs").transform.position;
            gameObject.transform.position = temp + new Vector3(-0.8f, 0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "BossTP")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("Stairs2").transform.position;
            gameObject.transform.position = temp + new Vector3(0, 1, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
        else if (col.gameObject.tag == "Stairs2")
        {
            Vector3 temp = GameObject.FindGameObjectWithTag("BossTP").transform.position;
            gameObject.transform.position = temp + new Vector3(0, -0.2f, 0);
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = gameObject.transform.position + new Vector3(0, 0, -10);
        }
    }
}
