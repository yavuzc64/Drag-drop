using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    bool one = true;
    [SerializeField] private Vector3[] BallPosition = new Vector3[]
    {
        new Vector3(70,15,-23),
        new Vector3(70,15,0),
        new Vector3(70,15,23)

    };
    
    [SerializeField] private GameObject[] balls;
    void Update()
    {
        if (RegionCollider.instance.generate && one)
        {
            for (int i = 0; i < ScoreManager.instance.BallNum; i++)
            {
                Instantiate(balls[i], BallPosition[i], Quaternion.identity);
            }
            one = false;
        }

    }
}
