

$('.hero-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 5000,
    arrows:true,
    prevArrow:'<button type="button" class="slick-prev"><i class="pe-7s-angle-left-circle"></i></button>',
    nextArrow:'<button type="button" class="slick-next"><i class="pe-7s-angle-right-circle"></i></button>',
    fade:true,
    cssEase: 'linear',
    waitForAnimate:true,                  
  });


  $('.slider').slick({
    infinite: true,
    slidesToShow: 6,
    slidesToScroll: 6, 
    arrows:true,
    prevArrow:'<button type="button" class="slick-prev"><i class="pe-7s-angle-left-circle"></i></button>',
    nextArrow:'<button type="button" class="slick-next"><i class="pe-7s-angle-right-circle"></i></button>',
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4,
          arrows:true,
          prevArrow:(".prev"),
          nextArrow:(".next"),
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4,
          arrows:true,
          prevArrow:(".prev"),
          nextArrow:(".next"),
        }
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          arrows:true,
          prevArrow:(".prev"),
          nextArrow:(".next"),
        }
      }
    
    ]
  });
  
  $('.sliderbestseller').slick({
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 4, 
    arrows:true,
    prevArrow:'<button type="button" class="slick-prev"><i class="pe-7s-angle-left-circle"></i></button>',
    nextArrow:'<button type="button" class="slick-next"><i class="pe-7s-angle-right-circle"></i></button>',
    
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4,
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4
        }
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3
        }
      }
    
    ]
  });
  $('.slider-bestseller-products').slick({
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 4, 
    
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4,
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 4
        }
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3
        }
      }
    
    ]
  });

// client slider
$('.client-slider').slick({
  infinite: true,
  slidesToShow: 1,
  slidesToScroll: 1, 
  arrows:true,
    prevArrow:(".prev"),
    nextArrow:(".next"),
 
  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows:true,
      
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows:true,
      }
    },
    {
      breakpoint: 480,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows:true,
      }
    }
  
  ]
});

//brand slider

$('.brand-slider').slick({
  infinite: true,
  slidesToShow: 5,
  slidesToScroll: 1,
  autoplay: true,
  autoplaySpeed: 3000,
  arrows:false,

  responsive: [
    {
      breakpoint: 1024,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,    
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1,
      }
    },
    {
      breakpoint: 480,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 1,
      }
    }
  
  ]
});


var $grid = $('.shoping-items').isotope({
    filter: ':nth-child(-n+8)',
 itemSelector:'.height-resize' ,
 layoutMode: 'fitRows',
  
  
});
// filter items on button click
$('.filter-button-group').on( 'click', 'li', function() {
  $('li').removeClass('active');
	$(this).addClass('active');
  var filterValue = $(this).attr('data-filter');
  $grid.isotope({ filter: filterValue });
});

//product details slider
const imgs = document.querySelectorAll('.img-select a');
const imgBtns = [...imgs];
let imgId = 1;

imgBtns.forEach((imgItem) => {
    imgItem.addEventListener('click', (event) => {
        event.preventDefault();
        imgId = imgItem.dataset.id;
        slideImage();
    });
});

function slideImage(){
    const displayWidth = document.querySelector('.img-shopcase img:first-child').clientWidth;

    document.querySelector('.img-shopcase').style.transform = `translateX(${- (imgId - 1) * displayWidth}px)`;
}

