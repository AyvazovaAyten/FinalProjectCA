$(document).ready(function () {

    $('#phone-btn').hover(function () {
        $('.phone-list').addClass('show');
    }, function () {
        $('.phone-list').removeClass('show');
    });

    $('#lang').click(function () {
        $(".lang-dropdown").toggleClass('show');
    });

    $(".hover-drop").hover(
        function () {
            $(".dropdown-content.account-dropdown").addClass("show");
        }, function () {
            $(".dropdown-content.account-dropdown").removeClass("show");
        }
    );

    CountCircle();



//Mobile Call
    $(document).on('click', '.mob-tel', function (e) {
        e.preventDefault();

        let tel = $(this).find('span').text();
        location.href = 'tel:' + tel; fbq('track', 'Contact');

    });





    ///Menu category click///
    let skip = 12;

    $(document).on('click', '.sticky-menu-btn', function (e) {
        e.preventDefault();


        if (!$(this).hasClass('active')) {
            $('.menu-item.active').removeClass('active');
            $(this).addClass('active');
        }

        $('#categoryName').html($(this).find('.menu-link').text());

        $("html, body").animate({
            scrollTop: parseInt($(".menu_section").position().top) - 64
        }, 20);

        let categoryId = $(this).attr('id');


        $.ajax({
            url: '/Menu/GetProducts',
            data: { CategoryId: categoryId },
            type: 'Get',
            success: function (res) {

                $('#ProductsList').html(res);
                skip = 12;

                let productsCount = parseInt($('#productCount').val());
                let currentProductCount = $('.singleProduct').children().length;

                if (!$.trim($('#load-btn-wrap').html()).length && productsCount > currentProductCount) {
                    $('#load-btn-wrap').html("<span>Load More</span>");
                    $('#load-btn-wrap').find('span').attr('id', 'load');
                } else if ($.trim($('#load-btn-wrap').html()).length && productsCount <= currentProductCount) {
                    $('#load').remove();
                }

            }
        })

    });

    //Product Load

    $(document).on('click', '#load', function (e) {
        e.preventDefault();

        let categoryId = +$('.menu-item.active.category').attr('id');

        $.ajax({
            url: '/Menu/Load',
            data: { skipCount: skip, CategoryId: categoryId },
            type: 'Get',
            success: function (res) {
                $('#ProductsList').append(res);
                let productsCount = parseInt($('#productCount').val());
                skip += 12;
                if (skip >= productsCount) {
                    $('#load').remove();
                }
            }
        })

    });


    //burger-btn//
    const centerLine = $('.main-burger-line');
    const menuNav = $('.menu-nav');
    const header = $('header');

    let menuOpen = false;
    function closeburger() {
        $('.burger-btn').removeClass('open');

        centerLine.removeClass('open');

        menuOpen = false;
        menuNav.removeClass('shown');
        $('.overlay').removeClass('show');
        $('body').removeClass('hidden-scroll');
    }


    $('.overlay').mouseup(e => {
        if (!$('.menu-nav').is(e.target) && $('.menu-nav').has(e.target).length === 0) {
            $('.menu-nav').removeClass('shown');
            $('.overlay').removeClass('show');
            closeburger();
        }
    });


    $(document).on('click', '.burger-btn', function () {
        if (!menuOpen) {

            if ($('#ShoppingBag').hasClass('show')) {
                $('#ShoppingBag').removeClass('show')
            }
            menuOpen = true;
            menuNav.addClass('shown');
            $('body').addClass('hidden-scroll');

            $('.overlay').addClass('show');

            centerLine.addClass('open');

            $('.burger-btn').addClass('open');


        } else {
            closeburger();
        }
    });

    $('.link').click(function () {
        window.open($(this).attr('data-link'), "_self");
    })



    //Cart operations//


    $(document).on('click', '.plus-btn', function (e) {

        e.preventDefault();
        let pr_id = $(this).attr('data-id');
        let countElement = $(this).parent().find('.TotalCount');
        let count = countElement.text();
        let circleCount = $('.count-circle').text();
        let pr_price = parseInt($(this).parent().parent().parent().children('.right-col').find('.current-price').text());
        let total_price = parseInt($('.cart-total').text());



        $.ajax({
            url: "/Cart/IncreaseCount",
            data: { id: pr_id },
            type: 'Get',
            success: function (res) {
                count++;
                circleCount++;
                total_price = total_price + pr_price;

                countElement.text(count);
                $('#summary-count').text(count);
                $('.count-circle').text(circleCount);
                $('.cart-total').text(total_price);
                $('#cart-count').text(circleCount);

            }
        })
    });

    $(document).on('click', '.minus-btn', function (e) {
        e.preventDefault();
        let pr_id = $(this).attr('data-id');
        let countElement = $(this).parent().find('.TotalCount');
        let count = countElement.text();
        let circleCount = $('.count-circle').text();
        let pr_price = parseInt($(this).parent().parent().parent().children('.right-col').find('.current-price').text());
        let total_price = parseInt($('.cart-total').text());

        if (+count > 1) {
            $.ajax({
                url: "/Cart/DecreaseCount",
                data: { id: pr_id },
                type: 'Get',
                success: function (res) {
                    count--;
                    circleCount--;
                    total_price = total_price - pr_price;

                    countElement.text(count);
                    $('#summary-count').text(count);
                    $('.count-circle').text(circleCount);
                    $('.cart-total').text(total_price);
                    $('#cart-count').text(circleCount);

                }
            })
        }
    });




    //////////Shopping///////



    $('.shopping').click(function () {
        GetSummaryCart();

        if ($('.menu-nav').hasClass('shown')) {
            closeburger();
        }

        if (+$('.count-circle').text() == 0) {
            $('.bag-content').html('The cart is empty');
        }
        $("#ShoppingBag").toggleClass('show');

    });


    function CountCircle() {
        if (+$('.count-circle').text() == 0 && $('.count-circle').hasClass('show')) {
            $('.count-circle').removeClass('show');
        } else if (+$('.count-circle').text() >= 1) {
            $('.count-circle').addClass('show');
        }
    }

    function GetSummaryCart() {
        $.ajax({
            url: "/cart/CartSummary",
            type: 'get',
            success: function (res) {
                $('#ShoppingBag').html(res);
                if (+$('#cart-summary-count').text() > 0) {
                    $('.count-circle').addClass('show');
                } else {
                    $('.bag-content').html('The cart is empty');
                }
                $('.count-circle').html($('#cart-summary-count').text());
            }
        })
    }
    GetSummaryCart();
    CountCircle();


    $(document).on('click', '.add-btn', function (e) {

        e.preventDefault();
        let pr_id = $(this).attr('data-id');
        let countelement = $(this).parent().find('.totalcount');
        let count = countelement.text();
        let circlecount = $('.count-circle').text();

        $.ajax({
            url: "/Cart/AddToCart",
            data: { id: pr_id },
            type: 'post',
            success: function (res) {
                $('.count-circle').addClass('show');
                count++;
                circlecount++;
                countelement.text(count);
                $('#summary-count').text(count);
                $('.count-circle').text(circlecount);

                GetSummaryCart();

            }
        })


    });


    $(document).on('click', '.cart-summary-del-btn', function (e) {
        e.preventDefault();

        let pr_id = $(this).attr('data-id');
        let productCount = parseInt($(this).parent().parent().find('#summary-count').text());
        let pr_price = parseInt($(this).parent().find('.current-price').text());
        let product = $(this).parent().parent().parent();
        let total_price = parseInt($('.cart-summary-total').text());
        let circlecount = parseInt($('.count-circle').text());

        $.ajax({
            url: "/cart/RemoveFromCart",
            data: { id: pr_id },
            type: 'post',
            success: function (res) {

                if (circlecount <= 1) {
                    $('.count-circle').removeClass('show');
                    $('.bag-content').html('The cart is empty');
                    circlecount = 0;
                } else {
                    circlecount -= productCount;
                }

                $('.count-circle').text(circlecount);
                $('#cart-summary-count').text(circlecount);

                total_price = total_price - (pr_price * productCount);

                $('.cart-summary-total').text(total_price);

                GetSummaryCart();
                CountCircle();

                $('#ShoppingBag').addClass('show');
            }
        })


    });




    $(document).on('click', '.del-btn.cart-del-btn', function (e) {
        e.preventDefault();

        let pr_id = $(this).attr('data-id');
        let productCount = parseInt($(this).parent().parent().find('.TotalCount').text());
        let pr_price = parseInt($(this).parent().find('.current-price').text());
        let total_price = parseInt($('.cart-total').text());
        let product = $(this).parent().parent().parent();
        let circlecount = parseInt($('.count-circle').text());


        $.ajax({
            url: "/cart/RemoveFromCart",
            data: { id: pr_id },
            type: 'post',
            success: function (res) {

                if (circlecount <= 1) {
                    $('.count-circle').removeClass('show');
                    $('.bag-content').html('The cart is empty');
                    circlecount = 0;
                } else {
                    circlecount -= productCount;
                }

                $('.count-circle').text(circlecount);

                $('#cart-count').text(circlecount);

                total_price = total_price - (pr_price * productCount);


                $('.cart-total').text(total_price);

                product.remove();

                CountCircle();

            }
        })

    })

    ///////user page

    $('.detail-btn').click(function () {
        let id = $(this).parent().attr('id');
        $(`.order-detail[data-id='${id}']`).toggleClass('show')
    });


    $('.menu-item').click(function () {
        $('.menu-item.active').removeClass('active');
        $(this).addClass('active');

        let id = $(this).attr('data-content');
        $('.content-wrapper.active').removeClass('active');
        $(`.content-wrapper[data-category='${id}']`).addClass('active');
    });


    ///Call Request


    $('.call-request').click(function () {
        $(".modal").addClass('open');
    });

    $('.close-btn').click(function () {
        if ($(".modal").hasClass('open')) {
            $(".modal").removeClass('open');
        }
    });



    $(function () {
        $('#callback-request').on('submit', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/Base/CallRequest',
                type: 'POST',
                data: $('#callback-request').serialize(),
                success: function (data) {
                    $('#callback-request').hide();
                    $(".modal-content").append("Your request has been sended. We'll call you!");
                    setTimeout(() => { $(".modal").removeClass('open'); }, 100);

                },
                error: function (data) {
                    $('#callback-request').find('.validation-error').text(data);
                },
            });
        });
    });


    ///Product Rating

    $(document).on('click', '.order-rate .star', function (e) {
        let star = $(this);
        $.ajax({
            url: '/UserAccount/RateProduct',
            data: { value: $(this).attr("value"), id: $(this).parent().attr("data-product") },
            type: 'Get',
            success: function (res) {
                if (res == "Ok") {
                    star.parent().addClass('rated');
                    star.find('.full').addClass("colored");
                    star.find('.full').css("width", "100%");
                    star.prevAll().find('.full').addClass("colored");
                    star.nextAll().find('.full').removeClass("colored");
                    $(this).nextAll().find('.full').css("width", "0%");
                    location.reload();
                } else {
                    $('#RatePartial').html(res);
                }

            }
        })


    });



    $(document).on('click', '.order-rate-btn', function (e) {

        $.ajax({
            url: '/UserAccount/Rating',
            data: { id: $(this).parent().parent().attr("id") },
            type: 'Get',
            success: function (res) {
                $('#RatePartial').html(res);
                $('.rate-modal').addClass('open');

            }
        })



    });

    $('.rate-modal .close-btn').click(function () {
        $('.rate-modal').removeClass('open');
    });


    $(document).on('mouseleave', '.order-rate.stars', function () {
        $('.star').find('.full').css({ "width": "0%" });
        $('.star.colored').find('.full').css({ "width": "100%" });
    });


    $(document).on('mouseenter', '.order-rate .star', function (e) {
        $(this).find('.full').css("width", "100%");
        $(this).prevAll().find('.full').css({ "width": "100%" });

    }).on('mouseleave', '.order-rate .star', function () {
        $(this).find('.full').css("width", "0%");
        $(this).nextAll().find('.full').css("width", "0%");
    });



  
});
