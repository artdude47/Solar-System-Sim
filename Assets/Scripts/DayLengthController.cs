using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLengthController : MonoBehaviour
{
    public static DayLengthController instance;

    [Tooltip("Length of an Earth day in seconds")]
    public float earthDayInSeconds = 24.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
