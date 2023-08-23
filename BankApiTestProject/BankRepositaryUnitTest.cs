using BankApi.Entites;
using BankApi.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Transactions;
using System.Xml.Linq;

namespace BankApiTestProject
{
    public class BankRepositaryUnitTest
    {
        private DbContextOptions<BankApiContext> dbContextOptions;
        private BankApiContext db;
        private BankRepositary? bankRepositary;
        public BankRepositaryUnitTest()
        {

            dbContextOptions = new DbContextOptionsBuilder<BankApiContext>().UseSqlite("Data Source = BankDB.db"));

            db = new BankApiContext(dbContextOptions);

        }

        [Fact]
        public void TestGetCustomersAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);

            //Act
            List<Customer> list = bankRepositary.GetCustomersAsync();

            //Assert
            Assert.Equal(0, list.Count);

        }


        [Fact]
        public void TestGetCustomerAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            int CustId = 12345;

            //Act
            Customer customer = bankRepositary.GetCustomerAsync(CustId);

            //Assert
            Assert.NotNull(customer);

        }

        [Fact]
        public void TestAddCustomerAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            Customer customer = new Customer()
            {
                CustId = 123,
                Name = "Hanish",
                Address = "wells",
                City = "BLR",
                Email = "hanish@gmail.com",
                Contact = 123456,
                Pincode = 211334
            };

            //Act
            bankRepositary.AddCustomer(customer);
            customer = bankRepositary.GetCustomerAsync(customer.CustId);

            //Assert        
            Assert.NotNull(customer);

        }

        [Fact]
        public void TestDeleteCustomer()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            Customer customer = new Customer()
            {
                CustId = 123,
                Name = "Hanish",
                Address = "wells",
                City = "BLR",
                Email = "hanish@gmail.com",
                Contact = 123456,
                Pincode = 211334
            };

            //Act
            bankRepositary.DeleteCustomer(customer);
            Customer customer = bankRepositary.GetCustomerAsync(customer.CustId);

            //Assert
            Assert.Null(customer);
        }

        [Fact]
        public void TestDeleteAccount()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            Account account = new Account()
            {
                AccId = 56789,
                AccType = "saving",
                Balance = 100,
                CardNo = 12345678,
                Pin = 1234,
                CustId = 12345

            };

            //Act
            bankRepositary.DeleteAccount(account);
            Account account = bankRepositary.GetAccountAsync(account.AccId);

            //Assert
            Assert.Null(account);
        }

        [Fact]
        public void TestAddAdminAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            Admin admin = new Admin()
            {
                Username = "wellsfargo",
                Password = "wellsfargo"
            };

            //Act
            bankRepositary.AddAdmin(admin);
            admin admin = bankRepositary.GetAdmin(admin);

            //Assert
            Assert.NotNull(admin);

        }

        [Fact]
        public void TestGetAdminAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            Admin admin = new Admin()
            {
                Username = "wellsfargo",
                Password = "wellsfargo"
            };

            //Act
            admin admin = bankRepositary.GetAdmin(admin);

            //Assert
            Assert.NotNull(admin);

        }

        [Fact]
        public void TestGetAccountAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            int AccNo = 12345678;

            //Act
            Account account = bankRepositary.GetAccountAsync(AccNo);

            //Assert
            Assert.NotNull(account);

        }

        [Fact]
        public void TestGetTransactionsAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);

            //Act
            List<Transaction> list = bankRepositary.GetTransactionsAsync();

            //Assert
            Assert.Equal(0, list.Count);

        }

        [Fact]
        public void TestAddTransactionAsync()
        {
            //Arrange
            bankRepositary = new BankRepositary(db);
            Transaction transaction = new Transaction()
            {
                TxnId = 56789,
                Status = "success",
                Amount = 5000,
                DebitedFrom = 12345678,
                CreditTo = 987654321,
                Date = "2023-08-24",
            };

            //Act
            bankRepositary.AddTransactionAsync(trasaction);
            List<Transaction> list = bankRepositary.GetTransactionsAsync();

            //Assert
            Assert.Equal(1, list.Count);
        }

    }

}

      