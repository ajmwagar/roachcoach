using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FoodMaterializer : MonoBehaviour {

	public Transform materializePoint;

	// Use this for initialization
	void Start ()
	{
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner>();

		foreach(var spawner in spawners)
		{
			spawner.onbuttonpress += MaterializeFood;
		}
	}
	
	public void MaterializeFood(GameObject prefab, Ingredient.ITypes type)
	{
		var obj = Instantiate(prefab, materializePoint.position, materializePoint.rotation);

		var item = obj.GetComponent<IngredientItem>();
        if (item)
        {
            item.type = type;

            NetworkServer.Spawn(obj);
        }

	}

}
