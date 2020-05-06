using UnityEngine;
 
 public class GameSparksManager : MonoBehaviour
 {
         private static GameSparksManager _instance = null;
 
         private void Awake()
         {
                 if (_instance == null)
                 {
                         _instance = this;
                         DontDestroyOnLoad(this.gameObject);
                 }
                 else
                 {
                         Destroy(this.gameObject);
                 }
         }
 }