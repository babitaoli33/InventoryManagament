$(document).ajaxSend(function (event, jqXHR, settings) {

    const token = localStorage.getItem("accessToken");

    if (!token) {
        return;
    }

    if (!settings.url.startsWith("/api/")) {
        return;
    }

    if (settings.url.startsWith("/api/auth/")) {
        return;
    }

    jqXHR.setRequestHeader(
        "Authorization",
        "Bearer " + token
    );

});