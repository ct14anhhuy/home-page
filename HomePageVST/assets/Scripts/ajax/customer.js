$(function () {
    $("#form-cus-register").submit(function () {
        event.preventDefault();
        var url = $(this).attr("action");
        var method = $(this).attr("method");
        var data = new FormData(this);
        $("#btn-cus-register").prop("disabled", true);
        $.ajax({
            type: method,
            url: url,
            data: data,
            processData: false,
            contentType: false,
            cache: false,
            success: function (response) {
                if (response.isCreateSuccess) {
                    notifyMetro("Register successful, please wait while we approval your request", "success");
                    $("#registerModal").modal("hide");
                } else if (response.isExists) {
                    notifyMetro("Register failed, this email is already exists", "white");
                } else if (response.modelErrors) {
                    var modelErrors = JSON.parse(response.modelErrors);
                    $.each(modelErrors, function (fIdx) {
                        if (modelErrors[fIdx].Value) {
                            $.each(modelErrors[fIdx].Errors, function (sIdx) {
                                notifyMetro(modelErrors[fIdx].Errors[sIdx].ErrorMessage, "white");
                            });
                        }
                    });
                } else {
                    notifyMetro("Register failed, check your input", "white");
                }
            },
            error: function () {
                notifyMetro("Error while register, try again later", "error");
            }
        });
        $("#btn-cus-register").prop("disabled", false);
    });

    $("#form-cus-login").submit(function () {
        event.preventDefault();
        var url = $(this).attr("action");
        var method = $(this).attr("method");
        var data = new FormData(this);
        $("#sub-cus-login").prop("disabled", true);
        $.ajax({
            type: method,
            url: url,
            data: data,
            processData: false,
            contentType: false,
            cache: false,
            success: function (response) {
                if (response.isLoginSuccess) {
                    location.reload();
                } else if (response.modelErrors) {
                    var modelErrors = JSON.parse(response.modelErrors);
                    $.each(modelErrors, function (fIdx) {
                        if (modelErrors[fIdx].Value) {
                            $.each(modelErrors[fIdx].Errors, function (sIdx) {
                                notifyMetro(modelErrors[fIdx].Errors[sIdx].ErrorMessage, "white");
                            });
                        }
                    });
                } else {
                    notifyMetro("Login failed, email or password incorrect", "white");
                }
            },
            error: function () {
                notifyMetro("Login failed, try again later", "error");
            }
        });
        $("#sub-cus-login").prop("disabled", false);
    });

    $("#form-cus-change-password").submit(function () {
        event.preventDefault();
        var url = $(this).attr("action");
        var method = $(this).attr("method");
        var data = new FormData(this);
        $("#sub-cus-change-password").prop("disabled", true);
        $.ajax({
            type: method,
            url: url,
            data: data,
            processData: false,
            contentType: false,
            cache: false,
            success: function (response) {
                if (response.isChangeSuccess) {
                    location.reload();
                } else if (response.modelErrors) {
                    var modelErrors = JSON.parse(response.modelErrors);
                    $.each(modelErrors, function (fIdx) {
                        if (modelErrors[fIdx].Value) {
                            $.each(modelErrors[fIdx].Errors, function (sIdx) {
                                notifyMetro(modelErrors[fIdx].Errors[sIdx].ErrorMessage, "white");
                            });
                        }
                    });
                } else {
                    notifyMetro("password change failed, check your input and try again", "white");
                }
            },
            error: function () {
                notifyMetro("password change failed, try again later", "error");
            }
        });
        $("#sub-cus-change-password").prop("disabled", false);
    });
});