CREATE VIEW [dbo].[FinancialProfiles]
	AS SELECT P.ID, P.ParticipantID, P.Total, P.ModifiedDate, P.MonthlyIncomeLimit, P.MonthlyExpenseLimit, 
(SELECT ISNULL(SUM(Amount), 0) FROM [Transactions] WHERE ParticipantProfileID = P.ID AND YEAR(Date) = YEAR(GETDATE()) AND MONTH(Date) = MONTH(GETDATE()) AND TransactionTypeID = 1) IncomeMTD,
(SELECT ISNULL(SUM(Amount), 0) FROM [Transactions] WHERE ParticipantProfileID = P.ID AND YEAR(Date) = YEAR(GETDATE()) AND MONTH(Date) = MONTH(GETDATE()) AND TransactionTypeID = 2) ExpenseMTD, 
(SELECT ISNULL(SUM(Amount), 0) FROM [Transactions] WHERE ParticipantProfileID = P.ID AND YEAR(Date) = YEAR(GETDATE()) AND TransactionTypeID = 1) IncomeYTD,
(SELECT ISNULL(SUM(Amount), 0) FROM [Transactions] WHERE ParticipantProfileID = P.ID AND YEAR(Date) = YEAR(GETDATE()) AND TransactionTypeID = 2) ExpenseYTD
FROM [ParticipantProfiles] P
