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
                    alert("Register successful, please wait while we approval your request");
                    $("#registerModal").modal("hide");
                } else {
                    if (data.isExists) {
                        alert("Register failed, this email is already exists");
                    } else {
                        alert("Register failed, check your input");
                    }
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
                    alert("Login failed, check your input or contact us to check your account");
                }
            },
            error: function () {
                alert("Error while login, try again later");
            }
        });
        return false;
    });

    $("#btn-cus-change-password").click(function () {
        var password = $("#changePasswordModal #password").val();
        var newPassword = $("#changePasswordModal #newPassword").val();
        var confirmNewPassword = $("#changePasswordModal #confirmNewPassword").val();

        if (!password || !newPassword || !confirmNewPassword) {
            alert('Check your input and try again');
            return false;
        }
        else {
            if (password == newPassword) {
                alert("Password and new password can not be same");
            } else if (newPassword != confirmNewPassword) {
                alert('New password and confirm do not match');
            }
            return false;
        }

        $.ajax({
            type: "POST",
            url: '/Customer/ChangePassword/',
            data: '{password: "' + password + '", newPassword: "' + newPassword + '"}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.isChangedSuccess) {
                    alert("password changed successfully");
                    location.reload();
                } else {
                    alert("password change failed, check your input or contact us to check your account");
                }
            },
            error: function () {
                alert("password change failed, try again later");
            }
        });
        return false;
    });
});