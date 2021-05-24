jQuery(function () {
    'use strict';

    var ajaxData = {}, delopt;

    //绑定事件
    _bind();

    //初始化
    _init();
    //_getgdname();
    _ychang();

    function _ychang() {
        $(".shijianuxanzhe").hide();
        $(".gdxuanzhekuang").hide();
    }

    function _init() {
        $('#option').hide();
        //_initData();
    }
    function _bind() {

        //创建行时间
        $('#addRow').on('click', function () {
            $(".shijianuxanzhe").show();
            $(".gdxuanzhekuang").show();
            var cls = $("#indexTab thead th").length;//列
            var ros = $("#indexTab tbody tr").length;//行
            if (ros == 0) {
                $('#option').show();
            }
            _crtImprotDataRow(cls - 1, ros);
        });
        //业务重置表单
        $('#resetBtn').on('click', function () {
            $("#indexTab tbody tr").remove();
            $('#option').hide();
            $('#addRow').show();
            $('.gdxuanzhekuang').hide();
        });
    }





    function _bind1() {
        /**  保存 */
        $('#btnSave1').click(function () {
            _save($(this), $(this).text());
            //_buildSubData();
        });
    }





    //创建导入行和列
    function _crtImprotDataRow(len, rowNo) {
        //var currDate = moment().format("MM");
        var htm = '<tr>';
        for (var i = 0; i < len; i++) {

            if (i == 0) {
                //var time = $("#stDate1").attr("value");
                htm += '<td align="center" style="border-color: #e1e1e1;width: 20%;" ><input type="text" class="" style="width: 100%;" /></td>';
            } else if (i == 1) {
                //console.log($('#mes1').html());
                htm += '<td align="center" style="border-color: #e1e1e1;width: 10%;" >  <select class="opt7" style="border-color: #e1e1e1;width: 100%;" ><option text="0" value="0">白金卡</option><option text="1" value="1">次卡</option><option text="2" value="2">金卡</option><option text="3" value="3">银卡</option><option text="4" value="4">送礼卡</option></td>';
            }
            else if (i == 2) {
                htm += '<td align="center" style="border-color: #e1e1e1;width: 10%;" ><input type="text" class="" /></td>';
            }
            else if (i == 3) {
                htm += '<td align="center" style="border-color: #e1e1e1;width: 10%;" ><select class="opt7" style="border-color: #e1e1e1;width: 100%;" ><option text="" value="" selected>1</option><option text="" value="">0.9</option><option text="" value="">0.8</option><option text="" value="">0.7</option><option text="" value="">0.6</option><option text="" value="">0.5</option><option text="" value="">0.4</option><option text="" value="">0.3</option><option text="" value="">0.2</option><option text="" value="">0.1</option></select></td>';
            }
            else if (i == 4) {
                htm += '<td align="center" style="border-color: #e1e1e1;width: 20%;" ><span class=""><input class="nowtimes" style="width: 96%;" onfocus="WdatePicker({dateFmt:\'yyyy-MM-dd\'});" value="" required/></span>';
            }

            else if (i == 5) {
                htm += '<td align="center" style="border-color: #e1e1e1;width: 10%;" ><input type="text" class="times" /></td>';
            }
            //else if (i == 6) {
            //    htm += '<td align="center" style="border-color: #e1e1e1;width: 10%;"  ><span class="timerq"><input class="" style="width: 96%;" onfocus="WdatePicker({dateFmt:\'yyyy-MM-dd\'});" value="" required/></span>';
            //}
            else if (i == 6) {
                htm += '<td align="center" align="center" style="border-color: #e1e1e1;width: 10%;" ><select class="opt7" style="border-color: #e1e1e1;width: 100%;" ><option text="0" value="0" selected>不限</option><option text="1" value="1">10</option><option text="1" value="1">20</option></select></td>';
            }
            else {
                htm += '<td align="center" style="border-color: #e1e1e1;width: 10%;"><input style="width: 96%;" /></td>';
            }
        }
        htm += _crtDelBtn();
        htm += '</tr>';
        $("#indexTab tbody").append(htm);
        _bind1();
        _bindDelRowEvent(rowNo);
        
    }

    function _bindDelRowEvent(rowNo) {
        $('#indexTab tbody tr').find('.opt-del').on('click', function () {
            $('#addRow').show();
            var rows = $("#indexTab tbody tr").length;
            if (rows == 1) {
                $('#option').hide();
            }
            $(this).parents('tr').remove();
        });
    }

    //表格的删除行功能
    function _crtDelBtn() {
        if (typeof (delopt) == 'undefined') {
            delopt = '<td>';
            delopt += $('#delTd').html();
            delopt += '</td>';
        }
        return delopt;
    }

    //function _bindTimeEvent() {
    //    //时间控件
    //    $('.times').timepicker({
    //        defaultTime: '',
    //        showInputs: true,
    //        minuteStep: 1,
    //        showMeridian: false,
    //        maxHours: 24,
    //    });
    //}

    //function _NowTime() {
    //    $(function () {
    //        var myDate = new Date;
    //        var year = myDate.getFullYear(); //获取当前年
    //        var mon = myDate.getMonth() + 1; //获取当前月
    //        var date = myDate.getDate(); //获取当前日
    //        var timeing = year + "-" + mon + "-" + date
    //        $(".nowtimes").attr("value", timeing);
    //    });

    //}

    //提交表单
    function _save($target, btnText) {
        _buildSubData();
        bootbox.dialog({
            title: "",
            message: '<div class="row">  ' +
                '<div class="col-xs-12"> ' +
                '请确认是否提交表单记录？' +
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
                            url: "/IdCard/Save",
                            data: ajaxData,
                            type: "POST",
                            success: function (result) {
                                if (result.code == 1) {
                                    FOXKEEPER_UTILS.alert('success', '操作成功');
                                    setTimeout(function () {
                                        location.replace('/IdCard/Index?d=' + location.search.replace(/[^\d]/g, ""));
                                    }, 1500);
                                    //} else if (result.code == -1) {
                                    //    FOXKEEPER_UTILS.alert('warning', '同一天不能添加相同的地址');
                                    //    $target.html(btnText).attr("disabled", false);
                                } else {
                                    FOXKEEPER_UTILS.alert('warning', '操作失败');
                                    $target.html(btnText).attr("disabled", false);
                                }
                            },
                            beforeSend: function () {
                                $target.html('<i class=\"fa fa-spinner\"></i>&nbsp;正在保存').attr("disabled", "disabled");
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

    function _buildSubData() {
        var tag = false;
        //获取table的每一行
        var $rows = $('#indexTab tbody').find("tr");
        var items = [];
        $rows.each(function (i, v) {
            var $that = $(this);
            var t1 = $that.find("td:eq(0) input").val();//获取卡号
            var t2 = $that.find("td:eq(1) select option:selected").text();//获取卡类型
            var t3 = $that.find("td:eq(2) input").val();//获取售卡人
            var t4 = location.search.replace(/[^\d]/g, "");//获取会员号
            var t5 = $that.find("td:eq(3) select option:selected").text();//获取卡折扣
            var t6 = $that.find("td:eq(4) input").val();//获取售卡时间
            var t7 = $that.find("td:eq(5) input").val();//获取卡内余额
            //var t8 = $that.find("td:eq(6) input").val();//获取期限
            var t8 = $that.find("td:eq(6) select option:selected").text();//获取次数
            //var t10 = $that.find("td:eq(8) select").find("option:selected").text();//获取公司
            //var tt10 = $that.find("td:eq(8) select").find("option:selected").val("value")
            var item = {};//一个什么也没有值的对象
            item.cCardId = t1;
            item.cardtype = t2;
            item.clubId = t4;
            item.collectiontype = t3; 
            item.cardseller = t5; 
            item.cUdeadline = t6;
            item.cda = t7;
            //item.cExpiretime = t8;
            item.cFrequency = t8;
            //item.transportcompanyName = t10;
            items.push(item);
        });
        //console.log(JSON.stringify(items));
        ajaxData.Ccar = items;
    }







});
