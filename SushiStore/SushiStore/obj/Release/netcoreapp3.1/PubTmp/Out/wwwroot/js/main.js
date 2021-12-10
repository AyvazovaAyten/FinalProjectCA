$(document).ready(function () {

  const scrolling = function () {
    const scrolledPixels = window.scrollY;
    const topHeight = $(".top-bar").height();

    if (topHeight == 0) {
    } else {
      if (scrolledPixels > 32) {
        $(".navigation-menu").addClass('fixed');
        $(".page-intro").addClass('scrolled');
        $("#ShoppingBag").addClass('scrolled');
      } else {
        $(".navigation-menu").removeClass('fixed');
        $(".page-intro").removeClass('scrolled');
        $("#ShoppingBag").removeClass('scrolled');
      }
    }
  }

  scrolling();


  document.addEventListener('scroll', (e) => {
    scrolling();
  });

  $('.product__image').click(function () {
    window.open(this.attr('data-link'));
    console.log(this.attr('data-link'));
  })

  function addToBasket(element) {
    $('.count-circle').addClass('show');
    $('.count-circle').text(`${count}`);
 
  }

});