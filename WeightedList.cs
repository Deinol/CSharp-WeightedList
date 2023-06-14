using System;
using System.Collections.Generic;

[Serializable]
public class WeightedItem<T>
{
    public T item;
    public float weight;
}

[Serializable]
public class WeightedList<T>
{
    public List<WeightedItem<T>> items;

    public WeightedList()
    {
        items = new List<WeightedItem<T>>();
    }

    public void Add(T item, float weight)
    {
        items.Add(new WeightedItem<T> { item = item, weight = weight });
    }

    public T GetRandom()
    {
        if (items.Count == 0) return default;

        float totalWeight = 0f;
        for (int i = 0; i < items.Count; i++)
        {
            WeightedItem<T> weightedItem = items[i];
            totalWeight += weightedItem.weight;
        }

        Random random = new Random();
        float randomValue = (float)(random.NextDouble() * totalWeight);

        for (int i = 0; i < items.Count; i++)
        {
            WeightedItem<T> weightedItem = items[i];
            randomValue -= weightedItem.weight;
            if (randomValue <= 0f) return weightedItem.item;
        }

        return items[0].item;//In case of any errors, return first item as fallback
    }
}