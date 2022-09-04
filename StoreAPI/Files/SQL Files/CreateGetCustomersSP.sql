CREATE PROCEDURE GetCustomer @ID INT
AS
--SELECT C.*, A.*, P.*
--FROM Customers C
--INNER JOIN Addresses A
--ON A.Id = C.Id
--INNER JOIN PhoneNumbers P
--ON P.PersonId = C.Id
--WHERE C.Id = @ID

select * from customers WHERE Id = @ID
select * from addresses WHERE Id = @ID
select * from PhoneNumbers WHERE PersonId = @ID





