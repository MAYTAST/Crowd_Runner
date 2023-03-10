using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elemets")]
    [SerializeField] private Chunk[] _chunkPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 chunkPos = Vector3.zero;
        for (int i = 0; i < 5; i++)
        {
            Chunk chunkToCreate = _chunkPrefab[Random.Range(0, _chunkPrefab.Length)];
            if(i>0)
            chunkPos.z += chunkToCreate.GetChunkLength() / 2;
            Chunk ChunkInstance = Instantiate(chunkToCreate, chunkPos,Quaternion.identity, transform);
            chunkPos.z += chunkToCreate.GetChunkLength()/2;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
