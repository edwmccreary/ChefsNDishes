using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int dishId {get;set;}
        [Required(ErrorMessage = "Your dish must have a name")]
        [MinLength(2,ErrorMessage = "Your dish name must be atleast 2 characters")]
        public string name {get;set;}
        [Required(ErrorMessage = "You must specify the number of calories for your dish")]
        [Range(0, int.MaxValue, ErrorMessage = "Calories must be more than 0")]
        public int calories {get;set;}
        [Required(ErrorMessage = "You must rate the tastiness of your dish")]
        [Range(1,5,ErrorMessage = "Tastiness value must be between 1 and 5")]
        public int tastiness {get;set;}
        [Required(ErrorMessage = "Your dish must have a description")]
        public string description {get;set;}

        //foreign key:
        [Required(ErrorMessage = "You must select a Chef name")]
        public int chefId {get;set;}
        //foreign object:
        public Chef chef {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}