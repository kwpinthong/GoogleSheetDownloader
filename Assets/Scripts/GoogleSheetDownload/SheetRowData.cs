using System.Collections.Generic;
using UnityEngine;

namespace GoogleSheetDownload
{
    public class SheetRowData
    {
        public List<KeyContainer> Columns;
        
        public SheetRowData()
        {
            Columns = new List<KeyContainer>();
        }

        public void Parse(string[] headerLine, string[] cells, int startColumnIndex = 0)
        {
            Columns.Clear();
            for (var i = startColumnIndex; i < headerLine.Length; i++)
            {
                Columns.Add(new KeyContainer
                {
                    Header = CSVParser.ClearUnwantedCharacters(headerLine[i]),
                    CellValue = CSVParser.ClearUnwantedCharacters(cells[i]),
                });
            }
        }

        public int GetInt(string header)
        {
            foreach (var column in Columns)
            {
                if (column.Header == header)
                {
                    return int.TryParse(column.CellValue, out var result) ? result : -1;
                }
            }
            return -1;
        }

        public float GetFloat(string header)
        {
            foreach (var column in Columns)
            {
                if (column.Header == header)
                {
                    return float.TryParse(column.CellValue, out var result) ? result : -1;
                }
            }
            return -1;
        }
        
        public string GetString(string header)
        {
            foreach (var column in Columns)
            {
                if (column.Header == header)
                {
                    return column.CellValue;
                }
            }
            return string.Empty;
        }
        
        public bool GetBool(string header)
        {
            foreach (var column in Columns)
            {
                if (column.Header == header)
                {
                    return bool.TryParse(column.CellValue, out var result) ? result : false;
                }
            }
            return false;
        }
    }
}
