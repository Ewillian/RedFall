using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    int index;
    bool isSidePanelActive = false;
    public bool selectingAnAction = false;
    public Actions action;

    GameObject[] arrows, panels;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        arrows = GameObject.FindGameObjectsWithTag("Flourish");
        panels = GameObject.FindGameObjectsWithTag("Panel");

        showArrowSelector(true);

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

    }

    public void resetSelection()
    {
        index = 0;
    }



    public void showArrowSelector(bool active)
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }

        if (active)
        {
            if (this.index == 4)
            {
                this.index = 0;
            }
            if (this.index == -1)
            {
                this.index = 3;
            }
             ((GameObject)arrows.GetValue(index)).SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectingAnAction) { 
            if (!isSidePanelActive)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    index++;
                    showArrowSelector(true);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    index--;
                    showArrowSelector(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
            
                if (index == 0)
                {
                    action = Actions.ATTACK;
                    selectingAnAction = false;
                    resetSelection();
                }
                else if (index == 3)
                {
                    Debug.Log("Vous partez en courant");
                }else
                {
                    isSidePanelActive = true;
                    showArrowSelector(false);
                    ((GameObject)panels.GetValue(index - 1)).SetActive(true);
                }
            
            }
            if (isSidePanelActive)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    isSidePanelActive = false;

                   foreach (GameObject panel in panels)
                    {
                        panel.SetActive(false);
                    }

                   ((GameObject)arrows.GetValue(index)).SetActive(true);
                }
            }
        }
    }
}
