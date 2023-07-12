using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [path(@"ordereddish.xml", "Ordered_Dish", "Rn_Dn")]
    public class Ordered_Dish
    {
        public string reservation_number { get; set; }//מאפיין שמציין את מספר ההזמנה.

        public string dish_name { get; set; }// מאפיין שמציין את שמות המנות המוזמנות

        public string Rn_Dn { get; set; }// מאפיין המייחד כל dish order

        public int number_of_dishes { get; set; }// מאפיין שמציין את כמות המנות מכל סוג מנה 

        public override string ToString()

        {

            return string.Format(" dish name: {0}, number of dishes: {1} , reservation number: { 2} , Rn_Dn(identify) : { 3}",dish_name,number_of_dishes,reservation_number,Rn_Dn);

        }
        public Ordered_Dish()
        {
        }

    }
}
