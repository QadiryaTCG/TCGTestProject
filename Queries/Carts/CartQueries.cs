﻿using Framework.Helpers;
using System;

namespace TCGplayerUI.Queries.Carts
{
   public class CartQueries
    {
        public string CartItemIdStoreFronts(string buyerEmail, string sellerId)
        {
            string sql = "select ci.CartItemId from dbo.[User] u Inner Join dbo.cart c ON c.ProviderUserKey = u.ProviderUserKey Inner Join dbo.cartitem ci ON ci.CartId = c.CartId where u.ProviderUserName = '" + buyerEmail + "' and c.ExpiresAt is NULL and c.SellerId = " + sellerId + " order by c.cartid desc";
            string cartItemId = DBSingleResultHelpers.DB_Method(sql);
            return cartItemId;
        }

        //This will return the specific CartItemId based on SellerID and ProductConditionId
        public string CartItemIdSpecific(string buyerEmail, string sellerId, string productConditionId)
        {
            string sql = "select ci.CartItemId from dbo.[User] u Inner Join dbo.cart c ON c.ProviderUserKey = u.ProviderUserKey Inner Join dbo.cartitem ci ON ci.CartId = c.CartId where u.ProviderUserName = '" + buyerEmail + "' and ci.StoreProductConditionID = " + productConditionId + "and c.ExpiresAt is NULL and c.SellerId = " + sellerId + " order by c.cartid desc";
            string cartItemId = DBSingleResultHelpers.DB_Method(sql);
            return cartItemId;
        }


        public string CartItemIdMarketPlace(string buyerName)
        {
            string sql = "select ci.CartItemId from dbo.[User] u Inner Join dbo.cart c ON c.ProviderUserKey = u.ProviderUserKey Inner Join dbo.cartitem ci ON ci.CartId = c.CartId where u.ProviderUserName = '" + buyerName + "' and c.ExpiresAt is NULL order by c.cartid desc";
            string cartItemId = DBSingleResultHelpers.DB_Method(sql);
            return cartItemId;
        }

        public string CartItemIdMarketPlaceSpecificItem(string buyerName, string productConditionId)
        {
            string sql = "select ci.CartItemId from dbo.[User] u Inner Join dbo.cart c ON c.ProviderUserKey = u.ProviderUserKey Inner Join dbo.cartitem ci ON ci.CartId = c.CartId where u.ProviderUserName = '" + buyerName + "'  and StoreProductConditionID = " + productConditionId + " and c.ExpiresAt is NULL order by c.cartid desc";
            string cartItemId = DBSingleResultHelpers.DB_Method(sql);
            return cartItemId;
        }


        public string CartKey(string buyerName, string sellerId)
        {
            string sql = "select top 1 c.CartKey from dbo.[User] u Inner Join dbo.cart c ON c.ProviderUserKey = u.ProviderUserKey Inner Join dbo.cartitem ci ON ci.CartId = c.CartId where u.ProviderUserName = '" + buyerName + "' and c.ExpiresAt is NULL and c.SellerId = " + sellerId + " order by c.cartid desc";
            string cartKey = DBSingleResultHelpers.DB_Method(sql);
            return cartKey;
        }

        //This will clear the buyer's cart via the DB.  Can be used for Umbrcao or MarketPlace carts.
        public void ClearCart(string buyerEmail)
        {
            string updateQuery = "DELETE FROM cartitem WHERE cartid IN (SELECT c.cartid FROM [cart] c INNER JOIN[user] u ON u.userid = c.createdbyuserid INNER JOIN cartitem ci ON ci.cartid = c.cartid WHERE providerusername = '" + buyerEmail + "' AND ExpiresAt IS NULL)";
            DBUpdateHelpers.DBUpdateMethod(updateQuery);
            Console.WriteLine("Database connection is done!");
        }
    }
}
