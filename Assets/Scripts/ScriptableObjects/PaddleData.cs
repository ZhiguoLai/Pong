using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    [CreateAssetMenu(menuName = "Data/ControlData/Paddle Data")]
    public class PaddleData : ScriptableObject
    {
        [Tooltip("the speed the paddle moves")]
        public float paddleSpeed;

        [Tooltip("how long the paddle is")][Range(0,10)]
        public float paddeLength;

    }
}
