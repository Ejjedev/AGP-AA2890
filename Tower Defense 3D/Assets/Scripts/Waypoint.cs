using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            InstantiatePrefab();
        }
    }

    private void InstantiatePrefab()
    {
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
    }
}