//product details tabs
$( function() {
  $( "#product-details-tabs" ).tabs({
    collapsible: true
  });
} );



  ////Cart Plus Minus Button
  //  var CartPlusMinus = $(".cart-plus-minus");
  //  CartPlusMinus.prepend('<div class="minus plmin">-</div>');
  //  CartPlusMinus.append('<div class="plus plmin">+</div>');
  //  $(".plmin").on("click", function () {
  //      var $button = $(this);
  //      var oldValue = $button.parent().find("input").val();
  //      if ($button.text() === "+") {
  //          var newVal = parseFloat(oldValue) + 1;
  //      } else {
  //          // Don't allow decrementing below zero
  //          if (oldValue > 1) {
  //              var newVal = parseFloat(oldValue) - 1;
  //          } else {
  //              newVal = 1;
  //          }
  //      }
  //      $button.parent().find("input").val(newVal);
  //  });







    $('.relatedProducts').slick({
      infinite: true,
      slidesToShow: 4,
      slidesToScroll: 1,
      autoplay: true,
      autoplaySpeed: 3000,
      arrows:true,
      prevArrow:(".prev"),
      nextArrow:(".next"),   
      responsive: [
        {
          breakpoint: 1200,
          settings: {
            slidesToShow: 3,
            slidesToScroll: 1,    
          }
        },
        {
          breakpoint: 900,
          settings: {
            slidesToShow: 2,
            slidesToScroll: 1,
          }
        },
        {
          breakpoint: 480,
          settings: {
            slidesToShow: 1,
            slidesToScroll: 1,
          }
        }
      
      ]
    });
    //fag accordion
    $( function() {
      $( "#fag-accordion" ).accordion({
        collapsible: true
      });
      
    } );

    // login tab
    $( function() {
      $( "#login-reg" ).tabs({
        collapsible: true
      });
    } );


    //checkbox toogle 
    function Cheked() {
      var checkBox = document.getElementById("CheckInput");
      
      var account = document.getElementById("chec-box");
    
      // If the  is checked, display the output text
      if (checkBox.checked == true){
        account.style.display = "block";
      } else {
        account.style.display = "none";
      }
    }
    

    function ChekedAdress() {
      var checkBox = document.getElementById("CheckAuthorAdress");
      
      var account = document.getElementById("different-adress");
    
      // If the  is checked, display the output text
      if (checkBox.checked == true){
        account.style.display = "block";
      } else {
        account.style.display = "none";
      }
    }
    //order accordion
    $( function() {
      $( "#order" ).accordion({
        collapsible: true
      });
    } );


    $(window).on("scroll", function (e) {
      var window_top = $(window).scrollTop() + 1;
      if (window_top > 250) {
          $(".header").addClass("sticky");
      } else {
          $(".header").removeClass("sticky");
      }
  });

  //Basket







$(document).on("keyup", "#searchinput", function () {

    let searchedstring = $(this).val();
    $.ajax({
        type: "GET",
        url: "/home/search?searchString=" + searchedstring,
        success: function (res) {
            $("#search-result li:not(:first-child)").remove();
            $("#search-result").append(res);
        }
          
    })

});



$(function () {
    $("#tabs").tabs().addClass("ui-tabs-vertical ui-helper-clearfix");
    $("#tabs li").removeClass("ui-corner-top").addClass("ui-corner-left");
});

//add to cart

