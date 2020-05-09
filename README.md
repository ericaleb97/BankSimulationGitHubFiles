# Bank Simulation
This program simulates a real ATM machine. The user will enter their userID (substituting for a card) and their PIN.
Once logged in, using their data from MS SQL, a second window will appear with their total amount of money displayed in a textbox.
From there, the user can enter into a second textbox on the same form a number they wish to deposit or withdraw into their account.
Their total amount of money will be affected in real time and the SQL database will be updated as well.

## Examples
This database contains two separate tables; User and Transaction.

The User table is reserved for personal information, such as their userID, Name, PIN, and startingBalance.
The Transaction table is where deposit and withdrawl information is stored, such as the transactionID, userID, amount, and transactionDate.

We run the program and see the first window pop up. In this case, let's assume the database already has a user created.
We will enter in E73561 in the userID text box, and 5312 for the PIN. Next, we hit the Enter button.

Once logged in, we will see a text box that contains the user's current balance, comprised of the initial starting balance they entered with at the moment their account was created combined with all of the deposits and withdrawls made until this point. For example, let's suppose Eric created his account and initially deposited $10,000. After time, he has deposited a total of $1,000 but has withdrawn $2,000. The value in the startingBalance column in the database would then be $9,000 ($10,000 + $1,000 - $2,000).

We have two action buttons; deposit and withdraw. Whichever we select, the number inside of the balance text box will reflect the amount deposited or withdrawn in real time. The startingBalance will be updated (not the actual value in the User table, rather, the startingBalance as explained above) and the Transaction table will show the new transactionID, userID, amount that was entered, and the date of the transaction.

## Prerequisites

### What you'll need to run the code:

* Internet connection

* Visual Studios 2012 v 11.0

* MS SQL Server 2012 v 11.0

### Download the latest versions:

https://visualstudio.microsoft.com/downloads/

https://www.microsoft.com/en-us/sql-server/sql-server-downloads# 
