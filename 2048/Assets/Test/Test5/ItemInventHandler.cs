using UnityEngine;
using System;

public class ItemInventHandler : MonoBehaviour
{
    [SerializeField] private ItemInventView prefab;
    [SerializeField] private Transform container;
    [SerializeField] private ItemDataCollection Collection;

    public event Action<ItemInventView> OnItemClicked;

    private void Start()
    {
        foreach (var item in Collection.GetAllInventoryItem())
        {
            ItemInventView newView = Instantiate(prefab, container);

            newView.Init(item);
            newView.OnItemClicked += OnItemClickedHandler;
        }
    }

    private void OnItemClickedHandler(ItemInventView view)
    {
        OnItemClicked?.Invoke(view);
    }
}
