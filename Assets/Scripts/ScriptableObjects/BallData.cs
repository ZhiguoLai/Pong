using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{   
    [CreateAssetMenu(menuName ="Data/ControlData/Ball Data")]
    public class BallData : ScriptableObject
    {
        [Tooltip("the speed ball moves")]
        public float ballSpeed;

        [Tooltip("the start direction ball moves")]
        public Vector2 ballStartDirection;

    }
}

