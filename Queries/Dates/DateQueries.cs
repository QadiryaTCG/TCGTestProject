using Framework.Base;
using Framework.Helpers;


namespace TCGplayerUI.Queries
{
    class DateQueries : StartBrowser
    {

        //Get the current month spelled out as the actual word.  (Example: January)
        public string GetCurrentMonthWord()
        {
            string sql = "DECLARE @date datetime2 = SYSDATETIME(); SELECT FORMAT(@date, 'MMMM', 'en-US')";
            string value = DBSingleResultHelpers.DB_Method(sql);            
            return value;            
        }

        //Get the month year (Month is spelled out as the actual word.  (Example: January 2022)
        public string GetCurrentMonthWordFullYear()
        {
            string sql = "declare @Existingdate datetime Set @Existingdate = SYSDATETIME() Select Format(@Existingdate, 'Y')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get the month and day in numeric form  (Example: 2022-08-03 for August 3, 2022)
        public string GetCurrentFullYearMonthDayNumeric()
        {
            string sql = "DECLARE @d DATE = SYSDATETIME() SELECT FORMAT(@d, 'yyyy-MM-dd', 'en-US')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get the month and day in numeric form  (Example: 08-03 for August 3rd)
        public string GetCurrentMonthDayNumeric()
        {
            string sql = "DECLARE @d DATE = SYSDATETIME() SELECT FORMAT(@d, 'MM-dd', 'en-US')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get the day in numeric form  (Example: 03 for 3rd of the month)
        public string GetCurrentDayNumeric()
        {
            string sql = "DECLARE @d DATE = SYSDATETIME() SELECT FORMAT(@d, 'dd', 'en-US')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get the day formated in full month, day, and YYYY (Example: August 3, 2022)
        public string GetCurrentFullMonthDayFullYearFormated()
        {
            string sql = "DECLARE @d DATE = SYSDATETIME() SELECT FORMAT(@d, 'MMMM d, yyyy', 'en-US')";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

    }
}
