using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using WebAppGitty.Models;

namespace WebAppGitty.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        private CloudTable table;
        public HomeController()
        {

            storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=webappgitty;AccountKey=SiHK3hNYpSYqTcCyScNWem9EvLEJg0CtWehoj4RfLxJMtwIcxtTgrGY67WQxcsxVuHPRObZYlBd0x8cevDd9VQ==");
            tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("msgInfo");
            table.CreateIfNotExists();

        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MSG()
        {
            return View();
        }
        [HttpPost]
        public ViewResult MSG(Class1 xd)
        {
            Class1 entity = new Class1("abc", Guid.NewGuid().ToString()) { Name = xd.Name, MyMessage = xd.MyMessage, Email = xd.Email };

            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);

            return View("Index");
        }
    }
}