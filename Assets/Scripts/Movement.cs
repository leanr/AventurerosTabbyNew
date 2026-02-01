using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{

    
        public float speed = 1f;
        public bool canMove = true;
       

        void Start()
        {
            
        }


        void Update()
        {
            if (!canMove) return;
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
        }

      
}


