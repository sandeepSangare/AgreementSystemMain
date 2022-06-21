$(document).ready(function () {
    $("#tbAgreement").DataTable({
        "ajax": {
            "url": "/Home/GetAgreement",
            "type": "POST",
            "datatype": "json",
            "dataSrc": "",
        },
        "columns": [
            { 'data': 'id' },
            { 'data': 'product_Description' },
            { 'data': 'group_Description' },
            { 'data': 'effective_Date' },
            { 'data': 'expiration_Date' },
            { 'data': 'product_Price' },
            { 'data': 'new_Price' },
            { 'data': 'active' },
            { 'data': null, title: 'Edit', wrap: true, "render": function (item) { return '<div class="btn-group"> <button type="button"  class="btn btn-warning" onclick="Edit(' + item.id + ')">Edit</button></div>' } },
            { 'data': null, title: 'Delete', wrap: true, "render": function (item) { return '<div class="btn-group"> <button type="button"  class="btn btn-warning" onclick="DeleteData(' + item.id + ')">Delete</button></div>' } }
        ]

    });
});

function Edit(id) {
    var placeHolder = $("#PlaceHolder");
    var url = "/Home/Create/" + id;
    $.get(url).done(function (data) {
        placeHolder.html(data);
        $("#btnAdd").html('Update')
        placeHolder.find('.modal').modal('show');
    })
}

function DeleteData(ID) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(ID);
    }
    else {
        return false;
    }
}


function Delete(ID) {
    var url = '@Url.Content("~/")' + "Home/DeleteAgreement";
    $.post(url, { ID: ID }, function (data) {
        if (data == "Deleted") {
            window.location.reload();
        }
        else {
            alert("Something Went Wrong!");
        }
    });
}