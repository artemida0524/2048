using TMPro;
using UnityEngine;

public class GetReceiveCW : MonoBehaviour
{
    public static GetReceiveCW Instance;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        //m_TextMeshPro.text = "";
        m_TextMeshPro.text += logString;
        m_TextMeshPro.text += stackTrace;
    }

}
