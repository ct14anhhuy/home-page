function showDocs(url) {
    $.ajax({
        type: "GET",
        url: '/Customer/CheckLoggedIn/',
        data: '',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.isLoggedIn || data.isCompanyAddress) {
                $("#iContent").attr("src", url);
                $("#exampleModal").modal("show");
            } else {
                $("#notifyModal").modal("show");
            }
        },
        error: function () {
            alert("Error, try again later");
        }
    });
}