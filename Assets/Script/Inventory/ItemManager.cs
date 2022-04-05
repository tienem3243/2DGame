using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public static ItemManager instance;

    private void Start()
    {
        instance = this;
        DisplayItem();
    }

    public void DisplayItem()
    {
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            slots[i].transform.GetChild(2).gameObject.SetActive(true);

        }
    }

    public void addItem(Item item)
    {
        Debug.Log("Add item to your inventory : " + item.itemName);
    }

    public void removeItem(int pos)
    {
        Debug.Log("Item " + pos + " removed");
    }

}
