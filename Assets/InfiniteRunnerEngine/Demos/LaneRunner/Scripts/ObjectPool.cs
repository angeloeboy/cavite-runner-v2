using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using UnityEngine.SceneManagement;
namespace MoreMountains.InfiniteRunnerEngine
{
    public class ObjectPool : MMSimpleObjectPooler
    {
        // Start is called before the first frame update

        protected override GameObject AddOneObjectToThePool()
        {
            if (GameObjectToPool == null)
            {
                Debug.LogWarning("The " + gameObject.name + " ObjectPooler doesn't have any GameObjectToPool defined.", gameObject);
                return null;
            }
            GameObject newGameObject = (GameObject)Instantiate(GameObjectToPool);
            SceneManager.MoveGameObjectToScene(newGameObject, this.gameObject.scene);

            newGameObject.transform.localScale = GameObjectToPool.transform.localScale; // ensure same scale as the prefab
            Debug.Log(GameObjectToPool.transform.localScale);
            newGameObject.gameObject.SetActive(false);
            if (NestWaitingPool)
            {
                newGameObject.transform.SetParent(_waitingPool.transform);
            }
            newGameObject.name = GameObjectToPool.name + "-" + _pooledGameObjects.Count;

            _pooledGameObjects.Add(newGameObject);

            _objectPool.PooledGameObjects.Add(newGameObject);

            return newGameObject;
        }
        // Update is called once per frame

    }

}
