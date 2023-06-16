using StalinKilledMelons.Gameplay.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe respons�vel pela interface do usu�rio (UI) do invent�rio.
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Text itemText; // Refer�ncia ao texto para exibir informa��es do item
        [SerializeField] private Image itemImage; // Refer�ncia � imagem para exibir o �cone do item
        [SerializeField] private GameObject inventorySlotPrefab; // Prefab do slot de invent�rio
        [SerializeField] private Transform inventoryContent; // Refer�ncia ao cont�iner do invent�rio

        private InventoryManager inventoryManager; // Refer�ncia ao gerenciador de invent�rio
        private List<InventorySlot> inventorySlots; // Lista de slots de invent�rio

        private void Start()
        {
            inventoryManager = GetComponent<InventoryManager>();
            inventorySlots = new List<InventorySlot>();
        }

        /// <summary>
        /// Atualiza a UI do invent�rio.
        /// </summary>
        public void UpdateInventoryUI()
        {
            // Limpa os slots de invent�rio existentes
            ClearInventoryUI();

            // Obt�m todos os itens no invent�rio
            List<InventoryItem> items = inventoryManager.GetAllItems();

            // Cria um slot de invent�rio para cada item
            foreach (InventoryItem item in items)
            {
                CreateInventorySlot(item);
            }
        }

        /// <summary>
        /// Cria um slot de invent�rio para um item.
        /// </summary>
        /// <param name="item">O item para o qual criar o slot de invent�rio.</param>
        private void CreateInventorySlot(InventoryItem item)
        {
            // Instancia o prefab do slot de invent�rio
            GameObject slotObject = Instantiate(inventorySlotPrefab, inventoryContent);
            InventorySlot inventorySlot = slotObject.GetComponent<InventorySlot>();

            // Configura o slot de invent�rio com as informa��es do item
            inventorySlot.Setup(item, inventoryManager.GetItemQuantity(item), this);

            // Adiciona o slot de invent�rio � lista
            inventorySlots.Add(inventorySlot);
        }

        /// <summary>
        /// Limpa os slots de invent�rio da UI.
        /// </summary>
        private void ClearInventoryUI()
        {
            foreach (InventorySlot slot in inventorySlots)
            {
                Destroy(slot.gameObject);
            }

            inventorySlots.Clear();
        }

        /// <summary>
        /// Atualiza a UI para exibir as informa��es de um item selecionado.
        /// </summary>
        /// <param name="item">O item selecionado.</param>
        public void UpdateSelectedItemUI(InventoryItem item)
        {
            itemText.text = item.ItemName;
            itemImage.sprite = item.Icon;
        }
    }

    /// <summary>
    /// Classe respons�vel pelo slot de invent�rio na interface do usu�rio (UI).
    /// </summary>
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image iconImage; // Refer�ncia � imagem para exibir o �cone do item
        [SerializeField] private Text quantityText; // Refer�ncia ao texto para exibir a quantidade do item

        private InventoryItem item; // O item associado ao slot
        private int quantity; // A quantidade do item
        private InventoryUI inventoryUI; // Refer�ncia � UI do invent�rio

        /// <summary>
        /// Configura o slot de invent�rio com as informa��es do item.
        /// </summary>
        /// <param name="item">O item associado ao slot.</param>
        /// <param name="quantity">A quantidade do item.</param>
        /// <param name="inventoryUI">A refer�ncia � UI do invent�rio.</param>
        public void Setup(InventoryItem item, int quantity, InventoryUI inventoryUI)
        {
            this.item = item;
            this.quantity = quantity;
            this.inventoryUI = inventoryUI;

            UpdateSlotUI();
        }

        /// <summary>
        /// Atualiza a UI do slot de invent�rio.
        /// </summary>
        private void UpdateSlotUI()
        {
            iconImage.sprite = item.Icon;
            quantityText.text = quantity.ToString();
        }

        /// <summary>
        /// Chamado quando o slot de invent�rio � clicado.
        /// </summary>
        public void OnClick()
        {
            inventoryUI.UpdateSelectedItemUI(item);
        }
    }
}