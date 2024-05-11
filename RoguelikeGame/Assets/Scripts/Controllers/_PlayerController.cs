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

        MOUSE0 = null;
        SPACE = null;
        E = null;
        I = null;
        WASD = null;

        switch (focus)
        {
            case Focus.EMPTY:
                break;

            case Focus.GAME:
                MOUSE0 = Attack;
                SPACE = Dash;
                E = Interact;
                I = OpenInventory;
                WASD = Move;
                break;

            case Focus.INVENTORY:
                SPACE = ThrowItem;
                I = OpenInventory;
                WASD = NavigateByInventoryMenu;
                break;
        }
    }

    protected void FixedUpdate()
    {
<<<<<<< Updated upstream
        if (movable != null)
            Move();
=======
        if (_CurrentFocus == Focus.GAME)
            WASD?.Invoke();
>>>>>>> Stashed changes
    }

    [SerializeField] GameObject obj;

    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
<<<<<<< Updated upstream
            attackable.FirstWeapon.FirstAttack.Attack();

        if (Input.GetMouseButtonDown(1))
            attackable.SecondWeapon.SecondAttack.Attack();
=======
            MOUSE0?.Invoke();
>>>>>>> Stashed changes

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
    ControllerMethod MOUSE0;
    ControllerMethod SPACE;
    ControllerMethod E;
    ControllerMethod I;
    ControllerMethod WASD;

    /// ------------------------------------------------------
    /// FOCUS GAME
    protected override void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movable.Move(x, z);
    }

    protected override void Attack()
    {
        if (attackable != null)
            attackable.Attack();
    }

    protected override void Dash()
    {
        if (dashable)
            StartCoroutine(dashable.Dash());
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

    //private void OnDrawGizmos()
    //{
    //   Gizmos.DrawSphere(transform.position, _InteractionRadius);
    //}

    // not work -------------------------------------------------------------
    /*
    private void GetFirstInteractableObject()
    {
        Physics.OverlapSphereNonAlloc(transform.position, InteractionRadius, Colliders);

        foreach (var collider in Colliders)
            if (collider && collider.TryGetComponent<IInteractable>(out var interactable))
            {
                Debug.Log("press E to Interact with " + interactable.name);
                Array.Clear(Colliders, 0, Colliders.Length);
                return;
            }

        Array.Clear(Colliders, 0, Colliders.Length);
    }
    */
}
