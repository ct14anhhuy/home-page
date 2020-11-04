$(function () {
    $("#btn-cus-register").click(function () {
        var customer = {};
        customer.companyName = $("#registerModal #companyName").val();
        customer.companyAddress = $("#registerModal #companyAddress").val();
        customer.telephone = $("#registerModal #telephone").val();
        customer.email = $("#registerModal #email").val();
        customer.password = $("#registerModal #password").val();

        $.ajax({
            type: "POST",
            url: '/Customer/Register/',
            data: '{customer: ' + JSON.stringify(customer) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert("Register successful");
                $("#registerModal").modal("show");
            },
            error: function () {
                alert("Error while register, try again later");
            }
        });
        return false;
    });

    $("#btn-cus-login").click(function () {
        var email = $("#loginModal #email").val();
        var password = $("#loginModal #password").val();

        $.ajax({
            type: "POST",
            url: '/Customer/Login/',
            data: '{email: "' + email + '", password: "' + password + '"}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.loginSuccess) {
                    location.reload();
                } else {
                    alert("Login failed, check your input");
                }
            },
            error: function () {
                alert("Error while login, try again later");
            }
        });
        return false;
    });
});