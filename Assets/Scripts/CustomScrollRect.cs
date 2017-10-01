using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class CustomScrollRect : ScrollRect
{
	private int contentCount;


	public void Next()
	{
		content.GetChild(0).SetAsLastSibling();
	}

	public void Prev()
	{
		content.GetChild(contentCount - 1).SetAsFirstSibling();
	}

	private Toggle aToggle;
	private Toggle bToggle;

	private ToggleGroup toggleGroup;

	private enum ToggleType
	{
		A,
		B
	}

	private Dictionary<ToggleType, Toggle> toggleMap;
	private Dictionary<ToggleType, Vector2> normalizedPositionMap;

	private ObservableEventTrigger scrollViewEventTrigger;

	protected override void Awake()
	{
		base.Awake();
		
		toggleMap = new Dictionary<ToggleType, Toggle>
		{
			{ToggleType.A, aToggle},
			{ToggleType.B, bToggle}
		};
		
		normalizedPositionMap = new Dictionary<ToggleType, Vector2>
		{
			{ToggleType.A, Vector2.down},
			{ToggleType.B, Vector2.up}
		};
	}
	
	protected override void Start()
	{
		base.Start();

		foreach (var pair in toggleMap)
		{
			pair.Value.OnValueChangedAsObservable()
				.Where(isOn => isOn)
				.Zip(pair.Value.OnPointerClickAsObservable(), (b, data) => Unit.Default)
				.First()
				.Repeat()
				.Subscribe(_ =>
				{
					//Call ScrollView Move Method
					//use pair.Key;
				}).AddTo(this);
		}

		GetNowToggleType().Subscribe(type => toggleMap[type].isOn = true).AddTo(this);

	}

	private UniRx.IObservable<ToggleType> GetNowToggleType()
	{
		return scrollViewEventTrigger.OnDragAsObservable()
			.Merge(scrollViewEventTrigger.OnScrollAsObservable())
			.Select(_ => normalizedPosition)
			.Select(positon => normalizedPositionMap.LastOrDefault(x => x.Value == positon).Key)
			.DistinctUntilChanged();
	}
}