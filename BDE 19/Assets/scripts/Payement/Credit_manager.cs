using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public static class Credit_manager{

	public static GameObject Camera_scan;
	public static GameObject New_user_panel;
	public static User_H current_user;
	public static User_data data;

	public static void Load_data()
	{
        QRCode.Scan_card();
	}

	public static void Credit_charge(int id_card)
	{
		current_user = new User_H();
		data = new User_data();
		data = DataManager.LoadSystem();
		//data.data_list.Add(new User_H {name = "nbouchez", credit = 250, status = 1});
        Debug.Log(id_card);
        foreach (User_H user in data.data_list)
        {
            if(user.id == id_card)
            {
            	current_user.id = id_card;
            	current_user.name = user.name;
            	current_user.credit = user.credit;
            	current_user.status = user.status;
            }
        }
        if(current_user.name == "")
        {
        	New_user_panel.gameObject.SetActive(true);
        }
    	MAJ_UI(current_user);
		MakeTransaction(data, current_user);
	}

	public static void MAJ_UI(User_H current_user)
	{
		GameObject Credit_left;
		GameObject Sub_total;
		GameObject Final_credit;

		GameObject Holder_card_name;
		GameObject User_img;
		GameObject Validation_btn;

		GameObject.Find("User_img").GetComponent<RawImage>().texture = LoadPNG(Application.dataPath + "/Resources/student/" + current_user.name + ".jpg");

		Credit_left = GameObject.Find("Credit_left");
		Sub_total = GameObject.Find("Prix");
		Final_credit = GameObject.Find("Next_sold");

		Holder_card_name = GameObject.Find("holder_card_name");
		//User_img = GameObject.Find("User_img");
		Camera_scan = GameObject.Find("Camera_scan");
		Validation_btn = GameObject.Find("Validation_btn");

		Camera_scan.gameObject.SetActive(false);
		Validation_btn.gameObject.GetComponent<Button>().interactable = true;

		Credit_left.GetComponent<UnityEngine.UI.Text>().text = "Solde actuel : " + string.Format("{0:#.00}", Convert.ToDecimal(current_user.credit.ToString()) / 100) + " €";
		Sub_total.GetComponent<UnityEngine.UI.Text>().text = "Prix : " + string.Format("{0:#.00}", Convert.ToDecimal(DataManager.sub_total.ToString()) / 100) + " €";
		Final_credit.GetComponent<UnityEngine.UI.Text>().text = "Solde restant : " + string.Format("{0:#.00}", Convert.ToDecimal((current_user.credit - DataManager.sub_total).ToString()) / 100) + " €";
		
		Holder_card_name.GetComponent<UnityEngine.UI.Text>().text = current_user.name.ToString();
		Debug.Log("Holder - Id : " + current_user.id);
		Debug.Log("Holder - Name : " + current_user.name);
		Debug.Log("Holder - Credit : " + current_user.credit);
		Debug.Log("Holder - Status : " + current_user.status);
    }

    public static void MakeTransaction(User_data data, User_H current_user)
    {
    	current_user.credit -= DataManager.sub_total;
    	//current_user.name = "";
    	data.data_list.RemoveAt(current_user.id - 1);
    	data.data_list.Insert(current_user.id - 1, current_user);
    	DataManager.MakeSave(data);
    }
    public static void SetNewName(string name)
    {
    	current_user.name = name;
    	data.data_list.RemoveAt(current_user.id - 1);
    	data.data_list.Insert(current_user.id - 1, current_user);
    	MakeTransaction(data, current_user);
    	DataManager.MakeSave(data);
    }

	public static Texture2D LoadPNG(string filePath) {

	Texture2D tex = null;
	byte[] fileData;
	Debug.Log(filePath);
	if (File.Exists(filePath))
	{
		fileData = File.ReadAllBytes(filePath);
		tex = new Texture2D(2, 2);
		tex.LoadImage(fileData);
	}
	else
	{
		//No img found !
	}
	return tex;
 }
}
