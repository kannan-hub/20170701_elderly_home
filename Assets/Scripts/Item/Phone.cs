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
        private const string CHARGE_BATTERY_POWER_POINT_TAG = "ChargePoint";
        private const int CONSUME_BATTERY_POWER_TIME = 1;
        private const int CHARGE_BATTERY_POWER_TIME = 1;

        [SerializeField]
        private Light _cameraLight;

        private readonly ReactiveProperty<int> remainBattery = new ReactiveProperty<int>(100);

        public UniRx.IObservable<int> RemainBattery
        {
            get { return remainBattery; }
        }

        private void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(CONSUME_BATTERY_POWER_TIME))
                .Where(_ => remainBattery.Value > 0)
                .Subscribe(_ =>
                {
                    remainBattery.Value -= 1;
                }).AddTo(this);

            eventTrigger.OnTriggerStayAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(CHARGE_BATTERY_POWER_TIME))
                .Where(_ => remainBattery.Value < 99)
                .Where(x => x.CompareTag(CHARGE_BATTERY_POWER_POINT_TAG))
                .Subscribe(_ => remainBattery.Value += 2)
                .AddTo(this);

            remainBattery.Subscribe(x =>
            {
                _cameraLight.enabled = x > 0;
            }).AddTo(this);
        }
    }
}