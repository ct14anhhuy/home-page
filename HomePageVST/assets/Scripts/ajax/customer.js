$(function () {
    $("#btn-cus-register").click(function () {
        var customer = {};
        customer.companyName = $("#registerModal #companyName").val();
        customer.companyAddress = $("#registerModal #companyAddress").val();
        customer.telephone = $("#registerModal #telephone").val();
        customer.email = $("#registerModal #email").val();
        customer.password = $("#registerModal #password").val();

        if (!customer.companyAddress || !customer.companyAddress || !customer.telephone || !customer.email || !customer.password) {
            notifyMetro("Check your input and try again", "white");
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
                    notifyMetro("Register successful, please wait while we approval your request", "success");
                    $("#registerModal").modal("hide");
                } else {
                    if (data.isExists) {
                        notifyMetro("Register failed, this email is already exists", "white");
                    } else {
                        notifyMetro("Register failed, check your input", "white");
                    }
                }
            },
            error: function () {
                notifyMetro("Error while register, try again later", "error");
            }
        });
        return false;
    });

    $("#btn-cus-login").click(function () {
        var email = $("#loginModal #email").val();
        var password = $("#loginModal #password").val();

        if (!email || !password) {
            notifyMetro("Check your input and try again", "white");
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
                    notifyMetro("Login failed, check your input or contact us to check your account", "white");
                }
            },
            error: function () {
                notifyMetro("Error while login, try again later", "error");
            }
        });
        return false;
    });

    $("#btn-cus-change-password").click(function () {
        var password = $("#changePasswordModal #password").val();
        var newPassword = $("#changePasswordModal #newPassword").val();
        var confirmNewPassword = $("#changePasswordModal #confirmNewPassword").val();

        if (!password || !newPassword || !confirmNewPassword) {
            notifyMetro("Check your input and try again", "white");
            return false;
        } else {
            if (password == newPassword) {
                notifyMetro("Password and new password can not be same", "white");
            } else if (newPassword != confirmNewPassword) {
                notifyMetro("New password and confirm do not match", "white");
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
                    notifyMetro("password changed successfully", "success");
                    location.reload();
                } else {
                    notifyMetro("password change failed, check your input or contact us to check your account", "white");
                }
            },
            error: function () {
                notifyMetro("password change failed, try again later", "error");
            }
        });
        return false;
    });
});