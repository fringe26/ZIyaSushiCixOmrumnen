using UnityEngine;
using Zenject;

namespace src.Mechanic
{
    public class StateChanger : MonoBehaviour
    {   
        private EventHolder _eventHolder;
        private StackHolder _collectedSushi;
        [SerializeField] private Texture _soyaTexture;
    
        [Inject]
        public void Construct(EventHolder eventHolder, StackHolder collectedSushi)
        {
            _eventHolder = eventHolder;
            _collectedSushi = collectedSushi;
        }
        private void OnEnable()
        {
            _eventHolder.OnSoyaAdd += SoyaActivator;
            _eventHolder.OnSalmonAdd += SalmonActivator;
            _eventHolder.OnWasabiAdd += WasabiActivator;
        }

        private void WasabiActivator(GameObject obj)
        {
            if (obj.transform.GetChild(0).gameObject.activeSelf)
            {
                obj.transform.GetChild(1).gameObject.SetActive(true);
                if (obj.TryGetComponent<PriceModel>(out PriceModel sushi) && sushi.Price==3)
                {
                    sushi.Price++;
                    _eventHolder.TagPriceChangeEvent();
                }
                   
                    
            }
        }

        private void SalmonActivator(GameObject obj)
        {
                obj.transform.GetChild(0).gameObject.SetActive(true);
                if (obj.TryGetComponent<PriceModel>(out PriceModel sushi) && sushi.Price==2)
                {
                    sushi.Price++;
                    _eventHolder.TagPriceChangeEvent();

                }
        }

        private void SoyaActivator(GameObject obj)
        {
            obj.GetComponent<Renderer>().material.mainTexture = _soyaTexture;
            if (obj.TryGetComponent<PriceModel>(out PriceModel sushi) && sushi.Price==1)
            {
                sushi.Price++;
                _eventHolder.TagPriceChangeEvent();

            }
                
        }
    }
}
