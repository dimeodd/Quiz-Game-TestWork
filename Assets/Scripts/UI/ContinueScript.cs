using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SaveService.WordsCompleted == 0)
            gameObject.SetActive(false);
    }
}
