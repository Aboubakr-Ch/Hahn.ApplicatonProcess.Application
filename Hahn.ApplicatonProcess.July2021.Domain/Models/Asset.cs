using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
