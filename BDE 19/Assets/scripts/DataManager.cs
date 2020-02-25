using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class DataManager {

	public static List<item_H> order_data;
	public static int sub_total;

	public static void MakeSave(User_data data)
	{
		Debug.Log("Save...");
		SaveSystem(data);
		Debug.Log("--- Save OK ---");
		foreach (User_H user in data.data_list)
        {
            Debug.Log("ID : " + user.id + " - Name : " + user.name + " - Credit : " + user.credit);
        }
        Debug.Log("---         ---");
	}

	public static void SaveSystem(User_data user_data)
	{
		//Debug.Log(user_data.all[0].name);
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/data.bde";
		FileStream stream = new FileStream(path, FileMode.Create);

		//User_data user_data = new User_data();

		formatter.Serialize(stream, user_data);
		stream.Close();
	}

	public static User_data LoadSystem()
	{
		string path = Application.persistentDataPath + "/data.bde";
		Debug.Log(path);
		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			User_data user_data = formatter.Deserialize(stream) as User_data;
			stream.Close();

			return user_data;
		}
		else
		{
			Generate_user_data();
			Debug.LogWarning("Save file not found in " + path);
			Debug.LogWarning("Creating new file - Recursive");

			return LoadSystem();
		}
	}

	public static void Generate_user_data()
	{
		User_data user_data = new User_data();
		for(int i = 1; i < 401; i++)
		{
			user_data.data_list.Add(new User_H { id = i, name = "", credit = 0 , status = 0});
			
			/* Generate QR Code */
			/*
			Texture2D tex = QRCode.generateQR(i.ToString());
			byte[] bytes = tex.EncodeToPNG();
			//Object.Destroy(tex);
			File.WriteAllBytes(Application.dataPath + "/" + i + ".png", bytes);
			*/
		}

		//Debug log

		foreach (User_H user in user_data.data_list)
        {
			Debug.Log(user.name + user.id);
        }
        SaveSystem(user_data);
	}
}
