jQuery(document).ready(function () {
    $('.phone').mask('0(999)-999-99-99');
    $('.mobilephone').mask('0(599)-999-99-99');
    $(".datepicker").mask('99.99.9999');

    $(".mobilephone,.phone").keyup(function (e) {
        var value = $(this).val();
        if (value[0] !== "0") {
            $(this).val("0" + value.substr(1, value.length));
        }
    });
    //    $(".numeric").numeric({ negative: false, decimal: "," });
});

function showLoading() {
    $('#pre-loader').fadeIn('slow');
}

function hideLoading() {
    $('#pre-loader').fadeOut('slow');
}

