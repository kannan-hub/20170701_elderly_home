using System;
using System.Security.Cryptography.X509Certificates;
using Base.Item;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Item
{
    public class Phone : ItemBase
    {
        [SerializeField]
        private Light _cameraLight;

        private readonly ReactiveProperty<int> remainBattery = new ReactiveProperty<int>(100);

        public UniRx.IObservable<int> RemainBattery
        {
            get { return remainBattery; }
        }

        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(1))
                .Where(_ => remainBattery.Value > 0)
                .Subscribe(_ =>
                {
                    remainBattery.Value -= 1;
                }).AddTo(this);

            eventTrigger.OnTriggerStayAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(1))
                .Where(_ => remainBattery.Value < 99)
                .Where(x => x.CompareTag("ChargePoint"))
                .Subscribe(_ => remainBattery.Value += 2)
                .AddTo(this);

            remainBattery.Subscribe(x =>
            {
                _cameraLight.enabled = x > 0;
            }).AddTo(this);
        }
    }
}