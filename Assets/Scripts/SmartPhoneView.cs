using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmartPhoneView : MonoBehaviour
{
	[SerializeField] private Text timeText;
	
	private DateTime now;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeText.text = DateTime.Now.ToString();
	}
}
