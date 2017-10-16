using UI;
using UniRx;
using UnityEngine;
using Utility;

namespace Manager
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        [SerializeField]
        private Reticle reticle;

        /// <summary>
        /// UIの依存性注入
        /// </summary>
        public void Bind(Player.Player player)
        {
            reticle.Bind(player);
        }
    }
}