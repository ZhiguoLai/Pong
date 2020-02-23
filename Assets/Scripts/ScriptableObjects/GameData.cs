using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Events;

namespace Pong
{   [CreateAssetMenu(menuName = "Data/GameData")]
    public class GameData : ScriptableObject
    {
        public int winScore;
        public VoidEvent gameEndEvent;
    }
}

