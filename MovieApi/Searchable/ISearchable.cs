using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieApi.Searchable
{
    public interface ISearchable
    {
        string searchableData { get; }
    }
}