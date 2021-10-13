using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ObjectSpawner : MonoBehaviour
{
	public KeyCode spawnKey;
	public GameObject prefabToInstantiate;
	public int objectCount = 1;
	private GameObject[] spawnedObjects = {};

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown(spawnKey))
	    {
			DestroyObjects(spawnedObjects);
			spawnedObjects = InstantiateObjects(objectCount, prefabToInstantiate);
	    }

	    if (Input.GetKeyDown(KeyCode.D))
	    {
		    DestroyObjects(spawnedObjects);
		}

		TranslateObjectsSinus(spawnedObjects);
	}

	/// <summary>
	/// Instantiates game objects of a given type.
	/// </summary>
    private GameObject[] InstantiateObjects(int count, GameObject prefab)
    {
	    GameObject[] gameObjects = new GameObject[count * count];

	    for (int i = 0; i < count; i++)
	    {
		    for (int j = 0; j < count; j++)
		    {
				gameObjects[i * count + j] = Instantiate(prefab);
				gameObjects[i * count + j].transform.position = new Vector3(j * 1.5f, 0, i * 1.5f);
			}
		}

	    return gameObjects;
    }

	/// <summary>
	/// Returns true if at least one object was destroyed.
	/// </summary>
    private bool DestroyObjects(GameObject[] objectsToDestroy)
    {
	    if (objectsToDestroy != null && objectsToDestroy.Length > 0)
	    {
		    foreach (GameObject gameObject in objectsToDestroy)
		    {
			    Destroy(gameObject);
		    }

		    return true;
	    }

		return false;
    }

	private void TranslateObjectsSinus(GameObject[] gameObjects)
	{
		foreach (GameObject gameObject in gameObjects)
		{
			if (gameObject != null)
            {
				Vector3 position = gameObject.transform.position;
				position.y = (float)Math.Sin((double)Time.time + position.x);
				gameObject.transform.position = position;
			}
		}
	}
}
