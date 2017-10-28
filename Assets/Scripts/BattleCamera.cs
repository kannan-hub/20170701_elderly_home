using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class BattleCamera : MonoBehaviour
{
    [SerializeField]
    private List<CinemachineVirtualCamera> virtualCameras;

    [SerializeField]
    private List<Button> targetButtons;

    private void Start()
    {
        targetButtons
            .Select(x => x.OnClickAsObservable()
                .Select(y => targetButtons.FindIndex(button => button == x)))
            .Merge()
            .Subscribe(x =>
            {
                virtualCameras.ForEach(y => y.gameObject.SetActive(false));
                virtualCameras[x].gameObject.SetActive(true);
            }).AddTo(this);
    }

}