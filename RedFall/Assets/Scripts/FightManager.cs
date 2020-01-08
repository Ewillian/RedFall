using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FightManager : MonoBehaviour
{
    public bool startFight = true;
    public Team teamAlly, teamEnemy;
    public Character[] characters;
    public Selection selectionScript;
    public Target targetScript;
    public Character currentCharacter;
    bool isturnOver = false;

    // Start is called before the first frame update
    void Start()
    {
        selectionScript = GameObject.Find("Choice panel").GetComponent<Selection>();
        targetScript = GameObject.Find("Charcters").GetComponent<Target>();
        
        Character p1 = new PlayerLogic("babtou 0", Class.Priest , 10 , 10);
        Character p2 = new PlayerLogic("babtou 1", Class.Priest , 10 , 10);
        Character p3 = new PlayerLogic("babtou 2", Class.Priest , 10 , 10);
        Character p4 = new PlayerLogic("babtou 3", Class.Priest , 10 , 10);
        Character p5 = new PlayerLogic("méchant 1", Class.Archer, 10 , 10);
        Character p6 = new PlayerLogic("méchant 2", Class.Thief, 10, 10);
        Character p7 = new PlayerLogic("méchant 3", Class.Thief, 10, 10);
        Character p8 = new PlayerLogic("méchant 4", Class.Thief, 10, 10);
        
        teamAlly = new Team();
        teamEnemy = new Team();
     
        teamAlly.AddMember(p1);
        teamAlly.AddMember(p2);
        teamEnemy.AddMember(p5);
        teamEnemy.AddMember(p6);
        teamEnemy.AddMember(p7);

        targetScript.enemies = teamEnemy;
        hideMissingCharacters();

        currentCharacter = p1;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isturnOver)
        {
            bool isActionDefined = selectionScript.action != Actions.NONE;
            if (!targetScript.selectingATarget && !isActionDefined || targetScript.cancelSelection)
            {
                startActionSelection();
            }
            if (!selectionScript.selectingAnAction && targetScript.target == null && !targetScript.cancelSelection)
            {
                startTargetSelection();
            }
            if (!targetScript.selectingATarget && !selectionScript.selectingAnAction && isActionDefined && targetScript.target != null)
            {
                switch (selectionScript.action)
                {
                    case Actions.ATTACK:
                        Debug.Log(targetScript.target);
                        currentCharacter.basicAttack(targetScript.target);
                        Debug.Log(targetScript.target);
                        break;
                    default:
                        Debug.Log("ERROR ACTION");
                        break;
                }
                isturnOver = true;
            }
        } 
    }

    void startTargetSelection()
    {
        targetScript.cancelSelection = false;
        targetScript.selectingATarget = true;
        targetScript.showTargetSelection();
    }
    
    void startActionSelection()
    {
        selectionScript.selectingAnAction = true;
        targetScript.cancelSelection = false;
    }

    void hideMissingCharacters()
    {
        for(int i = teamEnemy.Count +1 ; i < Team.MAX_SIZE + 1 ; i++)
        {
            GameObject enemyOnScreen = GameObject.Find("Enemy" + i);
            enemyOnScreen.SetActive(false);
        }
        for (int i = teamAlly.Count + 1; i < Team.MAX_SIZE + 1; i++)
        {
            GameObject allyOnScreen = GameObject.Find("Ally" + i);
            allyOnScreen.SetActive(false);
        }
    }
}
 