CREATE PROCEDURE GetCustomers
AS
SELECT C.*, A.City, A.State, A.StreetAddress, P.PhoneNumberType, P.PhoneNum
FROM Customers C
INNER JOIN Addresses A
ON A.Id = C.AddressId
INNER JOIN PhoneNumbers P
ON P.PersonId = C.Id





