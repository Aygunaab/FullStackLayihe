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
  filter: '.fabric', 
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



  //Cart Plus Minus Button
    var CartPlusMinus = $(".cart-plus-minus");
    CartPlusMinus.prepend('<div class="minus plmin">-</div>');
    CartPlusMinus.append('<div class="plus plmin">+</div>');
    $(".plmin").on("click", function () {
        var $button = $(this);
        var oldValue = $button.parent().find("input").val();
        if ($button.text() === "+") {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 1) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 1;
            }
        }
        $button.parent().find("input").val(newVal);
    });

    //Related Products slide

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
if ($(".remove-header-basket-item").length) {
  $(".remove-header-basket-item").click(function (e) {
      e.preventDefault();
      $.ajax({
          url: $(this).attr("href"),
          type: "get",

          success: function (res)
          {
              $(".header-basket").html(res)
           
          }
      });
  });
}
if ($(".remove-header-basket-item").length) {
  $(document).on("click",".remove-header-basket-item",function (e) {
    e.preventDefault();
    let elem = $(this);
    $.ajax({
        url: $(this).attr("href"),
        type: "get",
       

        success: function (res)
        {
            $(".header-basket").html(res);
          
            $.toast({
                heading: 'Məlumat',
                text: "Məhsul səbətinizdən silindi",
                icon: 'info',
                loader:true,
                bgColor: '#358EC1',
                loaderBg: '#f7d40d',
                position:'bottom-right'
            });
        }
    });
});
}

if ($(".add-to-cart").length) {
  $(document).on("click",".add-to-cart",function (e) {
      e.preventDefault();
    
      $.ajax({
          url: $(this).attr("href"),
          type: "get",
          success: function (res) {
             
              $(".header-basket").html(res);
              $.toast({
                  heading: 'Məlumat',
                  text: "Məhsul səbətinizə əlavə edildi",
                  icon: 'success',
                  loader:true,
                  bgColor: '#eaaa85',
                  loaderBg: '#f7d40d',
                  position: 'bottom-right'
              });
              
          }
      });
  });
}

