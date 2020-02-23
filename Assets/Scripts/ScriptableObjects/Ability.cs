using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{
    public abstract class Ability : ScriptableObject
    {
        /*Skill Sytem
         * define the skill system parameter
         */
        public string abilityName = "New Ability";
        public Sprite abilitySprite;
        public AudioClip abilitySound;
        public float abilityBaseCoolDown;

        public abstract void Initialize(GameObject obj);
        public abstract void TriggerAbility();
    }
}

