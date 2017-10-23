using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingList.Models;
using System.Collections;

namespace ShoppingList.Controllers
{
    public class ShoppingListController : ApiController
    {
        public static List<ShopList> shoppingLists = new List<ShopList>
        {
            new ShopList(){ Id = 0, Name = "Groceries", Items = {
                    new Item{ Name = "Milk"},
                    new Item{ Name = "Cron"},
                    new Item{ Name = "Strawberries"}
                }
            },
            new ShopList(){ Id = 1, Name = "Hardware"}
        };

        // GET: api/ShoppingList/5
        public IHttpActionResult Get(int id)
        {
            ShopList result = shoppingLists.FirstOrDefault(s=>s.Id == id);

            if (result == null)
            {
                //return NotFound();
            }
            return Ok(result);
        }

        // POST: api/ShoppingList
        public IEnumerable Post([FromBody]ShopList newList)
        {
            newList.Id = shoppingLists.Count;
            shoppingLists.Add(newList);
            return shoppingLists;
        }

        
    }
}
