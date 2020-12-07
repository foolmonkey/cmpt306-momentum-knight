using UnityEngine;
using System.Collections;
using System;



public class DelaySearch : MonoBehaviour

{
    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)

    {

        yield return new WaitForSeconds(delaySeconds);

        action();

    }

}