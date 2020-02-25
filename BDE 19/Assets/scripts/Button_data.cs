using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_data : MonoBehaviour {

	public int item_id;
	public string item_name;
	public int item_cost;
	public GameObject AppManager;

	public void OnClick_btn()
	{
		AppManager.GetComponent<Order_manager>().UpdateUI(item_id, item_name, item_cost, 1);
	}
	public void OnDelet_btn()
	{
		AppManager.GetComponent<Order_manager>().UpdateUI(item_id, item_name, item_cost, 0);
	}
}
