using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    class NoTrackingEmailQueries
    {
        //START OF EmailTemplateId:	21: EmailTemplateKey: CarrierTrackingNoTrackingEmailTemplateKey
        //Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a buyer that buys from the MP site.
        //Get SellerName from email Template 21:         
        public string GetSellerNameTemplate21(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 21 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Order Number from email Template 21: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.        
        public string GetOrderNumberTemplate21(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 21 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 21: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate21(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 21 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 21: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate21(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 21 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	21: EmailTemplateKey: CarrierTrackingNoTrackingEmailTemplateKey



        //START OF EmailTemplateId:	175: EmailTemplateKey: GuestCarrierTrackingNoTrackingEmailTemplateKey
        //Get SellerName from email Template 175: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a Guest buyer that buys from the MP site.
        public string GetSellerNameTemplate175(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 175 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }


        //Get Order Number from email Template 175: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderNumberTemplate175(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 175 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 175: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate175(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 175 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 175: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate175(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 175 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	175: EmailTemplateKey: GuestCarrierTrackingNoTrackingEmailTemplateKey


        //START OF EmailTemplateId:	132: EmailTemplateKey: StoreFrontCarrierTrackingNoTrackingEmailTemplateKey
        //Get StoreName from email Template 132: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a buyer that buys from the Prosite (Not Instore pickup).
        public string GetStoreNameTemplate132(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 132 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerName from email Template 132: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerNameTemplate132(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 132 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }


        //Get Order Number from email Template 132: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderNumberTemplate132(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 132 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 132: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate132(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 132 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 132: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderTrackingNumbersTemplate132(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'ORDERTRACKINGNUMBERS' " + "\n" +
            "AND EmailTemplateId = 132 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 132: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate132(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 132 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	132: EmailTemplateKey: StoreFrontCarrierTrackingNoTrackingEmailTemplateKey

    }
}
