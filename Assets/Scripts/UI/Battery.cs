using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Battery : MonoBehaviour
    {
        [SerializeField]
        private Text _batteryText;

        public void Bind(IObservable<int> remainBattery)
        {
            remainBattery.Subscribe(x =>
            {
                var p = Mathf.Max(x, 0);
                _batteryText.text = string.Format("{0}%", p);
            }).AddTo(this);
        }
    }
}