using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DoNotCommuteGameRules : MonoBehaviour
{
    public AssetReference m_assetReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnEnable()
    {
        Addressables.InstantiateAsync(m_assetReference).Completed += OnPlayerInstanciated;
    }

    private void OnPlayerInstanciated(AsyncOperationHandle<GameObject> handle)
    {
        GameObject go = handle.Result;
    }
}
