using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using cfg.cfg;
using UnityEngine;
using GameFramework;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityEditor;
using UnityGameFramework.Runtime;
using PrecodureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureEntry : ProcedureBase
{
    protected override void OnInit(PrecodureOwner procedureOwner)
    {
        base.OnInit(procedureOwner);
    }

    protected override void OnEnter(PrecodureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        GameEntry.GetComponent<EventComponent>().Subscribe(LoadDataTableSuccessEventArgs.EventId, LoadDataSuc);
        DataTableBase dataTable = GameEntry.GetComponent<DataTableComponent>().CreateDataTable(Type.GetType("cfg.cfg.actor"), "actor");
        dataTable.ReadData("Assets/Resources/LocalConfig/cfg_tbactor.bytes");
        
    }

    private void LoadDataSuc(object sender, GameEventArgs e)
    {
        IDataTable<actor> dtMusic = GameEntry.GetComponent<DataTableComponent>().GetDataTable<actor>();
        Log.Debug(dtMusic.Count);
    }

    protected override void OnUpdate(PrecodureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
    }

    protected override void OnLeave(PrecodureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
        GameEntry.GetComponent<EventComponent>().Unsubscribe(LoadDataTableSuccessEventArgs.EventId, LoadDataSuc);
    }

    protected override void OnDestroy(PrecodureOwner procedureOwner)
    {
        base.OnDestroy(procedureOwner);
    }
}
