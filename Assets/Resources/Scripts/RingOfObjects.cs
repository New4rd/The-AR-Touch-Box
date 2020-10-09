using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfObjects : MonoBehaviour
{
    static private RingOfObjects _inst;
    static public RingOfObjects Inst
    {
        get { return _inst; }
    }


    /// <summary>
    /// Objet à instancier en formation d'anneau
    /// </summary>
    public GameObject objectRing;

    private List<GameObject> _listRing;
    public List<GameObject> listRing
    {
        get { return _listRing; }
    }

    private void Awake()
    {
        _inst = this;
        _listRing = new List<GameObject>();
    }


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => objectRing != null);

        GameObject rings = new GameObject("rings");

        rings.transform.parent = this.transform;

        for (float i = 0; i < 2 * Mathf.PI; i += Mathf.PI / 3)
        {
            Vector3 pos = new Vector3(Mathf.Cos(i)/6, transform.position.y+.05f, Mathf.Sin(i)/6);
            GameObject inst = Instantiate(objectRing, pos, Quaternion.identity);
            inst.transform.parent = rings.transform;
            _listRing.Add(inst);
        }

        rings.AddComponent<MoveObject>();
        rings.GetComponent<MoveObject>().rotating = true;
        rings.GetComponent<MoveObject>().rotatingSpeed = GetComponent<MoveObject>().rotatingSpeed * -2 * Time.deltaTime;
    }
}
