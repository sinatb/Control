using UnityEngine;
using System.Collections.Generic;
public class AdvancedEnemyCollision : MonoBehaviour
{
    private AdvancedEnemy _ae;
    private List<string> _tags;
    private void Awake()
    {
        _ae = gameObject.GetComponent<AdvancedEnemy>();
        _tags = new List<string>(new string[] { "Wall", "Morphing_Enemy", "Advanced_Enemy", "Dropable" });
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!_tags.Contains(col.transform.tag)) return;
        var inNormal = col.contacts[0].normal;
        var direction = _ae.Direction;
        var prevDir = direction;
        direction = Vector2.Reflect(direction, inNormal);
        _ae.Direction = Quaternion.FromToRotation(prevDir,direction)*_ae.Direction;
    }
}
