using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.score = 0;
        GameOverManager.level2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
