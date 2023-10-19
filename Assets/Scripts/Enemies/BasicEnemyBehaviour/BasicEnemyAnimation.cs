using System;
using System.Collections;
using UnityEngine;

public class BasicEnemyAnimation : MonoBehaviour
{
    private Animation _anim;
    private float _time = 1.0f;
    private bool _isDone;
    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        _isDone = true;
    }
    private void Awake()
    {
        _anim = gameObject.GetComponent<Animation>();
    }
    public void Animate()
    {
        _anim.Play();
        StartCoroutine(Timer(_time));
    }

    private void Update()
    {
        if (_isDone)
            EndAnimation();
    }

    public void EndAnimation()
    {
        var bemm = gameObject.GetComponent<BasicEnemyMorphManager>();
        if (bemm == null) return;
        bemm.Die();
        GameManager.m?.Invoke(bemm.GetPos());
    }
}
