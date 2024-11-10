using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace GoogleSheetDownload.Example
{
    [CreateAssetMenu(fileName = "RemoteExampleDatabase", menuName = "GoogleSheetDownload/Example/RemoteExampleDatabase")]
    public class RemoteExampleDatabase : ScriptableObject
    {
#if UNITY_EDITOR
        public ExampleDatabase ExampleDatabase;
        public string SheetID;
        public string GID;

        [Button]
        public void DownloadDatabase()
        {
            // 1.Example
            /*
            var lines = CSVDownloader.Download(SheetID, GID);
            
            ExampleDatabase.Database.Clear();

            // int i = 0 is header
            for (int i = 1; i < lines.Count; i++)
            {
                var valueArray = lines[i].Split(",");

                ExampleData newExampleData = new ExampleData();
                
                newExampleData.Id = valueArray[0];
                newExampleData.Name = valueArray[1];
                newExampleData.Coin = int.Parse(valueArray[2]);
                newExampleData.Normalize = float.Parse(valueArray[3]);
                newExampleData.IsAllow = bool.Parse(valueArray[4]);
                
                ExampleDatabase.Database.Add(newExampleData);
            }
            */
            
            // 2.SheetRowData
            
            var sheetRowDatas = CSVDownloader.Download(SheetID, GID);
            
            ExampleDatabase.Database.Clear();
            
            for (int i = 0; i < sheetRowDatas.Count; i++)
            {
                ExampleData newExampleData = new ExampleData();

                var sheetRowData = sheetRowDatas[i];
                
                newExampleData.Id = sheetRowData.GetString("Id");
                newExampleData.Name = sheetRowData.GetString("Name");
                newExampleData.Coin = sheetRowData.GetInt("Coin");
                newExampleData.Normalize = sheetRowData.GetFloat("Normalize");
                newExampleData.IsAllow = sheetRowData.GetBool("IsAllow");
                
                ExampleDatabase.Database.Add(newExampleData);
            }
            
            EditorUtility.SetDirty(ExampleDatabase);
            AssetDatabase.Refresh();
        }
#endif
    }
}