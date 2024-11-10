using System.Collections.Generic;
using UnityEngine;

namespace GoogleSheetDownload.Example
{
    [CreateAssetMenu(fileName = "ExampleDatabase", menuName = "GoogleSheetDownload/Example/ExampleDatabase")]
    public class ExampleDatabase : ScriptableObject
    {
        public List<ExampleData> Database;
    }
}
