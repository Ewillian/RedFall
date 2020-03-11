using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public List<Sprite> itemList;

    public GameObject[] rows;

    // Start is called before the first frame update
    void Start()
    {
        itemList = new List<Sprite>();
        itemList.Add(Resources.Load<Sprite>("sword"));
        itemList.Add(Resources.Load<Sprite>("shield"));
        int i = 0;
        foreach (Transform rowT in this.transform)
        {
            GameObject row = rowT.gameObject;
            foreach (Transform itemT in row.transform)
            {
                GameObject item = itemT.gameObject;
                if (i < itemList.Count)
                {
                    item.GetComponent<Image>().sprite = itemList[i];
                    i += 1;
                }
            }
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
