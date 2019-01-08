using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieApi.Searchable
{
    // Interface for searchable objects. Every searhable object must supply data {SearcableData}
    // that can be matched againt the query.
    public interface ISearchable
    {
        string SearchableData { get; }
    }
}