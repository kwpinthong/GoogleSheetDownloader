#if UNITY_EDITOR
using GoogleSheetDownload.Editor;
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
                
        var spriteName = sheetRowData.GetString("SpriteName");
        newExampleData.Sprite = AssetFinder.Find<Sprite>(spriteName);

        return newExampleData;
    }
    
#endif
}
