using Framework.Helpers;
using System;

namespace TCGplayerUI.Queries
{
    public class InventoryQueries
    {
        public string InventoryQuantity(string sellerId, string productConditionId, string channelId)
        {
            string sql = "Select Quantity FROM dbo.StorePrice WHERE SellerId = " + sellerId + " AND StoreProductConditionId = " + productConditionId + " AND ChannelId = " + channelId;
            string inventoryQuantity = DBSingleResultHelpers.DB_Method(sql);
            if (inventoryQuantity == "")
            {
                inventoryQuantity = "0";
            }
            return inventoryQuantity;
        }


        public void DB_UpdateStorePriceTableChannel0(string sellerId, string productConditionId, string quantity, string price, string totalInStock)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @ProductConditionId BIGINT = " + productConditionId + " " + "\n" +
            "DECLARE @Quantity INT =  " + quantity + " " + "\n" +
            "DECLARE @Price DECIMAL(8, 2) = '" + price + "'" + " " + "\n" +
            "DECLARE @MaxFulfillableQty TINYINT = 0 " + "\n" +
            "DECLARE @ChannelId SMALLINT = 0 " + "\n" +
            "DECLARE @ReserveQuantity BIGINT = 0 " + "\n" +
            "DECLARE @TotalInStock INT = " + totalInStock + " " + "\n" +   

            //Update the AvailableInventory table
            "IF EXISTS(SELECT 1 FROM dbo.AvailableInventory WHERE SellerId = @SellerId AND StoreProductConditionId = @ProductConditionId AND ChannelId = @ChannelId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE dbo.AvailableInventory SET Price = @Price, Quantity = @Quantity, ReserveQuantity = @ReserveQuantity, MaxQty = @MaxFulfillableQty WHERE SellerId = @SellerId And StoreProductConditionId = @ProductConditionId And ChannelId = @ChannelId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO dbo.AvailableInventory(StoreProductConditionId, StoreProductId, StoreConditionId, Quantity, MaxQty, SellerId, ChannelId, ReserveQuantity, Price, LastUpdated, IsEligibleForSale) " + "\n" +
            "SELECT ProductConditionId, ProductId, ConditionId, @Quantity, 8, @SellerId, @ChannelId , @ReserveQuantity, @Price,  getutcdate(), 1 " + "\n" +
            "FROM PDT.ProductCondition " + "\n" +
            "WHERE ProductConditionId = @ProductConditionId " + "\n" +
            "END " + "\n" +
            "\n" +

            //Update the Inventory table
            "IF EXISTS(SELECT 1 FROM InventoryDb_" + envLower + ".inv.Inventory WHERE OwnerId = @SellerId AND SkuId = @ProductConditionId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE InventoryDb_" + envLower + ".inv.Inventory set TotalInStock = @TotalInStock where OwnerId = @SellerId and SkuId = @ProductConditionId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO InventoryDb_" + envLower + ".inv.Inventory(OwnerId, SkuId, TotalInStock, LastUpdated, UpdatedByUserId) " + "\n" +
            "values(@SellerId, @ProductConditionId, @TotalInStock, getutcdate(), 0) " + "\n" +
            "END " + "\n" +
            "\n" +

            //Update the InventoryChannel table
            "IF EXISTS(SELECT 1 FROM InventoryDb_" + envLower + ".inv.InventoryChannel WHERE OwnerId = @SellerId AND SkuId = @ProductConditionId And ChannelId = @ChannelId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE InventoryDb_" + envLower + ".inv.InventoryChannel set Price = @Price, ReserveQuantity = @ReserveQuantity Where OwnerId = @SellerId and SkuId = @ProductConditionId and ChannelId = @ChannelId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO InventoryDb_" + envLower + ".inv.InventoryChannel(OwnerId, SkuId, ChannelId, Price, ReserveQuantity, MaximumQuantityDisplayed, LastUpdated, UpdatedByUserId) " + "\n" +
            "values(@SellerId, @ProductConditionId, @channelId, @Price, @ReserveQuantity, '-1', getutcdate(), 0) " + "\n" +
            "END";
            
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }


