using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace WebAppGitty.Models
{
    public class Class1 : TableEntity
    {
        // public Class1(string category, string sku):base(category, sku)
        //{}
        public Class1() { }

        public Class1(string partitionKey, string rowKey) : base(partitionKey, rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;

        }


       // public Guid Id { get; set; }
        public string Name { get; set; }
        public string MyMessage { get; set; }
        public string Email { get; set; }


    }
}