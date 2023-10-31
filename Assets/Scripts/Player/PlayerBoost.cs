using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour
{
    private Player _currPlayer;
    private bool _isBoosting;
    private void Start()
    {
        _currPlayer = GetComponent<Player>();
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space)) && !_isBoosting) 
        {
            _isBoosting = true;
            StartCoroutine(BoostCalculator());           
        }
    }
    private IEnumerator BoostCalculator() 
    {
        float time_elapsed = 0.0f;
        for (int i = 0; i<50; i++)
        {
            if (i < 10)
                _currPlayer.Speed += 1.0f;
            else
                _currPlayer.Speed -= 0.25f;
            yield return new WaitForSeconds(0.01f);
            time_elapsed += 0.01f;
        }

        _isBoosting = false;
    }
}
