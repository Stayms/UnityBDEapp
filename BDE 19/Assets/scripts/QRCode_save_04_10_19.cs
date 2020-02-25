using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using System;
using UnityEngine.UI;

public class QRCode_ : MonoBehaviour {

	private WebCamTexture webcamTexture;
	public RawImage rawimage;
	private User_H user;

	void Start() {
		user = new User_H ();
		//Set the camera
		webcamTexture = new WebCamTexture();
		rawimage.texture = webcamTexture;
		webcamTexture.requestedHeight = (int)321.97;
  		webcamTexture.requestedWidth = (int)193.73;
		if (webcamTexture != null) {
			webcamTexture.Play();
		}
		StartCoroutine(CoroutineSearchForQR());
	}

	void Update()
	{
	}

	string SearchForQR()
	{
	  try {
	  	IBarcodeReader barcodeReader = new BarcodeReader ();
	    // decode the current frame
	    var result = barcodeReader.Decode(webcamTexture.GetPixels32(), webcamTexture.width, webcamTexture.height);
	    if (result != null) {
	    	return (result.Text);
	    }
	  }catch(Exception ex) 
	  { 
	  	Debug.LogWarning (ex.Message);
	  }
	  return "";
	}

	IEnumerator CoroutineSearchForQR()
	{
		string response = "";
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
					response = result.Text;
				}
			}catch(Exception ex) 
			{ 
			  Debug.LogWarning (ex.Message);
			}
			yield return null;
		}while(response == "");
		user.name = response;
		Debug.Log("User found :" + user.name);
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

	public Texture2D generateQR(string text) {
		var encoded = new Texture2D (256, 256);
		var color32 = Encode(text, encoded.width, encoded.height);
		encoded.SetPixels32(color32);
		encoded.Apply();
		return encoded;
	}

	void Display_QRCode()
	{
		Texture2D myQR = generateQR("nbouchez");
		if (GUI.Button (new Rect (0	, 0, 256, 256), myQR, GUIStyle.none)) {}
	}
}
