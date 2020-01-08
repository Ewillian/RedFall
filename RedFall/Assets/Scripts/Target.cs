using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    GameObject[] enemySelection, allySelection;

    public bool selectingATarget = false;
    int index = 0;
    public Team allies, enemies;
    public Character target ;
    public bool cancelSelection = false;
    // Start is called before the first frame update
    void Start()
    {
        enemySelection = GameObject.FindGameObjectsWithTag("TriangleEnemy");
        allySelection = GameObject.FindGameObjectsWithTag("TriangleAlly");
    }

    public void showTargetSelection()
    {
        unselectAll();
        enemySelection[index].GetComponent<SpriteRenderer>().color = Color.green;
    }

    void unselectAll()
    {
        foreach (GameObject enemy in enemySelection)
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectingATarget)
        {
            int previousIndex = index;
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                int numberOfEnemies = this.enemies.Count;
                this.index = ++this.index >= numberOfEnemies ? numberOfEnemies - 1 : this.index;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.index = --this.index <= -1 ? 0 : this.index;
            }
            if (previousIndex != index)
            {
                showTargetSelection();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                target = enemies[index];
                selectingATarget = false;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                selectingATarget = false;
                cancelSelection = true;
                unselectAll();
            }
        }
    }
}
