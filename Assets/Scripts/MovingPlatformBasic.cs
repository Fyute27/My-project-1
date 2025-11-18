using UnityEngine;

public class MovingPlatformBasic : MonoBehaviour
{
     public Transform pointA;
     public Transform pointB;
     public float speed =5f;

     
     
     private bool isGoingB = true;
     //Update is called once per frame 
     void Update()
     {
          Vector3 target;
          if (isGoingB)
          {
                target = pointB.position;
               
          }
          else
          {
                target = pointA.position;
          }
          var x = Mathf.MoveTowards(transform.position.x, target.x,  speed * Time.deltaTime);
          transform.position = new Vector3(x, transform.position.y, transform.position.z);
          
          if(x==target.x) isGoingB = !isGoingB;
         
     }

}
