using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Workbench : MonoBehaviour
{
    //Button okButton;

    public VisualTreeAsset itemsListTemplate;   //uxml-шаблон элементов списка
    Inventory _inventory;
    List<Item> items;//список товаров
    ListView itemsListView;
    void OnEnable()
    {
        _PlayerController._Instance.SetFocus(_PlayerController.Focus.CRAFT);
        //Получаем ссылку на компонент UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //Находим кнопку таким запросом, в параметр передаем имя кнопки
        //okButton = uiDocument.rootVisualElement.Q<Button>("okButton");
        //Регистрируем событие нажатия кнопки
        //okButton.RegisterCallback<ClickEvent>(ClickMessage);


        //Работаем со списком
        //1. Инициализируем список товаров
        _inventory = GetComponentInParent<Inventory>();
        items = _inventory.GetItemsList();


        //2. Находим отображаемый список на странице
        itemsListView = uiDocument.rootVisualElement.Q<ListView>("Items");

        //3. Связываем шаблон элементов списка с самим списком
        itemsListView.makeItem = () =>
        {
            return itemsListTemplate.Instantiate();
        };
        //Связываем список товаров по индексу

        //4. Связываем данные с отображаемым списком
        itemsListView.bindItem = (_item, _index) =>
        {
            var item = items[_index];
            //Получаем доступ к визуальным элементам шаблона по именам, которые мы указали в шаблоне
            _item.Q<Label>("name").text = item._Name;
            _item.Q<VisualElement>("Icon").style.backgroundImage =new StyleBackground( item.Icon);
        };

        //Здесь все стандартно
        itemsListView.itemsSource = items;

        //5. Регистрируем событие выбора из списка
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
            //Debug.Log($"{item.Name}: {item.Price} руб");
        }
    }

    void ClickMessage(ClickEvent e)
    {
        //Реализуем тут любые действия при нажатии кнопки
        Debug.Log("ok");
    }
}
