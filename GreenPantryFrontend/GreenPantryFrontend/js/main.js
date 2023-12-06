/*  ---------------------------------------------------
    Template Name: Ogani
    Description:  Ogani eCommerce  HTML Template
    Author: Colorlib
    Author URI: https://colorlib.com
    Version: 1.0
    Created: Colorlib
---------------------------------------------------------  */

'use strict';

(function ($) {

    /*------------------
        Preloader
    --------------------*/
    $(window).on('load', function () {
        $(".loader").fadeOut();
        $("#preloder").delay(200).fadeOut("slow");

        /*------------------
            Gallery filter
        --------------------*/
        $('.featured__controls li').on('click', function () {
            $('.featured__controls li').removeClass('active');
            $(this).addClass('active');
        });
        if ($('.featured__filter').length > 0) {
            var containerEl = document.querySelector('.featured__filter');
            var mixer = mixitup(containerEl);
        }
    });

    /*------------------
        Background Set
    --------------------*/
    $('.set-bg').each(function () {
        var bg = $(this).data('setbg');
        $(this).css('background-image', 'url(' + bg + ')');
    });

    //Humberger Menu
    $(".humberger__open").on('click', function () {
        $(".humberger__menu__wrapper").addClass("show__humberger__menu__wrapper");
        $(".humberger__menu__overlay").addClass("active");
        $("body").addClass("over_hid");
    });

    $(".humberger__menu__overlay").on('click', function () {
        $(".humberger__menu__wrapper").removeClass("show__humberger__menu__wrapper");
        $(".humberger__menu__overlay").removeClass("active");
        $("body").removeClass("over_hid");
    });

    /*------------------
		Navigation
	--------------------*/
    $(".mobile-menu").slicknav({
        prependTo: '#mobile-menu-wrap',
        allowParentLinks: true
    });

    /*-----------------------
        Categories Slider
    ------------------------*/
    $(".categories__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 4,
        dots: false,
        nav: true,
        navText: ["<span class='fa fa-angle-left'><span/>", "<span class='fa fa-angle-right'><span/>"],
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        responsive: {

            0: {
                items: 1,
            },

            480: {
                items: 2,
            },

            768: {
                items: 3,
            },

            992: {
                items: 4,
            }
        }
    });


    $('.hero__categories__all').on('click', function(){
        $('.hero__categories ul').slideToggle(400);
    });

    /*--------------------------
        Latest Product Slider
    ----------------------------*/
    $(".latest-product__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 1,
        dots: false,
        nav: true,
        navText: ["<span class='fa fa-angle-left'><span/>", "<span class='fa fa-angle-right'><span/>"],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true
    });

    /*-----------------------------
        Product Discount Slider
    -------------------------------*/
    $(".product__discount__slider").owlCarousel({
        loop: true,
        margin: 0,
        items: 3,
        dots: true,
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        responsive: {

            320: {
                items: 1,
            },

            480: {
                items: 2,
            },

            768: {
                items: 2,
            },

            992: {
                items: 3,
            }
        }
    });

    /*---------------------------------
        Product Details Pic Slider
    ----------------------------------*/
    $(".product__details__pic__slider").owlCarousel({
        loop: true,
        margin: 20,
        items: 4,
        dots: true,
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true
    });

    /*-----------------------
		Price Range Slider
	------------------------ */
    var rangeSlider = $(".price-range"),
        minamount = $("#minamount"),
        maxamount = $("#maxamount"),
        minPrice = rangeSlider.data('min'),
        maxPrice = rangeSlider.data('max');
   // debugger

    rangeSlider.slider({
        range: true,
        min: minPrice,
        max: maxPrice,
        values: [minPrice, maxPrice],
        slide: function (event, ui) {
            minamount.val('R' + ui.values[0]);
            maxamount.val('R' + ui.values[1]);

        }
    });
    minamount.val('R' + rangeSlider.slider("values", 0));
    maxamount.val('R' + rangeSlider.slider("values", 1));


    /*--------------------------
        Select
    ----------------------------*/
    $("select").niceSelect();

    /*------------------
		Single Product
	--------------------*/
    $('.product__details__pic__slider img').on('click', function () {

        var imgurl = $(this).data('imgbigurl');
        var bigImg = $('.product__details__pic__item--large').attr('src');
        if (imgurl != bigImg) {
            $('.product__details__pic__item--large').attr({
                src: imgurl
            });
        }
    });

    /*-------------------
		Quantity change
	--------------------- */
    var proQty = $('.pro-qty');
    proQty.prepend('<span class="dec qtybtn">-</span>');
    proQty.append('<span class="inc qtybtn">+</span>');
    proQty.on('click', '.qtybtn', function () {
        var $button   = $(this);
        var oldValue  = $button.parent().find('input').val();

        if ($button.hasClass('inc')) {
            var newVal = parseFloat(oldValue) + 1;

        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        $button.parent().find('input').val(newVal);

        var unitValue = $button.parent().parent().parent().parent().find('.shoping__cart__price').html();
        $button.parent().parent().parent().parent().find('.shoping__cart__total#pTotal').html((newVal * unitValue).toFixed(2));

        var unitID = $button.parent().parent().parent().parent().find('.cart__item-id').val();

        //change totals
        const elementTotals = document.getElementsByClassName('shoping__cart__total');
        var subTotal = 0;

        for (var i = 0; i < elementTotals.length; i++) {
            subTotal += parseFloat(elementTotals[i].innerHTML);
        }

        $('#checkout__cart-total').text("R" + subTotal.toFixed(2));


        if(window.location.pathname === "/cart.aspx") {

            var qtyOnhand = $button.parent().parent().parent().data("stock");
            if (newVal > qtyOnhand) {
                var removeToast = new Toastify({
                    text: "There are only " + qtyOnhand + " units available",
                    duration: 3000,
                    backgroundColor: "#dc3545",
                    close: true
                }).showToast();

                $button.parent().find('input').val(qtyOnhand);
                $button.parent().parent().parent().parent().find('.shoping__cart__total#pTotal').html((qtyOnhand * unitValue).toFixed(2));

            }
            else if (window.location.pathname === "/cart.aspx") {
                //update cookie
                var cookie = getCookie("cart");
                var cVal = cookie;
                if (newVal > 0) {
                    cVal = cVal.replace(unitID + "-" + oldValue, unitID + "-" + newVal);
                }
                else {
                    cVal = cVal.replace(unitID + "-" + oldValue + ",", "");
                }

                document.cookie = "cart=" + cVal;

                if (newVal <= 0)
                    $button.parent().parent().parent().parent().remove();

                $('#checkout__cart-subtotal').text("R" + subTotal.toFixed(2));

                //calculate VAT
                var VAT = subTotal * 15 / 115;
                $('#checkout__cart-VAT').text("R" + (VAT).toFixed(2));

                //calculate delivery fee
                var deliveryFee = 0;
                if (subTotal < 500)
                    deliveryFee = 60;
                if (subTotal === 0)
                    deliveryFee = 0;
                $('#checkout__cart-delivery').text("R" + (deliveryFee).toFixed(2));

                //calculate total
                var total = subTotal + deliveryFee;
                $('#checkout__cart-total').text("R" + total.toFixed(2));
            }

            if (cookie = getCookie("cart") === "") {
                location.reload();
            }
        } 

        //on list page
        if(window.location.pathname === "/shoppinglist.aspx") {
            var listCookie = getCookie("list");
            var cVal = listCookie; 

            if (newVal > 0) {
                cVal = cVal.replace(unitID + "-" + oldValue, unitID + "-" + newVal);
            }
            else {
                cVal = cVal.replace(unitID + "-" + oldValue + ",", "");
            }

            document.cookie = "list=" + cVal;

            if (newVal <= 0)
                $button.parent().parent().parent().parent().remove();

            //show removal confirmation
            var removeToast = new Toastify({
                text: "Remember to save your changes",
                duration: 2000,
                backgroundColor: "#fd7e14",
                close: true
            }).showToast();

        }

    });

    /*-------------------
        Cart item close
    --------------------- */
    var proClose = $('.icon_close');
    //$('.icon_close').on('click', function(){alert("entered")})
    $('.icon_close').on('click', function (event, target) {
        var $button = $(this);
        var unitID = $button.parent().parent().find('.cart__item-id').val();
        var unitQty = $button.parent().parent().find('input#item_qty').val();

        if (window.location.pathname === "/cart.aspx") {
            //get cookie value
            var cookie = getCookie("cart");

            var cVal = cookie.replace(unitID + "-" + unitQty + ",", "");
            document.cookie = "cart=" + cVal;

            //remove the row
            $button.parent().parent().remove();

            //change totals
            const elementTotals = document.getElementsByClassName('shoping__cart__total');
            var subTotal = 0;

            for (var i = 0; i < elementTotals.length; i++) {
                subTotal += parseFloat(elementTotals[i].innerHTML);
            }
            $('#checkout__cart-subtotal').text("R" + subTotal.toFixed(2));
            //calculate VAT
            var VAT = subTotal * 15 / 115;
            $('#checkout__cart-VAT').text("R" + (VAT).toFixed(2));

            //calculate delivery fee
            var deliveryFee = 0;
            if (subTotal < 500)
                deliveryFee = 60;
            if (subTotal === 0)
                deliveryFee = 0;
            $('#checkout__cart-delivery').text("R" + (deliveryFee).toFixed(2));

            //calculate total
            var total = subTotal + deliveryFee;
            $('#checkout__cart-total').text("R" + total.toFixed(2));

            //show removal confirmation
            var removeToast = new Toastify({
                text: "Successfully removed from cart",
                duration: 1500,
                backgroundColor: "#0FAB2C", 
                close: true
            }).showToast();

            if (cookie = getCookie("cart") === "") {
                location.reload();
            }

        }
        else if (window.location.pathname === "/shoppinglist.aspx") {
            //get list cookie
            var listCookie = getCookie("list");

            //update cookie value (i.e remove this product from cookie)
            var cookieVal = listCookie.replace(unitID + "-" + unitQty + ",", "");
            document.cookie = "list=" + cookieVal;

            $button.parent().parent().remove();

            //show removal confirmation
            var removeToast = new Toastify({
                text: "Remember to save your changes",
                duration: 3000,
                backgroundColor: "#fd7e14",
                close: true
            }).showToast();
        }
        
    });

    function getCookie(name) {
        var cookieArr = document.cookie.split(";");

        for (var i = 0; i < cookieArr.length; i++) {
            var singleCookie = cookieArr[i].split("=");

            if (name == singleCookie[0].trim()) {
                return decodeURIComponent(singleCookie[1]);
            }
        }

        return null;
    }

    flatpickr(".dateTimeID");

})(jQuery);