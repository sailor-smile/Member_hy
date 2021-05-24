jQuery(function () {
    'use strict';
    var ajaxData = {}, ajaxDatajilu = {};
    //绑定事件

    _bind1();
    //初始化



    //消费
    function tjbin() {
        //alert($('#dataList').find("tbody").find("tr").eq(3).find("button").attr("ref"));
        $(".xmulx").on("click", function () {
         /*  alert($(".xmulx").index(this));*/ // 0,1,2,3,4...
            var num = prompt("请输入,人数：");
            if ((/(^[1-9]\d*$)/.test(num))) {
                ajaxDatajilu.consum = num;
                ajaxData.consum = num;
                ajaxData.cCardId = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("ref");//获取按钮对应的卡号
                ajaxDatajilu.cCardId = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("ref");//获取按钮对应的卡号
                ajaxData.cda = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("cda");//获取按钮对应的卡号的余额
                ajaxDatajilu.cda = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("cda");//获取按钮对应的卡号的余额
                ajaxData.cardseller = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("red");//获取按钮对应的折扣
                ajaxDatajilu.discount = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("red");//获取按钮对应的折扣
                ajaxData.cFrequency = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("cis");//获取次卡对应的次数
                ajaxDatajilu.itemId = $('#dataList').find("tbody").find("tr").eq(($(".xmulx").index(this)) * 2 + 1).find("button").attr("cis");//获取次卡对应的次数

                //今天的时间
                var day2 = new Date();
                day2.setTime(day2.getTime());
                var s2 = day2.getFullYear() + "-" + (day2.getMonth() + 1) + "-" + day2.getDate() + day2.toLocaleTimeString();
                ajaxDatajilu.cDate = s2;//获取当时时间
                for (var i = 0; i < $(".gogo ul").length; i++) {
                    if ($(".gogo").find("ul").eq(i).find("li").eq(0).find("label").find("input").is(':checked') == true) {
                        ajaxData.xda = $(".gogo").find("ul").eq(i).find("li").eq(3).text();
                        ajaxDatajilu.pAmount = $(".gogo").find("ul").eq(i).find("li").eq(3).text();
                        ajaxDatajilu.cItems = $(".gogo").find("ul").eq(i).find("li").eq(1).text();
                    }
                }
                _xiangmu();
            }
            else {
                alert("输入有误!");
                reload();
            }
       
        });
    }


    //加载内容
    _initData($('#dataId').val());

    //搜索
    $("#QueryButton").on("click", function () {
        var a = $("#iid").val();
        $("#lid").val("");
        _initData(a);

    })

   
    

    //根据会员号查询
    function _initData(lid) {
        var querydata = {};
        var lid = $("#lid").val();//返回的卡号
        var cod = $("#MembershipCardNumber").val();//输入框里的数据
        if (lid != null && lid != "") {
            cod = lid;
        }
        querydata.dataId = $("#dataId").val();
        querydata.idcard = cod
        querydata.fhidcard = lid

        
        jQuery.ajax({
            dataType: "json",
            url: "/IdCard/FindCard",
            data: querydata,
            type: "Post",
            success: function (result) {
                if (result.code == 1) {
                    var $dataList = $('#dataList');
                    var list = result.data;
                    $dataList.find('tbody').html('');
                    if (list != null && list.length > 0) {
                        $("#listTpl").tmpl(list).appendTo('#dataList tbody');
                        bind();
                        _bindDelEvent();
                        biin();
                        tjbin();
                        liubi();

                    } else {
                        biin();
                    }
                }
            },
            error: function () {
                FOXKEEPER_UTILS.alert('danger', '程序出错.');
            }
        });
    }



    function _hycharsousuo(lid) {
       
        var cod = $("#MembershipCardNumber").val();
        if (lid != null && lid != "") {
            cod = lid;
        }
        jQuery.ajax({
            dataType: "json",
            url: "/IdCard/FindCard",
            data: { dataId: cod},
            type: "Get",
            success: function (result) {
               
                var $dataList = $('#dataList');
                var list = result.data;
                $dataList.find('tbody').html('');
                if (list != null) {
                    $("#listTpl").tmpl(list).appendTo('#dataList tbody');
                    bind();
                    _bindDelEvent();
                    biin();
                    tjbin();
                    liubi();
                } else {
                    alert("没有找到卡号:" + cod);

                }
            },
            beforeSend: function () {
            },
            error: function () {
                alert("系统正在开小差");
            }
        });
        return true;
    }






    //添加消费记录
    function _saveConsum() {
      
        jQuery.ajax({
            dataType: "json",
            url: "/IdCard/Xiaofeijilu",
            data: ajaxDatajilu,
            type: "POST",
            success: function (result) {
                if (result.code == 1) {
                    FOXKEEPER_UTILS.alert('success', '已生成消费记录');
                } else {
                    alert("系统正在开小差");

                }
            },
            beforeSend: function () {
            },
            error: function () {
                alert("系统正在开小差");
            }
        });
        return true;
    }








    //项目消费
    function _xiangmu($target, btnText) {
        bootbox.dialog({
            title: "",
            message: '<div class="row">  ' +
                '<div class="col-xs-12"> ' +
                '请确认是否结算此项目？' +
                '</div></div>',
            buttons: {
                cancel: {
                    label: "取消",
                    className: "btn-cancel",
                    callback: $.noop
                },
                confirm: {
                    label: "确定提交",
                    className: "btn-success",
                    callback: function () {
                        jQuery.ajax({
                            dataType: "json",
                            url: "/IdCard/Xiaofei",
                            data: ajaxData,
                            type: "POST",
                            success: function (result) {
                                if (result.code == 1) {
                                    FOXKEEPER_UTILS.alert('success', '操作成功');
                                    _saveConsum();

                                    setTimeout(function () {
                                        //location.replace('/IdCard/Index?d=' + location.search.replace(/[^\d]/g, ""));
                                        _initData($('#dataId').val()) 
                                    }, 1000);
                                } else if (result.code == 0) {
                                    FOXKEEPER_UTILS.alert('warning', '请选择项目');
                                } else if (result.code == -2) {
                                    FOXKEEPER_UTILS.alert('warning', '余额不足请充值');
                                } else if (result.code == -3) {
                                    FOXKEEPER_UTILS.alert('warning', '次数不足请充值');
                                } else {
                                    FOXKEEPER_UTILS.alert('warning', '系统正在开小差@~@！');

                                }
                            },
                            beforeSend: function () {
                              
                            },
                            error: function () {
                                FOXKEEPER_UTILS.alert('danger', '系统异常');
                            }
                        });
                        return true;
                    }
                }
            }
        })
    }








    function biin() {
        //var cname = $("#cname").text();
        //$("#tjk").attr("club", cname)
        //添加卡
        $('#tjk').on('click', function () {
            //var bid = $(this).attr('club');
            window.location.href = "/IdCard/Create?bid=" + location.search.replace(/[^\d]/g, "");
        });

        //流水信息
        $('.liusuixx').on('click', function () {
           var p =  $(this).attr("ref");
            window.location.href = "/Consumption/Index?lid=" + p;
        })

        //修改
        $('.updatexxc').on('click', function () {
            var x = $(this).attr("ref");
            window.location.href = "/IdCard/Modify?xid=" + x;

        });




    }

    function liubi() {
        $(".soso").on("click", function () {
            if ($(".gogo").find("ul").eq($(".soso").index(this)).find("li").eq(0).find("label").find("input").is(':checked') == true) {
                $(".gogo").find("ul").eq($(".soso").index(this)).css("background-color", "yellow");
                } else {
                $(".gogo").find("ul").eq($(".soso").index(this)).css("background-color", "white");
                }

            })
    }




    function bind() {
        //console.log(w);
        //tr长度
      //  var trlength = $("#dataList>tbody").children("tr").length;
        $(".opt-chakan").on('click', function () {
            var w = $(this).text().trim().replace(/\s/g, "");
            //alert($(".opt-chakan").index(this));//获取点击按钮的位置
            if (w == "查看消费菜单") {
                $("#dataList").find("tbody").find("tr").eq(($(".opt-chakan").index(this)) * 2 + 1).attr("class", "detail-row open");
                $(this).text("关闭消费菜单");


            } else {
                $("#dataList").find("tbody").find("tr").eq(($(".opt-chakan").index(this)) * 2 + 1).attr("class", "detail-row");
                $(this).text("查看消费菜单");
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
  
    }


    
   

   


    function _bind1() {
        /**  保存 */
        $('#btnSave1').click(function () {
            _save($(this), $(this).text());
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
                            url: '/IdCard/DeletIdCard?id=' + id,
                            data: null,
                            type: "POST",
                            success: function (result) {
                                if (result.code == 1) {
                                    setTimeout(function () {
                                        FOXKEEPER_UTILS.alert('success', '删除成功');
                                        location.replace('/IdCard/Index?d=' + location.search.replace(/[^\d]/g, ""));
                                    }, 1000);
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


