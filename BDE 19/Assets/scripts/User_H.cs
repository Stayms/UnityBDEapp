using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct item_H
{
	public int id;
	public string name;
	public int cost;
}

[System.Serializable]
public struct User_H
{
	public int id;
	public string name;
	public int credit;
	public int status;
}


[System.Serializable]
public class User_data{
	public List<User_H> data_list;

	public User_data ()
	{
		data_list = new List<User_H>();
	}
}

public class Order_data{
	public List<item_H> order;
}