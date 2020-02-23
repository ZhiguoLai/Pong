using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{   [CreateAssetMenu (menuName = "paddle")]
    public class PaddleAbility : ScriptableObject
    {
        public string padddleName = "Default";
        public Ability paddleAbility; 
    }
}

