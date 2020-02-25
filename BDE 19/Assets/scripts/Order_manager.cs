using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Order_manager : MonoBehaviour {

	public GameObject parent_item;
	public GameObject sub_total_txt;
	public UnityEngine.Object prefab_items_order;
	// Use this for initialization
	void Start () {
		DataManager.sub_total = 0;
		DataManager.order_data = new List<item_H>();
		Custom_value.Get_data_custom_value();
		Custom_value.Disabled_UI();
	}

	public void UpdateUI(int item_id, string item_name, int item_cost, int operation)
	{
		//prefab_items_order = Resources.Load("prefabs/item");
		DataManager.sub_total += item_cost;
		if(DataManager.sub_total != 0)
			sub_total_txt.GetComponent<UnityEngine.UI.Text>().text = "SOUS TOTAL : " + string.Format("{0:#.00}", Convert.ToDecimal(DataManager.sub_total.ToString()) / 100) + " €";
		else
			sub_total_txt.GetComponent<UnityEngine.UI.Text>().text = "";
		Debug.Log(item_cost);
		
		if(operation == 1)
		{
			DataManager.order_data.Add(new item_H { id = item_id, name = item_name , cost = item_cost});
			GameObject newObject = Instantiate(prefab_items_order, parent_item.transform) as GameObject;
			newObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = item_name;
			newObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:#.00}", Convert.ToDecimal(item_cost.ToString()) / 100) + " €";
			newObject.GetComponent<Item_data>().item_cost = item_cost;
		}else
		{

		}
		//newObject.transform.GetChild(2).GetComponent<UnityEngine.UI.Text>().text = item_name;
		//DataManager.order_data.Add(new item_H { id = 1, name = "Panini" , cost = 250});
		foreach(item_H item in DataManager.order_data)
		{
			Debug.Log("ID : " + item.id + " - Price : " + item.cost + " -");
		}
		Debug.Log("Updating UI");

	}
}
