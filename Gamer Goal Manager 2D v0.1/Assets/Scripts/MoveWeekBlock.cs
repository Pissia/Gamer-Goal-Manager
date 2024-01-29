using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWeekBlock : MonoBehaviour
{
    public GameObject weekBlock;
    public float addToX = 8;
    public float lerpDuration;

    public void MoveWeekBlockRight()
    {
       // weekBlock.transform.Translate(Vector3.right * addToX);

        StartCoroutine(LerpPosRight(weekBlock.transform.position, weekBlock.transform.position + (Vector3.right*addToX)));
    }

    public void MoveWeekBlockLeft()
    {
        StartCoroutine(LerpPosLeft(weekBlock.transform.position, weekBlock.transform.position - (Vector3.right * addToX)));
    }

    IEnumerator LerpPosRight(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            weekBlock.transform.position = Vector3.Lerp(start, end, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
    IEnumerator LerpPosLeft(Vector3 start, Vector3 end)
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            weekBlock.transform.position = Vector3.Lerp(start, end, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