        public void DB_UpdateStorePriceTableChannel1(string sellerId, string productConditionId, string quantity, string price, string totalInStock)
        {
            //Identify the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string updateQuery = "DECLARE @SellerId BIGINT = " + sellerId + " " + "\n" +
            "DECLARE @ProductConditionId BIGINT = " + productConditionId + " " + "\n" +
            "DECLARE @Quantity INT =  " + quantity + " " + "\n" +
            "DECLARE @Price DECIMAL(8, 2) = '" + price + "'" + " " + "\n" +
            "DECLARE @MaxFulfillableQty TINYINT = 0 " + "\n" +
            "DECLARE @ChannelId SMALLINT = 1 " + "\n" +
            "DECLARE @ReserveQuantity BIGINT = 0 " + "\n" +
            "DECLARE @TotalInStock INT = " + totalInStock + " " + "\n" +

            //Update the AvailableInventory table
            "IF EXISTS(SELECT 1 FROM dbo.AvailableInventory WHERE SellerId = @SellerId AND StoreProductConditionId = @ProductConditionId AND ChannelId = @ChannelId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE dbo.AvailableInventory SET Price = @Price, Quantity = @Quantity, ReserveQuantity = @ReserveQuantity, MaxQty = @MaxFulfillableQty WHERE SellerId = @SellerId And StoreProductConditionId = @ProductConditionId And ChannelId = @ChannelId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO dbo.AvailableInventory(StoreProductConditionId, StoreProductId, StoreConditionId, Quantity, MaxQty, SellerId, ChannelId, ReserveQuantity, Price, LastUpdated, IsEligibleForSale) " + "\n" +
            "SELECT ProductConditionId, ProductId, ConditionId, @Quantity, 8, @SellerId, @ChannelId , @ReserveQuantity, @Price,  getutcdate(), 1 " + "\n" +
            "FROM PDT.ProductCondition " + "\n" +
            "WHERE ProductConditionId = @ProductConditionId " + "\n" +
            "END " + "\n" +
            "\n" +

            //Update the Inventory table
            "IF EXISTS(SELECT 1 FROM InventoryDb_" + envLower + ".inv.Inventory WHERE OwnerId = @SellerId AND SkuId = @ProductConditionId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE InventoryDb_" + envLower + ".inv.Inventory set TotalInStock = @TotalInStock where OwnerId = @SellerId and SkuId = @ProductConditionId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO InventoryDb_" + envLower + ".inv.Inventory(OwnerId, SkuId, TotalInStock, LastUpdated, UpdatedByUserId) " + "\n" +
            "values(@SellerId, @ProductConditionId, @TotalInStock, getutcdate(), 0) " + "\n" +
            "END " + "\n" +
            "\n" +

            //Update the InventoryChannel table
            "IF EXISTS(SELECT 1 FROM InventoryDb_" + envLower + ".inv.InventoryChannel WHERE OwnerId = @SellerId AND SkuId = @ProductConditionId And ChannelId = @ChannelId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE InventoryDb_" + envLower + ".inv.InventoryChannel set Price = @Price, ReserveQuantity = @ReserveQuantity Where OwnerId = @SellerId and SkuId = @ProductConditionId and ChannelId = @ChannelId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO InventoryDb_" + envLower + ".inv.InventoryChannel(OwnerId, SkuId, ChannelId, Price, ReserveQuantity, MaximumQuantityDisplayed, LastUpdated, UpdatedByUserId) " + "\n" +
            "values(@SellerId, @ProductConditionId, @channelId, @Price, @ReserveQuantity, '-1', getutcdate(), 0) " + "\n" +
            "END";

            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }


