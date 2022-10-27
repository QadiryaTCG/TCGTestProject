using Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCGplayerUI.Queries
{
    class ManageListsQueries
    {
        //Creates a Product List, adds a product to the list (hard coded variables beacuse we do not need any specific product now)
        //Then it returns the ProductListKey
        public string CreateListWithProductReturnProductListKey(string providerUserName, string sellerId, string productConditionId, string quantity, string price, string productListAction)
        {
            //Create a ProductList based on a SellerId
            string createProductListQuery = "INSERT INTO dbo.ProductList (ProductListKey, UserId, CreatedAt, ProductListActionId, ActionTimestamp, ParentProductListId, Note, SellerId, IsArchived) " + "\n" +
            "VALUES(NEWID(), (select UserID from [User] where ProviderUserName = '" + providerUserName + "'), GETUTCDATE(), NULL, NULL, NULL, NULL, " + sellerId + ", 0)";
            DBUpdateHelpers.DBUpdateMethod(createProductListQuery);

            //Get the ProductListId just created
            string sqlProductListId = "select top 1 ProductListId from dbo.ProductList where SellerId = " + sellerId + " order by ProductListId desc";
            string productListId = DBSingleResultHelpers.DB_Method(sqlProductListId);

            //Add Product to a list        
            string productListItemQuery = "Insert into dbo.ProductListItem(ProductListId, ProductConditionId, Quantity, Price) values(" + productListId + ", " + productConditionId + ", " + quantity + ", " + price + ")";
            DBUpdateHelpers.DBUpdateMethod(productListItemQuery);

            //Set ProductListActionId         
            string productListActionIdQuery = "update dbo.ProductList set ProductListActionId = (select ProductListActionId from ProductListAction where Name = '" + productListAction + "'), ActionTimestamp = GETUTCDATE() where ProductListId = " + productListId;
            DBUpdateHelpers.DBUpdateMethod(productListActionIdQuery);

            string sqlProductListKey = "select top 1 ProductListKey from dbo.ProductList where SellerId = " + sellerId + " order by ProductListId desc";
            string productListKey = DBSingleResultHelpers.DB_Method(sqlProductListKey);
            return productListKey;

        }

        public string GetArchivedProductListKey(string sellerId)
        {
            string sql = "select top 1 ProductListKey from dbo.productlist where SellerId = " + sellerId + " and IsArchived = 1 order by ProductListId desc";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }

        public string GetDraftCount(string sellerId)
        {
            string sql = "select count (*) from dbo.productlist where SellerId = " + sellerId + " and ProductListActionId is Null";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }


        public string GetAssociatedProductListKey(string ProductListKey)
        {
            string sql = "select ProductListKey from dbo.ProductList where ParentProductListId = (select ProductListId from  dbo.ProductList where ProductListKey = '" + ProductListKey + "')";
            string result = DBSingleResultHelpers.DB_Method(sql);
            return result;
        }


    }
}
