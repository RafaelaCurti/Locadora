var addAlertToPage = function (message, type) {
    if (!toastr)
        return;

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-bottom-right",
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    var $toast = toastr[type](message, null);
    return false;
}
$(function () {
    $('form .submit').click(function (e) {
        $(this).parents('form').submit();
        e.preventDefault();
    });

    $.fn.uniformValidate = function () {
        $(this).find('input.invalid').removeClass('.invalid');

        $(this).find('input:visible, textarea:visible, select:visible').each(function () {
            $(this).focus();
            $(this).blur();
        });

        if ($(this).find('input.invalid:visible').length) {
            return false;
        }

        return true;
    }

    var tabContainers = $('div.tabs > div');
    tabContainers.hide().filter(':first').show();

    $(".ajax-request").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'GET',
            url: $(this).attr('href'),
            cache: false,
            success: function (data) {
                $("#dialog").empty().html(data);
            }
        });
    });

    //$('input:text').livequery(function () { $(this).setMask(); });

    var requiredLabel = $('.required').parent().find('label');
    requiredLabel.each(function () { $(this).text($(this).text() + " *") });

    $('[placeholder]').focus(function () {
        var input = $(this);
        if (input.val() == input.attr('placeholder')) {
            input.val('');
            input.removeClass('placeholder');
        }
    }).blur(function () {
        var input = $(this);
        if (input.val() == '' || input.val() == input.attr('placeholder')) {
            input.addClass('placeholder');
            input.val(input.attr('placeholder'));
        }
    }).blur().parents('form').submit(function () {
        $(this).find('[placeholder]').each(function () {
            var input = $(this);
            if (input.val() == input.attr('placeholder')) {
                input.val('');
            }
        })
    });

    jQuery.ajaxSettings.traditional = true;

    $(".ajax-modal").livequery(function () {
        $(this).click(function (e) {
            e.preventDefault();
            var address = $(this).attr("href");
            if (address != null && address != "") {
                $.get(address, function (data) {
                    if (data != false) {
                        if (data.match("^redirecionar")) {
                            var url = data.split('=')[1];
                            window.location.href = url;
                        }
                        $("#modal").empty().html(data);
                        $("#myModal").modal("show");
                    }
                });
            }
        });
    });
});