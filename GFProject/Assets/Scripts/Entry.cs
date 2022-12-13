#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：GameEntry
// 创 建 者：shuaibinliu
// 创建时间：2022年12月13日 星期二 16:17
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

public class Entry : MonoBehaviour
{
    private static ConfigComponent m_ConfigComponent;
    public static UnityGameFramework.Runtime.ConfigComponent ConfigComponent => m_ConfigComponent;
    
    private static DataTableComponent m_DataTableComponent;
    public static UnityGameFramework.Runtime.DataTableComponent DataTableComponent => m_DataTableComponent;

    private void Awake()
    {
        InitAllComponent();
    }

    private void InitAllComponent()
    {
        m_ConfigComponent = GameEntry.GetComponent<ConfigComponent>();
        m_DataTableComponent = GameEntry.GetComponent<DataTableComponent>();
    }
}
