using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InMenuMgr : MonoBehaviour
{
    #region // 變數區
    private Button btnStart;
    private Button btnExit;

    public GameObject canvasRoot;
    private GameObject UIPanel;
    #endregion

    #region  // 生命週期
    void Start()
    {
        ScanRoot();  //掃描物件

        BindingObject();  //綁定物件
    }




    void Update()
    {

    }
    #endregion

    #region // private function (輔助方法)

    private void ScanRoot()
    {
        //掃描
        int childCount = canvasRoot.transform.childCount;
        Debug.Log("canvasRoot.childCount= " + childCount);

        //逐一掃瞄 canvasRoot 的 "子" 物件
        for (int i = 0; i < childCount; i++)
        {
            GameObject gameObject = canvasRoot.transform.GetChild(i).gameObject;
            Debug.Log("gameObject.Name = " + gameObject.name);

            if (gameObject.name.Equals("UI_Panel"))
            {
                UIPanel = gameObject;
                //再掃描 下面的東西
                ScanUIPanel();
            }
        }
    }

    private void ScanUIPanel()
    {
        //掃描
        int childCount = UIPanel.transform.childCount;
        Debug.Log("UIPanel.childCount= " + childCount);

        //逐一掃瞄 canvasRoot 的 "子" 物件
        for (int i = 0; i < childCount; i++)
        {
            GameObject gameObject = UIPanel.transform.GetChild(i).gameObject;
            Debug.Log("gameObject.Name = " + gameObject.name);

            if (gameObject.name.Equals("btnStart"))
            {
                btnStart = gameObject.GetComponent<Button>();
            }
            if (gameObject.name.Equals("btnExit"))
            {
                btnExit = gameObject.GetComponent<Button>();
            }
        }
    }

    private void BindingObject()
    {
        btnStart.onClick.AddListener(btnStartOnClick);
        btnExit.onClick.AddListener(btnExitOnClick);
    }

    #endregion

    #region  // 事件(event)
    void btnStartOnClick()
    {
        Debug.Log("START");
    }

    void btnExitOnClick()
    {
        Debug.Log("EXIT");
    }

    #endregion

}
