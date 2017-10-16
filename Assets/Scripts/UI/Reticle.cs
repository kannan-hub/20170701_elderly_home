using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// レティクルの表示状態を扱うクラス
    /// </summary>
    public class Reticle : MonoBehaviour
    {
        [SerializeField]
        private Image reticle;

        [SerializeField]
        private Image takingImage;

        public void Bind(Player.Player player)
        {
            player.HitInteractItem().Subscribe(hit =>
            {
                if (!hit.Item1)
                {
                    reticle.color = Color.white;
                    return;
                }

                reticle.color = Color.red;
            }).AddTo(this);

            player.OnTaking().Subscribe(takeing =>
            {
                takingImage.gameObject.SetActive(takeing);
            }).AddTo(this);
        }


//        private void OnDrawGizmos()
//        {
//            if (isEnable == false)
//                return;
//
//            var center = new Vector3(Screen.width / 2f, Screen.height / 2f);
//            var ray = Camera.main.ScreenPointToRay(center);
//
//            var isHit = Physics.SphereCast(ray, radius, out hit, maxDistance);
//            if (isHit)
//            {
//                reticle.color = Color.red;
//                Gizmos.DrawRay(ray.origin, Camera.main.transform.forward * hit.distance);
//                Gizmos.DrawWireSphere(ray.origin + Camera.main.transform.forward * hit.distance, radius);
//            }
//            else
//            {
//                reticle.color = Color.white;
//                Gizmos.DrawRay(ray.origin, Camera.main.transform.forward * maxDistance);
//            }
//        }
    }
}