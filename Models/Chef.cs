using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int chefId {get;set;}
        [Required]
        public string firstname {get;set;}
        [Required]
        public string lastname {get;set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime dob {get;set;}

        public List<Dish> dishes {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int GetAge(){
            DateTime startDate = dob;
            DateTime endDate = DateTime.Now;
            int years = endDate.Year - startDate.Year;

            if (startDate.Month == endDate.Month && endDate.Day < startDate.Day || endDate.Month < startDate.Month)
            {
                years--;
            }

            return years;
        }
    }
}