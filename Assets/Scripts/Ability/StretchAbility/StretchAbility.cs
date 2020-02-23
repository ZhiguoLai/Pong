using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong
{
    [CreateAssetMenu(menuName = "Data/AbilityData/StrechAbility")]
    public  class StretchAbility : Ability
    {
        public float afterLength;
        private StretchPaddle sPaddle;

        public override void Initialize(GameObject obj)
        {
            sPaddle = obj.GetComponent<StretchPaddle>();
            sPaddle.afterLength = afterLength;
        }
        public override void TriggerAbility()
        {
            sPaddle.ChangePaddleLength();
        }
    }
}

