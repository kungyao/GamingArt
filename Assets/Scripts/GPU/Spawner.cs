using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjData
{
    public Vector3 _pos;
    public Vector3 _scale;
    public Quaternion _rot;

    public Matrix4x4 Matrix4X4
    {
        get
        {
            return Matrix4x4.TRS(_pos, _rot, _scale);
        }
    }

    public ObjData(Vector3 pos, Vector3 scale, Quaternion rot)
    {
        _pos = pos;
        _scale = scale;
        _rot = rot;
    }
}

public class Spawner : MonoBehaviour
{
    public int _count;
    public Vector3 _maxPos;
    public Mesh _objMesh;
    public Material _mat;

    private List<List<ObjData>> batches = new List<List<ObjData>>();
    // Start is called before the first frame update
    void Start()
    {
        int batchIndex = 0;
        List<ObjData> cur = new List<ObjData>();
        for(int i=0;i< _count; i++)
        {
            AddObj(cur, i);
            batchIndex++;
            if (batchIndex >= 1000)
            {
                batches.Add(cur);
                cur = BuildNewBatch();
                batchIndex = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RenderBatching();
    }

    void AddObj(List<ObjData> cur, int index)
    {
        Vector3 pos = new Vector3(Random.Range(-_maxPos.x, _maxPos.x), Random.Range(-_maxPos.y, _maxPos.y), Random.Range(-_maxPos.z, _maxPos.z));
        cur.Add(new ObjData(pos, new Vector3(20, 20, 20), Quaternion.identity));
    }

    List<ObjData> BuildNewBatch()
    {
        return new List<ObjData>();
    }

    void RenderBatching()
    {
        foreach (var batch in batches)
        {
            Graphics.DrawMeshInstanced(_objMesh, 0, _mat, batch.Select((a) => a.Matrix4X4).ToList());
        }
    }

}
