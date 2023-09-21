using UnityEngine;

public interface INCUnit
{
    public float Speed
    {
        get;
        set;
    }
    public float Health
    {
        get;
        set;
    }
    public Vector2 Direction
    {
        get;
        set;
    }
    public void PlanMove();
    public void Move();
}
