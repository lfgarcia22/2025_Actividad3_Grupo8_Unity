using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] public GameObject inventoryBorderUi;
    [SerializeField] public Button[] itemButtons;
    [SerializeField] public GameObject weaponLocationBorderUi;
    [SerializeField] public GameObject weaponIcon;
    [SerializeField] public Button[] weaponLocationButtons;


    private int availableButtons = 0;

    public void ToggleShowInventoryUI()
    {
        Debug.Log("InventoryUI - ShowInventory");
        inventoryBorderUi.SetActive(!inventoryBorderUi.activeSelf);
    }

    public void InventoryButtonCliked(int index, ItemSO item)
    {
        Debug.Log("InventoryButtonCliked: " + item.ToString());

        switch (item.type)
        {
            case ItemType.Weapon:
                SelectItemWeapon(item);
                break;
            case ItemType.Armor:
                SelectItemArmor(item);
                break;
            case ItemType.Consumable:
                break;
        }

        RemoveItem(index);
    }

    public void AddItem(ItemSO item)
    {
        Debug.Log("InventoryUI - AddItem: " + item.type);
        int currentIndex = availableButtons;
        ItemSO currentItem = item;

        itemButtons[currentIndex].gameObject.SetActive(true);
        itemButtons[currentIndex].GetComponent<Image>().sprite = currentItem.icon;
        itemButtons[currentIndex].onClick.RemoveAllListeners();
        itemButtons[currentIndex].onClick.AddListener(() => InventoryButtonCliked(currentIndex, currentItem));

        availableButtons++;
    }

    public void RemoveItem(int index)
    {
        Debug.Log("InventoryUI - RemoveItem: " + index);
        itemButtons[index].GetComponent<Image>().sprite = null;
        itemButtons[index].onClick.RemoveAllListeners();
        itemButtons[index].gameObject.SetActive(false);
        availableButtons--;

        inventoryBorderUi.SetActive(false);
        Debug.Log("availableButtons: " + availableButtons);
    }

    public void SelectItemWeapon(ItemSO item)
    {
        Debug.Log("InventoryUI - SelectItemWeapon: " + item.nameItem);
        ItemSO localItem = item;
        weaponLocationBorderUi.SetActive(true);
        weaponIcon.GetComponent<Image>().sprite = localItem.icon;

        for (int i = 0; i < weaponLocationButtons.Length; i++)
        {
            int index = i;
            weaponLocationButtons[index].onClick.RemoveAllListeners();
            weaponLocationButtons[index].onClick.AddListener(() => SelectWeaponLocation(index, localItem));
        }
    }

    public void SelectItemArmor(ItemSO item)
    {
        Debug.Log("InventoryUI - SelectItemArmor: " + item.nameItem);
    }

    public void SelectWeaponLocation(int index, ItemSO item)
    {
        Debug.Log("InventoryUI - SelectWeaponLocation: " + item.nameItem);
        
    }
}
