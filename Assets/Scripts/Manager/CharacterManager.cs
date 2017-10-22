using UnityEngine;
using Utility;

namespace Manager
{
    public class CharacterManager : SingletonMonoBehaviour<CharacterManager>
    {
        [SerializeField]
        private GameObject PlayerPrefab;

        [SerializeField]
        private GameObject EnemyPrefab;

        private Player.Player player;
        private Enemy.Enemy enemy;

        private void Start()
        {
            player = Instantiate(PlayerPrefab, transform, false).GetComponent<Player.Player>();
            enemy = Instantiate(EnemyPrefab, transform, false).GetComponent<Enemy.Enemy>();
        }
    }
}