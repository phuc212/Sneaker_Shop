var Order = Order || {};
Order.delete = function (id) {
    bootbox.confirm({
        title: "Warning",
        message: "Bạn Muốn Xóa Nó?",
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
                    url: `/Order/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data.result > 0) {
                            window.location.href = "/Order/Index/";
                        }
                    }
                });
            }
        }
    });
}
Order.ConfirmPay = function (id) {
    $.ajax({
        url: `/Order/ConfirmPay/${id}`,
        method: "GET",
        contentType: 'json',
        success: function (data) {
            console.log(data);
            bootbox.confirm({
                title: "Xác Nhận Thanh Toán",
                dataType: 'json',
                message: `<p><span style="color:green"> Tên Khách Hàng:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;${data.result[0]}</p>
                          <p><span style="color:green"> Ngày Tạo Hóa Đơn:</span> ${data.result[1]}</p>
                          <p><span style="color:green">Ngày Giao Hàng:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;${data.result[2]}</p>
                          <p><span style="color:green">Tổng Tiền:</span>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             ${data.result[3]}
                          </p>
                        `,
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
                            url: `/Order/Pay/${id}`,
                            method: "GET",
                            contentType: 'json',
                            success: function (data) {
                                if (data.result > 0) {
                                    window.location.href = "/Order/Index/";
                                }
                            }
                        });
                    }
                }
            });
        }
    })
}
$(document).ready(function () {
    $("#OrderIndex").dataTable(
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






















