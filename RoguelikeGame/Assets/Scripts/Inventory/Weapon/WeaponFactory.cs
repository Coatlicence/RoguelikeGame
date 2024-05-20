using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Unity.Barracuda;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class WeaponFactory : MonoBehaviour
{
    //�������� ������ �����
    public List<GameObject> guarts;
    public List<GameObject> blades;
    public List<GameObject> hilts;
    public List<string> NamesOfSwords;

    //�������� ������ �����
    public List<GameObject> pommels;
    public List<GameObject> spearheads;
    public List<GameObject> shafts;
    public List<string> NamesOfSpears;

    //�������� ������ �������
    public List<GameObject> handles;
    public List<GameObject> counterweights;
    public List<GameObject> axeBlades;
    public List<GameObject> axePommels;
    public List<string> NamesOfAxes;

    public List<string> NamesOfBows;
    GameObject empty;
    GameObject emptyTrue;
    //static WeaponGenerator weaponGenerator;

    // Start is called before the first frame update
    void Awake()
    {
        //�������� ������� ��� ��������� ������

        //������ ������
        empty = Resources.Load<GameObject>("empty/Empty");
        emptyTrue = Resources.Load<GameObject>("empty/EmptyTrue");
        //������ ��� �����
        blades = Resources.LoadAll<GameObject>("Swords/Blades").ToList<GameObject>();
        guarts = Resources.LoadAll<GameObject>("Swords/Guarts").ToList<GameObject>();
        hilts = Resources.LoadAll<GameObject>("Swords/Hilts").ToList<GameObject>();

        //������ ��� �����
        pommels = Resources.LoadAll<GameObject>("Spears/Pommels").ToList<GameObject>();
        spearheads = Resources.LoadAll<GameObject>("Spears/spearhead").ToList<GameObject>();
        shafts = Resources.LoadAll<GameObject>("Spears/Shafts").ToList<GameObject>();

        //Mo���� ��� �������
        handles = Resources.LoadAll<GameObject>("Axes/handles").ToList<GameObject>();
        counterweights = Resources.LoadAll<GameObject>("Axes/counterweight").ToList<GameObject>();
        axeBlades = Resources.LoadAll<GameObject>("Axes/axeBlades").ToList<GameObject>();
        axePommels = Resources.LoadAll<GameObject>("Axes/Pommels").ToList<GameObject>();



        //��������� �������� ����� �� �����
        StreamReader inp_stm = new StreamReader("Assets/Models/WeaponParts/Resources/Swords/namesOfSwords.txt");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            NamesOfSwords.Add(inp_ln);
        }
        inp_stm.Close();


        //��������� �������� ����� �� �����
        inp_stm = new StreamReader("Assets/Models/WeaponParts/Resources/Spears/namesOfSpears.txt");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            NamesOfSpears.Add(inp_ln);
        }
        inp_stm.Close();

        //��������� �������� ������� �� �����
        inp_stm = new StreamReader("Assets/Models/WeaponParts/Resources/Axes/namesOfAxes.txt");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            NamesOfAxes.Add(inp_ln);
        }
        inp_stm.Close();
        inp_stm = new StreamReader("Assets/Models/WeaponParts/Resources/Bows/namesOfBows.txt");

        //��������� �������� ����� �� �����
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            NamesOfBows.Add(inp_ln);
        }
        inp_stm.Close();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.J))
        //{
            
        //    CreateRandomWeapon(0, new Vector3(3.22f,0.32f,-3.44f),Quaternion.identity);
        //}
    }

    [System.Obsolete]
    public GameObject CreateRandomWeapon(int numOfStage, Vector3 pos, Quaternion quaternion)
    {
        GameObject model =null;

        int tmpDurabilityMax;
        //� ����������� �� ������� ������ ������ ��� ������
        float multiplierOfDurability;
        switch (numOfStage)
        {
            case 0:
                multiplierOfDurability = 0.4f;
                switch (Random.Range(0, 3))
                {
                    
                    case 0:
                        model = GenerateSwordModel(pos, quaternion);
                        //model.AddComponent<Weapon>();
                        SetSwordParametr(model, Random.Range(10, 20), Random.Range(0, 9), (uint)Random.Range(0, 100), Random.Range(50, 100), multiplierOfDurability);
                        break;
                    case 1:
                        model = GenerateSpearModel(pos, quaternion);
                        //model.AddComponent<Weapon>();
                        SetSpearParametr(model, Random.Range(5, 12), Random.Range(0, 4), (uint)Random.Range(0, 75), Random.Range(25, 75), multiplierOfDurability);
                        break;
                    case 2:
                        model = GenerateAxeModel(pos, quaternion);
                        //model.AddComponent<Weapon>();
                        SetAxeParametr(model,Random.Range(20,30),Random.Range(20, 19), (uint)Random.Range(0, 150),Random.Range(75,200),multiplierOfDurability);
                        break;
                    case 3:
                        model = GenerateBowModel(pos);
                        model.AddComponent<RangeWeapon>();

                        break;
                }

                break;
            case 1:

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;

        }
        return model;
    }
    void SetBaseParametrs(ref Weapon tmpMeleeWeapon, int MaxDamage, int MinDamage, uint price, int durabilityMax, float multiplierOfDurability)
    {
        tmpMeleeWeapon.SetMaxDamage(MaxDamage);
        tmpMeleeWeapon.SetMinDamage(MinDamage);
        tmpMeleeWeapon.SetPrice(price);
        tmpMeleeWeapon.SetDurabilityMax(durabilityMax);
        tmpMeleeWeapon.SetDurability(Random.Range((int)(multiplierOfDurability * (double)durabilityMax), durabilityMax));
    }

    void SetHandlers(ref Weapon tmpMeleeWeapon,float sumBoost,float delayTime,int minNumsOfUpdate,int MaxNumsOfUpdate)
    {
        BaseAttack baseAttack = new BaseAttack();
        DoDamage oNPress = new DoDamage();
        oNPress.weapon = tmpMeleeWeapon;

        switch (Random.Range(0, 2))
        {
            case 0:
                baseAttack.PressHandler = oNPress;
                tmpMeleeWeapon.FirstAttack = baseAttack;
                break;
            case 1:
                oNPress._damageBoost = (Random.value + sumBoost) / 4;
                Increase onIncreace = new Increase();
                onIncreace.doDamage = oNPress;
                onIncreace._stepIUp = Random.value + delayTime;
                onIncreace.NumTolnc = Random.Range(minNumsOfUpdate, MaxNumsOfUpdate);


                baseAttack.HoldHandler = onIncreace;
                baseAttack.ReleaseHandler = oNPress;
                tmpMeleeWeapon.FirstAttack = baseAttack;

                break;

        }
    }

    void SetSwordParametr(GameObject model, int MaxDamage, int MinDamage, uint price, int durabilityMax, float multiplierOfDurability)
    {
        Weapon tmpMeleeWeapon = model.GetComponent<Weapon>();
        SetBaseParametrs(ref tmpMeleeWeapon, MaxDamage, MinDamage, price, durabilityMax, multiplierOfDurability);

        tmpMeleeWeapon.SetModel(model);
        tmpMeleeWeapon.SetLore("Just simple sword.");
        tmpMeleeWeapon.SetName(NamesOfSwords[Random.Range(0, NamesOfSwords.Count)]);
        tmpMeleeWeapon.SetRange(Random.Range(1, 2));
        tmpMeleeWeapon.SetDelayTime(Random.Range(2, 4));
        tmpMeleeWeapon.SetKnockback(Random.Range(0, 5));

        SetHandlers(ref tmpMeleeWeapon, 0.4f, 0.2f, 2, 6);
    }

    void SetSpearParametr(GameObject model, int MaxDamage, int MinDamage, uint price, int durabilityMax, float multiplierOfDurability)
    {
        Weapon tmpMeleeWeapon = model.GetComponent<Weapon>();
        SetBaseParametrs(ref tmpMeleeWeapon, MaxDamage, MinDamage, price, durabilityMax, multiplierOfDurability);

        tmpMeleeWeapon.SetModel(model);
        tmpMeleeWeapon.SetRange(Random.Range(3, 5));
        tmpMeleeWeapon.SetDelayTime(Random.Range(1, 3));
        tmpMeleeWeapon.SetKnockback(Random.Range(0, 3));
        tmpMeleeWeapon.SetLore("Just simple spear.");
        SetHandlers(ref tmpMeleeWeapon, 0.2f, 0.1f, 1, 4);

    }
    void SetAxeParametr(GameObject model, int MaxDamage, int MinDamage, uint price, int durabilityMax, float multiplierOfDurability)
    {
        Weapon tmpMeleeWeapon = model.GetComponent< Weapon>();
        SetBaseParametrs(ref tmpMeleeWeapon, MaxDamage, MinDamage, price, durabilityMax, multiplierOfDurability);

        tmpMeleeWeapon.SetRange(Random.Range(1, 3));
        tmpMeleeWeapon.SetDelayTime(Random.Range(3, 6));
        tmpMeleeWeapon.SetKnockback(Random.Range(2, 8));
        tmpMeleeWeapon.SetName(NamesOfAxes[Random.Range(0, NamesOfAxes.Count)]);
        tmpMeleeWeapon.SetLore("Just simple Axe.");
        tmpMeleeWeapon.SetModel(model);

        SetHandlers(ref tmpMeleeWeapon, 1f, 0.5f, 3, 8);
    }
    void SetBowParametr(GameObject model, int MaxDamage, int MinDamage, uint price, int durabilityMax, float multiplierOfDurability)
    {
        BaseAttack baseAttack = new BaseAttack();
        DoDamage oNPress = new DoDamage(); 

        RangeWeapon tmpRangeWeapon = model.GetComponent<RangeWeapon>();
        tmpRangeWeapon.SetMaxDamage(Random.Range(20, 25));
        tmpRangeWeapon.SetMinDamage(Random.Range(0, 10));
        tmpRangeWeapon.SetRange(Random.Range(2, 5));
        tmpRangeWeapon.SetDelayTime(Random.Range(10, 15));
        tmpRangeWeapon.SetKnockback(Random.Range(2, 8));
        tmpRangeWeapon.SetName(NamesOfBows[Random.Range(0, NamesOfBows.Count)]);
        tmpRangeWeapon.SetPrice((uint)Random.Range(0, 150));
        tmpRangeWeapon.SetDurabilityMax(durabilityMax);
        tmpRangeWeapon.SetDurability(Random.Range((int)(0.3 * (double)durabilityMax), durabilityMax));
        tmpRangeWeapon.SetLore("Just simple Bows.");

        oNPress.weapon = tmpRangeWeapon;
        baseAttack.PressHandler = oNPress;
        tmpRangeWeapon.FirstAttack = baseAttack;
    }
    GameObject GenerateSwordModel(Vector3 pos, Quaternion quaternion)
    {
        GameObject weapon = Instantiate(empty, pos, Quaternion.identity);
        GameObject Sword = Instantiate(emptyTrue, Vector3.zero, Quaternion.identity);
        GameObject randomGuard = GetRandomPart(guarts);
        GameObject Guart = Instantiate(randomGuard, Vector3.zero, Quaternion.identity);
        WeaponBody SWBody = Guart.GetComponent<WeaponBody>();
        Guart.transform.parent = Sword.transform;

        GameObject randomBlade = GetRandomPart(blades);
        GameObject blade=Instantiate(randomBlade, SWBody.UpSocket.position, Quaternion.identity);
        blade.transform.parent = Sword.transform;
        
        GameObject randomHilt = GetRandomPart(hilts);
        GameObject hilt = Instantiate(randomHilt, SWBody.DownSocket.position, Quaternion.identity);
        hilt.transform.parent = Sword.transform;

        Sword.transform.parent =weapon.transform;

        //Sword.AddComponent<MeshCompile>();


        return weapon;
    }

    GameObject GenerateSpearModel(Vector3 pos, Quaternion quaternion)
    {
        GameObject weapon = Instantiate(empty, pos, Quaternion.identity);
        GameObject Spear = Instantiate(emptyTrue, pos, Quaternion.identity);
        GameObject shaft = GetRandomPart(shafts);
        shaft = Instantiate(shaft,pos, Quaternion.identity);
        WeaponBody body = shaft.GetComponent<WeaponBody>();
        shaft.transform.parent = Spear.transform;

        GameObject spearhead = GetRandomPart(spearheads);
        spearhead = Instantiate(spearhead, body.UpSocket.position, Quaternion.identity);
        spearhead.transform.parent = Spear.transform;

        GameObject pommel = GetRandomPart(pommels);
        pommel = Instantiate(pommel, body.DownSocket.position, Quaternion.identity);
        pommel.transform.parent = Spear.transform;

        Spear.transform.parent = weapon.transform;
        return weapon;
    }
    GameObject GenerateAxeModel(Vector3 pos, Quaternion quaternion)
    {
        GameObject weapon = Instantiate(empty, pos, Quaternion.identity);

        GameObject Axe = Instantiate(empty, pos, Quaternion.identity);
        GameObject handle = GetRandomPart(handles);
        handle = Instantiate(handle,pos,Quaternion.identity);
        WeaponBody body = handle.GetComponent<WeaponBody>();
        handle.transform.parent = Axe.transform;

        GameObject blade = GetRandomPart(axeBlades);
        blade = Instantiate(blade, body.UpSocket.position, Quaternion.identity);
        blade.transform.parent = Axe.transform;

        GameObject counterweight = GetRandomPart(counterweights);
        counterweight=Instantiate(counterweight, body.UpSocketRight.position, Quaternion.identity);
        counterweight.transform.parent = Axe.transform;

        GameObject pommel = GetRandomPart(axePommels);
        pommel = Instantiate(pommel,body.DownSocket.position, Quaternion.identity);
        pommel.transform.parent= Axe.transform;

        Axe.transform.parent = weapon.transform;

        return weapon;
    }
    GameObject GenerateBowModel(Vector3 pos)
    {
        GameObject Bow = Instantiate(empty, pos, Quaternion.identity);
        return Bow;
    }

    GameObject GenerateCrossbowModel(Vector3 pos)
    {
        GameObject CrossBow = Instantiate(empty, pos, Quaternion.identity);
        return CrossBow;
    }
    GameObject GenerateGunModel(Vector3 pos)
    {
        GameObject Gun = Instantiate(empty, pos, Quaternion.identity);
        return Gun;

    }

    GameObject GetRandomPart(List<GameObject> part)
    {
        int rndNumder = Random.Range(0, part.Count);
        return part[rndNumder];
    }
}
