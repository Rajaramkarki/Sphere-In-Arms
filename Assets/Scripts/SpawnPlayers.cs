using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float x1, x2, y1, y2, z1, z2;

    private void Start()
    {
        Vector3 spawn = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), Random.Range(z1, z2));
        PhotonNetwork.Instantiate(playerPrefab.name, spawn, Quaternion.identity);
    }

}
