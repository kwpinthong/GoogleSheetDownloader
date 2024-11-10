using System.Collections.Generic;

namespace GoogleSheetDownload
{
    public static class CSVDownloader
    {
        // 1. Example
        /*
        public static List<string> Download(string sheetID, string gid)
        {
            var url = FormatGoogleSheetLink(sheetID, gid);
            var csvString = DownloadEntry(url);
            return CSVParser.GetLines(csvString);
        }
        */

        // 2. SheetRowData
        
        public static List<SheetRowData> Download(string sheetID, string gid)
        {
            var url = FormatGoogleSheetLink(sheetID, gid);
            var csvString = DownloadEntry(url);
            return CSVParser.GetSheetRowDatas(csvString);
        }
        
        private static string FormatGoogleSheetLink(string sheetID, string gid, string format = "csv")
        {
            return $"https://docs.google.com/spreadsheets/d/{sheetID}/export?format={format}&gid={gid}";
        }

        private static string DownloadEntry(string url)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                string csv = client.DownloadString(url);
#if UNITY_EDITOR
                UnityEngine.Debug.Log(csv);
#endif
                return csv;
            }
        }
    }
}
