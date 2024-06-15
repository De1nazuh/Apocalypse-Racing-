using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    public class GameStateBase
    {
        public GameStateChanger gameStateChanger;
        public virtual void Enter()
        {

        }
        public virtual void Work()
        {

        }
        public virtual void Exit() 
        { 
        }
    }
}

