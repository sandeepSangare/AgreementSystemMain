// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var placeHolder = $("#PlaceHolder");
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url+'/0').done(function (data) {
            placeHolder.html(data);
            placeHolder.find('.modal').modal('show');
        })

    });

    placeHolder.on('click', '[data-save="modal"]', function (event) {

        var form = $(this).parents('.modal').find('form');
        var actionurl = form.attr('action');
        var sendData = form.serialize();

        $.ajax({
            type: 'POST',
            url: actionurl,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8', 
            data: sendData,
            success: function (result) {
                alert('Successfully received Data ');
                console.log(result);
                placeHolder.find('.modal').modal('hide');
                window.location.reload();
            },
            error: function (result) {
                alert('Failed to receive the Data');
                console.log(result);
            }
        })

    });

});



function FillProduct() {
    var Id = $('#Product_Group_Id').val();
    $.ajax({
        url: '/Home/Products/'+Id,
        type: "GET",
        dataType: "JSON",
        success: function (Products) {
            console.log(Products);
            $("#Product_Id").html("");
            $.each(Products, function (i, Product) {
                $("#Product_Id").append(
                    $('<option></option>').val(Product.id).html(Product.product_Description));
            });
        }
    });
}
