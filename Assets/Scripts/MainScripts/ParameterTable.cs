using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Create ParameterTable", fileName = "ParameterTable")]
public class ParameterTable : ScriptableObject
{
    private static readonly string RESOURCE_PATH = "ParameterTable";

    private static ParameterTable s_instance = null;
    public static ParameterTable Instance
    {
        get
        {
            if (s_instance == null)
            {
                var asset = Resources.Load(RESOURCE_PATH) as ParameterTable;
                if (asset == null)
                {
                    // アセットが指定のパスに無い。
                    // 誰かが勝手に移動させたか、消しやがったな！
                    Debug.AssertFormat(false, "Missing ParameterTable! path={0}", RESOURCE_PATH);
                    asset = CreateInstance<ParameterTable>();
                }

                s_instance = asset;
            }

            return s_instance;
        }
    }


    [SerializeField]
    public int m_maxLife = 100;
    [SerializeField]
    public Vector3 m_defaultPosition = Vector3.zero;
    [SerializeField]
    public float m_maxTime = 180.0f;

} // class ParameterTable