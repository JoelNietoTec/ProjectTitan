CREATE VIEW [dbo].[FinancialDashboards]
	AS SELECT ROW_NUMBER() OVER(ORDER BY ParticipantID) ID, * FROM(
SELECT  ParticipantProfiles.ParticipantID, MONTH(Transactions.Date) Month, TransactionTypes.Name Type, ProfileAccounts.Name Account,
TransactionSources.Name Source, Banks.ShortName Bank, ProfileProducts.Name ProfileProduct, FinancialProducts.Name FinancialProduct,
ProductTypes.Name ProductType,
  SUM(Transactions.Amount) Amount
FROM [dbo].Transactions
LEFT OUTER JOIN [dbo].TransactionTypes ON TransactionTypes.ID = Transactions.TransactionTypeID
LEFT OUTER JOIN [dbo].TransactionSources ON TransactionSources.ID = Transactions.TransactionSourceID
LEFT OUTER JOIN [dbo].ProfileAccounts ON ProfileAccounts.ID = Transactions.AccountID
LEFT OUTER JOIN [dbo].Banks ON Banks.ID = ProfileAccounts.BankID
LEFT OUTER JOIN [dbo].ParticipantProfiles ON ParticipantProfiles.ID = Transactions.ParticipantProfileID
LEFT OUTER JOIN [dbo].ProfileProducts ON ProfileProducts.ID = Transactions.ProfileProductID
LEFT OUTER JOIN [dbo].FinancialProducts ON FinancialProducts.ID = ProfileProducts.FinancialProductID
LEFT OUTER JOIN [dbo].ProductTypes ON ProductTypes.ID = FinancialProducts.ProductTypeID
GROUP BY ParticipantProfiles.ParticipantID, MONTH(Transactions.Date), TransactionTypes.Name, ProfileAccounts.Name,
TransactionSources.Name, Banks.ShortName, ProfileProducts.Name, FinancialProducts.Name,
ProductTypes.Name) AS X
