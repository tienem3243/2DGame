using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    /// <summary>Item on Display </summary>
    public List<Item> _items = new List<Item>();
    public List<int> _itemNumbers = new List<int>();
    public GameObject[] _slots;

    public static ItemManager _instance;

    private void Start()
    {
        _instance = this;
        DisplayItem();
    }

    public void DisplayItem()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            _slots[i].transform.GetChild(0).GetComponent<Image>().sprite = _items[i].itemSprite;

            _slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            _slots[i].transform.GetChild(1).GetComponent<Text>().text = _itemNumbers[i].ToString();

            _slots[i].transform.GetChild(2).gameObject.SetActive(true);

        }
    }

    public void addItem(Item item)
    {
        Debug.Log("Add item to your inventory : " + item.itemName);
        // Case 1: In time don't have in your inventory
        if (!_items.Contains(item))
        {
            _items.Add(item);
            _itemNumbers.Add(1);
        }
        // Case 2: Its already here 
        else
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].itemID == item.itemID)
                {
                    _itemNumbers[i]++;
                }
            }
        }

        // re display items
        DisplayItem();
    }

    public void removeItem(int pos)
    {
        Debug.Log("Item " + pos + " removed");
    }

}
