using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    
    public class CheckPointScript : MonoBehaviour
    {
        public Character Character;
            private void OnCollisionEnter(Collision other)
        {
            //if (other.collider.CompareTag("Player"))
            //{
                CharacterSaving();
            //}
        }

        public void CharacterSaving()
        {
            Debug.Log("Writing save file...");
        DataHandler.Save(DataHandler.UnityDirectory.StreamingAsset, Character, "character");
        }
        
    }

    [Serializable]
    public class Character
    {
        public string Name;
        public Vector3 Position;
    }
}