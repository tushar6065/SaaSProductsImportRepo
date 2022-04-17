# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields
- Answer : SELECT * FROM USERS WHERE ID IN (3,2,4)

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
Answer:

SELECT Users.First_Name,Users.Last_Name, 
SUM(CASE WHEN Listings.status = 2 then 1 else 0 end) AS basic,
SUM(CASE WHEN Listings.status = 3 then 1 else 0 end) AS premium FROM USERS 
inner join LISTINGS 
ON USERS.Id = LISTINGS.User_id
WHERE Users.Status = 2
GROUP BY Users.First_Name,Users.Last_Name


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

Answer : 

SELECT Users.First_Name,Users.Last_Name, 
SUM(CASE WHEN Listings.status = 2 then 1 else 0 end) AS basic,
SUM(CASE WHEN Listings.status = 3 then 1 else 0 end) AS premium FROM USERS 
inner join LISTINGS 
ON USERS.Id = LISTINGS.User_id
WHERE Users.Status = 2
GROUP BY Users.First_Name,Users.Last_Name
HAVING PremiumListings >= 1


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

Answer :

SELECT first_name, last_name, currency, SUM(clicks.price) AS revenue
FROM  users
INNER JOIN listings
ON users.id = listings.user_id
INNER JOIN clicks
ON clicks.listing_id = listings.id
WHERE YEAR(clicks.created) = '2013' AND USERS.STATUS = 2
GROUP BY first_name,last_name, currency


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

Answer:
 

INSERT INTO CLICKS(listing_id,price,currency,created)
VALUES (3,4,'USD', NOW());
SELECT LAST_INSERT_ID() AS id;

6. Show listings that have not received a click in 2013
- Please return at least: listing_name

Answer:

SELECT NAME as listing_name FROM LISTINGS
WHERE ID NOT IN 
(
SELECT LISTINGS.ID FROM LISTINGS
INNER JOIN CLICKS
ON LISTINGS.ID = CLICKS.LISTING_ID
WHERE YEAR(CREATED) = '2013'
)



7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected

Answer:


SELECT YEAR(CLICKS.Created) AS date, COUNT( DISTINCT clicks.listing_id) AS total_listings_clicked, COUNT(DISTINCT listings.user_id) total_vendors_affected 
FROM USERS 
RIGHT JOIN LISTINGS 
ON USERS.Id = LISTINGS.User_id
INNER JOIN CLICKS 
ON CLICKS.LISTING_ID = LISTINGS.ID
GROUP BY YEAR(CLICKS.CREATED)




8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

ANSWER : 


SELECT first_name, last_name,GROUP_CONCAT(LISTINGS.NAME) AS listing_names FROM USERS
INNER JOIN LISTINGS
ON USERS.ID = LISTINGS.USER_ID
WHERE USERS.STATUS = 2
GROUP BY FIRST_NAME, LAST_NAME