$(function() {
    "use strict";

    
	
	
	//if ($('html').hasClass('desktop')) {
	//		new WOW().init();
	//	  } 
	
	/* ==========================================================================
   Flex menu
   ========================================================================== */
    $(".flexy-menu").flexymenu({ speed: 300, scrollableMaxHeigh: 400 });
	
	
	/* ==========================================================================
     Textrotator
     ========================================================================== */   

    //$(".rotate").textrotator({
    //    animation: "dissolve",
    //    separator: ",",
    //    speed: 2500
    //});



    /* ==========================================================================
     For anchor smooth scroll
     ========================================================================== */  
    //$('a[href*=#]').on('click', function(event){     
    //    event.preventDefault();
    //    $('html,body').animate({scrollTop:$(this.hash).offset().top}, 500);
    //});
      	
	



});





//flexy.js
//(function ($) {

//    jQuery.fn.flexymenu = function (options) {
//        var settings = {
//            speed: 300,
//            type: "horizontal",
//            align: "left",
//            indicator: false,
//            hideClickOut: true,
//            submenuTrigger: "hover",
//            showDelay: 0,
//            hideDelay: 0,
//            mobileShowDelay: 0,
//            mobileHideDelay: 0,
//            scrollable: false,
//            scrollableMaxHeight: 400
//        }
//        $.extend(settings, options);

//        var bigScreen = false;
//        var menu = $(this);
//        var lastScreenWidth = windowWidth();
//        $(".flexy-menu").wrap("");
//		var menuWrapper = $(".flexy-menu-wrapper");

//        if (settings.type == "vertical") {
//            $(menu).addClass("vertical");
//            if (settings.align == "right") {
//                $(menu).addClass("right");
//            }
//        }

//        if (settings.indicator) {
//            $(menu).find("li").each(function () {
//                if ($(this).children("ul").length > 0) {
//                    $(this).append("+");
//                }
//            });
//        }

//        //$(menu).prepend("MENU");
		
//		screenSize();

//        $(window).resize(function () {
//            if (lastScreenWidth <= 768 && windowWidth() > 768) {
//                unbindEvents();
//                hideCollapse();
//                bindHover();
//                if (settings.type == "horizontal" && settings.align == "right" && bigScreen == false) {
//                    rightAlignMenu();
//                    bigScreen = true;
//                }
//            }
//            if (lastScreenWidth > 768 && windowWidth() <= 768) {
//                unbindEvents();
//                showCollapse();
//                bindClick();
//                if (bigScreen == true) {
//                    rightAlignMenu();
//                    bigScreen = false;
//                }
//            }
//            lastScreenWidth = windowWidth();
//        });

//        function screenSize() {
//            if (windowWidth() <= 768) {
//                showCollapse();
//                bindClick();
//                if (bigScreen == true) {
//                    rightAlignMenu();
//                    bigScreen = false;
//                }
//            }
//            else {
//                hideCollapse();
//                bindHover();
//                if (settings.type == "horizontal" && settings.align == "right" && bigScreen == false) {
//                    rightAlignMenu();
//                    bigScreen = true;
//                }
//            }
//        }

//        function bindHover() {
//            if (navigator.userAgent.match(/Mobi/i) || window.navigator.msMaxTouchPoints > 0 || settings.submenuTrigger == "click") {
//                $(menu).find("a").on("click touchstart", function (e) {
//                    e.stopPropagation();
//                    e.preventDefault();
//                    $(this).parent("li").siblings("li").find("ul").stop(true, true).fadeOut(settings.speed);
//                    if ($(this).siblings("ul").css("transform") == "translateY(0%)") {
//                        $(this).siblings("ul").stop(true, true).delay(settings.showDelay).fadeIn(settings.speed);
//                        return false;
//                    }
//                    else {
//                        $(this).siblings("ul").stop(true, true).delay(settings.hideDelay).fadeOut(settings.speed);
//                        $(this).siblings("ul").find("ul").stop(true, true).fadeOut(settings.speed);
//                    }
//                    window.location.href = $(this).attr("href");
//                });

