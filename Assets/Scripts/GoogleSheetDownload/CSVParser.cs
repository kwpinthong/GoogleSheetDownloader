using System.Collections.Generic;

namespace GoogleSheetDownload
{
    public static class CSVParser
    {
        public static List<string> GetLines(string csvString)
        {
            var lines = new List<string>();
            
            var linesArray = csvString.Split("\n");
            lines.AddRange(linesArray);
            
            return lines;
        }

        public static List<SheetRowData> GetSheetRowDatas(string csvString)
        {
            var sheetRowDatas = new List<SheetRowData>();
            
            var linesArray = csvString.Split("\n");
            var headerLine = linesArray[0].Split(",");
            for (int i = 1; i < linesArray.Length; i++)
            {
                var newSheetRowData = new SheetRowData();
                var cells = linesArray[i].Split(",");
                newSheetRowData.Parse(headerLine, cells);
                sheetRowDatas.Add(newSheetRowData);
            }
            
            return sheetRowDatas;
        }

        public static string ClearUnwantedCharacters(string lineString)
        {
            string newLineString = lineString;
            if (newLineString.Contains("\r"))
            {
                newLineString = lineString.Replace("\r", "");
            }
            return newLineString;
        }

    }
}
