using System;
using Interface.Item;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Utility;

namespace Base.Item
{
    [RequireComponent(typeof(ObservableEventTrigger))]
    public class ItemBase : MonoBehaviour, IItem
    {
        [SerializeField]
        private int needGetTime;

        [SerializeField]
        private ResultType result;
        
        [SerializeField]
        protected ObservableEventTrigger eventTrigger;

        private UniRx.IObservable<ResultType> ItemGetResult()
        {
            return eventTrigger.OnMouseDownAsObservable()
                .SelectMany(_ =>
                    Observable.Timer(TimeSpan.FromSeconds(needGetTime))
                        .Select(x => ResultType.Success)
                        .TakeUntil(eventTrigger.OnMouseUpAsObservable())
                        .DefaultIfEmpty(ResultType.Failure))
                .RepeatSafe()
                .Publish()
                .RefCount();
        }

        private void Start()
        {
            ItemGetResult().Subscribe(x => result = x).AddTo(this);
        }
    }
}