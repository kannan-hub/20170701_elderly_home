using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SmartPhoneView : MonoBehaviour
{
	private const float BatteryConsumeSeconds = 1.0f;

	[SerializeField] private Text timeText;
	[SerializeField] private Text batteryRateText;
	[SerializeField] private Image batteryRateImage;
	[SerializeField] private ReactiveProperty<float> batteryRate = new ReactiveProperty<float>(1.0f);
	
	private DateTime now;
	
	// Use this for initialization
	void Start ()
	{
		string todayTime = DateTime.Now.ToShortTimeString();
		timeText.text = todayTime;

		Observable.Interval(TimeSpan.FromMinutes(1))
			.Subscribe(_ =>
			{
				todayTime = DateTime.Now.ToShortTimeString();
				timeText.text = todayTime;
			}).AddTo(this);

		Observable.Interval(TimeSpan.FromSeconds(BatteryConsumeSeconds))
			.Subscribe(_ => batteryRate.Value -= 0.01f).AddTo(this);

		batteryRate.Subscribe(rate =>
		{
			batteryRateText.text = rate.ToString("P0");
			batteryRateImage.rectTransform.localScale =
				new Vector3(rate, batteryRateImage.transform.localScale.y, batteryRateImage.transform.localScale.z);
		}).AddTo(this);
	}
}
