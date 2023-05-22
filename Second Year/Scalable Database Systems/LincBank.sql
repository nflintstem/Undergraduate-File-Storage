CREATE DATABASE LincBank;

CREATE TABLE LincBank.Customer(
  UserID varchar(2) PRIMARY KEY,
  FirstName varchar(32),
  Surname varchar(32),
  DoB DATE,
  Telephone INTEGER(11),
  AddressLine1 varchar(64),
  City varchar(20),
  Country varchar(2),
  Postcode varchar(7)
);

CREATE TABLE LincBank.Loan(
  LoanID varchar(8) PRIMARY KEY,
  FirstPayment DATE,
  Amount DOUBLE,
  NoPayments INT,
  PaymentAmount DOUBLE,
  MonthlyPayment int
);

CREATE TABLE LincBank.Account(
  AccountID varchar(8) PRIMARY KEY,
  SortCode varchar(8),
  UserID varchar(2),
  InitialBalance float(2),
  LoanID varchar(8),
  FOREIGN KEY (LoanID) REFERENCES Loan(LoanID),
  FOREIGN KEY (UserID) REFERENCES Customer(UserID)
);

CREATE TABLE LincBank.Transaction(
  TransactionID varchar(8) PRIMARY KEY,
  AccountID varchar(8),
  Amount DOUBLE,
  Location varchar(64),
  TransacDate DATE,
  Pending CHAR,
  FOREIGN KEY (AccountID) References Account(AccountID)
);

INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("01", "Peter", "Bread", 1992-02-04, 07383923745, "44 Main Street", "London", "UK", "N1 3TD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("02", "Christopher", "Cross", 1998-04-05, 07293918174, "9 High Street", "Lincoln", "UK", "LN1 PG");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("03", "Eileen", "Dover", 1991-07-11, 07735483487, "574 New Street", "Nottingham", "UK", "NG1 3RM");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("04", "Lee", "Vitoff", 2001-04-29, 07823753093, "39 Lincolnshire Terrace", "York", "UK", "YO1 3OK");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("05", "Richard", "Tate", 2984-01-01, 07852103782, "44 South Road", "Norwich", "UK", "NR1 3TK");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("06", "Joseph", "King", 1995-12-02, 07016926823, "209 East Road", "Cambridge", "UK", "CB1 3CD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("07", "Helen", "Hywater", 2002-08-09, 07324512920, "53 Kensington Street", "Ipswich", "UK", "IP1 3EM");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("08", "Upton", "O'Goode", 1992-05-24, 07019036076, "93 Cambridge Road", "Birmingham", "UK", "B1 3LE");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("09", "Felix", "Cited", 1997-05-01, 07704081632, "99 Hill Terrace", "Leeds", "UK", "LS1 3LL");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("10", "Amanda", "Kiss", 2002-02-12, 07814070933, "85 Main Street", "Peterborough", "UK", "PE1 3JC");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("11", "Aimee", "Steak", 2000-01-01, 07012913945, "17 Oxford Street" , "Exeter", "UK", "EX1 3NY");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("12", "Jacqueline", "Hyde", 1999-12-31, 07816356172, "12 Winton Road","Bournemouth", "UK", "BH1 3FJ");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("13", "Teresa", "Greene", 2000-02-29, 07172516824, "11 Greene Road", "Portsmouth", "UK", "PO1 3PE");INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("14", "Fay Dingaway", "1985-03-04", 07192618351, "534 Victoria Avenue", "Plymouth", "UK", "PL14 3PK");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("15", "Ty", "Prighter", 1992-10-06, 07918261782, "617 Red Street", "Manchester", "UK", "M1 3TD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("16", "Zolton", "Pepper", 1992-11-07, 07848194772, "212 Banks Street", "Liverpool", "UK", "L1 3TD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("17", "Ella", "Vader", 1992-09-09, 07019735419, "15 London Road", "Newcastle", "UK", "NE1 3TD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("18", "Lee", "King", 1992-12-10, 07419617222, "22 Ashfield Park", "Bradford", "UK", "BD1 3TD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("19", "Arthur", "Sleep", 1982-08-10, 07007117389, "393 Northern Street", "Sheffield", "UK", "S1 3TD");
INSERT INTO Customer(UserID, FirstName, Surname, DoB, Telephone, AddressLine1, City, Country, Postcode) VALUES ("20", "Anita", "Bath", 1979-05-03, 07622118987, "32 High Street", "Lincoln", "UK", "LN1 3TD");

INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB210101", "90-01-66", "01","1192.28","LBL21001");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB210201", "90-28-11", "02","1625.21");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB210301", "90-35-02", "03","8853.83","LBL21002");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB210401", "90-47-24", "04","6603.03");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB210501", "90-96-99", "05","6151.78","LBL21003");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB210601", "90-16-XX", "06","5390.06");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB210701", "90-25-54", "07","983.13","LBL21004");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB210801", "90-11-23", "08","4800.90");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB210901", "90-27-78", "09","5090.65","LBL21005");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB211001", "90-50-10", "10","7084.09");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB211101", "90-20-12", "11","7084.09","LBL21006");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB211201", "90-12-92", "12","7629.73");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB211301", "90-37-75", "13","2416.13","LBL21007");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB211401", "90-36-89", "14","3574.70");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB211501", "90-31-73", "15","8501.33","LBL21008");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB211601", "90-29-19", "16","176.82");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB211701", "90-20-67", "17","4744.24","LBL21009");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB211801", "90-13-34", "18","2808.47");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance, LoanID) VALUES ("LB211901", "90-09-23", "19","7217.92","LBL21010");
INSERT INTO Account(AccountID, SortCode, UserID, InitialBalance) VALUES ("LB212001", "90-28-09", "20","8934.30");

INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21001", "2022-01-01", 3500.00, 5, 350, 1);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21002", "2022-01-24", 500.00, 10, 50, 24);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21003", "2022-11-03", 1050.00, 7, 150, 3);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21004", "2021-12-17", 640.00, 8, 80, 17);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21005", "2022-01-16", 1000.00, 10, 10, 16);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21006", "2022-01-05", 1000.00, 10, 100, 5);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21007", "2022-01-09", 1000.00, 10, 100, 9);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21008", "2022-01-04", 4500.00, 10, 450, 4);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21009", "2022-01-12", 2000.00, 10, 200, 12);
INSERT INTO LOAN(LoanID, FirstPayment, Amount, NoPayments, PaymentAmount, MonthlyPayment) VALUES ("LBL21010", "2021-12-28", 1000.00, 10, 100, 28);

insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22001", "LB210101", "-39.69", "Kensington","2022-01-03", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22002", "LB210201", "43.04", "University","2021-01-06", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22003", "LB210301", "-4.73", "Beeston","2022-01-20", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22004", "LB210401", "13.92", "Heslington","2021-05-17", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22005", "LB210501", "-89.02", "Costessey","2022-01-09", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22006", "LB210601", "-47.70", "Cherry Hinton","2021-11-19", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22007", "LB210701", "-38.02", "Castle Hill","2022-01-22", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22008", "LB210801", "6.42", "Solihull","2021-03-18", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22009", "LB210901", "-42.15", "Holbeck","2022-01-24", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22010", "LB211001", "65.18", "Whittlesey","2021-10-21", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22011", "LB211101", "-22.22", "Cullompton","2022-01-02", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22012", "LB211201", "9.35", "Winton","2021-02-02", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22013", "LB211301", "78.56", "Fratton","2022-01-09", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22014", "LB211401", "98.64", "Devonport","2021-12-19", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22015", "LB211501", "17.66", "Ancoats","2022-01-03", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22016", "LB211601", "32.78", "Warbreck","2021-09-16", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22017", "LB211701", "18.40", "Hebburn","2022-01-05", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22018", "LB211801", "-57.39", "Barkerend","2021-06-29", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22019", "LB211901", "12.40", "Heeley","2022-01-09", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22020", "LB212001", "51.30", "Monks Road","2021-07-21", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22021", "LB210101", "18.06", "Brent","2022-01-24", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22022", "LB210201", "-41.10", "Castle","2021-12-31", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22023", "LB210301", "86.45", "Clifton","2022-01-10", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22024", "LB210401", "11.06", "Minster","2021-07-05", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22025", "LB210501", "30.21", "Wymondham","2022-01-10", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22026", "LB210601", "91.20", "Cambridge Leisure","2021-09-15", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22027", "LB210701", "64.44", "Warren Heath","2022-01-11", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22028", "LB210801", "2.50", "Erdington","2021-01-09", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22029", "LB210901", "93.45", "Yeadon","2022-01-11", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22030", "LB211001", "-33.09", "Fengate","2021-09-02", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22031", "LB211101", "66.38", "Heavitree","2022-01-18", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22032", "LB211201", "-98.90", "Lansdowne","2021-11-04", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22033", "LB211301", "-90.86", "Old Portsmouth","2022-01-02", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22034", "LB211401", "74.88", "Cattedown","2021-07-17", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22035", "LB211501", "-83.07", "Canal Street","2022-01-20", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22036", "LB211601", "57.73", "Picton","2021-04-10", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22037", "LB211701", "-47.30", "Gaateshead","2022-01-05", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22038", "LB211801", "85.46", "Wibsey","2021-02-06", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22039", "LB211901", "52.69", "Burngreave","2022-01-04", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22040", "LB212001", "44.32", "University","2021-08-31", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22041", "LB210101", "70.42", "Westminster","2022-01-05", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22042", "LB210201", "76.48", "Cathedral","2021-05-17", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22043", "LB210301", "93.36", "Hucknall","2022-01-12", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22044", "LB210401", "64.74", "Hull Road","2021-09-21", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22045", "LB210501", "-73.65", "Thetford","2022-01-18", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22046", "LB210601", "15.82", "Arbury","2021-06-29", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22047", "LB210701", "-86.93", "Kesgrave","2022-01-09", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22048", "LB210801", "92.51", "Smethwick","2021-02-07", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22049", "LB210901", "-17.30", "Horsforth","2022-01-07", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22050", "LB211001", "93.50", "Parnwell","2021-11-03", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22051", "LB211101", "28.18", "Wonford","2022-01-17", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22052", "LB211201", "78.77", "Wimborne","2022-01-03", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22053", "LB211301", "-79.81", "Eastney","2021-12-DD", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22054", "LB211401", "81.10", "Mutley","2021-12-17", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22055", "LB211501", "72.94", "Hulme","2022-01-14", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22056", "LB211601", "66.81", "Anfield","2022-01-13", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22057", "LB211701", "-3.58", "Jarrow","2021-12-01", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22058", "LB211801", "88.29", "Shipley","2021-12-07", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22059", "LB211901", "17.10", "San Diego","2022-01-10", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22060", "LB212001", "24.93", "Castle","2022-01-05", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22061", "LB210101", "21.21", "Hackney","2022-01-13", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22062", "LB210201", "-21.20", "St Marks","2022-01-10", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22063", "LB210301", "4.91", "Nottingham Trent University","2021-12-02", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22064", "LB210401", "23.47", "Heworth","2022-01-02", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22065", "LB210501", "-2.86", "Mount Pleasant","2021-12-10", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22066", "LB210601", "80.22", "Histon","2022-01-14", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22067", "LB210701", "-73.56", "Westerfield","2021-12-15", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22068", "LB210801", "32.54", "Perry Barr","2022-01-18", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22069", "LB210901", "44.01", "Otley","2022-01-13", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22070", "LB211001", "41.76", "Woodston","2022-01-01", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22071", "LB211101", "0.89", "St Sidwells","2021-12-26", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22072", "LB211201", "-5.03", "Westbourne","2022-01-05", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22073", "LB211301", "20.02", "Westsea","2021-12-28", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22074", "LB211401", "94.86", "Efford","2022-01-09", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22075", "LB211501", "-16.85", "Ardwick","2022-01-13", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22076", "LB211601", "50.12", "Woolton","2022-01-22", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22077", "LB211701", "-58.48", "Wallsend","2021-12-30", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22078", "LB211801", "25.53", "Keighley","2021-12-08", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22079", "LB211901", "77.75", "Brinsworth","2021-01-21", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22080", "LB212001", "-16.36", "Tritton Road","2021-11-06", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22081", "LB210101", "-39.00", "Tower Hamlets","2022-01-16", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22082", "LB210201", "28.74", "High Street","2022-01-04", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22083", "LB210301", "-15.14", "Mansfield","2021-11-17", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22084", "LB210401", "66.47", "Derwenthorpe","2021-11-28", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22085", "LB210501", "4.67", "Cringleford","2022-01-22", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22086", "LB210601", "-2.04", "Fulbourn","2022-01-09", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22087", "LB210701", "88.00", "Copdock","2022-01-03", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22088", "LB210801", "15.55", "Digbeth","2021-12-16", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22089", "LB210901", "-30.05", "Armley","2021-12-17", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22090", "LB211001", "82.90", "Werrington","2022-01-14", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22091", "LB211101", "44.20", "Polsloe","2021-12-25", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22092", "LB211201", "34.32", "Boscombe","2022-01-11", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22093", "LB211301", "-7.17", "Hilsea","2022-01-08", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22094", "LB211401", "16.03", "Keyham","2021-12-16", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22095", "LB211501", "2.61", "Salford","2022-01-06", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22096", "LB211601", "43.72", "Clubmoor","2022-11-21", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22097", "LB211701", "99.46", "Longbenton","2022-01-22", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22098", "LB211801", "41.47", "Ilkley","2021-11-28", "y");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22099", "LB211901", "19.50", "Meersbrook","2022-11-21", "n");
insert into Transaction (TransactionID, AccountID, Amount, Location, TransacDate, Pending) values ("LBT22100", "LB212001", "-77.11", "Dixon Street","2022-11-23", "y");

