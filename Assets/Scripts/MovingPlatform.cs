using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform movingTarget;

    private void Start()
    {
        transform.DOMove(movingTarget.position, 5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
