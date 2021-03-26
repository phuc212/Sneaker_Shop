var Category = Category || {};

Category.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Sau khi xóa tất cả sản phẩm thuộc danh mục này sẻ di chuyển đến danh mục No Category",
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
                    url: `/Category/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.result > 0) {
                            window.location.href = "/Category/Index/";
                        }
                    }
                });
            }
        }
    });
}

Category.RemoveProductFromCategory = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Điều này sẻ chuyển sản phẩm sang danh mục No Category",
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
                    url: `/Category/RemoveProductFromCategory/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.result > 0) {
                            window.location.href = "/Category/Index/";
                        }
                    }
                });
            }
        }
    });
}

$(document).ready(function () {
    $("#CategoryIndex").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 3,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});

$(document).ready(function () {
    $("#WatchProductById").dataTable(
        {
            "columnDefs": [
                {
                    "targets": 5,
                    "orderable": false,
                    "searchable": false
                },
                {
                    "targets": 3,
                    "orderable": false,
                    "searchable": false
                }
            ]
        }
    );
});