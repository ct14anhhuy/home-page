$(function () {
    $("#btn-cus-sign-up").click(function () {
        var customer = {};
        customer.companyName = $("#registerModal #companyName").val();
        customer.companyAddress = $("#registerModal #companyAddress").val();
        customer.telephone = $("#registerModal #telephone").val();
        customer.email = $("#registerModal #email").val();
        customer.password = $("#registerModal #password").val();

        $.ajax({
            type: "POST",
            url: '/Customer/CreateCustomer/',
            data: '{customer: ' + JSON.stringify(customer) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert("Data has been added successfully.");
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        return false;
    });
});