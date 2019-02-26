/*global $, jQuery, alert*/
(function ($) {
    "use strict";

    function owlQuote() {
        $('.owl-carousel-quote').owlCarousel({
            items: 1,
            autoplay: true,
            loop: true,
            rewind: true,
            autoplayTimeout: 4200,
            autoplaySpeed: 500,
        })
    }




    function owlTestimonials() {
        $('.owl-carousel-testimonials').owlCarousel({
            items: 1,
            autoplay: true,
            loop: true,
            autoplayTimeout: 4200,
            autoplaySpeed: 500,
            dots: true
        })
    }




    function owlClients() {
        $('.owl-clients').owlCarousel({
            autoplay : true,
            autoplayTimeout: 4000,
            rewind: true,
            dots: false,
            nav: false,
            navText: false,
            responsive: {
                0: {
                    items: 1,
                    nav: true
                },
                600: {
                    items: 3,
                    nav: false
                },
                1000: {
                    items: 5,
                    nav: true,
                    loop: false
                }
            }
        });
    }




    function owlHeroSlider() {
        $(".hero-slider").owlCarousel({
            autoplay: true,
            items: 1,
            dots: false,
            nav: false,
            autoHeight: true,
            loop: true,
            animateIn: "fadeIn",
            animateOut: "fadeOut",
        });
    }




    function owlContentSlider() {
        $(".hero-content-slider").owlCarousel({
            autoplay: 8000,
            autoplayTimeout: 3500,
            autoplaySpeed: 1000,
            mouseDrag: false,
            touchDrag: false,
            loop: true,
            dots: false,
            dragEndSpeed: 800,
            responsiveRefreshRate: 200,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1200: {
                    items: 1
                }
            }
        })
    }
   
   


    // Counter Up Function
    function counterUp() {
        $('.counter').counterUp({
            delay: 16,
            time: 3000
        });
    }




    // Smooth Scroll to Anchor c) 2016 Chris Ferdinandi | MIT License | http://github.com/cferdinandi/smooth-scroll */
    smoothScroll.init({
    selector: '[data-scroll]', // Selector for links (must be a class, ID, data attribute, or element tag)
    selectorHeader: null, // Selector for fixed headers (must be a valid CSS selector) [optional]
    speed: 800, // Integer. How fast to complete the scroll in milliseconds
    easing: 'easeInOutCubic', // Easing pattern to use
    offset: 0, // Integer. How far to offset the scrolling anchor location in pixels
    callback: function ( anchor, toggle ) {} // Function to run after scrolling
    });




    // Navigation Close On Click Function
    $(document).on('click','.navbar-collapse.in',function(e) {
        if( $(e.target).is('a') && $(e.target).attr('class') != 'dropdown-toggle' ) {
            $(this).collapse('hide');
        }
    });




    // Back To Top Button Function
    function backtoTop() {
        $(window).on("scroll", function (){
            var back_to_top = $("#back-to-top");
            if ($(window).scrollTop() > 70) {
                back_to_top.stop().animate({ opacity: '1' }, 150);
            } else {
                back_to_top.stop().animate({ opacity: '0' }, 150);
            };
        })
    }




    // Portfolio Fullwidth - 3 Columns
    $('#portfolio-fullwidth-col-3').cubeportfolio({
        filters: '.portfolio-filter',
        loadMore: '#js-loadMore-lightbox-gallery',
        loadMoreAction: 'click',
        layoutMode: 'grid',
        mediaQueries: [{
            width: 1500,
            cols: 3,
        }, {
            width: 1100,
            cols: 2,
        }, {
            width: 800,
            cols: 2,
        }, {
            width: 480,
            cols: 1
        }],
        defaultFilter: '*',
        animationType: 'sequentially',
        gapHorizontal: 10,
        gapVertical: 10,
        gridAdjustment: 'responsive',
        caption: 'fadeIn'
    });




    // Portfolio Boxed - 3 Columns
    $('#portfolio-boxed-col-3').cubeportfolio({
        filters: '.portfolio-filter',
        loadMore: '#js-loadMore-lightbox-gallery',
        loadMoreAction: 'click',
        layoutMode: 'grid',
        mediaQueries: [{
            width: 1500,
            cols: 3,
        }, {
            width: 1100,
            cols: 3,
        }, {
            width: 800,
            cols: 2,
        }, {
            width: 480,
            cols: 1
        }],
        defaultFilter: '*',
        animationType: 'sequentially',
        gapHorizontal: 10,
        gapVertical: 10,
        gridAdjustment: 'responsive',
        caption: 'fadeIn'
    });




    // Portfolio Boxed - 2 Columns
    $('#portfolio-boxed-col-2').cubeportfolio({
        filters: '.portfolio-filter, .posts-filter',
        loadMore: '#js-loadMore-lightbox-gallery',
        loadMoreAction: 'click',
        layoutMode: 'grid',
        mediaQueries: [{
            width: 1500,
            cols: 2,
        }, {
            width: 1100,
            cols: 2,
        }, {
            width: 800,
            cols: 2,
        }, {
            width: 480,
            cols: 1
        }],
        defaultFilter: '*',
        animationType: 'sequentially',
        gapHorizontal: 30,
        gapVertical: 30,
        gridAdjustment: 'responsive',
        caption: 'fadeIn'
    });




    // Blog Boxed - 2 Columns
    $('#blog-boxed-col-2').cubeportfolio({
        filters: '.posts-filter',
        loadMore: '#js-loadMore-lightbox-gallery',
        loadMoreAction: 'click',
        layoutMode: 'grid',
        mediaQueries: [{
            width: 1500,
            cols: 3,
        }, {
            width: 1100,
            cols: 2,
        }, {
            width: 800,
            cols: 2,
        }, {
            width: 480,
            cols: 1
        }],
        defaultFilter: '*',
        animationType: 'fadeOut',
        gapHorizontal: 30,
        gapVertical: 30,
        gridAdjustment: 'responsive'
    });




    // Fadeout Content On Scroll & Navbar Animation
    $(window).on("scroll", function(){
        $(".hero-content").css("opacity", 1 - $(window).scrollTop() / $('.hero-content').height());
        
        // Navbar On Scroll Animation
        var navbar = $(".navbar");
        if (navbar.offset().top > 50) {
            navbar.addClass("nav-collapsed");
        } else {
            navbar.removeClass("nav-collapsed");
        }        
    });




    $(document).ready(function () {
        parallaxen();
        owlQuote();
        counterUp();
        owlHeroSlider();
        owlContentSlider();
        owlTestimonials();
        owlClients();
        backtoTop();
    });




}(jQuery));  