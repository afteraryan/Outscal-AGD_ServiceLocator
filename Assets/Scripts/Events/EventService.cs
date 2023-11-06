using UnityEngine;

/**  This script demonstrates implementation of the Observer Pattern.
  *  If you're interested in learning about Observer Pattern, 
  *  you can find a dedicated course on Outscal's website.
  *  Link: https://outscal.com/courses
  **/

namespace ServiceLocator.Events
{
    public class EventService : GenericMonoSingleton<EventService>
    {
        public GameEventController<int> OnMapSelected { get; private set; }
        public static EventService Instance {get{return _instance;}}
        private static EventService _instance;

        private void Awake()
        {
            OnMapSelected = new GameEventController<int>();
            
            //Singleton Implementation
            if(_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
                Debug.LogError("Singleton of EventService is trying to create another instance.");
            }
            
        }
        
    }
}