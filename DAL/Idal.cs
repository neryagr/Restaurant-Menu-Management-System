using System;
using System.Collections.Generic;
using BE;
namespace DAL
{
   public interface Idal
    {
        #region DISH
         void add_dish(Dish d);
         void remove_dish(string name);
         void update_dish(Dish d);
         Dish get_dish(string name);
         IEnumerable<Dish> Get_All_Dishs(Func<Dish, bool> predicate = null);
        #endregion

        #region bruanch
         void add_braunch(Braunch b);
         void remove_braunch(string num);
         void update_braunch(Braunch b);
         Braunch get_braunch(string num);
         IEnumerable<Braunch> Get_All_braunches(Func<Braunch, bool> predicate = null);
        #endregion

        #region Order
         void add_order(Order o);
         void remove_order(string num);
         void update_order(Order o);
         Order get_order(string num);
         IEnumerable<Order> Get_All_orders(Func<Order, bool> predicate = null);

        #endregion

        #region Ordered_Dish
         void add_ordered_dish(Ordered_Dish a);
         void remove_ordered_dish(string a);
         void update_ordered_dish(Ordered_Dish a);
         Ordered_Dish get_ordered_dish(string a);
         IEnumerable<Ordered_Dish> Get_All_Ordered_Dishs(Func<Ordered_Dish, bool> predicate = null);
        #endregion

        #region Client
         void add_client(Client c);
         void remove_client(string c);
         void update_client(Client c);
         Client get_client(string card);
         IEnumerable<Client> Get_All_clients(Func<Client, bool> predicate = null);
        #endregion
         void close();
          void open();
    }
}
