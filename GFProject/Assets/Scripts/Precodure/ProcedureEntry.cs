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
        
        Entry.DataTableComponent.LoadDataTable(typeof(actor), "");

    }

    private void LoadDataTable(Type type)
    {
        DataTableBase dataTable = GameEntry.GetComponent<DataTableComponent>().CreateDataTable(type);
        dataTable.ReadData("cfg_tbactor");
    }
    
    private void LoadDataSuc(object sender, GameEventArgs e)
    {
        IDataTable<actor> dt = GameEntry.GetComponent<DataTableComponent>().GetDataTable<actor>();
        foreach (var dActor in dt)
        {
            Log.Debug(dActor.ToString());
        }
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
