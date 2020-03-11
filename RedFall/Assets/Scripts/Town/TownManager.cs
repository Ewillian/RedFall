using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using Assets.Scripts.Town.constants;

public class TownManager : MonoBehaviour
{
    private const int NUMBER_OF_BUILDINGS = 4;

    private GameObject[] panels;
    private GameObject townBackground;
    private Sprite[] backgrounds;
    private int index = 0;

    private void Awake()
    {
        this.backgrounds = new Sprite[NUMBER_OF_BUILDINGS] {
            Resources.Load<Sprite>("town/guilde"),
            Resources.Load<Sprite>("town/inn"),
            Resources.Load<Sprite>("town/shop"),
            Resources.Load<Sprite>("town/blacksmith")
        };
    }

    void Start()
    {
        this.townBackground = GameObject.Find("TownBackground");
        this.panels = new GameObject[NUMBER_OF_BUILDINGS]
        {
            GameObject.Find("GuildPanel"),
            GameObject.Find("InnPanel"),
            GameObject.Find("ShopPanel"),
            GameObject.Find("BlackSmithPanel")
        };
        quitPanel();
        showCurrentBackgroundSelection();
    }

    void Update()
    {
        bool isPanelActive = Array.Exists(this.panels, panel => panel.activeSelf == true);
        bool isSelectionGreaterThanZero = this.index > 0;
        bool isSelectionLesserThanNumberOfBuildings = this.index < NUMBER_OF_BUILDINGS - 1;
        
        
        if (Input.GetKeyUp(KeyCode.RightArrow) && !isPanelActive && isSelectionLesserThanNumberOfBuildings)
        {
            this.index++;
            showCurrentBackgroundSelection();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !isPanelActive && isSelectionGreaterThanZero)
        {
            this.index--;
            showCurrentBackgroundSelection();
        }
        if (Input.GetKeyUp(KeyCode.Return) && !isPanelActive)
        {
            openPanel();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPanelActive)
        {
            quitPanel();
        }
    }

    public void showCurrentBackgroundSelection()
    {
        this.townBackground.GetComponent<SpriteRenderer>().sprite = this.backgrounds[this.index];
    }

    public void quitPanel()
    {
        foreach(GameObject panel in this.panels)
        {
            panel.SetActive(false);
        }
    }

    public void openPanel()
    {
        this.panels[this.index].SetActive(true);
    }
}
