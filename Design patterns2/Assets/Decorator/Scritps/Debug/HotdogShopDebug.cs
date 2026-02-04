using UnityEngine;

public class HotdogShopDebug : MonoBehaviour
{
    [SerializeField] HotdogDataSO _classicData;
    [SerializeField] HotdogDataSO _caesarData;
    [SerializeField] HotdogDataSO _meatData;
    [SerializeField] IngredientDataSO _picklesData;
    [SerializeField] IngredientDataSO _onionData;

    void Start()
    {
        Debug.Log("Меню:");
        if (_classicData != null) PrintInfo(new ClassicHotdog(_classicData));
        if (_caesarData != null) PrintInfo(new CaesarHotdog(_caesarData));
        if (_meatData != null) PrintInfo(new MeatHotdog(_meatData));
    }

    void PrintInfo(Hotdog baseHotdog)
    {
        if (_picklesData == null || _onionData == null) return;
        Hotdog withSalad = new IngredientDecorator(baseHotdog, _picklesData);
        Hotdog withMeat = new IngredientDecorator(baseHotdog, _onionData);

        string output = 
            $"--- {baseHotdog.GetName()} ---\n" + 
            $"Базовая цена: {FormatString(baseHotdog)}\n" +
            $"Добавки:\n" +
            $"1. {FormatString(withSalad)}\n" +
            $"2. {FormatString(withMeat)}\n";

        Debug.Log(output);
    }

    string FormatString(Hotdog h)
    {
        return $"{h.GetName()} ({h.GetWeight()}г) — {h.GetCost()}р.";
    }
}
