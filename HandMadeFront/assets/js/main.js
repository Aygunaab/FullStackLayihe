$('.hero-slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 5000,
    arrows:true,
    prevArrow:(".prev"),
    nextArrow:(".next"),
    fade:true,
    cssEase: 'linear',
    waitForAnimate:true,                  
  });


  $('.slider').slick({
    infinite: true,
    slidesToShow: 6,
    slidesToScroll: 6, 
    arrows:true,
    prevArrow:(".prev"),
    nextArrow:(".next"),
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



