using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Workbench : MonoBehaviour
{
    //Button okButton;

    public VisualTreeAsset itemsListTemplate;   //uxml-������ ��������� ������
    Inventory _inventory;
    List<Item> items;//������ �������
    ListView itemsListView;
    void OnEnable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.CRAFT);
        //�������� ������ �� ��������� UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //������� ������ ����� ��������, � �������� �������� ��� ������
        //okButton = uiDocument.rootVisualElement.Q<Button>("okButton");
        //������������ ������� ������� ������
        //okButton.RegisterCallback<ClickEvent>(ClickMessage);


        //�������� �� �������
        //1. �������������� ������ �������
        _inventory = GetComponentInParent<Inventory>();
        items = _inventory.GetItemsList();


        //2. ������� ������������ ������ �� ��������
        itemsListView = uiDocument.rootVisualElement.Q<ListView>("Items");

        //3. ��������� ������ ��������� ������ � ����� �������
        itemsListView.makeItem = () =>
        {
            return itemsListTemplate.Instantiate();
        };
        //��������� ������ ������� �� �������

        //4. ��������� ������ � ������������ �������
        itemsListView.bindItem = (_item, _index) =>
        {
            var item = items[_index];
            //�������� ������ � ���������� ��������� ������� �� ������, ������� �� ������� � �������
            _item.Q<Label>("name").text = item._Name;
            _item.Q<VisualElement>("Icon").style.backgroundImage =new StyleBackground( item._Icon);
        };

        //����� ��� ����������
        itemsListView.itemsSource = items;

        //5. ������������ ������� ������ �� ������
        itemsListView.onSelectionChange += ItemsListView_onSelectionChange;

    }
    void OnDisable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.GAME);
    }
    private void ItemsListView_onSelectionChange(IEnumerable<object> obj)
    {
        if (obj.Count() > 0)
        {
            var item = obj.First() as Item;
            //Debug.Log($"{item.Name}: {item.Price} ���");
        }
    }

    void ClickMessage(ClickEvent e)
    {
        //��������� ��� ����� �������� ��� ������� ������
        Debug.Log("ok");
    }
}
