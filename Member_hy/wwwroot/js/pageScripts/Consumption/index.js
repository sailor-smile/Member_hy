jQuery(function () {
    'use strict';
    var $paginationContainer = $('#paginationContainer');
    //分页功能
    var options = {
        //bootstrapMajorVersion:3,
        containerClass: 'dataTables_paginate paging_bootstrap',
        listContainerClass: 'pagination pull-right',
        currentPage: 1,
        totalPages: 10,
        numberOfPages: 5,
        pageUrl: function (type, page, current) {
            return "javascript:;";
        },
        onPageClicked: function (e, originalEvent, type, page) {
            options.currentPage = page;
            _initTData();
        }
    }

    var pageCond = {
        pageNo: 1,
        pageSize: 15
    };

    var Cond = {};
    _bind();

    function _bind() {
        _initTData();

    }
    function _setAjaxData1() {
        var iid = $("#iid").val();
        pageCond.cond = {
            idcard: iid
        };
    }


    function _setAjaxData2() {
        var cond = {};

        var time = $('#stDate').val();
        cond.statime = time;
        pageCond.cond = cond;
    }
    //分页传页码*
    function _setAjaxData() {
        pageCond.pageNo = options.currentPage;
    }
    //根据ID卡检索流水
    function _initTData() {
        _setAjaxData1();
        _setAjaxData();
        var $dataList = $('#dataList');
        $dataList.find('tbody').html('');
        jQuery.ajax({
            dataType: "json",
            url: "/Consumption/FindforPage",
            data: pageCond,
            type: "POST",
            success: function (rs) {
                if (rs.code == 1) {
                    var $dataList = $('#dataList');
                    var $pageTotalRecord = $('#pageTotalRecord');
                    var list = rs.data.data;
                    $dataList.find('tbody').html('');
                    if (list != null && list.length > 0) {
                        $("#listTpl").tmpl(list).appendTo('#dataList tbody');
                        var count = rs.data.totalRecords;
                        options.totalPages = rs.data.totalPages;
                        $paginationContainer.bootstrapPaginator(options);
                        _bindDelEvent();
                        day();
                        //_huoqian();
                        $pageTotalRecord.html('<div class="dataTables_info" role="status" aria-live="polite">共 '
                            + options.totalPages + ' 页 ' + count + '条记录，当前为第 ' + options.currentPage + ' 页');
                    } else {
                        $pageTotalRecord.html('<div class="dataTables_info" role="status" aria-live="polite">无查询记录</div>');
                        $paginationContainer.html('');
                    }
                    $('html').scrollTop(0);
                }
            },
            beforeSend: function () {
            },
            error: function () {
                alert('系统正在开小差~');
            }
        });

    }


    
   

    $("#fanhui").on("click", function () {
        var id = $("#iid").val();
        window.location.href = "/IdCard/Index?lid=" + id;
        
    })


   

    function _getCurrdate() {
        // 当前时间
        var myDate = new Date;
        var year = myDate.getFullYear(); //获取当前年
        var mon = myDate.getMonth() + 1; //获取当前月
        var date = myDate.getDate(); //获取当前日
        var timeing = year + "-" + mon + "-" + date;
        return timeing;
    }




   
    function day() {

        $('.optdayin').on('click', function () {
            $('#daying').html('');
            var lsid = $(this).attr("ref")
            _huoquday(lsid);

           

        })
    }

    //获取打印内容
    function _huoquday(id) {
        jQuery.ajax({
            dataType: "json",
            url: '/Consumption/FindforPagess?liushuicode=' + id,
            data: null,
            type: "GET",
            success: function (rs) {
                if (rs.data != null) {
                    var list = rs.data; 
                    if (list.discount != 0) {
                        
                        list.pAmount = list.pAmount * list.consum * list.discount;
                        list.pAmount = Math.floor(list.pAmount)
                        list.cda = list.cda - list.pAmount 
                        list.cda = Math.ceil(list.cda)

                    }else {
                        list.pAmount = list.pAmount * list.consum * 1;
                        list.cda = list.cda - list.pAmount 
                    }
                   
                    $("#listTpl1").tmpl(list).appendTo('#daying');
                    options.totalPages = rs.data.totalPages;
                    $paginationContainer.bootstrapPaginator(options);
                    dayin();
                    _initTData();
                } 
                    $('html').scrollTop(0);
                
            }
        });
        return true;

    }




    function dayin() {
        //$('#biaotou tbody').html('');
        //$('#biaotou tbody').append(tempGrp1);
        //if (tempLen > 0 && typeof (tempLen) != 'undefined') {
        //    $('#dayindataList tbody tr:lt(' + tempLen + ')').remove();
        //}
        //var nian = $("#niana").text();
        //$("#nianid").text(nian);
        //打印
        $("#daying").jqprint({
            debug: false,//如果是true则可以显示iframe查看效果（iframe默认高和宽都很小，可以再源码中调大），默认是false
            importCSS: true,//true表示引进原来的页面的css，默认是true。（如果是true，先会找$("link[media=print]")，若没有会去找$("link")中的css文件）
            printContainer: true,//表示如果原来选择的对象必须被纳入打印（注意：设置为false可能会打破你的CSS规则）
            operaSupport: false //表示如果插件也必须支持歌opera浏览器，在这种情况下，它提供了建立一个临时的打印选项卡。默认是true
        });
    }




    ////搜索
    //$("body").keyup(function () {
    //    if (event.keyCode == 13) {//keyCode=13是回车键
    //        _initTDatasousuo();
    //    }


    //});







    //function _huoqian() {
    //    for (var i = 0; i < $("#dataList").find("tbody").find("tr").length; i++) {
    //        var a = $("#dataList").find("tbody").find("tr").eq(i).find("td").eq(5).text();
    //        var b = $("#dataList").find("tbody").find("tr").eq(i).find("td").eq(6).text();
    //        var c = $("#dataList").find("tbody").find("tr").eq(i).find("td").eq(7).text();
    //        var sycs = $("#dataList").find("tbody").find("tr").eq(i).find("td").eq(9).text();
    //        if (b != 0 && c != 0) {
    //            var d = a - b * c;
    //        } else {
    //            var d = a - b * 1;
    //        }
            

    //        if (sycs == "" || sycs == null) {
    //            return;
    //        } else {
    //            if (!isNaN(sycs)) {
    //                $("#dataList").find("tbody").find("tr").eq(i).find("td").eq(9).text(sycs - 1);

    //            } else {
    //                $("#dataList").find("tbody").find("tr").eq(i).find("td").eq(8).text(d.toFixed(2));
    //            }

    //        }

    //    }

    //}


   

    


    $('#sousuo').on("click", function () {
      
        _initTDatasousuo();
       
    });

    //根据时间搜索
    function _initTDatasousuo() {
        _setAjaxData2();
        _setAjaxData();
        var $dataList = $('#dataList');
        $dataList.find('tbody').html('');
        jQuery.ajax({
            dataType: "json",
            url: "/Consumption/FindforPagesousuo",
            data: pageCond,
            type: "Post",
            success: function (rs) {
                if (rs.code == 1) {
                    var $dataList = $('#dataList');
                    var $pageTotalRecord = $('#pageTotalRecord');
                    var list = rs.data.data;
                    $dataList.find('tbody').html('');
                    if (list != null && list.length > 0) {
                        $("#listTpl").tmpl(list).appendTo('#dataList tbody');
                        var count = rs.data.totalRecords;
                        options.totalPages = rs.data.totalPages;
                        $paginationContainer.bootstrapPaginator(options);
                        _bindDelEvent();
                        day();
                        //_huoqian();
                        $pageTotalRecord.html('<div class="dataTables_info" role="status" aria-live="polite">共 '
                            + options.totalPages + ' 页 ' + count + '条记录，当前为第 ' + options.currentPage + ' 页');
                    } else {
                        $pageTotalRecord.html('<div class="dataTables_info" role="status" aria-live="polite">无查询记录</div>');
                        $paginationContainer.html('');
                    }
                    $('html').scrollTop(0);
                }
            },
            beforeSend: function () {
            },
            error: function () {
                alert('系统正在开小差~');
            }
        });

    }







    //提交保存数据
    //事件绑定
    function _bindDelEvent() {

        //删除
        $('.opt-del').on('click', function () {
            _del($(this).attr("ref"));
        });

        $('.opt-chakan').on('click', function () {
            var bid = $(this).attr('ref');

            window.location.href = "/IdCard/Index?d=" + bid;
        });
    }

    //删除字典
    function _del(id) {
        bootbox.dialog({
            title: "",
            message: '<div class="row">  ' +
                '<div class="col-xs-12"> ' +
                '请确认是否删除此条记录吗？' +
                '</div></div>',
            buttons: {
                cancel: {
                    label: "取消",
                    className: "btn-cancel",
                    callback: $.noop
                },
                confirm: {
                    label: "确定",
                    className: "btn-success",
                    callback: function () {
                        jQuery.ajax({
                            dataType: "json",
                            url: '/Consumption/DeletConsumption?id=' + id,
                            data: null,
                            type: "POST",
                            success: function (result) {
                                if (result.code == 1) {
                                    setTimeout(function () {
                                        FOXKEEPER_UTILS.alert('success', '删除成功');
                                    }, 0);
                                    setTimeout(function () {
                                        var $dataList = $('#dataList');
                                        $dataList.find('tbody').html('');
                                        _initTData();
                                    }, 0);
                                } else {
                                    //失败
                                }
                            }
                        });
                        return true;
                    }
                }
            }
        })
    }






});
