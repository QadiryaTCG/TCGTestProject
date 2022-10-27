using Framework.Base;
using Framework.Helpers;

namespace TCGplayerUI.Queries
{
    public class FeeQueries : StartBrowser
    {
        //Start of queries that will get the rates charged for fees based on the SellerId or OrderId.
        //Determine the percentage rate a seller is charged for US Credit Card fees         
        public string CreditCardUSPercentageRate(string sellerId)
        {
            string sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Credit Card US'";
            string creditCardPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            return creditCardPercentageRate;
        }

        //Determine the percentage rate a seller is charged for International Credit Card fees         
        public string CreditCardInternationalPercentageRate(string sellerId)
        {
            string sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Credit Card Intl'";
            string creditCardPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            return creditCardPercentageRate;
        }

        //Determine the percentage rate a seller is charged for US PayPal fees         
        public string PayPalUSPercentageRate(string sellerId)
        {
            string sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'PayPal US'";
            string creditCardPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            return creditCardPercentageRate;
        }

        //Determine the base rate a seller is charged for US Credit Card fees         
        public string CreditCardBaseRate(string sellerId)
        {
            string sql = "Select fri.BaseRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Credit Card US'";
            string creditCardBaseRate = DBSingleResultHelpers.DB_Method(sql);
            return creditCardBaseRate;
        }

        //Determine the base rate a seller is charged for International Credit Card fees         
        public string CreditCardInternationalBaseRate(string sellerId)
        {
            string sql = "Select fri.BaseRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Credit Card Intl'";
            string creditCardBaseRate = DBSingleResultHelpers.DB_Method(sql);
            return creditCardBaseRate;
        }

        //Determine the base rate a seller is charged for US Store Credit fees  
        public string StoreCreditUSPercentageRate(string sellerId)
        {
            string sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Store Credit US'";
            string storeCreditPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditPercentageRate;
        }

        //Determine the base rate a seller is charged for International Store Credit fees  
        public string StoreCreditInternationalPercentageRate(string sellerId)
        {
            string sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Store Credit Intl'";
            string storeCreditPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditPercentageRate;
        }

