using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterControl : MonoBehaviour
{
    public CharacterDataBinding dataBinding;
    private Vector3 tempMoveDir;
    public Transform trans;
    public float speed = 2f;
    private Vector3 move;
    public LayerMask mask;
    public Transform trans_Anchor;

    private bool isAlive = true;
    public bool IsAlive => isAlive;
    private int curblood = 0;
    private int maxBlood = 15;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        curblood = maxBlood;
        trans = transform;
       InputManager.instance.OnWeaponChange+= OnWeaponChange;
    }

    void OnWeaponChange(WeaponBehaviour obj)
    {
        obj.aimShoot = trans_Anchor;
    }


    // Update is called once per frame
    void Update()
    {
        float x = InputManager.instance.moveDir.x;
        float y = InputManager.instance.moveDir.y;
        x = Mathf.Round(x);
        y = Mathf.Round(y);
        Vector3 posMove = new Vector3(x, y, trans.position.z);
         move = new Vector3(x, y);

        float speedMove = move.magnitude;
        speedMove = Mathf.RoundToInt(speedMove);
        if (speedMove > 0)
        {

            Vector3 newMoveDir = new Vector3(x, y);
            if (tempMoveDir != newMoveDir)
            {

                tempMoveDir = newMoveDir;
            }
            dataBinding.MoveDir = tempMoveDir;
            trans_Anchor.up = posMove.normalized;
        }
       
        RaycastHit2D raycast = Physics2D.Raycast(trans.position+ posMove.normalized*0.1f, posMove, 0.5f, mask);
        if (raycast.collider != null)
        {
            if (raycast.collider.tag == "Down")
            {
                speedMove = 0;
            }
            else if (raycast.collider.tag == "Up")
            {
               // raycast.collider.GetComponentInParent<SpriteRenderer>().sortingOrder = 3;

            }
            else
            {
               
            }

        }
       
        dataBinding.SpeedMove = speedMove;
        trans.position = Vector3.MoveTowards(trans.position, trans.position + posMove,
         speedMove * speed * Time.deltaTime);
     
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive)
            return;

        curblood += damage;
        if(curblood <= 0)
        {
            curblood = 0;
            isAlive = false;
            ViewManager.instance.OnSwitchView(ViewIndex.PauseView, new PauseParam { totalKill = MissionManager.instance.TotalEnemyDead });
        }
        InputManager.instance.ChangeBlood((float)curblood / maxBlood);
    }
}
