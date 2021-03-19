using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ObjectBase, IMove
{
    [Header("스테이터스")]
    public PlayerState state;

    protected override IEnumerator OnAwakeCoroutine()
    {

        return base.OnAwakeCoroutine();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * 0.1f * state.moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * 0.1f * state.moveSpeed;

        if (x > 0) transform.localScale = new Vector2(-1, 1);
        else if (x < 0) transform.localScale = new Vector2(1, 1);

        x.Log();

        transform.Translate(new Vector2(x, y));
    }
}

[System.Serializable]

public class PlayerState
{
    [Header("이동 속도")]
    public float moveSpeed;
}