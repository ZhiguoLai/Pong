using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{   
    [CreateAssetMenu (menuName = "Data/AbilityData/FireBallAbility")]
    public class FireBallAbility : Ability
    {
        public float fireSpeed;
        private FireBall fireBall;

        public override void Initialize(GameObject obj)
        {
            fireBall = obj.GetComponent<FireBall>();
            fireBall.fireSpeed = fireSpeed;
        }
        public override void TriggerAbility()
        {
            fireBall.UseFireBall();
        }
    }
}

