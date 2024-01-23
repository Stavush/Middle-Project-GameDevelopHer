using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public static TrapManager Instance;

    public GameObject[] trapPrefabs;
    public List<Transform> trapLocations;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlaceTraps();
    }

    void PlaceTraps()
    {
        foreach (Transform location in trapLocations)
        {
            int randomTrapIndex = Random.Range(0, trapPrefabs.Length);
            GameObject trapPrefab = trapPrefabs[randomTrapIndex];
            Instantiate(trapPrefab, location.position, location.rotation);
        }
    }
}