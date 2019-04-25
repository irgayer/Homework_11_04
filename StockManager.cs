using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_04
{
    public class StockManager
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1) Добавить товар ");
                Console.WriteLine("2) Удалить товар");
                Console.WriteLine("3) Обновать товар");
                Console.WriteLine("4) Посмотреть всё");

                if(int.TryParse(Console.ReadLine(), out int menu))
                {
                    switch (menu)
                    {
                        case 1:
                            {
                                Product product = new Product();
                                Console.WriteLine("Введите имя: ");
                                product.Name = Console.ReadLine();
                                Console.WriteLine("Введите цену: ");
                                if(int.TryParse(Console.ReadLine(), out int cost))
                                {
                                    product.Cost = cost;
                                    using(var context = new AppContext())
                                    {
                                        context.Products.Add(product);
                                        context.SaveChanges();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка");
                                }
                                
                                
                                break;
                            }
                        case 2:
                            {
                                using(var context = new AppContext())
                                {
                                    List<Product> products = context.Products.ToList();
                                    if(products.Count > 0)
                                    {
                                        foreach(var product in products)
                                        {
                                            product.Print();
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Введите имя продукта: ");
                                        string productName = Console.ReadLine();
                                        if(products.Contains(products.Where(product => product.Name.ToUpper() == productName.ToUpper()).FirstOrDefault()))
                                        {
                                            var productToDelete = context.Products.Where(product => product.Name.ToUpper() == productName.ToUpper()).FirstOrDefault();
                                            context.Products.Remove(productToDelete);
                                            context.SaveChanges();
                                        }
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Товаров еще нет!");
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                using (var context = new AppContext())
                                {
                                    List<Product> products = context.Products.ToList();
                                    if (products.Count > 0)
                                    {
                                        foreach (var product in products)
                                        {
                                            product.Print();
                                            Console.WriteLine();
                                        }
                                        Console.WriteLine("Введите имя продукта: ");
                                        string productName = Console.ReadLine();
                                        if (products.Contains(products.Where(product => product.Name.ToUpper() == productName.ToUpper()).FirstOrDefault()))
                                        {
                                            var productToChange = context.Products.Where(product => product.Name.ToUpper() == productName.ToUpper()).FirstOrDefault();
                                            Console.WriteLine("Введите новую цену: ");
                                            if(int.TryParse(Console.ReadLine(), out int cost))
                                            {
                                                if(cost > 0)
                                                {
                                                    productToChange.Cost = cost;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Цена должна быть больше 0");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого товара нет!");
                                            }
                                            context.SaveChanges();
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Товаров еще нет!");
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                using(var context = new AppContext())
                                {
                                    List<Product> products = context.Products.ToList();
                                    foreach(var product in products)
                                    {
                                        product.Print();
                                    }
                                }
                                break;
                            }
                    }

                }
            }
            
        }
    }
}
