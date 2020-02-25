using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public static class Custom_value {

	public static GameObject value_panel;
	public static int custom_value;

	public static void Get_data_custom_value()
	{
		value_panel = GameObject.Find("Value_panel");
	}

	public static int Get_custom_value()
	{
		GameObject Value_custom_txt = GameObject.Find("Value_custom_txt");
		return System.Convert.ToInt32(Convert.ToDecimal(Value_custom_txt.GetComponent<UnityEngine.UI.Text>().text) * 100);
	}

	public static void Enabled_UI()
	{
		value_panel.gameObject.SetActive(true);
	}

	public static void Disabled_UI()
	{
		value_panel.gameObject.SetActive(false);
	}
}
