// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.tag').hide();
$('.item').hide();

$('.tagCheckbox').click(function () {
    if ($(this).is(':checked') == true) {
        $('.tag').show();
    } else {
        $('.tag').hide();
    }
})


$('.itemCheckbox').click(function () {
    if ($(this).is(':checked') == true) {
        $('.item').show();
    } else {
        $('.item').hide();
    }
})

