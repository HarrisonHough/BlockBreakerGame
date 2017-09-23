using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugControl : MonoBehaviour {

    public static UIDebugControl instance;

    [SerializeField]
    private Text debugText;
	// Use this for initialization
	void Awake () {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        if (instance == null)
        {
            instance = this;
        }
	}

    public void ClearDebugText()
    {

    }

    public void AddDebugText(string textToAdd)
    {
        debugText.text += "\n" + textToAdd;
    }
}
