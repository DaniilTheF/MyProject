using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Objects.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Objects.DB
{
    public class AddProducts
    {
        public static void Db(DataBase DB)
        {

            if (!DB.Types.Any()) { DB.AddRange(Type.Select(c => c.Value)); }

            if (!DB.Products.Any())
            {
                DB.AddRange(
new Products
{
 Name = "Банан",
 Description = "Крайне питателен",
 IMG = "https://xs.uz/upload/24cf37aee85c1430eab7d2c7919cf9361230.jpg",
 Cost = 4,
 OnMain = false,
 IsActive = false,
 Types = Type["Фрукты"]
},
new Products
{
   Name = "Яблоко",
   Description = "Лучше чем кофе по утрам",
   IMG = "https://klike.net/uploads/posts/2019-06/1561279309_9.jpg",
   Cost = 3,
   OnMain = true,
   IsActive = true,
   Types = Type["Фрукты"]
},
new Products
{
  Name = "Клубника",
  Description = "Полезная и вкусная",
  IMG = "https://s1.1zoom.ru/big0/211/Strawberry_Closeup_597662_1280x853.jpg",
  Cost = 10,
  OnMain = true,
  IsActive = true,
  Types = Type["Ягоды"]
},
 new Products
 {
     Name = "Черника",
     Description = "Полезна для глаз",
     IMG = "https://www.sunhome.ru/i/wallpapers/17/chernika-oboi.orig.jpg",
     Cost = 8,
     OnMain = false,
     IsActive = true,
     Types = Type["Ягоды"]
 },
    new Products
    {
        Name = "Лук",
        Description = "Лук от семи недуг",
        IMG = "http://www.rabstol.net/uploads/gallery/main/549/rabstol_net_vegetables_19.jpg",
        Cost = 1,
        OnMain = false,
        IsActive = true,
        Types = Type["Овощи"]
    },
     new Products
     {
         Name = "Помидор",
         Description = "Лучший овощ",
         IMG = "https://sadovyexpert.ru/wp-content/uploads/2021/03/spisok-luchshih-sortov-pomidorov-14.jpg",
         Cost = 7,
         OnMain = true,
         IsActive = false,
         Types = Type["Овощи"]
     },
     new Products
     {
         Name = "Говядина",
         Description = "Одно из самых полезных видов мяса",
         IMG = "https://eda-land.ru/images/article/thumb/715-0/2018/10/mramornaya-govyadina-opisanie-svojstva-i-sposoby-prigotovleniya-1.jpg",
         Cost = 100,
         OnMain = true,
         IsActive = true,
         Types = Type["Мясо"]
     },
          new Products
          {
              Name = "Баранина",
              Description = "Лучшее мясо для шашлыка",
              IMG = "https://img.povar.ru/uploads/24/cf/27/69/baranina_marinovannaya-151593.jpg",
              Cost = 80,
              OnMain = false,
              IsActive = true,
              Types = Type["Мясо"]
          }
);
            }
            DB.SaveChanges();
        }



        private static Dictionary<string, Types> type;
        public static Dictionary<string, Types> Type
        {
            get
            {
                if (type == null)
                {
                    var list = new Types[]
                    {
                         new Types { TypesName = "Овощи", Descrip = "Выращивают в парниках"   },
                    new Types { TypesName = "Фрукты", Descrip = "Растут на деревьях"   },
                    new Types { TypesName = "Ягоды", Descrip = "Растут на деревьях"   },
                    new Types { TypesName = "Мясо", Descrip = "Получают из животных"   }
                    };
                    type = new Dictionary<string, Types>();
                    foreach (Types item in list)
                    {
                        type.Add(item.TypesName, item);
                    }
                }
                return type;

            }
        }
    }
}
