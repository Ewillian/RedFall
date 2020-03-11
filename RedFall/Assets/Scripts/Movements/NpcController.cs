using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NpcController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 dir;
    public float turnSpeed;
    float targetAngle;
    Vector3 currentPos;
    bool play = true;
    Vector3 direction;

    private bool mobIsFighting = false;
    private float timeToDestroy = 0;

    void Start()
    {
        dir = Vector3.up;
        InvokeRepeating("Start1", 0f, 5f);
    }
    void Start1()
    {
        play = true;
        direction = (Vector3)Random.insideUnitCircle;
    }
    void Update()
    {
        currentPos = transform.position;//current position of gameObject
        if (play)
        { //calculating direction
            dir = direction;
            dir.Normalize();
            play = false;
        }
        Vector3 target = dir * moveSpeed + currentPos;  //calculating target position
        transform.position = Vector3.Lerp(currentPos, target, Time.deltaTime);//movement from current position to target position
        targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; //angle of rotation of gameobject
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime); //rotation from current direction to target direction

        if (this.timeToDestroy > 0)
        {
            timeToDestroy -= Time.deltaTime;
            Debug.Log(timeToDestroy);
            if (this.timeToDestroy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        CancelInvoke();//stop call to start1 method
        direction = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-4.0f, 4.0f), 0); //again provide random position in x and y
        play = true;
        if (col.gameObject.tag == "Player")
        {
            mobIsFighting = true;
            if (mobIsFighting == true) { 
                moveSpeed = 0;
            }
            this.timeToDestroy = 1.25f;
            mobIsFighting = false;
        }

    }
    void OnCollisionExit2D()
    {
        InvokeRepeating("Start1", 2f, 5f);
    }
}