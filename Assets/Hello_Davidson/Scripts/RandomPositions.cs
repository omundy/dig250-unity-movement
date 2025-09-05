using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    public List<float> values;
    public int counter;

    void Start()
    {
        RandomizeList();
    }

    void RandomizeList()
    {
        values = new List<float>();
        foreach (Transform child in transform)
        {
            values.Add(Random.Range(-4, 4));
        }
    }

    void Update()
    {
        if (++counter % 200 == 0)
            RandomizeList();

        int i = 0;
        foreach (Transform child in transform)
        {
            child.localPosition = Vector3.Lerp(
                child.localPosition,
                new Vector3(child.localPosition.x, values[i], child.localPosition.z),
                Time.deltaTime * 3
            );
            i++;
        }
    }

}
