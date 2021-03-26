var Product = Product || {};

Product.delete = function (id) {
    bootbox.confirm({
        title: "Warning",
        message: "are you sure?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.result > 0) {
                            window.location.href = "/Product/Index/";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#ProductIndex").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 7,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 4,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});