        //Determine the base rate a seller is charged for US Store Credit fees         
        public string StoreCreditUSBaseRate(string sellerId)
        {
            string sql = "Select fri.BaseRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Store Credit US'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Determine the base rate a seller is charged for International Store Credit fees         
        public string StoreCreditInternationalBaseRate(string sellerId)
        {
            string sql = "Select fri.BaseRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Where s.SellerId = " + sellerId + " " + "\n" +
                "and fti.[Name] = 'Store Credit Intl'";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //Determine the percentage rate a seller is charged for Commission fees.  This can be used for any order including Direct.  
        //Loops through and determines the percentage rate based on the how the code works.           
        public string CommissionPercentageRate(string productTypeId, string orderNumber)
        {
            //If the seller is an non ProSellers, no rate adjustments are made.
            string sql = "Select fri.PercentageRate " + "\n" +
            "From Seller s " + "\n" +
            "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
            "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
            "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
            "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
            "Where fti.[Name] = 'Commission' " + "\n" +
            "and ProductTypeId = " + productTypeId + "\n" +
            "and s.ProServicesLevelId IS NULL " + "\n" +
            "and so.OrderNumber = '" + orderNumber + "'";
            string commissionPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            if (commissionPercentageRate == "")
            {
                //The flag to apply only the 2.5 % fee is that the dbo.Seller.ProServicesLevelId value is 1(TCGplayer Pro) and the dbo.Order.ChannelId value is 1 (Storefront) .
                //The 2.5 % fee is the only fee applied. This value is stored in the configuration file in the TCGplayer code.
                sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
                "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
                "Where fti.[Name] = 'Commission' " + "\n" +
                "and ProductTypeId = " + productTypeId + "\n" +
                "and s.ProServicesLevelId = 1 " + "\n" +
                "and so.ShippingMethodId IS NULL " + "\n" +
                "and o.ChannelId = 1 " + "\n" +
                "and so.OrderNumber = '" + orderNumber + "'";
                commissionPercentageRate = DBSingleResultHelpers.DB_Method(sql);
                if (commissionPercentageRate != "")
                {
                    commissionPercentageRate = "2.50";
                }
                else if (commissionPercentageRate == "")
                {
                    //The flag to apply the 2.5% additional fee is that the dbo.Seller.ProServicesLevelId value is 1(TCGplayer Pro) and the dbo.Order.ChannelId value is 0 (Marketplace)
                    //The 2.5 % fee is added on top of existing commission fees. This value is stored in the configuration file in the TCGplayer code.
                    sql = "Select fri.PercentageRate " + "\n" +
                    "From Seller s " + "\n" +
                    "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                    "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                    "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
                    "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
                    "Where fti.[Name] = 'Commission' " + "\n" +
                    "and ProductTypeId = " + productTypeId + "\n" +
                    "and s.ProServicesLevelId = 1 " + "\n" +
                    "and so.ShippingMethodId IS NULL " + "\n" +
                    "and o.ChannelId = 0 " + "\n" +
                    "and so.OrderNumber = '" + orderNumber + "'";
                    commissionPercentageRate = DBSingleResultHelpers.DB_Method(sql);
                    if (commissionPercentageRate != "")
                    {
                        decimal commissionPercentageRateDecimal = decimal.Parse(commissionPercentageRate);
                        string commissionPercentageRateDecimalString = commissionPercentageRateDecimal.ToString();
                        decimal percent = 2.50M;
                        commissionPercentageRateDecimal = (commissionPercentageRateDecimal + percent);
                        commissionPercentageRate = commissionPercentageRateDecimal.ToString();
                    }
                    else if (commissionPercentageRate == "")
                    {
                        //If the dbo.SellerOrder.ShippingMethodId value is 4(In - Store Pickup) there should not be any fees applied. Only applies to dbo.Seller.ProServicesLevelId value is 1(TCGplayer Pro)
                        sql = "Select fri.PercentageRate " + "\n" +
                        "From Seller s " + "\n" +
                        "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                        "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                        "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
                        "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
                        "Where fti.[Name] = 'Commission' " + "\n" +
                        "and ProductTypeId = " + productTypeId + "\n" +
                        "and s.ProServicesLevelId = 1 " + "\n" +
                        "and so.ShippingMethodId = 4 " + "\n" +
                        "and so.OrderNumber = '" + orderNumber + "'";
                        commissionPercentageRate = DBSingleResultHelpers.DB_Method(sql);
                        if (commissionPercentageRate != "")
                        {
                            commissionPercentageRate = "0.00";
                        }
                        else
                        {
                            StartBrowser.childTest.Fail("Query results for fees encountered a problem.  Failing test.");
                        }
                    }
                }
            }
            return commissionPercentageRate;
        }


        //Determine the percentage rate a seller is charged for Shipping fees. This can be used for any order EXCEPT Direct.  
        //Loops through and determines the percentage rate based on the how the code works.           
        public string ShippingPercentageRate(string orderNumber)
        {
            //If the seller is an non ProSellers, no rate adjustments are made.
            string sql = "Select fri.PercentageRate " + "\n" +
            "From Seller s " + "\n" +
            "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
            "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
            "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
            "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
            "Where fti.[Name] = 'Shipping Cost' " + "\n" +
            "and s.ProServicesLevelId IS NULL " + "\n" +
            "and so.OrderNumber = '" + orderNumber + "'";
            string shippingPercentageRate = DBSingleResultHelpers.DB_Method(sql);
            if (shippingPercentageRate == "")
            {
                //The flag to apply only the 2.5 % fee is that the dbo.Seller.ProServicesLevelId value is 1(TCGplayer Pro) and the dbo.Order.ChannelId value is 1 (Storefront) .
                //The 2.5 % fee is the only fee applied.  This value is stored in the configuration file in the TCGplayer code.
                sql = "Select fri.PercentageRate " + "\n" +
                "From Seller s " + "\n" +
                "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
                "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
                "Where fti.[Name] = 'Shipping Cost' " + "\n" +
                "and s.ProServicesLevelId = 1 " + "\n" +
                "and so.ShippingMethodId IS NULL " + "\n" +
                "and o.ChannelId = 1 " + "\n" +
                "and so.OrderNumber = '" + orderNumber + "'";
                shippingPercentageRate = DBSingleResultHelpers.DB_Method(sql);
                if (shippingPercentageRate != "")
                {
                    shippingPercentageRate = "2.50";
                }
                else if (shippingPercentageRate == "")
                {
                    //The flag to apply the 2.5% additional fee is that the dbo.Seller.ProServicesLevelId value is 1(TCGplayer Pro) and the dbo.Order.ChannelId value is 0 (Marketplace)
                    //The 2.5 % fee is added on top of existing commission fees.  This value is stored in the configuration file in the TCGplayer code.
                    sql = "Select fri.PercentageRate " + "\n" +
                    "From Seller s " + "\n" +
                    "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                    "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                    "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
                    "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
                    "Where fti.[Name] = 'Shipping Cost' " + "\n" +
                    "and s.ProServicesLevelId = 1 " + "\n" +
                    "and so.ShippingMethodId IS NULL " + "\n" +
                    "and o.ChannelId = 0 " + "\n" +
                    "and so.OrderNumber = '" + orderNumber + "'";
                    shippingPercentageRate = DBSingleResultHelpers.DB_Method(sql);
                    if (shippingPercentageRate != "")
                    {
                        decimal shippingPercentageRateDecimal = decimal.Parse(shippingPercentageRate);
                        string shippingPercentageRateDecimalString = shippingPercentageRateDecimal.ToString();
                        decimal percent = 2.50M;
                        shippingPercentageRateDecimal = (shippingPercentageRateDecimal + percent);
                        shippingPercentageRate = shippingPercentageRateDecimal.ToString();
                    }
                    else if (shippingPercentageRate == "")
                    {
                        //If the dbo.SellerOrder.ShippingMethodId value is 4(In - Store Pickup) there should not be any fees applied. Only applies to dbo.Seller.ProServicesLevelId value is 1(TCGplayer Pro)
                        sql = "Select fri.PercentageRate " + "\n" +
                        "From Seller s " + "\n" +
                        "Inner Join FeeRate fri ON fri.RateCardId = s.RateCardId " + "\n" +
                        "Inner Join FeeType fti ON fti.FeeTypeId = fri.FeeTypeId " + "\n" +
                        "Inner Join SellerOrder so ON so.SellerId = s.SellerId " + "\n" +
                        "Inner Join[Order] o ON o.OrderId = so.OrderId " + "\n" +
                        "Where fti.[Name] = 'Shipping Cost' " + "\n" +
                        "and s.ProServicesLevelId = 1 " + "\n" +
                        "and so.ShippingMethodId = 4 " + "\n" +
                        "and so.OrderNumber = '" + orderNumber + "'";
                        shippingPercentageRate = DBSingleResultHelpers.DB_Method(sql);
                        if (shippingPercentageRate != "")
                        {
                            shippingPercentageRate = "0.00";
                        }
                        else
                        {
                            StartBrowser.childTest.Fail("Query results for fees encountered a problem.  Failing test.");
                        }
                    }
                }
            }
            return shippingPercentageRate;
        }

        //Determine the Direct progam fee.  Based on card quantity and product cost.
        public string DirectProgramFee(string quantity, decimal productCost)
        {
            string sql = "select top 1 cast((Round((SELECT dof.TotalFee), 2, 0)) as decimal(10,2)) " + "\n" +
            "from shp.PackageTypeTier ptt " + "\n" +
            "Inner Join shp.Postage p On p.PackageTypeTierId = ptt.PackageTypeTierId " + "\n" +
            "Inner Join TCGD.DirectOrderFee dof on p.PostageId = dof.PostageId " + "\n" +
            "where ptt.InclusiveMaxCards >= " + quantity + "\n" +
            "and ptt.InclusiveMaxProductCost >= '" + productCost + "' " + "\n" +
            "and ptt.IsActive = 1 " + "\n" +
            "and p.IsActive = 1 " + "\n" +
            "and dof.IsActive = 1 " + "\n" +
            "order by dof.TotalFee";
            string directProgramFee = DBSingleResultHelpers.DB_Method(sql);
            return directProgramFee;
        }
        //End of queries that will get the rates charged for fees based on the SellerId or OrderId.



        //Start of SellerOrderFee Table: Queries for the fees that were actually charged on orders
        //SellerOrderFee table: US Credit Card Fees.  This is the percent rate. 
        public string CreditCardUSPercentageFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Credit Card US' and sof.FlatRate = '0.00'";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: International Credit Card Fees.  This is the percent rate. 
        public string CreditCardInternationalPercentageFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Credit Card Intl' and sof.FlatRate = '0.00'";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: US Credit Card Fees.  This is the base rate. 
        public string CreditCardUSBaseFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Credit Card US' and sof.PercentRate = '0.00'";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: International Credit Card Fees.  This is the base rate. 
        public string CreditCardInternationalBaseFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Credit Card Intl' and sof.PercentRate = '0.00'";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: US Store Credit Fees.  This is the percent rate. 
        public string StoreCreditUSPercentageFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Store Credit US' and sof.FlatRate = '0.00'";
            string storeCreditUSFee = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditUSFee;
        }

        //SellerOrderFee table: International Store Credit Fees.  This is the percent rate. 
        public string StoreCreditInternationalPercentageFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Store Credit Intl' and sof.FlatRate = '0.00'";
            string storeCreditUSFee = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditUSFee;
        }

