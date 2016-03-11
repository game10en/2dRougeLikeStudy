using UnityEngine;
using System.Collections;

public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

// Custom serializable class
[System.Serializable]
public class Ingredient : System.Object
{
    string name;
    int amount = 1;
    IngredientUnit unit;
}

public class ForTest : MonoBehaviour
{
    public Ingredient potionResult;
    public  Ingredient[] potionIngredients;

    void Update()
    {
        // Update logic here...
    }
}
