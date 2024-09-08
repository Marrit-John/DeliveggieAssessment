using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveggieAPI.Models
{
    public interface IDeliveggieDBSettings
    {
        string DeliveggieConnectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
