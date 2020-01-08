using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerLogic _this;
    public float walkSpeed = 5.0f;
    public FightManager fightManager;

    // Start is called before the first frame update
    void Start()
    {
        fightManager = GameObject.Find("Fightmanager").GetComponent<FightManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = movement();
        if (Input.GetKey(KeyCode.Return))
        {
            fightManager.startFight = true;
            Debug.Log(fightManager.startFight);
            Team team2 = new Team();
            team2.AddMember(new NonPlayerLogic("Patrick", Class.Wizard));
            team2.AddMember(new NonPlayerLogic("Patrick", Class.Wizard));
            //fightManager.initializeFight(_this.team , team2);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            fightManager.startFight = false;
            Debug.Log(fightManager.startFight);
        }
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
