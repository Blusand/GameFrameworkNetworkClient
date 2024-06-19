using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor.NetworkTool
{
    internal sealed class NetworkTool : EditorWindow
    {
        [MenuItem("Game Framework/Network Tools/Protocol Window", false, 0)]
        private static void Open()
        {
            NetworkTool window = GetWindow<NetworkTool>("ProtocolWindow", true);
            window.Show();
        }

        private uint m_Column = 1;

        private class ProtocolData
        {
            public bool IsOn;
            public FileInfo FileInfo;

            public ProtocolData(bool isOn, FileInfo fileInfo)
            {
                IsOn = isOn;
                FileInfo = fileInfo;
            }
        }

        private List<ProtocolData> m_ProtocolDatas;

        private GUIStyle m_NormalStyle;
        private GUIStyle m_SelectedStyle;

        private Vector2 m_ScrollPos;

        /// <summary>
        /// 协议配置文件所在路径
        /// </summary>
        private static string m_ProtocolPath = "../Protobuf-27.0/protocol";

        /// <summary>
        /// 协议生成可执行文件路径
        /// </summary>
        private static string m_ExePath = "../Protobuf-27.0/bin";

        /// <summary>
        /// 协议生成可执行文件名字
        /// </summary>
        private static string m_ExeName = "protoc.exe";

        /// <summary>
        /// C#文件生成的路径
        /// </summary>
        private static string m_CodePath = "Scripts/Network/Protocol";

        private void OnEnable()
        {
            m_ProtocolDatas = new List<ProtocolData>();

            m_NormalStyle = new GUIStyle();
            m_NormalStyle.normal.textColor = Color.white;

            m_SelectedStyle = new GUIStyle();
            m_SelectedStyle.normal.textColor = Color.green;

            RefreshProtocolData();
        }

        private void OnGUI()
        {
            m_ScrollPos = EditorGUILayout.BeginScrollView(m_ScrollPos, false, false);

            for (int i = 0; i < m_ProtocolDatas.Count; i++)
            {
                var protocolData = m_ProtocolDatas[i];
                if (m_Column > 1 && i % m_Column == 0)
                {
                    EditorGUILayout.BeginHorizontal();
                }

                protocolData.IsOn = EditorGUILayout.ToggleLeft(protocolData.FileInfo.Name, protocolData.IsOn,
                    protocolData.IsOn ? m_SelectedStyle : m_NormalStyle);

                if (m_Column > 1 && (i % m_Column == m_Column - 1 || i == m_ProtocolDatas.Count - 1))
                {
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Refresh Window"))
            {
                RefreshProtocolData();
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select All"))
            {
                m_ProtocolDatas.ForEach(data => data.IsOn = true);
            }

            if (GUILayout.Button("Cancel All"))
            {
                m_ProtocolDatas.ForEach(data => data.IsOn = false);
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Open File"))
            {
                m_ProtocolDatas.ForEach(data =>
                {
                    if (data.IsOn)
                    {
                        System.Diagnostics.Process.Start(data.FileInfo.FullName);
                    }
                });
            }

            if (GUILayout.Button("Generate"))
            {
                string protocols = string.Join(" ",
                    m_ProtocolDatas.Where(data => data.IsOn).Select(data => data.FileInfo.Name));
                if (!string.IsNullOrEmpty(protocols))
                {
                    ExecuteCMD(protocols);
                }
                else
                {
                    Debug.Log("没有选中任何Protocol文件");
                }
            }
        }

        /// <summary>
        /// 刷新协议文件数据
        /// </summary>
        private void RefreshProtocolData()
        {
            m_ProtocolDatas.Clear();

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo($"{Application.dataPath}/{m_ProtocolPath}");
                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    if (fileInfo.Extension != ".proto")
                    {
                        Debug.Log($"{fileInfo.Name}不是proto文件");
                    }
                    else
                    {
                        m_ProtocolDatas.Add(new ProtocolData(false, fileInfo));
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log($"{e} {e.Message}");
            }
        }

        /// <summary>
        /// 执行Protocol代码生成CMD
        /// </summary>
        /// <param name="protocols"></param>
        private void ExecuteCMD(string protocols)
        {
            var pStartInfo = new System.Diagnostics.ProcessStartInfo(m_ExeName);
            pStartInfo.Arguments =
                $"--csharp_out=\"{Application.dataPath}/{m_CodePath}\" --proto_path=\"{Application.dataPath}/{m_ProtocolPath}\" {protocols}";
            pStartInfo.CreateNoWindow = false;
            pStartInfo.UseShellExecute = true;
            pStartInfo.RedirectStandardError = false;
            pStartInfo.RedirectStandardInput = false;
            pStartInfo.RedirectStandardOutput = false;
            pStartInfo.WorkingDirectory = $"{Application.dataPath}/{m_ExePath}";
            System.Diagnostics.Process.Start(pStartInfo);
        }
    }
}