$(".add_to-cart").click(function (e) {
    e.preventDefault();
    //get product name
    let div = $(this).parent().parent();
    let name = div.parent("div").find("product-title").children().text();


    //Get product type id and quantity
    var Id = $(this).data("id");
    var Quantity = $(this).data("quantity");

    //console.log(TypeId);
    //console.log(Quantity);

    if (Id == undefined || Quantity == undefined) {
        toastr.error('This product was not added cart list..', { timeOut: 3000 });
    }
    else {

        $.ajax({

            url: "/basket/AddToCart/",
            type: "get",
            dataType: "json",

            data: { Id: Id, quantity: Quantity },
            success: function (response) {

                if (response != -404) {

                    //cart toast counter
                    $(".cart-count span").text(response);

                    $(".subTotal").change();
                   



                    //if success show 
                    $.toast({
                        heading: name,
                        text: "Səbətə əlavə olundu",
                        icon: 'success',
                        loader: false,
                        bgColor: '#00A663',
                        loaderBg: '#f7d40d',
                        position: 'bottom-right'
                    });
                }
                else {
                    toastr.info('Already exist in the cart', name, { timeOut: 3000 });
                }


            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    }

});
//Get add to cart item's count
$.ajax({

    url: "/basket/GetToCartCount/",
    type: "get",
    dataType: "json",

    //data: { typeId: TypeId, quantity: Quantity },
    success: function (response) {

        //cart toast counter
        $(".cart-count span").text(response);
    },
    error: function (response) {

        console.log("error: " + response);
    }

});

$(".subTotal").on("change", function (e) {
    e.preventDefault();

    $.ajax({

        url: "/basket/getToCartSum/",
        type: "get",
        dataType: "json",

        //data: { typeId: TypeId, quantity: Quantity },
        success: function (response) {
            var sum = response.toFixed(2);
            //cart toast counter
            $(".subTotal").text("₼" + sum);
        },
        error: function (response) {

            console.log("error: " + response);
        }

    });


});


$(".remove-basket").click(function (e) {
    e.preventDefault();

    var Id = parseInt($(this).data("id"));

    $.ajax({

        url: "/basket/removeFromCart/",
        type: "get",
        dataType: "json",

        data: { id: Id },
        success: function (response) {
            console.log(response);
            if (response == 200) {
                location.reload();
            }

        },
        error: function (response) {

            console.log("error: " + response);
        }

    });

});

$(".add-to-card-detail").click(function (e) {
    //
    var name = $(".prod-name").text();

    var quantity = $(".cart-plus-minus-box").val();
    var productId = $(this).data("productid");

   
        $.ajax({

            url: "/basket/AddToCart/",
            type: "get",
            dataType: "json",

            data: {Id: productId, quantity: quantity },
            success: function (response) {

                //location.reload();

                if (response != -404 && response != 404) {
                    //cart counter
                    $(".cart-count span").text(response);


                    //if success show 
                    $.toast({
                        heading: name,
                        text: "Səbətə əlavə olundu",
                        icon: 'success',
                        loader: false,
                        bgColor: '#00A663',
                        loaderBg: '#f7d40d',
                        position: 'bottom-right'
                    });

                    CalculateAddToCartSum();

                }
                else {
                    toastr.error('This product already exist in the cart', { timeOut: 3000 });
                }



            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    

});

function CalculateAddToCartSum() {
    $.ajax({

        url: "/basket/getToCartSum/",
        type: "get",
        dataType: "json",

        success: function (response) {
            var sum = response.toFixed(2);
            //cart toast counter
            $(".subTotal").text("$" + sum);
        },
        error: function (response) {

            console.log("error: " + response);
        }

    });
};
///Add to cart from Wishlist
$(".add-cart-wish").click(function (e) {
    e.preventDefault();
    //get product name
    var name = $(this).data("name");

    //Get product type id and quantity
    var Id = $(this).data("id");
    var Quantity = 1;

    //this
    var removeBtn = $(this).parent().find("a.wish-delete-btn");


        $.ajax({

            url: "/basket/AddToCart/",
            type: "get",
            dataType: "json",

            data: { Id: Id, quantity: Quantity },
            success: function (response) {

                if (response != -404) {
                    $(".cart-count span").text(response);

                    $(".subTotal").change();

                    //Remove this wish item from wishlist
                    removeBtn.click();


                    //if success show 
                    $.toast({
                        heading: name,
                        text: "Səbətə əlavə olundu",
                        icon: 'success',
                        loader: false,
                        bgColor: '#00A663',
                        loaderBg: '#f7d40d',
                        position: 'bottom-right'
                    });
                  
                }
                else {
                    toastr.info('Already exist in the cart', name, { timeOut: 3000 });
                }
                //cart toast counter


            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    

});

//wishlist
$(".add_to-wish").click(function () {

    let div= $(this).parent().parent();
    let name = div.parent("div").find(".product-title").children().text();
 

    var TypeId = $(this).data("id");

    if (TypeId == undefined) {

        toastr.error('Bu məhsul Favorilərə əlavə olunmadı ', { timeOut: 3000 });
    }
    else {

        $.ajax({

            url: "/basket/AddToWish/",
            type: "get",
            dataType: "json",

            data: { typeId: TypeId },
            success: function (response) {

               

                if (response == -404) {


                    toastr.info('Bu məhsul Favorilərdə var', name, { timeOut: 3000 } );

                }
                else if (response == 404) {
                    toastr.error('Bu məhsul Favorilərə əlavə olunmadı');
                }
                else {
                    //cart toast counter
                    $(".wishlist_count").text(response);  
                    let name = div.parent("div").find(".product-title").children().text();
               
                    $.toast({
                        heading: name,
                        text: "Favorilərə əlavə olundu",
                        icon: 'success',
                        loader: false,
                        bgColor: '#eaaa85',
                        loaderBg: '#f7d40d',
                        position: 'bottom-right'
                    });
                  
                  
                 
                }


            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    }
});
//Get wishlist item's count
$.ajax({

    url: "/basket/GetToWishCount/",
    type: "get",
    dataType: "json",

    //data: { typeId: TypeId, quantity: Quantity },
    success: function (response) {

        //cart toast counter
        $(".wishlist_count").text(response);
    },
    error: function (response) {

        console.log("error: " + response);
    }

});

///Add to wishlist Detail 
$(".add-to-wishlist-detail").click(function (e) {
   
    var name = $(".prod-name").text();

    var Id = $(this).data("productid");
    
        $.ajax({

            url: "/basket/AddToWish/",
            type: "get",
            dataType: "json",

            data: { typeId: Id },
            success: function (response) {

                //console.log(response);
                //location.reload();

                //cart counter
                $(".wishlist_count").text(response);
                $.toast({
                    heading: name,
                    text: "Favorilərə əlavə olundu",
                    icon: 'success',
                    loader: false,
                    bgColor: '#eaaa85',
                    loaderBg: '#f7d40d',
                    position: 'bottom-right'
                });
              

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

});

//Wishlist delete item
$(".wish-delete-btn").click(function (e) {
    e.preventDefault();

    var Id = parseInt($(this).data("id"));
    var itemBox = $(this).parent().parent();

    $.ajax({

        url: "/basket/RemoveFromWish/",
        type: "get",
        dataType: "json",

        data: { id: Id },
        success: function (response) {
            if (response == 200) {
                itemBox.remove();
                GetWishCount();

            } else {
                location.reload();
            }

        },
        error: function (response) {

            console.log("error: " + response);
        }

    });

});
//get wish clunt
function GetWishCount() {
    $.ajax({

        url: "/basket/GeetWishCount/",
        type: "get",
        dataType: "json",
        success: function (response) {

            //cart counter
            $(".wishlist_count").text(response);
        },
        error: function (response) {

            console.log("error: " + response);
        }

    });

};
///subscribe
$("#subscribe-form").submit(function (e) {
    e.preventDefault();

    var email = $("#subscribe-input").val();

    var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;

    if (email == "") {
        toastr.error('Zəhmət olmasa e-poçt ünvanınızı daxil edin', { timeOut: 3000 });
    }
    else if (!pattern.test(email)) {
        toastr.error('DE-poçt düzgün deyil', { timeOut: 3000 });
    }
    else {
        $.ajax({

            url: "/contact/addSubscribe/",
            type: "get",
            dataType: "json",

            data: { email: email },
            success: function (response) {
                if (response == 200) {
                    //success
                    toastr.success('Artıq bizi izləyirsiniz, Təşəkkür edirik!', { timeOut: 3000 });

                }
                else if (response == 505) {
                    //error
                    toastr.info('Siz artıq bizə üzv olmusunuz', { timeOut: 3000 });
                }
                else {
                    //error
                    toastr.error('Zəhmət olmasa email ünvanınızı daxil edin.', { timeOut: 3000 });
                }
            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

    }

});


//decrease
$(".plus").click(function () {
    var oldValue = parseInt($(this).prev().val());
    var maxValue = parseInt($(this).data("max"));
    if (oldValue < maxValue) {
        var newValue = oldValue + 1;
        $(this).prev().val(newValue);

        var input = $(this).prev();
        $(input).change();

    }

});

//increase
$(".minus").click(function () {
    var oldValue = parseInt($(this).next().val());

    if (oldValue > 1) {
        var newValue = oldValue - 1;
        $(this).next().val(newValue);

        var input = $(this).next();
        $(input).change();
    }

});

//Add to cart input's limite
$(".cart-plus-minus-box").on("keyup", function (e) {
    e.preventDefault();
    var inputValue = parseInt($(this).val());
    var maxValue = parseInt($(this).next().data("max"));
    if (inputValue > maxValue) {
        $(this).val(maxValue);
    }
    if (inputValue < 0) {
        $(this).val(1);
    }

    //add change function
    $(this).change();
});


$(".cart-plus-minus-box").keypress(function (e) {

    if (e.keyCode == 13) {
        e.preventDefault();
        return false;
    }
});


$(".cart-plus-minus-box").on("change", function (e) {
    e.preventDefault();


    var price = parseFloat($(this).data("price"));
    var quantity = parseInt($(this).val());
    var Id = parseInt($(this).data("id"));



    //total box
    var oldValue = $(this).parent().parent().next().find("strong");


    //for checking empty value
    var stringValue = $(this).val();

    if (quantity != null && quantity > 0 && stringValue != "") {

        //ajax
        $.ajax({

            url: "/basket/UpdateCart/",
            type: "get",
            dataType: "json",

            data: {
                id: Id,
                quantity: quantity
            },
            success: function (response) {

                console.log(response);

            },
            error: function (response) {

                console.log("error: " + response);
            }

        });

        oldValue.empty();
        var total = parseFloat(price * quantity).toFixed(2);
        oldValue.text("$" + total);

        var sum = 0;
        $('.product-subtotal').each(function () {
            var prdTotal = parseFloat($(this).children().text().slice(1, $(this).children().text().length));
            sum += prdTotal;
        });

        //console.log(sum.toFixed(2));
          $("#subtotal").text("$" + sum.toFixed(2));

            if (sum < 100) {
                $("#tax").text("$" + (sum * 18 / 100).toFixed(2));
                $("#orderTotal").text("$" + (sum + (sum * 18 / 100)).toFixed(2)); 
            }
            else {
                $("#tax").text("$0.00");
                $("#orderTotal").text("$" + sum.toFixed(2)); 
                $(".subtotal").text("$" + sum.toFixed(2)); 
            }


    }

});

$(".cart-plus-minus-box").focusout(function (e) {
    //for checking empty value
    var stringValue = $(this).val();
    var intValue = parseInt($(this).val());

    if (stringValue == "") {
        $(this).val(1);
        $(this).change();
    }
    if (intValue < 1) {
        $(this).val(1);
        $(this).change();
    }
});


$('#selectlist').on('change', function () {

    var countryId = parseInt(this.value);

    //Old Shipping Price
    var oldText = $("#shipping_price").text();
    var oldVal = parseFloat(oldText.substr(1));

    //Old Subtotal
    var subText = $(".checkout_subtotal").text();
    var subtotal = parseFloat(subText.substr(1));

    $.ajax({

        url: "/basket/getShippPrice/",
        type: "get",
        dataType: "json",

        data: { countryId: countryId },
        success: function (response) {


            if (oldText != "Free") {

                var resetSub = subtotal - oldVal;
                $(".checkout_subtotal").text("$" + resetSub.toFixed(2));
                subtotal = resetSub;
            }


            if (parseFloat(response) > 0) {

                var price = parseFloat(response);
                $("#shipping_price").text("$" + price.toFixed(2));
                var sumSubAndShipping = price + subtotal;
                $(".checkout_subtotal").text("$" + sumSubAndShipping.toFixed(2));

            } else {
                $("#shipping_price").text("Free");
            }

        },
        error: function (response) {

            console.log("error: " + response);
        }

    });


});
