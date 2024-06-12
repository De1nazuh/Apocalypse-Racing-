using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{

    public class InjectService : MonoBehaviour
    {
        public static void Inject(object obj)
        {
            ProjectContext.Instance.Container.Inject(obj);
        }

        //public static T GetObject<T>()
    }
}