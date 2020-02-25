using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_manager : MonoBehaviour {

	public GameObject Payement_state_panel;
	GameObject Validation_btn;
	public int charge_pay;
	public GameObject AppManager;

	void Start()
	{
		Credit_manager.New_user_panel = GameObject.Find("New_user_panel");
		Validation_btn = GameObject.Find("Validation_btn");
		Payement_state_panel = GameObject.Find("Payement_state");
		Payement_state_panel.gameObject.SetActive(false);
		Credit_manager.New_user_panel.gameObject.SetActive(false);
		charge_pay = 0;
	}


	public void Charge_btn()
	{
		Payement_state_panel.gameObject.SetActive(true);
		Validation_btn.gameObject.GetComponent<Button>().interactable = false;
		Credit_manager.Load_data();
		//QRCode.GetQRCode();
	}

	public void Close_scan_btn()
	{
		Reset_board.Close_scan();
	}

	public void Charge_card_btn()
	{
		charge_pay = 1;
		Custom_value.Enabled_UI();
	}

	public void Valide_card_btn()
	{
		int value = Custom_value.Get_custom_value();
		Custom_value.Disabled_UI();
		if(charge_pay == 1)
		{
			AppManager.GetComponent<Order_manager>().UpdateUI(0, "Chargement", -value, 1);
		}
		else
		{
			AppManager.GetComponent<Order_manager>().UpdateUI(9999, "Custom", value, 1);
		}
		Custom_value.custom_value = 0;
	}

	public void Custom_btn()
	{
		charge_pay = 0;
		Custom_value.Enabled_UI();
		Custom_value.custom_value = 0;
	}

	public void Close_custom_btn()
	{
		charge_pay = 1;
		Custom_value.Disabled_UI();
		Custom_value.custom_value = 0;
	}

	public void Valide_btn_new_user()
	{
		GameObject New_name_txt = GameObject.Find("New_name_txt");
		Credit_manager.SetNewName(New_name_txt.GetComponent<UnityEngine.UI.Text>().text);
		Credit_manager.New_user_panel.gameObject.SetActive(false);
	}
}
