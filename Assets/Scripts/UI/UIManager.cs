using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Reticle reticle;

        [SerializeField]
        private Battery battery;

        public void Bind(Player.Player player)
        {
            reticle.Bind(player);
            battery.Bind(player.Phone.RemainBattery);
        }
    }
}