using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PaperCluesManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnLocations = new List<Transform>();
    [SerializeField] private GameObject _fakePaper;
    [SerializeField] private GameObject _realPaper;

    public void Start()
    {
        int realPaperLocation = Random.Range(0, _spawnLocations.Count);
        for(int i = 0; i < _spawnLocations.Count; i++)
        {
            if(i == realPaperLocation)
            {
                Instantiate(_realPaper, _spawnLocations[i].position, Quaternion.identity);
                continue;
            }

            Instantiate(_fakePaper, _spawnLocations[i].position, Quaternion.identity);
        }
    }
}
