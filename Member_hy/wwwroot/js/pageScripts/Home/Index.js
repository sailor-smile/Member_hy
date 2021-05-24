
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
    _init();
    function _init() {
        var def_date = $('#rqrqrq').val();
        if (!def_date) {
            def_date = _getCurrdate();
        }
        $('#stDate').val(def_date);
    }


    function _getCurrdate() {
        // 当前时间
        var myDate = new Date;
        var year = myDate.getFullYear(); //获取当前年
        var mon = myDate.getMonth() + 1; //获取当前月
        var date = myDate.getDate(); //获取当前日
        var timeing = year + "-" + mon + "-" + date;
        return timeing;
    }


    //添加条件*
    function _setAjaxData1() {
        var cond = {};
        cond.mobile = $("#hyphone").val();

        pageCond.cond = cond;
    }

    function _bind() {
        _initTData();
    }

       //搜索
      $("#sousuo").on("click",function () {
            _initTDatasousuo();
    });



    //搜索
    //$("body").keyup(function () {
    //    if (event.keyCode == 13) {//keyCode=13是回车键
    //        _initTDatasousuo();
    //    }
           
       
    //});
   


    //分页传页码*
    function _setAjaxData() {
        pageCond.pageNo = options.currentPage;
    }



    //查询会员
    function _initTData() {
        _setAjaxData();
        
        var $dataList = $('#dataList');
        $dataList.find('tbody').html('');
        jQuery.ajax({
            dataType: "json",
            url: "/Home/FindforPage",
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




    //会员搜索
    function _initTDatasousuo() {

        _setAjaxData1();
        _setAjaxData();
        var $dataList = $('#dataList');
        $dataList.find('tbody').html('');
        jQuery.ajax({
            dataType: "json",
            url: "/Home/FindforPagesousuo",
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
        //跳转到id卡管理页面
        $('.opt-chakan').on('click', function () {
            var bid = $(this).attr('ref');

            window.location.href = "/IdCard/Index?d=" + bid;
        });
        $('.opt-xiugai').on("click", function () {

            var xid = $(this).attr('ref');
            window.location.href = "/Home/Modify?x=" + xid;

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
                            url: '/Home/DeletMemberM?id=' + id,
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
