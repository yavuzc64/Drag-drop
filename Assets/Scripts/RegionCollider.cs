using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RegionCollider : MonoBehaviour
{
    private string objectTag;
    //public bool TimeFinish = false;
    public static RegionCollider instance;
    public bool generate = true;
    public bool isFinish;
    public bool control = false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        objectTag = transform.tag;
        StartCoroutine(TimeCoroutine());
    }
    private void Update()
    {
        isFinish = Countdown.instance.isFinish;
    }
    private IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(15);
        //TimeFinish = true;
        generate = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (isFinish && control)
        {
            if (other.CompareTag(objectTag))
            {

                ScoreManager.instance.IncreaseScore(1);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
                Debug.Log("yandi");
                ScoreManager.instance.DecreaseBall(-1);
            }
            generate = true;
            control = false;
        }
        
    }
    
}
