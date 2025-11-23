using UnityEngine;
using DG.Tweening;

public class MovingSaw : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform sawBody;
 
    private void Start()
    {
        sawBody.transform.position = pointA.position;
        sawBody.transform.DOMove(pointB.position, 5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
