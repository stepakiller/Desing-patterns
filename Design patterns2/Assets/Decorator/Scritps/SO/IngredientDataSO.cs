using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredientData", menuName = "Hotdogs/Ingredient Data")]
public class IngredientDataSO : ScriptableObject
{
    [SerializeField] string _ingredientNameSuffix;
    [SerializeField] int _addedCost;
    [SerializeField] int _addedWeight;
    public string IngredientNameSuffix => _ingredientNameSuffix;
    public int AddedCost => _addedCost;
    public int AddedWeight => _addedWeight;
}
