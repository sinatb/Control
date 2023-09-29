using UnityEngine;

public class BasicEnemyAnimation : MonoBehaviour
{
    private Animation _anim;
    private void Awake()
    {
        _anim = gameObject.GetComponent<Animation>();
    }
    public void Animate()
    {
        _anim.Play();
    }
}
