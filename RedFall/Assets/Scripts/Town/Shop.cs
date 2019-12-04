using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int index;
    public List<Item> items;
    public bool isPanelActive;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        items = new List<Item>();
        items.Add(new Armor("Gants du babtou frileux", ArmorType.Hands, 1));
        items.Add(new Armor("Protege genoux du babtou ", ArmorType.Legs, 2));
        items.Add(new Armor("Bob du iencli", ArmorType.Head, 4));
        items.Add(new Armor("Sandalettes du germain", ArmorType.Feet, 10));

        // get GO and there sizes
        GameObject prefabShopItem = Resources.Load("ItemShop") as GameObject;
        RectTransform prefabRowRectTransform = prefabShopItem.GetComponent<RectTransform>();
        GameObject shopContent = GameObject.Find("ShopContent");
        RectTransform shopContentRectTransform = gameObject.GetComponent<RectTransform>();

        for (int i = 0; i < items.Count; i++)
        {
            // create prefab and assign in hierarchy
            GameObject shopItem = Instantiate(prefabShopItem, shopContent.transform, false);
            RectTransform shopItemRectTransform = shopItem.GetComponent<RectTransform>();

            GameObject shopItemText = shopItem.transform.Find("Name").gameObject;
            shopItemText.GetComponent<UnityEngine.UI.Text>().text = items[i].Name;


            // move and size the created prefab
            shopItemRectTransform.sizeDelta = new Vector2(200, 100);
            shopItemRectTransform.anchoredPosition = shopContentRectTransform.anchoredPosition + new Vector2(500, -90 * i);
        }

        isPanelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (items.Count >= 1 && isPanelActive)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                index++;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                index--;
            }
            index = index < 0 ? 0 : (index >= items.Count ? items.Count - 1 : index);
        }
    }
}
