using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ElesticSearch.Models
{
    public class ElasticSearchInsertManyModel:ElasticSearchModel
    {
        public object[] Items { get; set; }
    }
}
