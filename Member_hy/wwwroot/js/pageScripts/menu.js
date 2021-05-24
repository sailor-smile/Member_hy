//左菜单处理事件
jQuery(function () {

    _initMenuEvent();

    function _initMenuEvent() {
        var activePage = __system_navigation_config.currentNav;
        if (activePage!='') {

        }
        var _target = $("#menu-list li ul>li a[href='" + activePage + "']");
        _target.parent().addClass("active");
        _target.parent().parent().parent().addClass('open');
        //_target.parent().parent().attr("style", "display:block;");
        //$('#menu-list li a').trigger("click");
    }

    //$(function () {
    //    var _target = $("#menu-list li ul>li a");

    //    _target.addClass("active");
    //    _target.parent().parent().parent().addClass('open');
    //    _target.parent().parent().attr("style", "display:block;");
    //    $('#menu-lis li a').trigger("click");
    //});

    if ($('#suid').val() != 'bi') {
        $('#navbar').removeClass('hide');
    } else {
        if (!$('#navbar').hasClass('hide')) {
            $('#navbar').addClass('hide');
        }
    }

    $('#menu-list li a').click(function (e) {
        //var $that = $(this);
        //var $parent = $that.parent();
        //$parent.addClass("active");
        //$('#menu-list li').removeClass("open");
        //$('#menu-list li').removeClass("active");
        //$("#menu-list li ul>li a").removeClass("active");
        //var $parent = $that.parent();
        //$parent.addClass("active");
        //$parent.parent(".submenu").parent().addClass("open");
        
        //
        //if ($(this).next().next().hasClass('submenu') === false) {
        //    return;
        //}

        //var parent = $(this).parent().parent();
        //var sub = $(this).next();

        //parent.children('li.open').children('.submenu').slideUp(200);
        //parent.children('li.open').children('a').children('.arrow').removeClass('open');
        //parent.children('li').removeClass('open');

        //if (sub.is(":visible")) {
        //    $(this).find(".arrow").removeClass("open");
        //    sub.slideUp(200);
        //} else {
        //    $(this).parent().addClass("open");
        //    $(this).find(".arrow").addClass("open");
        //    sub.slideDown(200);
        //}

    });
});