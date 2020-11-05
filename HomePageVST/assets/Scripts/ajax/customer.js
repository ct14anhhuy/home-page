$(function () {
    $("#btn-cus-register").click(function () {
        var customer = {};
        customer.companyName = $("#registerModal #companyName").val();
        customer.companyAddress = $("#registerModal #companyAddress").val();
        customer.telephone = $("#registerModal #telephone").val();
        customer.email = $("#registerModal #email").val();
        customer.password = $("#registerModal #password").val();

        if (!customer.companyAddress || !customer.companyAddress || !customer.telephone || !customer.email || !customer.password) {
            alert('Check your input and try again');
            return false;
        }

        $.ajax({
            type: "POST",
            url: '/Customer/Register/',
            data: '{customer: ' + JSON.stringify(customer) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.createdSuccess) {
                    alert("Register successful");
                    $("#registerModal").modal("hide");
                } else {
                    alert("Register failed, check your input");
                }
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

        if (!email || !password) {
            alert('Check your input and try again');
            return false;
        }

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