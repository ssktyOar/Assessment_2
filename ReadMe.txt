

_____________________1_______________________

Compiled program itself is named ClientTicket.exe and can be found at path:

1. C:\Assessment1\Program\bin\Release\net7.0

or

2. C:\Assessment1\Program\bin\Debug\net7.0



_____________________2_______________________

Whenewer you choose new path for saving data you need to put

at least one file with account data on path: 

C:\Assessment1\Program\bin\Release\net7.0\settings\Accounts\*username*.txt


Registration from Help Desk App is not available due to security reasons, 

so at least one file with account data should be placed here before atarting app, otherwise you will be unable to register.


_____________________3_______________________

Structure of account data file is simple:

it names filename.txt, where if filename is a user's name,

the file itself contains only 3 lines of UTF8 text.


First line is for password, second for stuffID and third for user's E-mail.



_____________________4_______________________

In settings directory aside from Account subdirectory there is another 3:


1. Created - is directory for all tasks that has been created, and this also helps app

to find highest ticket's number after resart.


2. Resolved - is diretory for resolved tickets.


3. To solve - is directory for tickets that should be solved.



_____________________5_______________________

Every ticket will be saved into independend *.txt file, data inside saved as UTF8 text.

Name of file is a number that starts from 2000, this is also a number of the ticket contained inside.

Data should be separated from key words by space, no terminate symbols in the data allowed.

There is an example of this file:



Ticket_Number: 2001
Ticket_Creator: Leo
StuffID: AMSHSBDH
Email_Address: leo@whitecliffe.co.nz
Description: Router is broken
Response: Quickly has been fixed by team 68
Ticket_Status: Closed



File includes only these 7 lines, numeration starts from 1.

Data in lines number 2, 3, 4, 5, 6 can be any UTF8 text without special symbols. In line 6 default value is: Not Yet Provided

Data in first line can contain only symbols 0123456789, as integer it can not be bigger than 2147483647. Number and name of file should be similar.

Data in the line 7 can contaion only word Open or only word Closed. Tickets with value "Open" should be contained in "To solve" directory,

otherwise it should be contained in "Resolved" directory.

Dublicate of each file placed in directory "Created" and its data should be updated right after it's update in "Resolved" or "To solve" directories.



_____________________6_______________________


To compile source there is necessary to install Visual Studio 2022 ver. 17.7.2 or higher, .NET 7.0 runtime required.