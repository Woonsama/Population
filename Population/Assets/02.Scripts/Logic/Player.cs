using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ObjectBase, IMove, ICatch
{
    [Header("스테이터스")]
    public PlayerState state;

    [Header("확인용 - 지금 시민을 잡고 있는지")]
    [SerializeField] private bool isCatch = false;

    [Header("확인용 - 적과 가까이 있는지")]
    [SerializeField] private bool isNear = false;

    private GameObject target;
    private Vector2 targetInitialPos;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isNear && !isCatch)
            {
                target.transform.parent = transform;
                target.GetComponent<BoxCollider2D>().enabled = false;
                "시민을 잡았습니다".Log();
                isCatch = true;
            }
            else if (isNear && isCatch || !isNear && isCatch)
            {
                target.GetComponent<BoxCollider2D>().enabled = true;
                transform.DetachChildren();
                "시민을 놓아주었습니다".Log();
                target = null;
                isCatch = false;
            }
            else if(!isNear && !isCatch)
            {

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Citizen")
        {
            if(!isCatch)
            {
                target = collision.collider.gameObject;
                targetInitialPos = target.transform.position;
            }
            isNear = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Citizen")
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