using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    class TrackingEmailQueries
    {

        //START OF EmailTemplateId:	19: EmailTemplateKey: CarrierTrackingNoMovementCheckingEmailTemplateKey
        //Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a buyer that buys from the MP site.
        //Get SellerName from email Template 19:         
        public string GetSellerNameTemplate19(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 19 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Order Number from email Template 19: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderNumberTemplate19(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 19 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 19: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate19(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 19 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 19: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate19(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 19 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	19: EmailTemplateKey: CarrierTrackingNoMovementCheckingEmailTemplateKey


        //Used in QA instead of 182:    179 is used in QA.  182 is used in Staging.
        //START OF EmailTemplateId:	179: EmailTemplateKey: GuestCarrierTrackingNoMovementCheckingEmailTemplateKey
        //Get SellerName from email Template 179: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a Guest buyer that buys from the MP site.
        public string GetSellerNameTemplate179(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 179 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }


        //Get Order Number from email Template 179: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderNumberTemplate179(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 179 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 179: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate179(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 179 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 179: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate179(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 179 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	179: EmailTemplateKey: GuestCarrierTrackingNoMovementCheckingEmailTemplateKey

        //Used in Staging instead of 179.  179 is used in QA.  182 is used in Staging.    
        //START OF EmailTemplateId:	182: EmailTemplateKey: GuestCarrierTrackingNoMovementCheckingEmailTemplateKey
        //Get SellerName from email Template 182: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a Guest buyer that buys from the MP site.
        public string GetSellerNameTemplate182(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 182 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Order Number from email Template 182: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderNumberTemplate182(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 182 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 182: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate182(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 182 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 182: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate182(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 182 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	182: EmailTemplateKey: GuestCarrierTrackingNoMovementCheckingEmailTemplateKey

        //START OF EmailTemplateId:	130: EmailTemplateKey: StoreFrontCarrierTrackingNoMovementCheckingEmailTemplateKey
        //Get Store Name from email Template 130: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        //Sent to a buyer that buys from the Prosite (Not Instore pickup).
        public string GetStoreNameTemplate130(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 130 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Seller Name from email Template 130: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerNameTemplate130(string buyer)
        {
            string sql = "SELECT TOP 1 d.value('.','varchar(50)') AS SellerName " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'SELLERNAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 130 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Order Number from email Template 130: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetOrderNumberTemplate130(string buyer)
        {
            string sql = "SELECT TOP 1 c.value('.','varchar(50)') AS OrderNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 130 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get SellerKey from email Template 130: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetSellerKeyTemplate130(string buyer)
        {
            string sql = "SELECT TOP 1 e.value('.','varchar(50)') AS SellerKey " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "AND EmailTemplateId = 130 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Tracking Number from email Template 130: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetTrackingNumberTemplate130(string buyer)
        {
            string sql = "SELECT TOP 1 f.value('.','varchar(500)') AS TrackingNumber " + "\n" +
            "FROM dbo.email " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as t(c) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as u(d) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as v(e) " + "\n" +
            "CROSS APPLY variables.nodes('/variables/variable') as w(f) " + "\n" +
            "WHERE c.value('(@name)', 'varchar(50)') = 'ORDERNUMBER' " + "\n" +
            "AND d.value('(@name)', 'varchar(50)') = 'STORENAME' " + "\n" +
            "AND e.value('(@name)', 'varchar(50)') = 'SELLERKEY' " + "\n" +
            "and f.value('(@name)','varchar(50)') = 'ORDERTRACKINGNUMBERS' " + "\n" +
            "AND EmailTemplateId = 130 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        //Get Body from email Template 130: Subject: Your TCGplayer.com order of ##TOP_ITEM_IN_ORDER## has shipped.
        public string GetBodyTemplate130(string buyer)
        {
            string sql = "SELECT TOP 1 Body " +
            "FROM dbo.email " + "\n" +
            "WHERE EmailTemplateId = 130 " + "\n" +
            "AND ToEmail = '" + buyer + "' " + "\n" +
            "ORDER BY emailid DESC";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }
        //END OF EmailTemplateId:	130: EmailTemplateKey: StoreFrontCarrierTrackingNoMovementCheckingEmailTemplateKey
    }
}
