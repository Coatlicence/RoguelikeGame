using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _PlayerController : StandartController
{
    public enum Focus
    {
        EMPTY = 0,
        GAME,
        INVENTORY,
        // add other focuses
    }
    //private Collider[] Colliders = new Collider[100];

    [Tooltip("Singleton of this class")]
    public static _PlayerController _Instance { get; private set; }

    [Tooltip("Indicates current key bindings, which will invoke during game")]
    public Focus _CurrentFocus { get; private set; }

    // For animator
    private float RunScaler = 0f;

    private Quaternion _CurrentRotation = Quaternion.identity;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
            Destroy(this);        
        else
            _Instance = this;

        SetFocus(Focus.GAME);
    }


    public void SetFocus(Focus focus)
    {
        _CurrentFocus = focus;

        MOUSE_RIGHT = null;
        MOUSE_LEFT  = null;
        SPACE       = null;
        WASD        = null;
        E           = null;
        I           = null;

        switch (focus)
        {
            case Focus.EMPTY:
                break;

            case Focus.GAME:
                MOUSE_RIGHT = AttackRight;
                MOUSE_LEFT  = AttackLeft;
                SPACE       = Dash;
                WASD        = Move;
                E           = Interact;
                I           = OpenInventory;
                break;

            case Focus.INVENTORY:
                WASD    = NavigateByInventoryMenu;
                SPACE   = ThrowItem;
                I       = OpenInventory;
                break;
        }
    }

    protected void FixedUpdate()
    {
        if (_CurrentFocus == Focus.GAME)
            WASD?.Invoke();
    }

    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MOUSE_LEFT?.Invoke();

        if (Input.GetMouseButtonDown(1))
            MOUSE_RIGHT?.Invoke();

        if (Input.GetKeyDown(KeyCode.Space))
            SPACE?.Invoke();

        if (Input.GetKeyDown(KeyCode.E))
            E?.Invoke();

        if (Input.GetKeyDown(KeyCode.I))
            I?.Invoke();

        if (_CurrentFocus == Focus.INVENTORY)
            WASD?.Invoke();
    }

    private delegate void ControllerMethod();
    ControllerMethod MOUSE_LEFT;
    ControllerMethod MOUSE_RIGHT;
    ControllerMethod SPACE;
    ControllerMethod E;
    ControllerMethod I;
    ControllerMethod WASD;

    /// ------------------------------------------------------
    /// FOCUS GAME
    protected override void Move()
    {
        if (movable)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            bool isMoving = x != 0 || z != 0;

            movable.Move(x, z);

            if (animator)
            {
                float target = Convert.ToSingle(isMoving);

                RunScaler = Mathf.Lerp(RunScaler, target, 0.3f);

                animator.SetFloat("Run", RunScaler);
            }

            if (isMoving)
            {
                float angleRad = Mathf.Atan2(x, z);

                float angleDeg = angleRad * Mathf.Rad2Deg - 45;

                var targetRotation = Quaternion.Euler(0, angleDeg, 0);

                _CurrentRotation = Quaternion.Lerp(_CurrentRotation, targetRotation, 0.3f);

                transform.GetChild(0).transform.rotation = _CurrentRotation;
            }
        }
    }

    protected override void AttackLeft()
    {
        //if (attackable && attackable.FirstWeapon)
            //attackable.FirstWeapon.FirstAttack.Attack();

        if (animator)
        {
            //var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //animator.runtimeAnimatorController.animationClips[1];

            animator.SetTrigger("Attack");
        }
    }

    protected override void AttackRight()
    {
        if (attackable && attackable.SecondWeapon)
            attackable.SecondWeapon.SecondAttack.Attack();
    }

    protected override void Dash()
    {
        if (dashable)
        {
            animator.SetFloat("Run", 0f);
            animator.SetTrigger("Dash");
            
            StartCoroutine(dashable.Dash());
        }
    }

    private void OpenInventory()
    {
        InventoryUIManager.GetInstance().OpenInventory();
    }

    /// -----------------------------------------------------
    /// FOCUS INVENTORY
    protected void ThrowItem()
    {
        var inv = GetComponent<Inventory>();

        inv.Throw(inv._ChoosedItem);
    }

    protected void NavigateByInventoryMenu()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A))
        {
            var inv = GetComponent<Inventory>();

            Iterator it = new(inv);

            if (!it._Item) return;

            if (inv._ChoosedItem)
                it.SetItem(inv._ChoosedItem);
            else
            {
                inv._ChoosedItem = it._Item;
                return;
            }

            it--;

            if (it._Item)
                inv._ChoosedItem = it._Item;

        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            var inv = GetComponent<Inventory>();
            Iterator it = new(inv);

            if (!it._Item) return;

            if (inv._ChoosedItem)
                it.SetItem(inv._ChoosedItem);
            else
            {
                inv._ChoosedItem = it._Item;
                return;
            }

            it++;

            if (it._Item)
                inv._ChoosedItem = it._Item;
        }
    }
}
