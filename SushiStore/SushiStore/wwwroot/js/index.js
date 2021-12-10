$(document).ready(function () {

  const scrolling =function() {
    const scrolledPixels = window.scrollY;
      const menuPosition = $(".menu_section").position().top;
      let exists = $('.download_section').length;
      let statement;
      if (exists) {
          const downloadPosition = $(".download_section").position().top;
          statement = scrolledPixels < downloadPosition;
      } else {
          statement = true;
      }
    
    const topHeight = $(".top-bar").height();

    if (topHeight == 0) {
    } else {
      if (scrolledPixels > 32) {
        $(".navigation-menu").addClass('fixed');
        $(".first_section").addClass('scrolled');
          $("#ShoppingBag").addClass('scrolled');
          $(".page-intro").addClass('scrolled');
      } else {
          $(".navigation-menu").removeClass('fixed');
          $(".page-intro").removeClass('scrolled');
        $(".first_section").removeClass('scrolled');
        $("#ShoppingBag").removeClass('scrolled');
      }
      }



    if (scrolledPixels >= menuPosition - 64 && statement) {
      if (!$(".sticky-menu").hasClass('sticked')) {
        $(".sticky-menu").addClass('sticked');
      }
    } else if ($(".sticky-menu").hasClass('sticked')) {
      $(".sticky-menu").removeClass('sticked');
    }
  }

  scrolling();

  
  document.addEventListener('scroll', (e) => {
    scrolling();
  });



    ///Scroll on  click



  ////////////Slick///////////////

  $('.owl-carousel').slick({
    autoplay: true,
    slidesToShow: 4,
    slidesToScroll: 1,
    arrows: false,
    prevArrow: false,
    nextArrow: false,
    autoplaySpeed: 2000,
    dots: false,

    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 4,
          slidesToScroll: 1,
          infinite: true,
        }
      },
      {
        breakpoint: 680,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1
        }
      },
      {
        breakpoint: 480,
        settings: {
          centerMode: true,
          centerPadding: '48px',
          slidesToShow: 1,
        }
      }
    ]
  });


});
