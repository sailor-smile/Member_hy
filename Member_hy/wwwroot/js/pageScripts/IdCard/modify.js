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
            url: "/IdCard/GetCbercar?dataId=" + id,
            data: null,
            type: "GET",
            success: function (result) {
                if (result.code == 1) {
                    var o = result.data;
                    $('#klx').find("option:selected").text(o.cardtype);
                    $('#soukaren').val(o.collectiontype);
                    $('#kzk').find("option:selected").text(o.cardseller);
                    $('#stime').val(o.cUdeadline);
                    $('#kye').val(o.cda);
                    //$('#qxx').val(o.cExpiretime);
                    $('#cis').find("option:selected").text(o.cFrequency);

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
        ajaxData.cCardId = $('#xid').val();
        ajaxData.cardtype = $('#klx').find("option:selected").text();
        ajaxData.collectiontype = $('#soukaren').val(); 
        ajaxData.cardseller = $('#kzk').find("option:selected").text();
        ajaxData.cUdeadline = $('#stime').val();
        ajaxData.cda = $('#kye').val();
        //ajaxData.cExpiretime = $('#qxx').val();
        ajaxData.cFrequency = $('#cis').find("option:selected").text();
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
            url: "/IdCard/Update",
            data: ajaxData,
            type: "POST",
            success: function (result) {
                if (result.code == 1) {
                    FOXKEEPER_UTILS.alert('success', '操作成功');
                    setTimeout(function () {
                        location.replace('javascript: history.go(-1)');
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


