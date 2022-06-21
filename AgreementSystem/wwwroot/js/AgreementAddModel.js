

$(function () {
    var placeHolder = $("#PlaceHolder");
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        $.get(url + '/0').done(function (data) {
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
                alert('Success...!');
                console.log(result);
                placeHolder.find('.modal').modal('hide');
                window.location.reload();
            },
            error: function (result) {
                alert('Filds Required..!');
                console.log(result);
            }
        })

    });

});



function FillProduct() {
    var Id = $('#Product_Group_Id').val();
    $.ajax({
        url: '/Home/Products/' + Id,
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
