using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public class FireBall : MonoBehaviour
    {
        [HideInInspector] public float fireSpeed;
        
        public void UseFireBall()
        {
            //define the fire ball skill effect, connecting to the buff system
            GetComponent<Paddle>().ChangeAttribute(2);
        }

    }
}

