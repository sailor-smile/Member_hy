jQuery(function () {
    'use strict';

    var ajaxData = {}, ysgs = true;;

    //绑定
    _bind();

    _init();

    function _init() {

    }

    function _bind() {
        /**  保存 */
        $('#btnSave').click(function () {
            _save();
            //_buildSubData();
        });
    }

    //提交表单
    function _save() {
        _buildSubData();
        jQuery.ajax({
            dataType: "json",
            url: "/Home/Save",
            data: ajaxData,
            type: "POST",
            success: function (result) {
                if (result.code == 1) {
                    setTimeout(function () {
                        location.replace('/Home/Index');
                    }, 0);
                    //} else if (result.code == -1) {
                    //    FOXKEEPER_UTILS.alert('warning', '同一天不能添加相同的地址');
                    //    $target.html(btnText).attr("disabled", false);
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

    function _buildSubData() {
        ajaxData.cType = $("#w3_country").find("option:selected").text();
        ajaxData.clubname = $("#rnames").val();
        ajaxData.cSex = $("input[type='radio']:checked").val();
        ajaxData.cMobile = $("#phonex").val();
        ajaxData.cBirthday = $("#datepicker").val();
        ajaxData.cRemarks = $("#beiz").val();
    }



});