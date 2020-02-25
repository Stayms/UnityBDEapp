using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using System;
using UnityEngine.UI;

public class QRCode : MonoBehaviour{

	private static WebCamTexture webcamTexture;
	public static RawImage rawimage;
	public static QRCode instance;

	void Awake()
	{
		instance = this;
		rawimage = GameObject.Find("Camera_scan").GetComponent<RawImage>();
	}

	public static void Scan_card()
	{
		//Set the camera
		webcamTexture = new WebCamTexture();
		rawimage.texture = webcamTexture;
		webcamTexture.requestedHeight = (int)556.5;
  		webcamTexture.requestedWidth = (int)334.9;
		if (webcamTexture != null) {
			webcamTexture.Play();
		}
		//Start search Coroutine
		instance.StartCoroutine(instance.CoroutineSearchForQR());
	}

	private IEnumerator CoroutineSearchForQR()
	{
		int user_id = -1;
		IBarcodeReader barcodeReader = new BarcodeReader ();
	    // decode the current frame
		do
		{
			//Debug.Log("Search for a QR code ...");
			try 
			{
				var result = barcodeReader.Decode(webcamTexture.GetPixels32(), webcamTexture.width, webcamTexture.height);
				if(result != null)
				{
					user_id = System.Convert.ToInt32(result.Text);
				}
			}catch(Exception ex)
			{ 
			  Debug.LogWarning (ex.Message);
			}
			yield return null;
		} while(user_id == -1);
		Debug.Log("FOUND" + user_id);
		Credit_manager.Credit_charge(user_id);
		yield return null;

	}

	private static Color32[] Encode(string textForEncoding, 
	  int width, int height) {
	  var writer = new BarcodeWriter {
	    Format = BarcodeFormat.QR_CODE,
	    Options = new QrCodeEncodingOptions {
	      Height = height,
	      Width = width
	    }
	  };
	  return writer.Write(textForEncoding);
	}

	public static Texture2D generateQR(string text) {
		var encoded = new Texture2D (256, 256);
		var color32 = Encode(text, encoded.width, encoded.height);
		encoded.SetPixels32(color32);
		encoded.Apply();
		return encoded;
	}

	static void Display_QRCode()
	{
		Texture2D myQR = generateQR("nbouchez");
		if (GUI.Button (new Rect (0	, 0, 256, 256), myQR, GUIStyle.none)) {}
	}
}
