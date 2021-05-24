jQuery(function () {
    'use strict';
    var ajaxData = {};
    //绑定
    _bind();
    _init();
    function _init() {
    }

    function _bind() {
        $('.lgn').on('focus', function () {
            $('#errorInfo').text('');
        });
        /** 首页PC端登录**/
        $('#btnLogin').on('click', function () {
            _login($(this));
        });

        //document.keyup = function (e) {
        //    var ev = document.all ? window.event : e;
        //    if (ev.keyCode == 13) {
        //        _login($('#btnLogin'));
        //    }
        //}
    }
    //getCookie("CSRF-TOKEN")
    function _login($target) {
        _setAjaxData();
        //var token = $("input[name='__RequestVerificationToken']").val();
        if (_verifyAjaxData()) {
            jQuery.ajax({
                dataType: "json",
                url: "/Login/Loginog",
                //headers:
                //{
                //    "RequestVerificationToken": token
                //},
                data: ajaxData,
                type: "POST",
                success: function (result) {
                    if (result.code == 1) {
                        setTimeout(function () {
                            location.replace(result.data);
                        }, 1000);
                    } else {
                        $('#errorInfo').text(result.msg);
                    }
                    //alert(result.msg);
                    $target.attr("disabled", false);
                },
                beforeSend: function () {
                    $target.attr("disabled", "disabled");
                },
                error: function () {
                    //alert(result.msg);
                    $('#errorInfo').text(result.msg);
                    $target.attr("disabled", false);
                }
            });
        } else {
            return false;
        }
        return false;
    }
    function _setAjaxData() {
        var act = $('#act').val().replace(' ', '');
        var pwd = $('#pwd').val().replace(' ', '');
        if (act) {
            act = window.btoa(act);
        } else {
            $('#errorInfo').text('账户名不能为空');
            return true;
        }
        ajaxData.userName = act;
        if (pwd) {
            pwd = window.btoa(pwd);
        } else {
            $('#errorInfo').text('密码不能为空');
            return true;
        }
        ajaxData.newpwd = pwd;
    }
    /** 请求参数验证 */
    function _verifyAjaxData() {
        return true;
    }
});
