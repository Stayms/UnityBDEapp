using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BackUp_data : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DateTime now = DateTime.Now;
		//Debug.Log(now.DayOfYear);
		string path = Application.persistentDataPath + "/data.bde";
		String path2 = Application.persistentDataPath + "/data_" + now.DayOfYear + ".bde";
		File.Copy(path, path2, true);
	}
}