        //SellerOrderFee table: US Store Credit Fees.  This is the base rate. 
        public string StoreCreditUSBaseFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Store Credit US' and sof.PercentRate = '0.00'";
            string storeCreditUSFee = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditUSFee;
        }

        //SellerOrderFee table: International Store Credit Fees.  This is the base rate. 
        public string StoreCreditInternationalBaseFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Store Credit Intl' and sof.PercentRate = '0.00'";
            string storeCreditUSFee = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditUSFee;
        }

        //SellerOrderFee table: Commission Fee for a seller order 
        public string CommissionFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Commission'";
            string commissionFee = DBSingleResultHelpers.DB_Method(sql);
            //If Null, convert it to 0.
            if (commissionFee == "")
            {
                commissionFee = "0.00";
            }
            return commissionFee;
        }

        //SellerOrderFee table: Shipping Cost for a seller order         
        public string ShippingFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Shipping Cost'";
            string shippingFee = DBSingleResultHelpers.DB_Method(sql);
            //If Null, convert it to 0.
            if (shippingFee == "")
            {
                shippingFee = "0.00";
            }
            return shippingFee;
        }

        //SellerOrderFee table: Direct Program Fee
        public string DirectProgramFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Direct Program Fee'";
            string directProgramFee = DBSingleResultHelpers.DB_Method(sql);
            return directProgramFee;
        }

        //SellerOrderFee table: Small Direct Order Fee
        public string SmallDirectOrderFeeCharged(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 1 and f.Name = 'Small Direct Order Fee'";
            string smallDirectOrderFee = DBSingleResultHelpers.DB_Method(sql);
            return smallDirectOrderFee;
        }
        //End of SellerOrderFee Table: Queries for the fees actually charged on orders


        //Start of SellerOrderFee Table: Queries for refunded fees
        //SellerOrderFee table: US Credit Card Fees for a refunded seller order.  (This is the percent rate.)
        public string CreditCardUSPercentageFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Credit Card US' and sof.FlatRate = '0.00' order by SellerOrderFeeId desc";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: International Credit Card Fees for a refunded seller order.  (This is the percent rate.)
        public string CreditCardInternationalPercentageFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Credit Card Intl' and sof.FlatRate = '0.00' order by SellerOrderFeeId desc";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: US Credit Card Fees for a refunded seller order.  (This is the base rate.  Only refunded for full refunds.)
        public string CreditCardUSBaseFeeRefunded(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Credit Card US' and sof.PercentRate = '0.00' order by SellerOrderFeeId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //SellerOrderFee table: International Credit Card Fees for a refunded seller order.  (This is the base rate.  Only refunded for full refunds.)
        public string CreditCardInternationalBaseFeeRefunded(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Credit Card Intl' and sof.PercentRate = '0.00' order by SellerOrderFeeId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //SellerOrderFee table: US PayPal Fees for a refunded seller order.  (This is the percent rate.)
        public string PayPalUSPercentageFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'PayPal US' and sof.FlatRate = '0.00' order by SellerOrderFeeId desc";
            string creditCardUSFee = DBSingleResultHelpers.DB_Method(sql);
            return creditCardUSFee;
        }

        //SellerOrderFee table: US PayPal Fees for a refunded seller order.  (This is the base rate.  Only refunded for full refunds.)
        public string PayPalUSBaseFeeRefunded(string orderNumber)
        {
            string sql = "Select sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'PayPal US' and sof.PercentRate = '0.00' order by SellerOrderFeeId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //SellerOrderFee table: US Store Credit Fees for a refunded seller order.  (This is the percent rate.  )
        public string StoreCreditUSPercentageFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Store Credit US' and sof.FlatRate = '0.00' order by SellerOrderFeeId desc";
            string storeCreditUSFee = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditUSFee;
        }

        //SellerOrderFee table: International Store Credit Fees for a refunded seller order.  (This is the percent rate.  )
        public string StoreCreditInternationalPercentageFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Store Credit Intl' and sof.FlatRate = '0.00' order by SellerOrderFeeId desc";
            string storeCreditUSFee = DBSingleResultHelpers.DB_Method(sql);
            return storeCreditUSFee;
        }

        //SellerOrderFee table: US Store Credit Fees for a refunded seller order.  (This is the base rate.  Only refunded for full refunds.)
        public string StoreCreditUSBaseFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Store Credit US' and sof.PercentRate = '0.00' order by SellerOrderFeeId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        //SellerOrderFee table: International Store Credit Fees for a refunded seller order.  (This is the base rate.  Only refunded for full refunds.)
        public string StoreCreditInternationalBaseFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Store Credit Intl' and sof.PercentRate = '0.00' order by SellerOrderFeeId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        // table: Commission Fee for a refunded seller order 
        public string CommissionFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Commission' order by SellerOrderFeeId desc";
            string commissionFee = DBSingleResultHelpers.DB_Method(sql);
            //If Null, convert it to 0.
            if (commissionFee == "")
            {
                commissionFee = "0.00";
            }
            return commissionFee;
        }

        //SellerOrderFee table: Shipping Cost for a refunded seller order         
        public string ShippingFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Shipping Cost' order by SellerOrderFeeId desc";
            string shippingFee = DBSingleResultHelpers.DB_Method(sql);
            //If Null, convert it to 0.
            if (shippingFee == "")
            {
                shippingFee = "0.00";
            }
            return shippingFee;
        }

        //SellerOrderFee table: Shipping Cost for a refunded seller order         
        public string DirectProgramFeeRefunded(string orderNumber)
        {
            string sql = "Select top 1 sof.Amt from dbo.SellerOrderFee sof Inner Join dbo.SellerOrder so on sof.SellerOrderId = so.SellerOrderId Inner Join dbo.FeeType f on sof.FeeTypeId = f.FeeTypeId " +
            "Where so.OrderNumber = '" + orderNumber + "' and sof.RateProcessingTypeId = 2 and f.Name = 'Direct Progam Fee' order by SellerOrderFeeId desc";
            string shippingFee = DBSingleResultHelpers.DB_Method(sql);
            //If Null, convert it to 0.
            if (shippingFee == "")
            {
                shippingFee = "0.00";
            }
            return shippingFee;
        }

        //SellerOrderFee table: Get last SellerOrderFeeId from a SellerOrderId         
        public string GetLastSellerOrderFeeId(string sellerOrderId)
        {
            string sql = "select top 1 SellerOrderFeeId from dbo.SellerOrderFee where sellerOrderId = " + sellerOrderId +" order by SellerOrderFeeId desc";
            string value = DBSingleResultHelpers.DB_Method(sql);            
            return value;
        }
        //End of SellerOrderFee Table: Queries for refunded fees


        //Get Tax charge to an order.  Any order: Direct and non Direct.
        public string TaxAmt(string orderNumber)
        {
            string taxAmount = "0.00";
            //SellerOrder Table: SellerTaxAmt for an order
            string sql = "Select so.SellerTaxAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Where so.OrderNumber = '" + orderNumber + "'";
            string SellerTaxAmt = DBSingleResultHelpers.DB_Method(sql);
            //SellerOrder Table: TCGTaxAmt for an order
            sql = "Select so.TCGTaxAmt from dbo.SellerOrder so Inner Join dbo.[Order] o On o.OrderId = so.OrderId Where so.OrderNumber = '" + orderNumber + "'";
            string TCGTaxAmt = DBSingleResultHelpers.DB_Method(sql);
            if (SellerTaxAmt != "0.00")
            {
                taxAmount = SellerTaxAmt;
            }
            else if (TCGTaxAmt != "0.00")
            {
                taxAmount = TCGTaxAmt;
            }
            return taxAmount;
        }

        public string GetRateCardId(string sellerId)
        {
            string sql = "Select RateCardId from dbo.Seller Where SellerId = " + sellerId;
            string rateCardId = DBSingleResultHelpers.DB_Method(sql);
            return rateCardId;
        }

        public string GetStoreCreditUSFeeRefundedFromFullRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 9 AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetStoreCreditInternationalFeeRefundedFromFullRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 10 AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetCreditCardUSFeeRefundedFromFullRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 5 AND sof.FlatRate = '0.00' AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetCreditCardInternationalFeeRefundedFromFullRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 6 AND sof.FlatRate = '0.00' AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetStoreCreditUSFeeRefundedSinceLastPartialRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 9 AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetStoreCreditInternationalFeeRefundedSinceLastPartialRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 10 AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetCreditCardUSFeeRefundedSinceLastPartialRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 5 AND sof.FlatRate = '0.00' AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }

        public string GetCreditCardInternationalFeeRefundedSinceLastPartialRefund(string orderNumber)
        {
            string sql = "SELECT Amt FROM SellerOrderFee sof INNER JOIN SellerOrder so ON sof.SellerOrderId = so.SellerOrderId WHERE so.OrderNumber = '" + orderNumber + "'  " +
            "AND FeeTypeId = 6 AND sof.FlatRate = '0.00' AND RateProcessingTypeId = 2";
            string value = DBSingleResultHelpers.DB_Method(sql);
            return value;
        }
    }
}


