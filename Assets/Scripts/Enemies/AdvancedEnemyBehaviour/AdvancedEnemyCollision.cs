using UnityEngine;

public class AdvancedEnemyCollision : MonoBehaviour
{
    private AdvancedEnemy _ae;
    private void Awake()
    {
        _ae = gameObject.GetComponent<AdvancedEnemy>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("Wall") && !col.transform.CompareTag("Morphing_Enemy")
                                              && !col.transform.CompareTag("Advanced_Enemy")) return;
        var inNormal = col.contacts[0].normal;
        var direction = _ae.Direction;
        var prevDir = direction;
        direction = Vector2.Reflect(direction, inNormal);
        _ae.Direction = Quaternion.FromToRotation(prevDir,direction)*_ae.Direction;
    }
}
