using StalinKilledMelons.Gameplay.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StalinKilledMelons.Gameplay.UI
{
    /// <summary>
    /// Classe responsável pela interface do usuário (UI) do inventário.
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Text itemText; // Referência ao texto para exibir informações do item
        [SerializeField] private Image itemImage; // Referência à imagem para exibir o ícone do item
        [SerializeField] private GameObject inventorySlotPrefab; // Prefab do slot de inventário
        [SerializeField] private Transform inventoryContent; // Referência ao contêiner do inventário

        private InventoryManager inventoryManager; // Referência ao gerenciador de inventário
        private List<InventorySlot> inventorySlots; // Lista de slots de inventário

        private void Start()
        {
            inventoryManager = GetComponent<InventoryManager>();
            inventorySlots = new List<InventorySlot>();
        }

        /// <summary>
        /// Atualiza a UI do inventário.
        /// </summary>
        public void UpdateInventoryUI()
        {
            // Limpa os slots de inventário existentes
            ClearInventoryUI();

            // Obtém todos os itens no inventário
            List<InventoryItem> items = inventoryManager.GetAllItems();

            // Cria um slot de inventário para cada item
            foreach (InventoryItem item in items)
            {
                CreateInventorySlot(item);
            }
        }

        /// <summary>
        /// Cria um slot de inventário para um item.
        /// </summary>
        /// <param name="item">O item para o qual criar o slot de inventário.</param>
        private void CreateInventorySlot(InventoryItem item)
        {
            // Instancia o prefab do slot de inventário
            GameObject slotObject = Instantiate(inventorySlotPrefab, inventoryContent);
            InventorySlot inventorySlot = slotObject.GetComponent<InventorySlot>();

            // Configura o slot de inventário com as informações do item
            inventorySlot.Setup(item, inventoryManager.GetItemQuantity(item), this);

            // Adiciona o slot de inventário à lista
            inventorySlots.Add(inventorySlot);
        }

        /// <summary>
        /// Limpa os slots de inventário da UI.
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
        /// Atualiza a UI para exibir as informações de um item selecionado.
        /// </summary>
        /// <param name="item">O item selecionado.</param>
        public void UpdateSelectedItemUI(InventoryItem item)
        {
            itemText.text = item.ItemName;
            itemImage.sprite = item.Icon;
        }
    }

    /// <summary>
    /// Classe responsável pelo slot de inventário na interface do usuário (UI).
    /// </summary>
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image iconImage; // Referência à imagem para exibir o ícone do item
        [SerializeField] private Text quantityText; // Referência ao texto para exibir a quantidade do item

        private InventoryItem item; // O item associado ao slot
        private int quantity; // A quantidade do item
        private InventoryUI inventoryUI; // Referência à UI do inventário

        /// <summary>
        /// Configura o slot de inventário com as informações do item.
        /// </summary>
        /// <param name="item">O item associado ao slot.</param>
        /// <param name="quantity">A quantidade do item.</param>
        /// <param name="inventoryUI">A referência à UI do inventário.</param>
        public void Setup(InventoryItem item, int quantity, InventoryUI inventoryUI)
        {
            this.item = item;
            this.quantity = quantity;
            this.inventoryUI = inventoryUI;

            UpdateSlotUI();
        }

        /// <summary>
        /// Atualiza a UI do slot de inventário.
        /// </summary>
        private void UpdateSlotUI()
        {
            iconImage.sprite = item.Icon;
            quantityText.text = quantity.ToString();
        }

        /// <summary>
        /// Chamado quando o slot de inventário é clicado.
        /// </summary>
        public void OnClick()
        {
            inventoryUI.UpdateSelectedItemUI(item);
        }
    }
}