using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_data : MonoBehaviour {

	public int item_cost;
	public GameObject AppManager;

	void Start()
	{
		AppManager = GameObject.Find("AppManager");
	}

	public void Delet_item()
	{
		Destroy(gameObject);
		AppManager.GetComponent<Order_manager>().UpdateUI(0, "", -item_cost, 0);

	}

	public void die()
	{
		Destroy (gameObject);
	}
}