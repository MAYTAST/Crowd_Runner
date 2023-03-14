using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager _instance;
    [Header("Elemets")]
    [SerializeField] private Chunk[] _chunkPrefabOrdered;
    [SerializeField] private Chunk[] _chunkPrefabRandom;
    [SerializeField] Chunk StartChunk;
    private GameObject finishLine;
    private void Awake()
    {
        if (_instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        GenrateOrderedLevel();
        finishLine = GameObject.FindWithTag("Finish");
    }
    void GenrateOrderedLevel()
    {
        Vector3 chunkPos = Vector3.zero;
        for (int i = 0; i <_chunkPrefabOrdered.Length; i++)
        {
            Chunk chunkToCreate = _chunkPrefabOrdered[i];
            if (i > 0)
            {
                chunkPos.z += chunkToCreate.GetChunkLength() / 2;
            }
            Chunk ChunkInstance = Instantiate(chunkToCreate, chunkPos, Quaternion.identity, transform);
            chunkPos.z += chunkToCreate.GetChunkLength() / 2;
        }
    }
    void GenrateRandomLevel()
    {
        Vector3 chunkPos = Vector3.zero;
        for (int i = 0; i < 10; i++)
        {
            Chunk chunkToCreate = _chunkPrefabRandom[Random.Range(0, _chunkPrefabRandom.Length)];
            if (i > 0)
            {
                chunkPos.z += chunkToCreate.GetChunkLength() / 2;
            }
            Chunk ChunkInstance = Instantiate(chunkToCreate, chunkPos, Quaternion.identity, transform);
            chunkPos.z += chunkToCreate.GetChunkLength() / 2;
        }
    }
    public float GetFinishLineZpos()
    {
        return finishLine.transform.position.z;
    }
}