DELIMITER //
CREATE OR REPLACE PROCEDURE `LincBank`.`sp_get_loans` ()
BEGIN
    SELECT Customer.UserID, Customer.FirstName, Customer.Surname, loan.MonthlyPayment from Loan
    JOIN account on Loan.LoanID = Account.LoanID
    JOIN Customer on Account.UserID = Customer.UserID
    Group by Account.AccountID HAVING Loan.MonthlyPayment < 7;
END//

SELECT account.AccountID, Customer.UserID, Customer.FirstName, Customer.Surname, Transaction.Amount as TransactionValue, Transaction.TransacDate  as Date from transaction
    JOIN account on Transaction.AccountID = Account.AccountID
    JOIN Customer on Account.UserID = Customer.UserID
    WHERE Transaction.TransacDate >= DATE_SUB('2022-01-25', INTERVAL 5 DAY);

DELIMITER //
CREATE OR REPLACE PROCEDURE `LincBank`.`sp_get5000` ()
BEGIN
    SELECT Customer.UserID, sum(transaction.Amount + Account.InitialBalance) as balance from transaction
    JOIN account on Transaction.AccountID = Account.AccountID
    JOIN Customer on Account.UserID = Customer.UserID
    GROUP BY Account.AccountID Having sum(transaction.Amount + Account.InitialBalance) > 5000.00; -- group the results by account, rather than transaction
END//

DELIMITER //
CREATE OR REPLACE PROCEDURE `LincBank`.`sp_get_balance` ()
BEGIN
    SELECT account.AccountID, Customer.UserID, sum(transaction.Amount + Account.InitialBalance) as totalOutstandings from transaction
    JOIN account on Transaction.AccountID = Account.AccountID
    JOIN Customer on Account.UserID = Customer.UserID
    Group BY Account.AccountID; -- group the results by account, rather than transaction
END//
