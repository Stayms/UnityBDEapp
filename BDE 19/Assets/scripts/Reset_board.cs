using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Reset_board {

	public static GameObject ItemsParents;
	public static GameObject Payement_panell;
	public static GameObject sub_total_txt;

	public static void Close_scan()
	{
		//Clear all item
		ItemsParents = GameObject.Find("ItemsParents");
		sub_total_txt = GameObject.Find("Sub_total");
		foreach (Transform child in ItemsParents.transform)
		{
     		Item_data die_script = child.GetComponent<Item_data>();
     		die_script.die();
 		}
 		//Clear Sub_total
 		DataManager.sub_total = 0;
 		sub_total_txt.GetComponent<UnityEngine.UI.Text>().text = "";

 		//Clear user_data

 		//Clear user_img
 		GameObject.Find("User_img").GetComponent<RawImage>().texture = null;


 		//Disable panel
 		Credit_manager.Camera_scan.gameObject.SetActive(true);
 		Payement_panell = GameObject.Find("Payement_state");
		Payement_panell.gameObject.SetActive(false);
	}
}
