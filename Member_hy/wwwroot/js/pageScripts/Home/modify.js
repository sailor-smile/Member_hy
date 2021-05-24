jQuery(function () {
    'use strict';
    var ajaxData = {};
    //绑定事件

    _bind();
    //初始化

    //加载内容
    _initData($('#xid').val());
  




    //根据id加载一行数据
    function _initData(id) {
        jQuery.ajax({
            dataType: "json",
            url: "/Home/GetCber?dataId=" + id,
            data: null,
            type: "GET",
            success: function (result) {
                if (result.code == 1) {
                    var o = result.data;
                    $('#cname').val(o.clubname);
                    $('#xbie').val(o.cSex);
                    $('#huiylx').find("option:selected").text(o.cType);
                    $('#hydh').val(o.cMobile);
                    $('#hyrs').val(o.cBirthday);
                    $('#hybz').val(o.cRemarks);
                } else {
                    FOXKEEPER_UTILS.alert('danger', '程序出错.');
                }
            },
            error: function () {
                FOXKEEPER_UTILS.alert('danger', '程序出错.');
            }
        });
    }

    function _setAjaxData() {
        ajaxData.clubId = $('#xid').val();
        ajaxData.clubname = $('#cname').val();
        ajaxData.cSex = $('#xbie').val();
        ajaxData.cType = $('#huiylx').find("option:selected").text();
        ajaxData.cMobile = $('#hydh').val();
        ajaxData.cBirthday = $('#hyrs').val();
        ajaxData.cRemarks = $('#hybz').val();
    }

    function _bind() {
        /**  保存 */
        $('#btnSave').click(function () {
            _save($(this), $(this).text());
        });
    }


    //修改提交
    function _save($target, btnText) {
        _setAjaxData();
        jQuery.ajax({
            dataType: "json",
            url: "/Home/Update",
            data: ajaxData,
            type: "POST",
            success: function (result) {
                if (result.code == 1) {
                    FOXKEEPER_UTILS.alert('success', '操作成功');
                    setTimeout(function () {
                        location.replace('/Home/Index');
                    }, 1000);
                } else if (result.code == -1) {
                    FOXKEEPER_UTILS.alert('warning', '状态为-1');
                    $target.html(btnText).attr("disabled", false);
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
    }




});


