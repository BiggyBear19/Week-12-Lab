using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IventoryManager : MonoBehaviour
{
    public List<InventoryItem> iventory = new List<InventoryItem>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InventoryItem item1 = gameObject.AddComponent<InventoryItem>();
        item1.name = "Swain";
        item1.value = 3;
        item1.ID = 12345;
        iventory.Add(item1);
        
        InventoryItem item2 = gameObject.AddComponent<InventoryItem>();
        item2.name = "Ekko";
        item2.value = 5;
        item2.ID = 4321;
        iventory.Add(item2);
        
        InventoryItem item3 = gameObject.AddComponent<InventoryItem>();
        item3.name = "Hwei";
        item3.value = 9;
        item3.ID = 333;
        iventory.Add(item3);
        
        InventoryItem item4 = gameObject.AddComponent<InventoryItem>();
        item4.name = "Jhin";
        item4.value = 3;
        item4.ID = 4444;
        iventory.Add(item4);
        
        InventoryItem item5 = gameObject.AddComponent<InventoryItem>();
        item5.name = "Flub";
        item5.value = 7;
        item5.ID = 777;
        iventory.Add(item5);
        
        InventoryItem item6 = gameObject.AddComponent<InventoryItem>();
        item6.name = "IDC";
        item6.value = 0;
        item6.ID = 01010;
        iventory.Add(item6);
        
        InventoryItem item7 = gameObject.AddComponent<InventoryItem>();
        item7.name = "Sword";
        item7.value = 1;
        item7.ID = 11111;
        iventory.Add(item7);
        
        InventoryItem item8 = gameObject.AddComponent<InventoryItem>();
        item8.name = "fire";
        item8.value = 8;
        item8.ID = 55555;
        iventory.Add(item8);
        
        QuickSort(iventory.ToArray(), 0, iventory.Count() - 1);

        foreach (InventoryItem item in iventory)
        {
            Console.WriteLine(item.value);
        }

        string test1 = LinearSearchByName("Ekko");
        
        Console.Write(test1);

        int test2 = BinarySearchByID(iventory, 4321);
        
        Console.Write(test2);
        

    }

    // Update is called once per frame
    public string LinearSearchByName(string itemname)
    {
        foreach (InventoryItem item in iventory)
        {
            if (item.name == itemname)
            {
                return itemname;
            }
        }

        return null;
    }

    

    public int BinarySearchByID(List<InventoryItem> list, int desiredID)
    {
        List<InventoryItem> sortedlist = new List<InventoryItem>(list.OrderBy(x => x.ID));
        InventoryItem[] searchArray = list.ToArray();

        int low = 0;

        int high = sortedlist.Count - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;


            if (searchArray[mid].ID == desiredID)
            {
                return searchArray[mid].ID;
            }
            
            if (searchArray[mid].ID > desiredID)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }

            
        }
        
        return -1;

    }

    static int partition(InventoryItem[] inventory, int low, int high)
    {
        InventoryItem pivot = inventory[high];

        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (inventory[j].value < pivot.value)
            {
                i++;
                swap(inventory, i, j);
            }
        }
        
        swap(inventory, i+1, high);
        return i + 1;
    }

    static void swap(InventoryItem[] inventory, int i, int j)
    {
        InventoryItem temp = inventory[i];
        inventory[i] = inventory[j];
        inventory[j] = temp;
        
    }

    static void QuickSort(InventoryItem[] inventory, int low, int high)
    {
        if(low < high)
        {
            int pi = partition(inventory, low, high);
            
            
            QuickSort(inventory, low, pi- 1);
            QuickSort(inventory, pi + 1, high);
        }
        
        
    }
}
