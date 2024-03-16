using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regenerate : MonoBehaviour
{
    [SerializeField] private Vector3[] RegionPosition = new Vector3[]
    {
        new Vector3(-96,-4,27),
        new Vector3(-96,-4,-25),
        new Vector3(-44,-4,27),
        new Vector3(-44,-4,-25)
    };
    //[SerializeField] private Vector3[] BallPosition = new Vector3[]
    //{
    //    new Vector3(70,15,-23),
    //    new Vector3(70,15,0),
    //    new Vector3(70,15,23)

    //};
    [SerializeField] private GameObject[] regions;
    //[SerializeField] private GameObject[] balls;
    
    int select;
    [SerializeField] private bool Generate;

    
    private void Start()
    {
        select = 0;
        //Debug.Log(balls[2].transform.position);
    }

    private void Update()
    {
        Generate = RegionCollider.instance.generate;
        if (Generate)
        {
            
            for (int i = 0; i < RegionPosition.Length; i++)
            {
                int randomIndex = GetUniqueRandomIndex();
                Vector3 randomPosition = RegionPosition[randomIndex];

                regions[i].transform.position = randomPosition + new Vector3(70, 14, -7);
            }
            //for (int i = 0; i < BallPosition.Length; i++)
            //{
            //    if (balls[i] != null)
            //    {
            //        balls[i].transform.position = BallPosition[i];
            //        Debug.Log(BallPosition[i]);
            //    }
            //}
            RegionCollider.instance.generate = false;
            Countdown.instance.isFinish = false;
        }
    }


    //son uc index e benzemeyen random index
    private int lastIndex = -1;
    private int maxIndex = 4;
    private int[] selected = new int[3];
    public int GetUniqueRandomIndex()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, maxIndex);
        }
        while (randomIndex == selected[0] || randomIndex == selected[1] || randomIndex == selected[2]);

        selected[select % 3] = randomIndex;
        select++;
        return randomIndex;
    }


}
