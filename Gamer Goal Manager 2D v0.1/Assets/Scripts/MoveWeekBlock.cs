using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWeekBlock : MonoBehaviour
{
    public GameObject weekBlock;
    public float addToX = 8;
    public float lerpDuration;
    private bool coroutineStarted = false;
    private float leftLimit = 7;
    private float rightLimit = -47;
    private float leftEndPos = 8;
    private float rightEndPos = -48;

    public float[] weekDayPos;

    

    public void MoveToCurrentDay()
    {
        for(int i = 0; i < weekDayPos.Length; i++)
        {
            if(i == GameManager.instance.weekDayNumber)
            {
                StartCoroutine(LerpPosRight(weekBlock.transform.position, weekBlock.transform.position - (Vector3.right * weekDayPos[i])));
            }
        }
    }
    public void MoveWeekBlockRight()
    {
        // weekBlock.transform.Translate(Vector3.right * addToX);
        if (coroutineStarted == false && weekBlock.transform.position.x < rightLimit)
        {
            StartCoroutine(LerpPosRight(weekBlock.transform.position, Vector3.right * leftEndPos));
        }   
       else if (coroutineStarted == false && weekBlock.transform.position.x > rightLimit)
        {
            StartCoroutine(LerpPosRight(weekBlock.transform.position, weekBlock.transform.position - (Vector3.right * addToX)));
        }
        
    }

    public void MoveWeekBlockLeft()
    {
        if (coroutineStarted == false && weekBlock.transform.position.x > leftLimit)
        {
            StartCoroutine(LerpPosRight(weekBlock.transform.position, Vector3.right * rightEndPos));
        }
        else if(coroutineStarted == false && weekBlock.transform.position.x < leftLimit)
        {
            StartCoroutine(LerpPosLeft(weekBlock.transform.position, weekBlock.transform.position + (Vector3.right * addToX)));
        }
    }

    IEnumerator LerpPosRight(Vector3 start, Vector3 end)
    {
        coroutineStarted = true;
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            weekBlock.transform.position = Vector3.Lerp(start, end, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        coroutineStarted = false;
    }
    IEnumerator LerpPosLeft(Vector3 start, Vector3 end)
    {
        coroutineStarted = true;
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            weekBlock.transform.position = Vector3.Lerp(start, end, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        coroutineStarted = false;
    }
}
