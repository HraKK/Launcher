using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	void OnGUI()
	{
		if(GUI.Button(new Rect(25, 25, 100, 20), "Exit"))
		{
			Application.Quit();
		}
	}
}
