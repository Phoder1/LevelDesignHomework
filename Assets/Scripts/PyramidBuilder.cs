using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class PyramidBuilder : MonoBehaviour {
    [SerializeField]
    MeshFilter meshFilter;
    [SerializeField]
    float baseSize = 20;
    float lastFrameBasesize;
    [SerializeField]
    bool inverse = true;
    bool lastFrameInverse;

    Mesh mesh;
    int[] triangles;
    Vector3[] vertices;

    static readonly float SqrtGoldenRatio = Mathf.Sqrt((1 + Mathf.Sqrt(5)) / 2);
    // Start is called before the first frame update
    void Start() {
        
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        BuildPyramid();
        SaveChanges();
    }

    private void Update() {
        if (DataChanged()) {
            SaveChanges();
            BuildPyramid();
        }
    }

    bool DataChanged() {
        return lastFrameBasesize != baseSize || lastFrameInverse != inverse;
    }
    void SaveChanges() {
        lastFrameBasesize = baseSize;
        lastFrameInverse = inverse;
    }

    private void BuildPyramid() {
        vertices = new Vector3[5]{
            new Vector3(-baseSize/2, 0, baseSize/2),
            new Vector3(baseSize/2, 0, baseSize/2),
            new Vector3(-baseSize/2, 0, -baseSize/2),
            new Vector3(baseSize/2, 0, -baseSize/2),
            Vector3.up * baseSize/2 * SqrtGoldenRatio
        };


        triangles = new int[] { 0, 1, 2, 1, 3, 2, 0, 4, 1, 1, 4, 3, 3, 4, 2, 2, 4, 0 };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }


}
