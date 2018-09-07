using System;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WebAPI.CustomObjects
{
    public class ExcelUtility
    {
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook book = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    if (filePath.IndexOf(".xlsx") > 0)
                    {
                        book = new XSSFWorkbook(fs);
                    }
                    else if (filePath.IndexOf(".xls") > 0)
                        book = new HSSFWorkbook(fs);

                    if (book != null)
                    {
                        sheet = book.GetSheetAt(0);
                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(0);
                                int cellCount = firstRow.LastCellNum;
                                if (isColumnName)
                                {
                                    startRow = 1;
                                    for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            switch (cell.CellType)
                                            {
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.Numeric:
                                                    short format = cell.CellStyle.DataFormat;
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)


                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }

                }
                return dataTable;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }

                return null;
            }
        }
        public static DataTable FileToDataTable(IFormFile file, bool isColumnName)
        {
            DataTable dataTable = null;
            Stream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook book = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;
            string filePath = Path.GetTempFileName();
            try
            {
                using (fs = file.OpenReadStream())
                {
                    if (file.FileName.IndexOf(".xlsx") > 0)
                    {
                        book = new XSSFWorkbook(fs);
                    }
                    else if (file.FileName.IndexOf(".xls") > 0)
                        book = new HSSFWorkbook(fs);

                    if (book != null)
                    {
                        sheet = book.GetSheetAt(0);
                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(0);
                                int cellCount = firstRow.LastCellNum;
                                if (isColumnName)
                                {
                                    startRow = 1;
                                    for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; i++)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            switch (cell.CellType)
                                            {
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.Numeric:
                                                    short format = cell.CellStyle.DataFormat;
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)


                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }

                return null;
            }
        }
    }
}