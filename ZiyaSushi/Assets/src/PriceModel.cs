using System;
using UnityEngine;

namespace src
{
    public class PriceModel : MonoBehaviour
    {
        public int Price;

        private void Update()
        {
            if (Price >= 5)
            {
                Price = 4;
            }
        }
    }
}