//                $(menu).find("li").bind("mouseleave", function () {
//                    $(this).children("ul").stop(true, true).fadeOut(settings.speed);
//                });

//                if (settings.hideClickOut == true) {
//                    $(document).bind("click.menu touchstart.menu", function (ev) {
//                        if ($(ev.target).closest(menu).length == 0) {
//                            $(menu).find("ul").fadeOut(settings.speed);
//                        }
//                    });
//                }
//            }
//            else {
//                $(menu).find("li").bind("mouseenter", function () {
//                    //$('.flexy-menu > li').find('ul').hide();//this line is my custom code for tab fixes when hover is done
//                    $(this).children("ul").stop(true, true).delay(settings.showDelay).fadeIn(settings.speed);
//                }).bind("mouseleave", function () {
//                    $(this).children("ul").stop(true, true).delay(settings.hideDelay).fadeOut(settings.speed);
//                });
//            }
//        }

//        function bindClick() {
//            $(menu).find("li:not(.showhide)").each(function () {
//                if ($(this).children("ul").length > 0) {
//                    $(this).children("a").on("click", function () {
//                        if ($(this).siblings("ul").css("display") == "none") {
//                            $(this).siblings("ul").delay(settings.mobileShowDelay).slideDown(settings.speed);
//                            $(this).parent("li").siblings("li").find("ul").delay(settings.mobileHideDelay).slideUp(settings.speed);
//                            return false;
//                        }
//                        else {
//                            $(this).siblings("ul").delay(settings.mobileHideDelay).slideUp(settings.speed);
//                        }
//                    });
//                }
//            });
//        }

//        function showCollapse() {
//            $(menu).children("li:not(.showhide)").hide(0);
//            $(menu).children("li.showhide").show(0).bind("click", function () {
//                if ($(menu).children("li").is(":hidden")) {
//                    $(menu).children("li").slideDown(settings.speed);
//                    scrollable(true);
//                }
//                else {
//                    $(menu).children("li:not(.showhide)").slideUp(settings.speed);
//                    $(menu).children("li.showhide").show(0);
//                    $(menu).find("ul").hide(settings.speed);
//                    scrollable(false);
//                }
//            });
//        }

//        function hideCollapse() {
//            $(menu).children("li").show(0);
//            $(menu).children("li.showhide").hide(0);
//            scrollable(false);
//        }

//        function rightAlignMenu() {
//            $(menu).children("li").addClass("right");
//            var menuItems = $(menu).children("li");
//            $(menu).children("li:not(.showhide)").detach();
//            for (var i = menuItems.length; i >= 1; i--) {
//                $(menu).append(menuItems[i]);
//            }
//        }

//        function unbindEvents() {
//            $(menu).find("li, a").unbind();
//            $(document).unbind("click.menu touchstart.menu");
//            $(menu).find("ul").hide(0);
//        }

//        function windowWidth() {
//            return document.documentElement.clientWidth || document.body.clientWidth || window.innerWidth;
//        }

//        function scrollable(flag) {
//            if (settings.scrollable) {
//                if (flag) {
//                    $(menuWrapper).css("max-height", settings.scrollableMaxHeight).addClass("scrollable")
//                }
//                else {
//                    $(menuWrapper).css("max-height", "auto").removeClass("scrollable")
//                }
//            }
//        }

//        //Fixes Aria Stuff
//        $('.flexy-menu > li').keydown(function (event) {
//            if (event.which == 13) {
//                if ($(this).find('ul').length > 0) {
//                    var menu_dat = $(this).find('ul');
//                    $(menu_dat).show();
//                }
//            }
//        });

//        var top_level_links = $('.flexy-menu').find('> li > ul li:last-child a');
//        $(top_level_links).blur(function () {
//            $('.flexy-menu > li').find('ul').hide();
//        });

//    }

//}(jQuery));
