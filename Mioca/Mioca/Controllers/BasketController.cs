using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mioca.Models;
using Repository.Data;
using Repository.Enums;
using Repository.Models;
using Repository.Repositories.ContentRepositories;
using Repository.Repositories.ShoppingRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Controllers
{
    public class BasketController : BaseController
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinManager;
        private readonly MiocaDbContext _context;
        private readonly IMapper _mapper;
        private readonly IProductRepository _product;
        private readonly IContentRepository _content;
        private readonly IAccountRepository _account;

        public BasketController(UserManager<User> usermanager, 
                                SignInManager<User> signinManager,
                                MiocaDbContext context, IMapper mapper, 
                                IProductRepository product,
                                IContentRepository content,
                                IAccountRepository account)
        {
            _usermanager = usermanager;
            _signinManager = signinManager;
            _context = context;
            _mapper = mapper;
            _product = product;
            _content = content;
            _account = account;
        }
        public JsonResult AddToCart(int Id, decimal? quantity)
        {
            if (quantity == null)
            {
                return Json(404);
            }
            Product product = _product.GetProductById(Id);

            if (quantity > product.Quantity && product.Quantity != 0)
            {
                quantity = product.Quantity;
            }
         
            if (product.Quantity == 0)
            {
              
                int productId = product.Id;

                Product prd = _context.Products.FirstOrDefault(t => t.Id == productId && t.Quantity > 0);
                product = prd;

                if (quantity > prd.Quantity)
                {
                    quantity = prd.Quantity;
                }

            }

            if (product == null)
            {
                return Json(404);
            }

            int count = 1;
            bool IsExist = false;

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
                    if (Convert.ToInt32(item.Split("-")[0]) == Id)
                    {
                        IsExist = true;
                    
                        break;

                    }
                }

                if (!IsExist)
                {
                    count = Request.Cookies["cart"].Split("/").Count() + 1;

                    string newPrd = Id + "-" + quantity;
                    string newCart = oldCart + "/" + newPrd;
                    Response.Cookies.Append("cart", newCart, options);
                }
                else
                {
                    //count = Request.Cookies["cart"].Split("/").Count();
                    count = -404;
                }


            }
            else
            {
                Response.Cookies.Append("cart", "" + Id + "-" + quantity + "", options);
            }

            return Json(count);
        }
        public IActionResult EmptyCart()
        {
            var setting = _content.GetSetting();
            BaseViewModel model = new BaseViewModel
            {
                Setting = _content.Getset(),
            };
            return View(model);
        }
        public IActionResult EmptyWish()
        {
            var setting = _content.GetSetting();
            BaseViewModel model = new BaseViewModel
            {
                Setting = _content.Getset(),
            };
            return View(model);
        }
        public JsonResult UpdateCart(int? id, int? quantity)
        {
            if (id == null || quantity == null)
            {
                return Json(404);
            }

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };
            int indexOfPrd = 0;

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    Convert.ToInt32(item.Split("-")[0]);
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        indexOfPrd = prdList.IndexOf(item);
                        break;
                    }
                }

                int iteration = 0;

                //Append new quentity to product
                prdList[indexOfPrd] = id + "-" + quantity;

                string newCard = null;
                foreach (var item in prdList)
                {
                    if (item == prdList[prdList.Count - 1])
                    {
                        if (iteration != prdList.Count - 1)
                        {
                            newCard += item + "/";
                        }
                        else
                        {
                            newCard += item;
                        }
                    }
                    else
                    {
                        newCard += item + "/";
                    }
                    iteration++;
                }

                if (newCard != null)
                {
                    Response.Cookies.Append("cart", newCard, options);
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
            List<BasketViewModel> Products = new List<BasketViewModel>();
         

            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    BasketViewModel prd = new BasketViewModel();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                  var product = _product.GetProductByDetailsId(id);
                    var modelprd = _mapper.Map<Product, ProductViewModel>(product);
                    if (modelprd == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //product id
                    prd.Id = product.Id;

                    //product image
                    prd.MainImage = modelprd.MainImage;
                    //product name
                    prd.Name = modelprd.Name;

                    //price or discount price
                    if (modelprd.Discount!=null)
                    {
                        if (modelprd.Discount.EndDate > DateTime.Now && modelprd.Price > 0)
                        {
                            prd.Price = modelprd.Price - (modelprd.Price * modelprd.Discount.Percentage / 100);
                        }
                        else
                        {
                            prd.Price = modelprd.Price;
                        }
                    }
                    else
                    {
                        prd.Price = modelprd.Price;
                    }
                    //add cart product quantity
                    prd.Quantity = quantity;
                    //product max quantity
                    prd.MaxQuantity = modelprd.Quantity;
                
                    Products.Add(prd);
                }
            }
            else
            {
                return RedirectToAction("EmptyCart", "basket");
            }


            AddToCartVm model = new AddToCartVm()
            {
                //Layout

                Setting = _content.Getset(),
                Tax = _context.Taxs.FirstOrDefault(),
                Products = Products,
            
            };

            return View(model);
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
        public JsonResult GetToCartCount()
        {
            int count = 0;

            if (Request.Cookies["cart"] != null)
            {
                count = Request.Cookies["cart"].Split("/").Count();
            }

            return Json(count);
        }
        public JsonResult getToCartSum()
        {
            decimal sum = 0;

            if (Request.Cookies["cart"] != null)
            {
                string oldCart = Request.Cookies["cart"];
                List<string> prdList = oldCart.Split("/").ToList();
                foreach (var item in prdList)
                {
                    int typeid = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);

                    Product Product = _context.Products.Find(typeid);

                    if (Product == null)
                    {
                        Notify("There is error with cart items!", notificationType: NotificationType.error);
                        return Json(0);
                    }

                    sum += Product.Price * quantity;
                }

               
            }
            else
            {
                return Json(0);
            }


            return Json(sum);
        }
        public IActionResult Confirm()
        {
            var setting = _content.GetSetting();
            BaseViewModel model = new BaseViewModel
            {
                Setting = _content.Getset(),
            };
            
            return View(model);
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
            Tax tax = _context.Taxs.FirstOrDefault();

            if (cart != null)
            {
                List<string> prdList = cart.Split("/").ToList();

                foreach (var item in prdList)
                {
                    ChecoutViewModel prd = new ChecoutViewModel();
                    int id = Convert.ToInt32(item.Split("-")[0]);
                    int quantity = Convert.ToInt32(item.Split("-")[1]);
                    Product prod = _product.GetProductByIdCheck(id);
                    var modelprd = _mapper.Map<Product, ProductViewModel>(prod); ;
                   

                    if (modelprd == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    //product id
                    prd.productid = modelprd.Id;

                    //product name
                    prd.Name = modelprd.Name;

                    //price or discount price
                    if (modelprd.Discount!=null)
                    {
                        if (modelprd.Discount.EndDate > DateTime.Now)
                        {
                            prd.Price = modelprd.Price - ((modelprd.Price * modelprd.Discount.Percentage) / 100);
                        }
                        else
                        {
                            prd.Price = modelprd.Price;
                        }
                    }
                    else
                    {
                        prd.Price = modelprd.Price;
                    }
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
                User user = _account.GetUserByid(userId);

                Country userCountry = _content.GetUserCountry(user.CountryId);
                decimal shippingPrice = 0;

                if (userCountry.ShippingPrice != null)
                {
                    shippingPrice = (decimal)userCountry.ShippingPrice;
                }

                VmUserNotRegister model1 = new VmUserNotRegister()
                {
                    //Layout
                    Setting = _content.Getset(),
                    Tax = _content.GetTax().FirstOrDefault(),

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

                return View(model1);
            }
            else
            {
                VmUserNotRegister model = new VmUserNotRegister()
                {
                    //Layout
                    Setting = _content.Getset(),

                    //SaleProduts
                    SaleProduts = Products,
                    Tax = _content.GetTax().FirstOrDefault(),

                    //Subtotal
                    SubTotal = subtotal

                };

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(VmUserNotRegister model)
        {
            List<Country> countries = _content.getContrys();
            countries.Insert(0, new Country { Id = 0, Name = "Country*" });
            ViewBag.Country = countries;

            /* If Model state is not valid */
            string cart = Request.Cookies["cart"];
            if (cart == null)
            {
                return RedirectToAction("ErrorPage", "home");
            }

            List<ChecoutViewModel> Products = new List<ChecoutViewModel>();
              Products.DefaultIfEmpty();
            decimal subtotal = 0;
            Tax tax = _content.GetTax().FirstOrDefault();
           

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
                        Product prod = _product.GetProductByIdCheck(id);
                        var promod = _mapper.Map<Product, ProductViewModel>(prod);

                        if (promod == null)
                        {
                            return RedirectToAction("errorpage", "home");
                        }

                        //id
                        prd.productid = promod.Id;

                        //product name
                        prd.Name = promod.Name;

                        //price or discount price
                        if (promod.Discount.EndDate > DateTime.Now)
                        {
                            prd.Price = promod.Price - ((promod.Price * promod.Discount.Percentage) / 100);
                        }
                        else
                        {
                            prd.Price = promod.Price;
                        }
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
                //layout
                model.Setting = _content.Getset();      
                model.SaleProduts =Products;
                model.SubTotal = subtotal;
                model.Tax = _content.GetTax().FirstOrDefault();
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
                        User user = _account.GetUserByid(userId);
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
                        //First you must check this email is this customer registered before or not
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

                            //Automatically login
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

                    //for not be null after Total price will change
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
                        User user = _account.GetUserByid(userId);
                        sale.UserId = user.Id;

                    }
                    else
                    {
                        //sale.CustomUserId = _context.CustomUsers.FirstOrDefault(u => u.Email == model.Email).Id;
                    }
                    _context.Sales.Add(sale);
                    _context.SaveChanges();

                    Notify("The order was successfully registered.");


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
                        Product Product = _context.Products.Find(item.ProductId);

                        if (Product.Discount != null)
                        {
                            if (Product.Discount.EndDate > DateTime.Now)
                            {
                                saleItem.Price = Product.Price - ((Product.Price * Product.Discount.Percentage) / 100);
                            }
                            else
                            {
                                saleItem.Price = Product.Price;
                            }
                        }
                        else
                        {
                            saleItem.Price = Product.Price;
                        }
                        _context.SaleItems.Add(saleItem);
                        Product.Quantity = Product.Quantity - item.Quantity;
                   
                        _context.Entry(Product).State = EntityState.Modified;
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

                    //tax
                    if (subTotal < tax.PriceLimit && tax != null)
                    {
                        subTotal = subTotal + (subTotal * tax.Percent / 100);
                    }

                    //final total
                    finalTotal = subTotal;


                    //***you can add final total to sale table***//

                    Sale thisSale = _context.Sales.Find(sale.Id);

                    //Shipping Price
                    finalTotal += (decimal)shippingPrice;


                    thisSale.TotalPrice = finalTotal;

                    //update Sale
                    _context.Entry(thisSale).State = EntityState.Modified;

                    //Don't change this properties
                    _context.Entry(thisSale).Property(a => a.Id).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.InvoiceNo).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.Date).IsModified = false;
                    _context.Entry(thisSale).Property(a => a.UserId).IsModified = false;

                    _context.SaveChanges();

                    //Remove Cart Cookie
                    CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(-1) };
                    Response.Cookies.Append("cart", "", options);


                    return RedirectToAction("confirm", "basket");
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
                    Product pro = _product.GetProductByDetailsId(id);
                    var promod = _mapper.Map<Product, ProductViewModel>(pro);

                    if (promod == null)
                    {
                        return RedirectToAction("errorpage", "home");
                    }

                    // id
                    prd.productid = promod.Id;

                    //product name
                    prd.Name = promod.Name;

                    //price or discount price
                    if (promod.Discount.EndDate > DateTime.Now )
                    {
                        prd.Price = promod.Price - ((promod.Price * promod.Discount.Percentage) / 100);
                    }
                    else
                    {
                        prd.Price = promod.Price;
                    }
                    //add cart product quantity
                    prd.Quantity = quantity;

                    Products.Add(prd);
                }

                //Calculate Subtotal
                foreach (var item in Products)
                {
                    subtotal += item.Price * item.Quantity;
                }


                if (shippingPrice != null && ModelState.IsValid)
                {
                    subtotal += (decimal)shippingPrice;
                }

            }

            //layout
            model.Setting =_content.Getset();
            model.SaleProduts = Products;
            model.SubTotal = subtotal;
            model.Tax = _content.GetTax().FirstOrDefault();
            model.ShippingPrice = (decimal)shippingPrice;

            return View(model);
        }

        public JsonResult getShippPrice(int? countryId)
        {
            if (countryId == null)
            {
                return Json(-404);
            }

            Country country = _context.Countries.FirstOrDefault(c => c.Id == countryId);

            if (country == null)
            {
                return Json(-404);
            }

            decimal? shippingPrice = country.ShippingPrice;

            if (shippingPrice == null)
            {
                shippingPrice = 0;
            }

            return Json(shippingPrice);
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
                    prd.Price = prmod.Price;
                    //product quantity
                    prd.Quantity = prmod.Quantity;

                    //Add type to product type list
                    Products.Add(prd);
                }
            }
            else
            {
                return RedirectToAction("EmptyWish", "basket");
            }

            AddToWishViewModel model = new AddToWishViewModel()
            {                        
                Products = Products,
                Setting = _content.Getset(),
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

            return Json(count);
        }
        public JsonResult GetToWishCount()
        {
            int count = 0;

            if (Request.Cookies["wish"] != null)
            {
                count = Request.Cookies["wish"].Split("/").Count();
            }

            return Json(count);
        }
        public JsonResult RemoveFromWish(int? id)
        {
            if (id == null)
            {
                return Json(404);
            }

           Product product = _context.Products.FirstOrDefault(t => t.Id == id);

            if (product == null)
            {
                return Json(404);
            }

            int count = 0;

            CookieOptions options = new CookieOptions() { Expires = DateTime.Now.AddDays(5) };

            if (Request.Cookies["wish"] != null)
            {
                string oldWish = Request.Cookies["wish"];
                List<string> prdList = oldWish.Split("/").ToList();
                string prd = null;
                count = prdList.Count;

                foreach (var item in prdList)
                {
                    Convert.ToInt32(item.Split("-")[0]);
                    if (Convert.ToInt32(item.Split("-")[0]) == id)
                    {
                        prd = item;
                        break;
                    }
                }
                if (prd != null)
                {
                    prdList.Remove(prd);
                    string newWish = null;
                    foreach (var item in prdList)
                    {
                        if (item == prdList[prdList.Count - 1])
                        {
                            newWish += item;
                        }
                        else
                        {
                            newWish += item + "/";
                        }
                    }
                    if (newWish != null)
                    {
                        Response.Cookies.Append("wish", newWish, options);
                    }
                    else
                    {
                        options.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Append("wish", "", options);

                    }

                }
            }
            else
            {
                return Json(404);
            }

            if (count == 1)
            {
                return Json(100);
            }

            return Json(200);
        }
        public JsonResult GeetWishCount()
        {
            int count = 0;

            if (Request.Cookies["wish"] != null)
            {
                count = Request.Cookies["wish"].Split("/").Count();
            }

            return Json(count);
        }
       
    }
}
