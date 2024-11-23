#if UNITY_EDITOR
using GoogleSheetDownload.Editor;
using GoogleSheetDownload.Editor.Data;
using GoogleSheetDownload.Editor.Utility;
#endif
using GoogleSheetDownload.Runtime;
using UnityEngine;

[CreateAssetMenu(fileName = "RemoteExampleDatabase", menuName = "GoogleSheetDownload/Example/RemoteExampleDatabase")]
public class ExampleDatabase : RemoteDatabase<ExampleData>
{
#if UNITY_EDITOR

    protected override ExampleData CreateData(SheetRowData sheetRowData)
    {
        var newExampleData = new ExampleData();
        
        newExampleData.Id = sheetRowData.GetString("Id");
        newExampleData.Name = sheetRowData.GetString("Name");
        newExampleData.Coin = sheetRowData.GetInt("Coin");
        newExampleData.Normalize = sheetRowData.GetFloat("Normalize");
        newExampleData.IsAllow = sheetRowData.GetBool("IsAllow");
        
        newExampleData.ItemList = sheetRowData.GetList<string>("ItemList", ",");
        newExampleData.ItemList2 = sheetRowData.GetList<string>("ItemList2",",");
        newExampleData.ItemList3 = sheetRowData.GetList<string>("ItemList3",",");
        newExampleData.ItemList4 = sheetRowData.GetList<string>("ItemList4",";");
                
        var spriteName = sheetRowData.GetString("SpriteName");
        newExampleData.Sprite = AssetFinder.Find<Sprite>(spriteName);

        return newExampleData;
    }
    
#endif
}
