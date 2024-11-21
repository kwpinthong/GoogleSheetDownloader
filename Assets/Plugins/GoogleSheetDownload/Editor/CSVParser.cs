using System.Collections.Generic;

namespace GoogleSheetDownload.Editor
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
                
                if (IsAllEmptyLine(cells))
                    continue;
                
                newSheetRowData.Parse(headerLine, cells);
                sheetRowDatas.Add(newSheetRowData);
            }
            
            return sheetRowDatas;
        }

        public static string ClearUnwantedCharacters(string lineString)
        {
            string newLineString = lineString;
            
            if (newLineString.Contains("\r"))
                newLineString = lineString.Replace("\r", "");
            
            return newLineString;
        }

        private static bool IsAllEmptyLine(string[] lineString)
        {
            bool[] emptyLineBoolList = new bool[lineString.Length];
            
            for (int i = 0; i < lineString.Length; i++)
            {
                var newStringLine = ClearUnwantedCharacters(lineString[i]);
                if (string.IsNullOrEmpty(newStringLine))
                    emptyLineBoolList[i] = true;
            }
            
            foreach (var isEmpty in emptyLineBoolList)
            {
                if (!isEmpty)
                    return false;
            }
            
            return true;
        }
    }
}
