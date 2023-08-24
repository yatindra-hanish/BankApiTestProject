using BankApi.Entities;
using BankApi.Services;
using BankApi.Contexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Transactions;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BankApiTestProject
{
    public class BankRepositoryUnitTest
    {
        private DbContextOptions<BankApiContext> dbContextOptions;
        private BankApiContext db;
        private BankRepository? bankRepository;
        public BankRepositoryUnitTest()
        {

            //dbContextOptions = new DbContextOptionsBuilder<BankApiContext>().UseSql("Data Source = BankDB.db");
            dbContextOptions = new DbContextOptionsBuilder<BankApiContext>().UseSqlServer("Data Source = BankDB.db");
            db = new BankApiContext(dbContextOptions);

        }

        [Fact]
        public void TestGetCustomersAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);

            //Act
            List<Customer> list = bankRepository.GetCustomersAsync();

            //Assert
            Assert.Equal(0, list.Count);

        }


        [Fact]
        public void TestGetCustomerAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);
            int CustId = 12345;

            //Act
            Customer customer = bankRepository.GetCustomerAsync(CustId);

            //Assert
            Assert.NotNull(customer);

        }

        [Fact]
        public void TestAddCustomerAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);
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
            bankRepository.AddCustomerAsync(customer);
            customer = bankRepository.GetCustomerAsync(customer.CustId);

            //Assert        
            Assert.NotNull(customer);

        }

        [Fact]
        public void TestDeleteCustomer()
        {
            //Arrange
            bankRepository = new BankRepository(db);
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
            bankRepository.DeleteCustomer(customer);
            customer = bankRepository.GetCustomerAsync(customer.CustId);

            //Assert
            Assert.Null(customer);
        }

        [Fact]
        public void TestDeleteAccount()
        {
            //Arrange
            bankRepository = new BankRepository(db);
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
            bankRepository.DeleteAccount(account);
            account = bankRepository.GetAccountAsync(account.AccId);

            //Assert
            Assert.Null(account);
        }

        [Fact]
        public void TestAddAdminAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);
            Admin admin = new Admin()
            {
                Username = "wellsfargo",
                Password = "wellsfargo"
            };

            //Act
            bankRepository.AddAdminAsync(admin);
            admin = bankRepository.GetAdminAsync(admin);

            //Assert
            Assert.NotNull(admin);

        }

        [Fact]
        public void TestGetAdminAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);
            Admin admin = new Admin()
            {
                Username = "wellsfargo",
                Password = "wellsfargo"
            };

            //Act
            admin = bankRepository.GetAdminAsync(admin);

            //Assert
            Assert.NotNull(admin);

        }

        [Fact]
        public void TestGetAccountAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);
            int AccNo = 12345678;

            //Act
            Account account = bankRepository.GetAccountAsync(AccNo);

            //Assert
            Assert.NotNull(account);

        }

        [Fact]
        public void TestGetTransactionsAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);

            //Act
            List<System.Transactions.Transaction> list = bankRepository.GetTransactionsAsync();

            //Assert
            Assert.Equal(0, list.Count);

        }
/*
        [Fact]
        public void TestAddTransactionAsync()
        {
            //Arrange
            bankRepository = new BankRepository(db);
            Transactions transactions = new System.Transactions()
            {
                TxnId = 56789,
                Status = "success",
                Amount = 5000,
                DebitedFrom = 12345678,
                CreditTo = 987654321,
                Date = "2023-08-24",
            };

            //Act
            bankRepository.AddTransactionAsync(transactions);
            List<System.Transactions.Transaction> list = bankRepository.GetTransactionsAsync();

            //Assert
            Assert.Equal(1, list.Count);
        }
*/

    }

}

      