using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform platformBody;
 
    private void Start()
    {
        platformBody.transform.position = pointA.position;
        platformBody.transform.DOMove(pointB.position, 5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
