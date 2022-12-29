using System;
using UnityEngine;

namespace src.Mechanic
{
    public class EventHolder
    {
        /// <summary>
        /// Sushi Collector
        /// </summary>
        public Action<CollectedSushi> OnSushiCollect;
        
        /// <summary>
        /// Sushi Eraser logic start
        /// </summary>
        public Action<GameObject> OnObstacleCollide;
        
        /// <summary>
        /// Will have several States:
        /// OnIceCreamAdd = Active child that contains ice cream ball
        /// OnChocolateAdd = Active child that contains chocolate cream
        /// OnTopingAdd = Active child that contains toping and pipe;
        /// </summary>
        public Action<GameObject> OnSoyaAdd;
        public Action<GameObject> OnSalmonAdd;
        public Action<GameObject> OnWasabiAdd;
        
        /// <summary>
        /// Finish Arrive Logic + UI Subscribe
        /// </summary>
        public Action<GameObject> OnFinishArrive;
        public Action<GameObject> OnLastFinishArrive;
        public Action OnTagPriceChange;
        public Action<Transform> OnSellMoneyChange;
        public Action OnSushiStackEmpty;


        /// <summary>
        /// Finish Behavior Hands Camera ETC
        /// </summary>
        public Action OnGetSushiDish;

        public void DishGetSushi()
        {
            OnGetSushiDish?.Invoke();
        }
        public void SushiStackGetEmpty()
        {
            OnSushiStackEmpty?.Invoke();
        }

        public void SellMoneyChange(Transform sushi)
        {
            OnSellMoneyChange?.Invoke(sushi);
        }

        public void TagPriceChangeEvent()
        {
            OnTagPriceChange?.Invoke();
        }

        public void SushiCollectEvent(CollectedSushi sushi)
        {
            OnSushiCollect?.Invoke(sushi);
        }

        public void ObstacleCollidedEvent(GameObject sushi)
        {
            OnObstacleCollide?.Invoke(sushi);
        }

        public void SoyaAdd(GameObject sushi)
        {
            OnSoyaAdd?.Invoke(sushi);
        }

        public void SalmonAdd(GameObject sushi)
        {
            OnSalmonAdd?.Invoke(sushi);
        }

        public void WasabiAdd(GameObject sushi)
        {
            OnWasabiAdd?.Invoke(sushi);
        }

        public void FinishArrivedEvent(GameObject sushi)
        {
            OnFinishArrive?.Invoke(sushi);
        }

        public void CarArriveEvent(GameObject sushi)
        {
            OnLastFinishArrive?.Invoke(sushi);
        }
    }
}
