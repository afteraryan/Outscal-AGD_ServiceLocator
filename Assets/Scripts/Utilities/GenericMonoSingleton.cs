using System;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T: GenericMonoSingleton<T>
{
     private static T _instance;
     public static T Instance {get{return _instance;}}

     private void Awake()
     {
          if (_instance == null)
               _instance = (T)this;
          else
          {
               Destroy(gameObject);
               Debug.LogError($"Singleton of {typeof(T)} is trying to create another instance.");
          }
     }
}
