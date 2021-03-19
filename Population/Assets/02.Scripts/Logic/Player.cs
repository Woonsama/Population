using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ObjectBase, IMove, ICatch
{
    [Header("스테이터스")]
    public PlayerState state;

    private bool isCatch = false;
    private bool isNear = true;

    protected override IEnumerator OnAwakeCoroutine()
    {

        return base.OnAwakeCoroutine();
    }

    private void Update()
    {
        Move();
        Catch();
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

    public void Catch()
    {
        //가까이에 있으면서 시민을 안 잡고 있는 경우
        if(isNear && !isCatch)
        {
            isCatch = true;
        }
        //가까이에 있으면서 시민을 이미 잡은 경우
        else if(isNear && isCatch)
        {
            isCatch = false;
        }
        //가까이에 없으면서 시민을 안 잡고 있는 경우
        else if(!isNear && !isCatch)
        {

        }
        //가까이에 없으면서 시민을 잡고 있는 경우
        else if (!isNear && isCatch)
        {
            isCatch = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Citizen" && !isCatch)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }
    }
}

[System.Serializable]

public class PlayerState
{
    [Header("이동 속도")]
    public float moveSpeed;
}