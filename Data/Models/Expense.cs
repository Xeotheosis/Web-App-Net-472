using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int AssociationId { get; set; }
        public int? StaircaseId { get; set; } // Nullable for association-wide expenses
        public string Description { get; set; }
        public float Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
    }

    public enum ExpenseType
    {
        Association,
        Staircase
    }
}
