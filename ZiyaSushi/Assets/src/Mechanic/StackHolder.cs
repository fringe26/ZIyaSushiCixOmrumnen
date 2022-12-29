using System.Collections.Generic;
using UnityEngine;

namespace src.Mechanic
{
    public class StackHolder
    {
        [SerializeField] private List<Transform> _sushiStack = new List<Transform>();
        public List<Transform> SushiStack
        {
            get => _sushiStack;
            private set => _sushiStack = value;
        }
    }
}
