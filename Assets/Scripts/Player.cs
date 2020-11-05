using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 40;

    private void Start()
    {
        LoadPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            PlayerData playerData = new PlayerData(this);
            DataHandler.Save(DataHandler.UnityDirectory.StreamingAsset, playerData, "PlayerFile.dat");
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            
        }
    }

    public void LoadPlayer()
    {
        if (!DataHandler.CheckFile(DataHandler.GetDirectory(DataHandler.UnityDirectory.StreamingAsset) + Path.AltDirectorySeparatorChar + "PlayerFile.dat")) return;
        PlayerData data = DataHandler.Load<PlayerData>(DataHandler.UnityDirectory.StreamingAsset, "PlayerFile.dat");
        
        health = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
}
