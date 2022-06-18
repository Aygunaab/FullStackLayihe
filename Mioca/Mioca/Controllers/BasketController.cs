using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Models;
using Repository.Data;
using Repository.Models;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class BasketController : Controller
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinManager;
        private readonly MiocaDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;

        public BasketController(UserManager<User> usermanager, SignInManager<User> signinManager, MiocaDbContext context, IMapper mapper, IProductRepository product)
        {
            _usermanager = usermanager;
            _signinManager = signinManager;
            _context = context;
            _mapper = mapper;
            _product = product;
        }

        public JsonResult addToCart(int? id)
        {
            if (id == null)
            {
                return Json(404);
            }

            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return Json(404);
            }

            decimal count = 1;
            bool isExist = false;

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5)
            };

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    string newPrd = id + "-" + count;
                    string newCart = oldCart + "/" + newPrd;
                    Response.Cookies.Append("cart", newCart, options);
                }
            }
            else
            {
                Response.Cookies.Append("cart", "" + id + "-" + count + "", options);
            }

            return Json(200);
        }
        public IActionResult EmptyCart()
        {
            return View();
        }
        public JsonResult updateCart(int? id, int? quantity)
        {
            if (id == null || quantity == null)
            {
                return Json(404);
            }

            int indexOfPrd = 0;

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5)
            };

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        indexOfPrd = prdList.IndexOf(item);
                        break;
                    }
                }

                prdList[indexOfPrd] = id + "-" + quantity;

                string newCart = null;
                foreach (var item in prdList)
                {
                    if (item == prdList[prdList.Count - 1])
                    {
                        newCart += item;
                    }
                    else
                    {
                        newCart += item + "/";
                    }
                }

                if (newCart != null)
                {
                    Response.Cookies.Append("cart", newCart, options);
                }
            }
            else
            {
                return Json(404);
            }

            return Json(200);
        }
        public IActionResult Cart()
        {
            string cart = Request.Cookies["cart"];
            if (cart == null)
            {
                return RedirectToAction("emptycart","basket");
            }
            List<string> prdList = cart.Split("/").ToList();
            List<BasketViewModel> products = new List<BasketViewModel>();

            foreach (var item in prdList)
            {
                int prdId = Convert.ToInt32(item.Split("-")[0]);
                int prdQuantity = Convert.ToInt32(item.Split("-")[1]);
                BasketViewModel prd = new BasketViewModel();
                Product product = _context.Products.FirstOrDefault(c => c.Id == prdId);
                if (product == null)
                {
                    return NotFound();
                }

                prd.Id = product.Id;
                prd.MainImage = product.MainImage;
                prd.Name = product.Name;
                prd.Price = product.Price;
                prd.Quantity = prdQuantity;

                products.Add(prd);
            }

            return View(products);
        }

        public JsonResult removeFromCart(int? id)
        {
            if (id == null)
            {
                return Json(404);
            }

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5)
            };

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                string prd = null;

                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        prd = item;
                        break;
                    }
                }

                if (prd != null)
                {
                    prdList.Remove(prd);
                    string newCart = null;
                    foreach (var item in prdList)
                    {
                        if (item == prdList[prdList.Count - 1])
                        {
                            newCart += item;
                        }
                        else
                        {
                            newCart += item + "/";
                        }
                    }
                    if (newCart != null)
                    {
                        Response.Cookies.Append("cart", newCart, options);
                    }
                    else
                    {
                        options.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Append("cart", "", options);
                    }
                }
            }
            else
            {
                return Json(404);
            }

            return Json(200);
        }

        public IActionResult Confirm()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id = 0, Name = "Country*" });
            ViewBag.Country = countries;

            string cart = Request.Cookies["cart"];
            List<ChecoutViewModel> Products = new List<ChecoutViewModel>();
            Products.DefaultIfEmpty();

            decimal subtotal = 0;
        

            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    ChecoutViewModel prd = new ChecoutViewModel();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                    Product product = _product.GetProductById(id);
                    var prodmodel = _mapper.Map<Product, ProductViewModel>(product);
                    

                    if (prodmodel == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //product id
                    prd.productid = prodmodel.Id;

                    //product name
                    prd.Name = prodmodel.Name;

                    if (prodmodel.Discount!=null)
                    {
                        
                        if (prodmodel.Discount.EndDate > DateTime.Now && prodmodel.DiscountPrice > 0)
                        {
                            prd.Price = (prodmodel.Price * prodmodel.Discount.Percentage) / 100;
                        }
                        else
                        {
                            prd.Price = prodmodel.Price;
                        }

                    }
                   
                    prd.Price = prodmodel.Price;
                    //add cart product quantity
                    prd.Quantity = quantity;

                    Products.Add(prd);
                }

                //Calculate Subtotal
                foreach (var item in Products)
                {
                    subtotal += item.Price * item.Quantity;
                }

            }

            if (_signinManager.IsSignedIn(User))
            {
                //Find User
                string userId = _usermanager.GetUserId(User);
                User user = _context.Users.Find(userId);

                Country userCountry = _context.Countries.Find(user.CountryId);
                decimal shippingPrice = 0;

                if (userCountry.ShippingPrice != null)
                {
                    shippingPrice = (decimal)userCountry.ShippingPrice;
                }

                VmUserNotRegister modell = new VmUserNotRegister()
                {
                    

                    //SaleProduts
                    SaleProduts = Products,

                    //Subtotal
                    SubTotal = subtotal,

                    //Users infos return
                    CountryId = user.CountryId,
                    State = user.State,
                    Zipcode = user.ZipCode,
                    Phone = user.Phone,
                    ShippingPrice = shippingPrice

                };

                return View(modell);
            }
            else
            {
                VmUserNotRegister model = new VmUserNotRegister()
                {
                   

                    //SaleProduts
                    SaleProduts = Products,
                      //Subtotal
                    SubTotal = subtotal

                };

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(VmUserNotRegister model)
        {
            List<Country> countries = _context.Countries.ToList();
            countries.Insert(0, new Country { Id = 0, Name = "Country*" });
            ViewBag.Country = countries;

            string cart = Request.Cookies["cart"];
            if (cart == null)
            {
                return RedirectToAction("ErrorPage", "home");
            }

            List<ChecoutViewModel> allProducts = new List<ChecoutViewModel>();
            allProducts.DefaultIfEmpty();
            decimal subtotal = 0;

            if (model.CountryId == 0 || model.CountryId == null)
            {
                ModelState.AddModelError("CountryId", "Please select your country.");
                if (cart != null)
                {
                    List<string> prdList = cart.Split("/").ToList();

                    foreach (var item in prdList)
                    {
                        ChecoutViewModel prd = new ChecoutViewModel();
                        int id = Convert.ToInt32(item.Split("-")[0]);
                        int quantity = Convert.ToInt32(item.Split("-")[1]);
                        Product product = _product.GetProductById(id);
                        var prodmodel = _mapper.Map<Product, ProductViewModel>(product);

                        if (prodmodel == null)
                        {
                            return RedirectToAction("errorpage", "home");
                        }

                        
                        prd.productid = prodmodel.Id;

                        //product name
                        prd.Name = prodmodel.Name;

                        //price or discount price
                        if (prodmodel.Discount.EndDate > DateTime.Now && prodmodel.DiscountPrice > 0)
                        {
                            prd.Price = (prodmodel.Price * prodmodel.Discount.Percentage) / 100;
                        }
                        else
                        {
                            prd.Price = prodmodel.Price;
                        }
                        //add cart product quantity
                        prd.Quantity = quantity;

                        allProducts.Add(prd);
                    }

                    //Calculate Subtotal
                    foreach (var item in allProducts)
                    {
                        subtotal += item.Price * item.Quantity;
                    }

                }
                model.SubTotal = subtotal;
                model.ShippingPrice = 0;

                return View(model);
            }


            //Shipping Price
            Country CurrentCountry = _context.Countries.FirstOrDefault(c => c.Id == model.CountryId);
            decimal? shippingPrice = CurrentCountry.ShippingPrice;

            if (shippingPrice == null)
            {
                shippingPrice = 0;
            }


            //Checkout precess
            if (ModelState.IsValid)
            {
                //Request to bank API
                //
                //
                //

                bool isBankOk = true;
                //End of API to Bank

                if (isBankOk)
                {
                    //USER CONTROL
                    if (_signinManager.IsSignedIn(User))
                    {
                        //Find User
                        string userId = _usermanager.GetUserId(User);
                        User user = _context.Users.Find(userId);
                        user.CountryId = model.CountryId;
                        user.State = model.State;
                        user.ZipCode = model.Zipcode;
                        user.Phone = model.Phone;
                        _context.SaveChanges();

                        model.Name = user.Name;
                        model.Surname = user.Surname;
                        model.Email = user.Email;
                        model.Password = user.PasswordHash;
                    }
                    else
                    {
                        //Check email
                        bool CustomUser = _context.Users.Any(u => u.Email == model.Email);
                        if (CustomUser)
                        {
                            //if registered before, let for login.
                            return RedirectToAction("login", "account", new { email = model.Email, isCart = true });
                        }

                        //if user not registered
                        //Register
                        if (ModelState.IsValid)
                        {
                            var customUser = new User()
                            {
                                Name = model.Name,
                                Surname = model.Surname,
                                Email = model.Email,
                                UserName = model.Email,
                                Phone = model.Phone,
                                CountryId = model.CountryId,
                                State = model.State,
                                ZipCode = model.Zipcode

                            };
                            var result = await _usermanager.CreateAsync(customUser, model.Password);


                            //Add roles
                            await _usermanager.AddToRoleAsync(customUser, "Customer");


                            if (result.Succeeded)
                            {
                                await _signinManager.SignInAsync(customUser, false);
                            }
                            else
                            {
                                foreach (var error in result.Errors)
                                {
                                    ModelState.AddModelError("", error.Description);
                                }
                                return View(model);
                            }

                            //Login
                            await _signinManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                        }

                    }

                    //SALE
                    Sale sale = new Sale();
                    Sale lastSale = _context.Sales.OrderBy(o => o.Id).LastOrDefault();
                    //Invoice
                    //Find last sale for make invoice number unique
                    string saleInvoice = "";
                    if (lastSale != null)
                    {
                        saleInvoice = "AZ-" + (Convert.ToInt32(lastSale.InvoiceNo.Split("-")[1]) + 1);
                    }
                    else
                    {
                        saleInvoice = "AZ-1";
                    }
                    sale.InvoiceNo = saleInvoice;
                    sale.Date = DateTime.Now;

                    //Add shipping price
                    sale.ShippingPrice = (decimal)shippingPrice;
                    sale.TotalPrice = 0;
                    sale.CountryId = (int)model.CountryId;
                    sale.State = model.State;
                    sale.ZipCode = model.Zipcode;

                    //CustomUserId
                    //If person was login
                    if (_signinManager.IsSignedIn(User))
                    {
                        //Find User
                        string userId = _usermanager.GetUserId(User);
                        User user = _context.Users.Find(userId);
                        sale.UserId = user.Id;

                    }
                   
                    _context.Sales.Add(sale);
                    _context.SaveChanges();

                 


                    //COOKIE
                    string cartCookie = Request.Cookies["cart"];

                    List<string> prdList = cartCookie.Split("/").ToList();
                    List<CartCookieVm> cartCookies = new List<CartCookieVm>();

                    foreach (var item in prdList)
                    {
                        CartCookieVm vmCartCookie = new CartCookieVm();
                        vmCartCookie.ProductId = Convert.ToInt32(item.Split("-")[0]);
                        vmCartCookie.Quantity = Convert.ToInt32(item.Split("-")[1]);
                        cartCookies.Add(vmCartCookie);
                    }

                    foreach (var item in cartCookies)
                    {
                        SaleItem saleItem = new SaleItem();
                        saleItem.SaleId = sale.Id;
                        saleItem.ProductId = item.ProductId;
                        saleItem.Quantity = item.Quantity;
                        //Find this product
                        Product allinfoProduct = _context.Products.Find(item.ProductId);
                       
                      
                        saleItem.Price = allinfoProduct.Price;
                        _context.SaleItems.Add(saleItem);

                        allinfoProduct.Quantity = (int)(allinfoProduct.Quantity - saleItem.Quantity);
                        _context.Entry(allinfoProduct).State = EntityState.Modified;
                        _context.SaveChanges();
                    }

                    decimal subTotal = 0;
                    decimal finalTotal = 0;

                    List<SaleItem> currentSaleItems = _context.SaleItems.Where(s => s.SaleId == sale.Id).ToList();

                    //find subtotal
                    foreach (var item in currentSaleItems)
                    {
                        subTotal += item.Price * item.Quantity;
                    }

                    //final total
                    finalTotal = subTotal;

                    Sale thisSale = _context.Sales.Find(sale.Id);

                    //Shipping Price
                    finalTotal += (decimal)shippingPrice;


                    thisSale.TotalPrice = finalTotal;

                    //update Sale
                    _context.Entry(thisSale).State = EntityState.Modified;
                    _context.Entry(thisSale).Property(a => a.Id).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.InvoiceNo).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.Date).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.UserId).IsModified = false;

                    _context.SaveChanges();

                    //Remove Cart Cookie
                    CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(-1) };
                    Response.Cookies.Append("cart", "", options);


                    return RedirectToAction("profile", "account");
                }
                else
                {
                    ModelState.AddModelError("", "There is a problem with your card");
                }
            }


            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    ChecoutViewModel prd = new ChecoutViewModel();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                    Product prdType = _product.GetProductByDetailsId(id);
                    var prmod = _mapper.Map<Product, ProductViewModel>(prdType);

                    if (prmod == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //type id
                    prd.productid = prmod.Id;

                    //product name
                    prd.Name = prmod.Name;

                    //price or discount price
                    if (prmod.Discount.EndDate > DateTime.Now && prmod.DiscountPrice > 0)
                    {
                        prd.Price = (prmod.Discount.Percentage* prmod.Price)/100;
                    }
                    else
                    {
                        prd.Price = prmod.Price;
                    }
                    //add cart product quantity
                    prd.Quantity = quantity;

                    allProducts.Add(prd);
                }

                //Calculate Subtotal
                foreach (var item in allProducts)
                {
                    subtotal += item.Price * item.Quantity;
                }


                if (shippingPrice != null && ModelState.IsValid)
                {
                    subtotal += (decimal)shippingPrice;
                }

            }

           
            model.SaleProduts = allProducts;
            model.SubTotal = subtotal;
            model.ShippingPrice = (decimal)shippingPrice;

            return View(model);
        }


        // WishList
        public IActionResult Wish()
        {
            string wish = Request.Cookies["wish"];
            List<WishViewModel> Products = new List<WishViewModel>();
            Products.DefaultIfEmpty();

            if (wish != null)
            {
                List<string> prdList = wish.Split("/").ToList();

                foreach (var item in prdList)
                {
                    WishViewModel prd = new WishViewModel();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    string date = item.Split("-")[1];

                    Product product = _product.GetProductByDetailsId(id);
                    var prmod = _mapper.Map<Product, ProductViewModel>(product);

                    if (prmod == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                 
                    prd.ProductId = prmod.Id;
                    prd.Date = date;
                    prd.Image = prmod.Photos.First();
                    //product name
                    prd.Name = prmod.Name;

                    //price or discount price
                    if (prmod.Discount != null)
                    {

                        if (prmod.Discount.EndDate > DateTime.Now && prmod.DiscountPrice > 0)
                        {
                            prd.Price = (prmod.Price * prmod.Discount.Percentage) / 100;
                        }
                        else
                        {
                            prd.Price = prmod.Price;
                        }

                    }
                    //product quantity
                    prd.Quantity = prmod.Quantity;

                    //Add type to product type list
                    Products.Add(prd);
                }
            }

            AddToWishViewModel model = new AddToWishViewModel()
            {
              
                
                Products = Products,
            };

            return View(model);
        }
        public JsonResult AddToWish(int? typeId)
        {
            if (typeId == null)
            {
                return Json(404);
            }

            Product productType = _context.Products.FirstOrDefault(t => t.Id == typeId);

            if (productType == null)
            {
                return Json(404);
            }

            int count = 1;
            bool IsExist = false;

            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5)
            };

            if (Request.Cookies["wish"] != null)
            {
                string oldCart = Request.Cookies["wish"];


                List<string> prdList = oldCart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    if (Convert.ToInt32(item.Split("-")[0]) == typeId)
                    {
                        IsExist = true;
                        break;
                    }
                }

                if (!IsExist)
                {
                    count = Request.Cookies["wish"].Split("/").Count() + 1;
                    string date = (DateTime.Now).ToString("dd.MM.yyyy");
                    string newPrd = typeId + "-" + date;
                    string newCart = oldCart + "/" + newPrd;
                    Response.Cookies.Append("wish", newCart, options);
                }
                else
                {
                    count = Request.Cookies["wish"].Split("/").Count();
                    return Json(-404);
                }


            }
            else
            {
                string date = (DateTime.Now).ToString("dd.MM.yyyy");
                Response.Cookies.Append("wish", "" + typeId + "-" + date + "", options);
            }

            return Json(200);
        }



    }
}
