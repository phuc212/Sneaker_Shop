
function GetvalueForInputs() {
    var ProductId = $("#Product").val();
    var Discount = $("#Discount").val();
    var Quantity = $("#Quantity").val();
    $.ajax({
        url: `/OrderDetail/GetPrice/${ProductId}/${Discount}/${Quantity}`,
        method: "GET",
        contentType: "json",
        success: function (data) {
            $("#Price").val(data);
        }
    });
};

$(function () {
    $("#Discount").change(GetvalueForInputs);
});

$(function () {
    $("#Quantity").change(GetvalueForInputs);
});

$(function () {
    $("#Product").change(function () {
        var id = $("#Product").val();
        $.ajax({
            url: `/OrderDetail/DefaultByProductId/${id}`,
            method: "GET",
            contentType: "json",
            success: function (data) {
                $("#Quantity").val(1);
                $("#Discount").val(0);
                $("#Price").val(data);
            }
        })
    });
});

$(function () {
    $("#Category").change(function () {
        var id = $("#Category").val();
        $.ajax({
            url: `/OrderDetail/GetProductsByCategoryId/${id}`,
            method: "GET",
            contentType: "json",
            success: function (data) {
                var items = '';
                $("#Product").empty();
                $.each(data, function (i, row) {
                    items += "<option value='" + row.value + "'>" + row.text + "</option>";
                });
                $("#Product").html(items);

                var Productid = $("#Product").val();
                $.ajax({
                    url: `/OrderDetail/DefaultByProductId/${Productid}`,
                    method: "GET",
                    contentType: "json",
                    success: function (data) {
                        $("#Quantity").val(1);
                        $("#Discount").val(0);
                        $("#Price").val(data);
                    }
                });
            }
        })
    });
});