        public void DB_UpdateDirectInventory(string productConditionId)
        {

            string updateQuery = "DECLARE @ProductConditionId BIGINT = " + productConditionId + " " + "\n" +

            //Update the TCGD.DirectInventory table
            "IF EXISTS(SELECT * FROM TCGD.DirectInventory WHERE ProductConditionId = @ProductConditionId) " + "\n" +
            "BEGIN " + "\n" +
            "UPDATE TCGD.DirectInventory SET QtyAvailable = 300 WHERE ProductConditionId = @ProductConditionId " + "\n" +
            "END " + "\n" +
            "ELSE BEGIN " + "\n" +
            "INSERT INTO TCGD.DirectInventory(ProductConditionId, QtyAvailable, QtyArchive, CreatedByUserId, CreatedAt) " + "\n" +
            "VALUES(@ProductConditionId, 300, 0, 0, getutcdate()) " + "\n" +
            "END " + "\n" +

            //Update the PDT.Product table
            "UPDATE PDT.Product SET MaxFulfillableQty = 255 WHERE ProductId = (SELECT ProductId FROM PDT.ProductCondition WHERE ProductConditionId = @ProductConditionId)";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Update a price that exists in the StorePriceCustom table.  Used for Listos
        public void DB_StorePriceCustomPrice(string price, string storePriceCustomId)
        {
            string updateQuery = "update dbo.StorePriceCustom set price = '" + price + "' where StorePriceCustomId = " + storePriceCustomId;
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }

        //Use the following 4 queries to delete a Listo product in the DB.
        //If Listos was not edited: Use these 2 queries in this order: DeleteListoCustomImage, then DeleteListoProduct 
        //If Listo was edited: Use all 4 queries in this order: DeleteListoAuditChangeId, DeleteListoAuditId, DeleteListoCustomImage, then DeleteListoProduct 
        //Deletes the listo audit change records from the StorePriceCustomAuditChange table
        public void DeleteListoAuditChangeId(string productConditionId, string sellerId)
        {
            string updateQuery = "DELETE FROM ADT.StorePriceCustomAuditChange WHERE StorePriceCustomAuditChangeId in (select ac.StorePriceCustomAuditChangeId  " + "\n" +
            "from ADT.StorePriceCustomAuditChange ac " + "\n" +
            "Inner join ADT.StorePriceCustomAudit a on a.StorePriceCustomAuditId = ac.StorePriceCustomAuditId " + "\n" +
            "Inner join dbo.StorePriceCustom spc ON a.StorePriceCustomId = spc.StorePriceCustomId " + "\n" +
            "where spc.ProductConditionId = " + productConditionId + " and SellerId = " + sellerId + ")";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }
        //Deletes the listo audit records from the StorePriceCustomAudit table
        public void DeleteListoAuditId(string productConditionId, string sellerId)
        {
            string updateQuery = "DELETE FROM ADT.StorePriceCustomAudit WHERE StorePriceCustomAuditId in (select a.StorePriceCustomAuditId " + "\n" +
            "from ADT.StorePriceCustomAudit a " + "\n" +
            "Inner join dbo.StorePriceCustom spc ON a.StorePriceCustomId = spc.StorePriceCustomId " + "\n" +
            "where spc.ProductConditionId = " + productConditionId + " and SellerId = " + sellerId + ")";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
        }
        //Deletes the listo Custom Image from the StorePriceCustomImage table
        public void DeleteListoCustomImage(string productConditionId, string sellerId)
        {
            string updateQuery = "DELETE FROM dbo.StorePriceCustomImage WHERE StorePriceCustomImageId in (select spci.StorePriceCustomImageId " + "\n" +
            "from dbo.StorePriceCustomImage spci " + "\n" +
            "Inner join dbo.StorePriceCustom spc ON spci.StorePriceCustomId = spc.StorePriceCustomId " + "\n" +
            "where spc.ProductConditionId = " + productConditionId + " and SellerId = " + sellerId + ")";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            
        }
        //Deletes the Listo Product from the StorePriceCustom table
        public void DeleteListoProduct(string productConditionId, string sellerId)
        {
            string updateQuery = "DELETE FROM dbo.StorePriceCustom WHERE StorePriceCustomId in (select StorePriceCustomId " + "\n" +
            "from dbo.StorePriceCustom " + "\n" +
            "where ProductConditionId = " + productConditionId + " and SellerId = " + sellerId + ")";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine(updateQuery);
        }


        public string SelectProductWithinPriceRange(string sellerId, string channelId)
        {
            string sql = "SELECT TOP 1 sp.StoreProductConditionId FROM dbo.StorePrice sp INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN PDT.ProductType pt ON pt.ProductTypeId = p.ProductTypeID " + "\n" +
            "INNER JOIN PDT.ProductStatus ps ON ps.ProductStatusId = p.ProductStatusId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId " + "\n" +
            "WHERE ps.ProductStatusID IN(1,20) " + "\n" +
            "AND p.ProductTypeId = 1 " + "\n" +
            "AND sp.Quantity > 0 " + "\n" +
            "AND sp.Price >= '3.00' AND sp.Price <= '200.00' " + "\n" +
            "AND s.SellerId = " + sellerId + " AND sp.ChannelId = " + channelId;
            string productConditionId = DBSingleResultHelpers.DB_Method(sql);
            return productConditionId;

        }

        //Use the following 2 queries together to get a product and a seller.  Queries are identical except that one returns a ProductConditionId and one returns a live seller that sells that ProdutConditionId.
        //Seller RateCardID = 11
        public string SelectProductWithinPriceRangeForRateCard11(string sellerId)
        {
            string sql = "SELECT TOP 1 pc.ProductConditionId FROM dbo.StorePrice sp INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN PDT.ProductType pt ON pt.ProductTypeId = p.ProductTypeID " + "\n" +
            "INNER JOIN PDT.ProductStatus ps ON ps.ProductStatusId = p.ProductStatusId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId " + "\n" +
            "WHERE ps.ProductStatusID IN(1,20) " + "\n" +
            "AND p.ProductTypeId = 1 " + "\n" +
            "AND sp.Quantity > 0 " + "\n" +
            "AND sp.Price >= '20.00' AND sp.Price <= '200.00' " + "\n" +
            "AND s.sellerId = " + sellerId + " and s.RateCardId = 11 and SellerStatusInd = 'Live'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }
        public string SelectSellerForRateCard11()
        {
            string sql = "SELECT TOP 1 s.SellerId FROM dbo.StorePrice sp INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN dbo.store_CrystalCommerce cc ON cc.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN PDT.ProductType pt ON pt.ProductTypeId = p.ProductTypeID " + "\n" +
            "INNER JOIN PDT.ProductStatus ps ON ps.ProductStatusId = p.ProductStatusId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId " + "\n" +
            "WHERE ps.ProductStatusID IN(1,20) " + "\n" +
            "AND p.ProductTypeId = 1 " + "\n" +
            "AND sp.Quantity > 0 " + "\n" +
            "AND sp.Price >= '20.00' AND sp.Price <= '200.00' " + "\n" +
            "AND s.RateCardId = 11 and SellerStatusInd = 'Live'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;

        }

        //Get ProductConditionId from ProductId and ConditionName
        public string GetProductConditionIdFromProductIdConditionName(string productId, string conditionName)
        {
            string sql = "select pc.ProductConditionId " + "\n" +
            "from pdt.ProductCondition pc " + "\n" +
            "INNER JOIN pdt.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.Condition c ON c.ConditionId = pc.ConditionId " + "\n" +
            "Where pc.ProductId = " + productId + " and c.ConditionName = '" + conditionName + "'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get Product Price. Use for any channel
        public string GetProductPrice(string sellerId, string channelId, string productConditionId)
        {
            string sql = "Select CONVERT(varchar, Price) AS Price FROM dbo.StorePrice WHERE SellerId = " + sellerId + "  AND ChannelId = " + channelId + " and StoreProductConditionId = " + productConditionId;
            string price = DBSingleResultHelpers.DB_Method(sql);
            return price;
        }

        //Get Listo Price
        public string GetListoPrice(string sellerId, string productConditionId)
        {
            string sql = "Select CONVERT(varchar, Price) AS Price FROM dbo.StorePriceCustom WHERE SellerId = " + sellerId + " and ProductConditionId = " + productConditionId;
            string price = DBSingleResultHelpers.DB_Method(sql);
            return price;
        }

        public string GetProductId(string sellerId, string channelId, string productConditionId)
        {
            string sql = "Select StoreProductId FROM dbo.StorePrice WHERE SellerId = " + sellerId + "  AND ChannelId = " + channelId + " and StoreProductConditionId = " + productConditionId;
            string productId = DBSingleResultHelpers.DB_Method(sql);
            return productId;
        }

        //Get StorePriceId from the StorePriceId table
        public string GetStorePriceId(string sellerId, string channelId, string productConditionId)
        {
            string sql = "Select StorePriceId FROM dbo.StorePrice WHERE SellerId = " + sellerId + "  AND ChannelId = " + channelId + " and StoreProductConditionId = " + productConditionId;
            string productId = DBSingleResultHelpers.DB_Method(sql);
            return productId;
        }


        //New for PD page changes
        //Get AvailableInventoryId from the AvailableInventory table
        public string GetAvailableInventoryId(string sellerId, string channelId, string productConditionId)
        {
            string sql = "Select AvailableInventoryId FROM dbo.AvailableInventory WHERE SellerId = " + sellerId + "  AND ChannelId = " + channelId + " and StoreProductConditionId = " + productConditionId;
            string productId = DBSingleResultHelpers.DB_Method(sql);
            return productId;
        }

        public string GetProductName(string productId)
        {
            string sql = "Select ProductName FROM pdt.Product WHERE ProductId = " + productId; 
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        public string GetProductNameFromProductConditionId(string productConditionId)
        {
            string sql = "Select top 1 ProductName from pdt.Product p INNER JOIN PDT.ProductCondition pc ON pc.ProductID = p.ProductId where pc.ProductConditionId = " + productConditionId;
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        public string GetFeaturedProduct(string sellerId, string productId, string channelId)
        {
            string sql = "select top 1 sp.StoreProductConditionID from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc(NOLOCK) ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c(NOLOCK) ON pc.ConditionId = c.ConditionId " + "\n" +
            "where sp.sellerID = " + sellerId + "\n" +
            "and sp.storeproductId = " + productId + "\n" +
            "and sp.Quantity > 0 " + "\n" +
            "and c.ConditionId in (1, 36, 34) " + "\n" +
            "and sp.ChannelId = " + channelId + "\n" +
            "order by sp.price";
            string featuredProductId = DBSingleResultHelpers.DB_Method(sql);
            return featuredProductId;
        }

        public string GetReserveQuantity(string sellerId, string productConditionId, string channelId)
        {
            string sql = "Select ReserveQuantity FROM dbo.StorePrice WHERE SellerId = " + sellerId + " AND StoreProductConditionId = " + productConditionId + " AND ChannelId = " + channelId;
            string inventoryQuantity = DBSingleResultHelpers.DB_Method(sql);
            return inventoryQuantity;
        }

        //Use this query to determine how many product condtions a seller has in thier inventory.  If only one, then we do not have to take into consideration if the product is featured or or not.  It will be a  featured product.
        public string GetProductConditonsCount(string sellerId, string productId, string channelId)
        {
            string sql = "select count (*) from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc(NOLOCK) ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c(NOLOCK) ON pc.ConditionId = c.ConditionId " + "\n" +
            "where sp.sellerID = " + sellerId + "\n" +
            "and sp.storeproductId = " + productId + "\n" +
            "and sp.Quantity > 0 " + "\n" +
            "and sp.ChannelId = " + channelId + "\n";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }




        //*******Start of: Use these queries to verify sorts and searches within the inventory tab.*********

        //******Start of page load******
        //Get first category name in search results in ascending order when page first loads
        public string GetFirstCategoryByCategorySortAcs()
        {
            string sql = "SELECT top 1 cat.CategoryName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by CategoryName, SetName, ProductName";
            string categoryName = DBSingleResultHelpers.DB_Method(sql);
            return categoryName;
        }

        //Get first product name in search results in ascending order when page first loads
        public string GetFirstProductByCategorySortAcs()
        {
            string sql = "SELECT top 1 p.ProductName " + "\n" +
            "FROM PDT.Product p " +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by CategoryName, SetName, ProductName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        //Get first SetName in search results in ascending order when page first loads
        public string GetFirstSetNameByCategorySortAcs()
        {
            string sql = "SELECT top 1 sn.SetName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by CategoryName, SetName, ProductName";
            string setName = DBSingleResultHelpers.DB_Method(sql);
            return setName;
        }
        //******End of page load******


        //******Start of sort by SetName asc******
        //Get first category name in search results when SetName is sorted in ascending order
        public string GetFirstCategoryBySetNameSortAcs()
        {
            string sql = "SELECT top 1 cat.CategoryName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by SetName, CategoryName, ProductName";
            string categoryName = DBSingleResultHelpers.DB_Method(sql);
            return categoryName;
        }

        //Get first product name in search results when SetName is sorted in ascending order
        public string GetFirstProductBySetNameSortAcs()
        {
            string sql = "SELECT top 1 p.ProductName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by SetName, CategoryName, ProductName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        //Get first SetName in search results when SetName is sorted in ascending order
        public string GetFirstSetNameBySetNameSortAcs()
        {
            string sql = "SELECT top 1 sn.SetName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by SetName, CategoryName, ProductName";
            string setName = DBSingleResultHelpers.DB_Method(sql);
            return setName;
        }
        //******End of sort by  SetName asc******


        //******Start of sort by product name asc******
        //Get first category name in search results when product is sorted in ascending order
        public string GetFirstCategoryByProductSortAcs()
        {
            string sql = "SELECT top 1 cat.CategoryName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by ProductName, CategoryName, SetName";
            string categoryName = DBSingleResultHelpers.DB_Method(sql);
            return categoryName;
        }

        //Get first product name in search results when product is sorted in ascending order
        public string GetFirstProductByProductSortAcs()
        {
            string sql = "SELECT top 1 p.ProductName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by ProductName, CategoryName, SetName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        //Get first SetName in search results when product is sorted in ascending order
        public string GetFirstSetNameByProductSortAcs()
        {
            string sql = "SELECT top 1 sn.SetName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by ProductName, CategoryName, SetName";
            string setName = DBSingleResultHelpers.DB_Method(sql);
            return setName;
        }
        //******End of sort by  product name asc******


        //******Start of sort by product name desc******
        //Get first category name in search results when product is sorted in descending order
        public string GetFirstCategoryByProductSortDesc()
        {
            string sql = "SELECT top 1 cat.CategoryName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by ProductName desc, CategoryName, SetName";
            string categoryName = DBSingleResultHelpers.DB_Method(sql);
            return categoryName;
        }

        //Get first product name in search results when product is sorted in descending order
        public string GetFirstProductByProductSortDesc()
        {
            string sql = "SELECT top 1 p.ProductName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by ProductName desc, CategoryName, SetName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        //Get first SetName in search results when product is sorted in descending order
        public string GetFirstSetNameByProductSortDesc()
        {
            string sql = "SELECT top 1 sn.SetName " + "\n" +
            "FROM PDT.Product p " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "where cat.MPCanSearch = 1 " + "\n" +
            "and cat.MPCanSell = 1 " + "\n" +
            "and sn.Active = 1 " + "\n" +
            "order by ProductName desc, CategoryName, SetName";
            string setName = DBSingleResultHelpers.DB_Method(sql);
            return setName;
        }
        //******End of sort by  product name desc******




        //******Start of sort by category nane asc when 'My Inventory Only' is selected******
        //Get first category name in search results in ascending order when 'My Inventory Only' is selected
        public string GetFirstCategoryMyInventoryOnlyAcs(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT Top 1 cat.CategoryName " + "\n" +
            "from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN InventoryDb_" + envLower + ".inv.Inventory i on i.SkuId = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId and s.SellerId = i.OwnerId " + "\n" +
            "where sp.SellerId = " + sellerId + "\n" +
            "and sp.quantity > 0 " + "\n" +
            "order by CategoryName, SetName, ProductName";
            string categoryName = DBSingleResultHelpers.DB_Method(sql);
            return categoryName;
        }
        //Get first product name in search results in ascending order when 'My Inventory Only' is selected
        public string GetFirstProductMyInventoryOnlyAcs(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT Top 1 p.ProductName " + "\n" +
            "from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN InventoryDb_" + envLower + ".inv.Inventory i on i.SkuId = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId and s.SellerId = i.OwnerId " + "\n" +
            "where sp.SellerId = " + sellerId + "\n" +
            "and sp.quantity > 0 " + "\n" +
            "order by CategoryName, SetName, ProductName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        //Get first SetName in search results in ascending order when 'My Inventory Only' is selected
        public string GetFirstSetNameMyInventoryOnlyAcs(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT Top 1 sn.SetName " + "\n" +
            "from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN InventoryDb_" + envLower + ".inv.Inventory i on i.SkuId = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId and s.SellerId = i.OwnerId " + "\n" +
            "where sp.SellerId = " + sellerId + "\n" +
            "and sp.quantity > 0 " + "\n" +
            "order by CategoryName, SetName, ProductName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }
        //******End of sort by category nane asc when 'My Inventory Only' is selected******



        //******Start of sort by category name desc when 'My Inventory Only' is selected******
        //Get first category name in search results when 'My Inventory Only' is selected and category is in descending order
        public string GetFirstCategoryMyInventoryOnlyDescByCatgegory(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT Top 1 cat.CategoryName " + "\n" +
            "from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN InventoryDb_" + envLower + ".inv.Inventory i on i.SkuId = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId and s.SellerId = i.OwnerId " + "\n" +
            "where sp.SellerId = " + sellerId + "\n" +
            "and sp.quantity > 0 " + "\n" +
            "order by CategoryName desc, SetName, ProductName";
            string categoryName = DBSingleResultHelpers.DB_Method(sql);
            return categoryName;
        }

        //Get first product name in search results when 'My Inventory Only' is selected and category is in descending order
        public string GetFirstProductMyInventoryOnlyDescByCatgegory(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT Top 1 p.ProductName " + "\n" +
            "from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN InventoryDb_" + envLower + ".inv.Inventory i on i.SkuId = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId and s.SellerId = i.OwnerId " + "\n" +
            "where sp.SellerId = " + sellerId + "\n" +
            "and sp.quantity > 0 " + "\n" +
            "order by CategoryName desc, SetName, ProductName";
            string productName = DBSingleResultHelpers.DB_Method(sql);
            return productName;
        }

        //Get first SetName in search results when 'My Inventory Only' is selected and category is in descending order
        public string GetFirstSetNameMyInventoryOnlyDescByCatgegory(string sellerId)
        {
            //Identifies the test region so variable can be passed in query below.
            var envData = JsonHelpers.GetJsonDataEnv("EnvironmentValues.json");
            string envLower = envData["envLower"];

            string sql = "SELECT Top 1 sn.SetName " + "\n" +
            "from dbo.StorePrice sp " + "\n" +
            "INNER JOIN PDT.ProductCondition pc ON sp.StoreProductConditionID = pc.ProductConditionId " + "\n" +
            "INNER JOIN InventoryDb_" + envLower + ".inv.Inventory i on i.SkuId = pc.ProductConditionId " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "INNER JOIN dbo.Seller s ON s.SellerID = sp.SellerId and s.SellerId = i.OwnerId " + "\n" +
            "where sp.SellerId = " + sellerId + "\n" +
            "and sp.quantity > 0 " + "\n" +
            "order by CategoryName desc, SetName, ProductName";
            string setName = DBSingleResultHelpers.DB_Method(sql);
            return setName;
        }
        //******End of sort by category nane desc when 'My Inventory Only' is selected******
        //*******End of: Use these queries to verify sorts and searches within the inventory tab.*********



        //*******************Lowest Listing - Last Sold- MarketPrice*********************

        //Get lowest listing   --Lowest Price (  StoreProductLowestPrice table uses StoreProductId and StoreConditionId, rather than StoreProductConditionId)
        public string GetLowestListing(string productConditionId, string conditionId)
        {
            string sql = "SELECT distinct cast(s.LowestPrice as numeric(10,2)) AS PriceLowestPrice " + "\n" +
            "FROM dbo.StoreProductLowestPrice s " + "\n" +
            "INNER JOIN  dbo.StorePrice sp ON sp.StoreProductId = s.StoreProductId " + "\n" +
            "where sp.StoreProductConditionId = " + productConditionId + "\n" +
            "and s.StoreConditionId = " + conditionId;
            string lowestListing = DBSingleResultHelpers.DB_Method(sql);
            return lowestListing;
        }

        public string GetLowestPriceShipping(string productConditionId, string conditionId)
        {
            string sql = "SELECT distinct cast(s.LowestPriceShipping as numeric(10,2)) AS PriceLowestPrice " + "\n" +
            "FROM dbo.StoreProductLowestPrice s " + "\n" +
            "INNER JOIN  dbo.StorePrice sp ON sp.StoreProductId = s.StoreProductId " + "\n" +
            "where sp.StoreProductConditionId = " + productConditionId + "\n" +
            "and s.StoreConditionId = " + conditionId;
            string lowestListing = DBSingleResultHelpers.DB_Method(sql);
            return lowestListing;
        }

        //Get ProductConditionId a seller has in thier Stage Pricing abd also has a High Price Value   
        public string GetProductConditionIdWithMarketPriceInStagedInventory(string sellerId)
        {
            string sql = "SELECT top 1 mpsp.ProductConditionId " + "\n" +
            "from dbo.MPStagedPricing mpsp " + "\n" +
            "Inner Join dbo.StorePrice sp On sp.StoreProductConditionId = mpsp.ProductConditionId " + "\n" +
            "Inner Join dbo.MPStagedPricingUpload mpspu On mpspu.MPStagedPricingUploadId = mpsp.MPStagedPricingUploadId " + "\n" +
            "Inner Join seller s On s.SellerId = mpspu.SellerId " + "\n" +
            "Inner Join pdt.ProductCondition pc On pc.ProductConditionId = mpsp.ProductConditionId " + "\n" +
            "Inner Join dbo.StoreProductMarketPrice spmp ON spmp.ProductConditionId = mpsp.ProductConditionId " + "\n" +
            "where s.SellerId = " + sellerId + "\n" +
            "and mpsp.Price is not Null";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get Last Sold Product Info
        //Place holder.  Not usable just yet.
        public string[] GetLastSoldProductInfo(string productConditionId)
        {
            string sql = "declare @T dbo.GenericIdData insert into @t(Id) values(" + productConditionId + ") EXEC[dbo].[GetProductConditionLastSold] @ProductConditionIds = @t";
            string[] value = DBMultipleResultsHelpers.DB_MethodReturnArray(sql);
            return value;
        }

        //Get Market Price 
        public string GetMarketPrice(string productConditionId)
        {
            string sql = "SELECT cast(Price as numeric(10,2)) AS Price FROM dbo.StoreProductMarketPrice where ProductConditionId = " + productConditionId;
            string marketPrice = DBSingleResultHelpers.DB_Method(sql);
            return marketPrice;
        }

        //Get Market Pricing Upload Id 
        public string MPStagedPricingUploadId(string sellerId)
        {
            string sql = "Select top 1 MPStagedPricingUploadId from dbo.MPStagedPricingUpload where sellerId = " + sellerId + " order by MPStagedPricingUploadId desc";
            string mpStagedPricingUploadId = DBSingleResultHelpers.DB_Method(sql);
            return mpStagedPricingUploadId;
        }

        //Get quantity from the dbo.MPStagedPricing table
        public string MPStagedPricingQuantity(string sellerId)
        {
            string sql = "Select top 1 Quantity from dbo.MPStagedPricingUpload u Inner Join dbo.MPStagedPricing p ON p.MPStagedPricingUploadId = u.MPStagedPricingUploadId " + "\n" +
            "where sellerId = " + sellerId + " order by u.MPStagedPricingUploadId desc";
            string mpStagedPricingUploadId = DBSingleResultHelpers.DB_Method(sql);
            return mpStagedPricingUploadId;
        }

        //Get count from the StorePrice table for a seller and StoreProductConditionId combination    
        public string GetStoreProductConditionIdCount(string sellerId, string StoreProductConditionId)
        {
            string sql = "select count (*) FROM StorePrice where SellerId = " + sellerId + " and StoreProductConditionId = " + StoreProductConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get SetName of a product based on the ProductConditionId
        public string GetSetName(string productConditionId)
        {
            string sql = "Select sn.SetName " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get Condition based on the ProductConditionId   
        public string GetCondition(string productConditionId)
        {
            string sql = "Select c.ConditionName " + "\n" +
            "From PDT.ProductCondition pc " + "\n" +
            "INNER JOIN PDT.Condition c ON pc.ConditionId = c.ConditionId " + "\n" +
            "INNER JOIN PDT.Product p ON p.ProductId = pc.ProductId " + "\n" +
            "INNER JOIN PDT.SetName sn ON sn.SetNameID = p.SetNameID " + "\n" +
            "INNER JOIN PDT.Category cat ON cat.CategoryID = p.CategoryId " + "\n" +
            "Where pc.ProductConditionId = " + productConditionId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Get Inventory Total per Inventory DB  
        public string GetInventoryTotal(string sellerId)
        {
            string sql = "Declare @SellerId BIGINT = " + sellerId + "\n" +
            "select" + "\n" +
            "(select sum(TotalInStock)" + "\n" +
            "from InventoryDb_QA.inv.Inventory" + "\n" +
            "where OwnerId = @SellerId and TotalInStock > 0)" + "\n" +
            "+" + "\n" +
            "(select sum(Quantity)" + "\n" +
            "from dbo.StorePriceCustom" + "\n" +
            "where SellerId = @SellerId" + "\n" +
            "and Price > 0 and Quantity > 0)" + "\n" +
            "+" + "\n" +
            "(select sum(sop.[Quantity])" + "\n" +
            "FROM[dbo].[SellerOrderProduct] sop" + "\n" +
            "INNER JOIN[dbo].[SellerOrder] so ON sop.[SellerOrderId] = so.[SellerOrderId]" + "\n" +
            "INNER JOIN[dbo].[Order] o ON o.[OrderId] = so.[OrderId]" + "\n" +
            "WHERE" + "\n" +
            "so.[SellerId] = @SellerId" + "\n" +
            "AND so.[SellerOrderStatusId] in (17, 25, 26, 21, 5)" + "\n" +  //VENDORRECEIVED, FRAUDPENDING, FRAUDWARNING, SALECOMPLETE, CAPTURED
            "AND so.[SellerPayStatusId] not in (5, 6)" + "\n" + //PAID, PAYABLE
            "AND NOT(" + "\n" +  //Exclude completed In - Store Pickup Pay Later
            "so.[SellerPayStatusId] = 4" + "\n" +  //NOTPROCESSED
            "AND so.[ShippingMethodId] = 4" + "\n" +  //IN - STORE PICKUP
            "AND o.[PaymentTypeId] = 9" + "\n" +  //PAYLATER
            "AND so.PickupStatusId = 4" + "\n" +  // PICKED UP
            "AND o.OrderStatusId = 3" + "\n" +  //SALECOMPLETE
            ")" + "\n" +
            "AND NOT EXISTS(SELECT 1 FROM[dbo].[TrackingNumber] WHERE[SellerOrderId] = so.[SellerOrderId])" + "\n" +  //Doesn't have a tracking number
            ")" ; 
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }


        //Get total count from StorePrice table   
        public string StorePriceCount(string sellerId)
        {
            string sql = "select count (*) from dbo.StorePrice where sellerId = " + sellerId;
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

    }
}